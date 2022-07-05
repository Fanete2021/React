import React from 'react';
import MovieItem from './MovieItem';

const MovieList = function ({ movies, remove, isMovieLoading }) {

    if (!movies.length && !isMovieLoading) {
        return (
            <h1 style={{ textAlign: 'center' }}>
                The list is empty
            </h1>
        )
    }

    return (
        <div className="app">
            {!isMovieLoading &&
                <h1 style={{ textAlign: 'center' }}>
                    List of movies
                </h1>
            }
            {movies.map(movie => 
                <MovieItem remove={remove} movie={movie} key={movie.id} />
            )}
        </div>
    );
};

export default MovieList;