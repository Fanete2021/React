import React, { useEffect, useState } from 'react';
import MovieService from '../API/MovieService';
import Button from '../components/UI/Button/Button';
import Loader from '../components/UI/Loader/Loader';
import MovieFilter from '../components/UI/Filter/MovieFilter';
import MovieForm from '../components/UI/Movie/MovieForm';
import MovieList from '../components/UI/Movie/MovieList';
import { useFetching } from '../hooks/UseFetching';
import { getPageCount } from '../utils/pages';
import { contains } from '../utils/contains';
import useDebounce from '../hooks/useDebounce';
import PageNavigation from '../components/UI/PageNavigation/PageNavigation';
import Creator from '../components/UI/Creator/Creator';


function Movies() {
    const [movies, setMovies] = useState([])
    const [totalPagesMovies, setTotalPagesMovies] = useState(0)
    const [limitMovies, setLimitMovies] = useState(10)
    const [pageMovies, setPageMovies] = useState(1)

    const [filter, setFilter] = useState({ title: '', genres: [], actors: [] });
    const debouncedFilter = useDebounce(filter, 1000); //Processing the request after 1c
    const [visibleCreature, setVisibleCreature] = useState(false);

    const [fetchMovies, isMovieLoading, movieError] = useFetching(async (limit, page) => {
        //Recording [limit] movies and getting their actors, genres

        const response =  await MovieService.getMovies(filter.title,
                filter.actors.map(a => a.id),
                filter.genres.map(g => g.id),
                limit, page)

        const totalCountMovies = response.headers['x-total-count']
        setTotalPagesMovies(getPageCount(totalCountMovies, limitMovies))

        for (let i = 0; i < response.data.length; i++) {
            response.data[i] = {
                ...response.data[i],
                genres: await MovieService.getGenres(response.data[i].id),
                actors: await MovieService.getActors(response.data[i].id)
            }
        }

        setMovies(response.data)
    })

    const resetView = () => {
        window.scrollTo(0, 0);
    }

    useEffect(() => {
        fetchMovies(limitMovies, pageMovies)
    }, [])

    useEffect(() => {
        resetView()
        fetchMovies(limitMovies, pageMovies)
    }, [debouncedFilter])

    useEffect(() => {
        changePage(1)
    }, [filter])

    const createMovie = async (newMovie, genres, actors) => {
        await MovieService.addMovie(newMovie)
        newMovie = {
            ...newMovie, id: await MovieService.getLast(), genres: genres, actors: actors
        }
        genres.map(genre => MovieService.addGenre(newMovie.id, genre.id))
        actors.map(actor => MovieService.addActor(newMovie.id, actor.id))
        setVisibleCreature(false);

        if (movies.length < 10) {
            if (contains(newMovie.genres.map(g => g.id), filter.genres.map(g => g.id)) &&
                contains(newMovie.actors.map(a => a.id), filter.actors.map(a => a.id)) &&
                newMovie.title.toLowerCase().includes(filter.title.toLowerCase()))
                setMovies([...movies, newMovie])
        } else if (pageMovies == totalPagesMovies) {
            setTotalPagesMovies(totalPagesMovies + 1)
        }
    }

    const removeMovie = async (movie) => {
        await MovieService.deleteMovie(movie.id)
        let offset = 0

        if (pageMovies == totalPagesMovies && movies.length == 1) {
            offset = 1
            setPageMovies(pageMovies - 1)
        }

        fetchMovies(limitMovies, pageMovies - offset)
    }
        
    const changePage = (newValue) => {
        resetView()
        setMovies([])
        
        if (newValue > 0 && newValue <= totalPagesMovies) {
            setPageMovies(newValue)
            fetchMovies(limitMovies, newValue)
        }
    }

    return (
        <div className="infoBlock">
            <Button style={{ marginTop: 30 }} onClick={() => setVisibleCreature(true)}>
                Add a new movie
            </Button>

            {visibleCreature &&
                <Creator setVisible={setVisibleCreature}>
                    <MovieForm create={createMovie} />
                </Creator>
            }
            <hr style={{ margin: '15px 0' }} />

            <MovieFilter filter={filter} setFilter={setFilter} />

            {movieError &&
                <h1>${movieError}</h1>
            }

            {isMovieLoading &&
                <div className="loader"><Loader /></div>
            }

            <MovieList isMovieLoading={isMovieLoading} remove={removeMovie} movies={movies} title="Movies" />

            <PageNavigation totalPages={totalPagesMovies} isLoading={isMovieLoading} page={pageMovies} changePage={changePage} />
        </div>
    );
}


export default Movies;