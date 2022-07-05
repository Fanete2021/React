import React, { useEffect, useMemo, useState } from 'react';
import ActorService from '../../../API/ActorService';
import useDebounce from '../../../hooks/useDebounce';
import FormChoiceActors from '../Form/FormChoiceActors';
import cl from './ActorSelector.module.css';

const ActorSelector = function ({ addActor, deleteActor, selectedActors }) {
    const [visible, setVisible] = useState(false)
    const [searchedActors, setSearchedActors] = useState([])
    const [substr, setSubstr] = useState('')
    const debouncedSubstr = useDebounce(substr, 400);

    const updateSearchedActors = async (value) => {
        const response = await ActorService.getActors(value, selectedActors.map(a => a.id))
        setSearchedActors(response.data)
    }

    const changeSubstr = async (e) => {
        const value = e.target.value
        setSubstr(value)
    }

    useEffect(() => {
        updateSearchedActors(substr)
    }, [debouncedSubstr])

    const filtredActors = useMemo(() => searchedActors.filter(a => selectedActors.findIndex(actor => a.id === actor.id) < 0, [selectedActors]))
    
    return (
        <div>
            <div className={cl.wrap}>
                <p><strong>Selected actors: </strong></p>

                {selectedActors.map((actor, index) => {
                    let fullName = actor.name + ' ' + actor.surname
                    if (index + 1 !== selectedActors.length)
                        fullName += ', '
                    return (
                        <span key={actor.id} className={cl.actor} onClick={() => deleteActor(actor)}>
                            {fullName}
                        </span>
                    )
                })}
            </div>

            <input
                className={cl.wrap}
                type="text"
                onFocus={() => setVisible(true)}
                onBlur={() => setVisible(true)}
                onChange={changeSubstr}
            />

            <FormChoiceActors actors={filtredActors} changeActors={addActor} visible={visible} setVisible={setVisible}/>
        </div>
    );
};

export default ActorSelector;