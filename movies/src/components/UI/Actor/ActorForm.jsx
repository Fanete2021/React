import React, { useState } from 'react';
import Button from '../Button/Button';
import Input from '../Input/Input';

const ActorForm = function ({ create }) {
    const [actor, setActor] = useState({ name: '', surname: '' });

    async function addNewActor(e){
        e.preventDefault();
        create(actor)
        setActor({ name: '', surname: '' });
    }

    return (
        <form>
            <Input
                value={actor.name}
                onChange={e => setActor({ ...actor, name: e.target.value })}
                type="text"
                placeholder="Name"
            />
            <Input
                value={actor.surname}
                onChange={e => setActor({ ...actor, surname: e.target.value})}
                type="text"
                placeholder="Surname"
            />
            <Button onClick={addNewActor}>Add a new actor</Button>
        </form>
    );
};

export default ActorForm;