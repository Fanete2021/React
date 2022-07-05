import React, { useContext, useState } from 'react';
import { Context } from '../../../context';
import Button from '../Button/Button';
import Input from '../Input/Input';
import ChoiceGenres from '../Form//FormChoiceGenres';
import ActorSelector from '../Select/ActorSelector';

const MovieForm = function ({ create }) {
    const [movie, setMovie] = useState({ title: '', description: '', premiereYear: '' });
    const [movieGenres, setMovieGenres] = useState([]);
    const [movieActors, setMovieActors] = useState([]);
    const { genres } = useContext(Context)

    async function addNewMovie(e){
        e.preventDefault();
        if (isNaN(movie.premiereYear)) {
            alert("Characters are not allowed in the 3rd field")
        }
        else if (movie.description.length === 0 || movie.title.length === 0 || movie.premiereYear.length === 0) {
            alert("Don't leave the fields empty")
        }
        else if (movieGenres.length === 0 || movieActors.length === 0) {
            alert("Don't leave the selection forms with genres and actors empty")
        }
        else {
            movie.premiereYear = +movie.premiereYear
            if (movie.premiereYear < 1895 || movie.premiereYear > 2030)
                alert("Enter the year in the range from 1895 to 2030")
            else {
                create(movie, movieGenres, movieActors)
                setMovie({ title: '', description: '', premiereYear: '' });
            }
        }
    }

    const changeGenres = (e, genre) => {
        if (e.target.checked) {
            setMovieGenres([...movieGenres, genre])
        }
        else {
            setMovieGenres(movieGenres.filter(g => g.id !== genre.id))
        }
    }

    const addActor = (actor) => {
        setMovieActors([ ...movieActors, actor ])
    }

    const deleteActor = (actor) => {
        setMovieActors(movieActors.filter(a => a.id !== actor.id))
    }

    return (
        <div>
            <Input
                value={movie.title}
                onChange={e => setMovie({ ...movie, title: e.target.value })}
                type="text"
                placeholder="Title"
            />
            <Input
                value={movie.description}
                onChange={e => setMovie({ ...movie, description: e.target.value})}
                type="text"
                placeholder="Description"
            />
            <Input
                value={movie.premiereDate}
                onChange={e => setMovie({ ...movie, premiereYear: e.target.value })}
                type="number"
                placeholder="Premiere Year"
            />

            <ChoiceGenres genres={genres} changeArray={changeGenres} />

            <div>
                <ActorSelector addActor={addActor} deleteActor={deleteActor} selectedActors={movieActors} />
            </div>

            <br/>
            <Button onClick={addNewMovie}>Add a new movie</Button>
        </div>
    );
};

export default MovieForm;