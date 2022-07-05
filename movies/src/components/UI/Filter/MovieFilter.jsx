import React, { useContext } from 'react';
import { Context } from '../../../context';
import FormChoiceGenres from '../Form/FormChoiceGenres';
import Input from '../Input/Input';
import ActorSelector from '../Select/ActorSelector';
import cl from './MovieFilter.module.css';

const MovieFilter = function ({ filter, setFilter }) {
    const { genres } = useContext(Context)

    const changeGenres = (e, genre) => {
        if (e.target.checked) {
            setFilter({ ...filter, genres: [...filter.genres, genre] })
        }
        else {
            setFilter({ ...filter, genres: filter.genres.filter(g => g.id !== genre.id) })
        }
    }

    const addActor = async (actor, setVisible) => {
        setVisible(false)
        setFilter({ ...filter, actors: [...filter.actors, actor] })
    }

    const deleteActor = async (actor) => {
        setFilter({ ...filter, actors: filter.actors.filter(a => a.id !== actor.id) })
    }

    return (
        <div className={cl.search}>
            <h2 className={cl.heading}>
                Search parameters
            </h2>

            <Input className={cl.input}
                value={filter.title}
                onChange={e => setFilter({ ...filter, title: e.target.value })}
                placeholder="movie title"
            />

            <FormChoiceGenres genres={genres} changeArray={changeGenres} />
    
            <div>
                <ActorSelector addActor={addActor} deleteActor={deleteActor} selectedActors={filter.actors} />
            </div>
        </div>
    );
};

export default MovieFilter;