import React from 'react';
import Button from '../Button/Button';
import cl from './Movie.module.css';

const MovieItem = function (props) {
    return (
        <div className={cl.movie}>
            <div>
                <strong className={cl.movie__header}>{props.movie.title}</strong> (premiere: {props.movie.premiereYear})
                <div className={cl.movie__description}>{props.movie.description}</div>
                <div>
                    <div>
                        <strong>Genres </strong>{props.movie.genres.map(genre => genre.title).join(', ')}
                    </div>
                    <div>
                        <strong>Cast </strong>{props.movie.actors.map(actor => actor.name + ' ' + actor.surname).join(', ')}
                    </div>
                </div>
            </div>
            <div>
                <Button onClick={() => props.remove(props.movie)}>
                    Delete
                </Button>
            </div>
        </div>
    );
};

export default MovieItem;