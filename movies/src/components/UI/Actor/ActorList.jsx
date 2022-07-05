import React from 'react';
import ActorItem from './ActorItem';

const ActorList = function ({ actors, remove }) {

    if (!actors.length) {
        return (
            <h1 style={{ textAlign: 'center' }}>
                The list is empty
            </h1>
        )
    }

    return (
        <div className="app">
            <h1 style={{ textAlign: 'center' }}>
                List of actors
            </h1>
            {actors.map(actor => 
                <ActorItem remove={remove} actor={actor} key={actor.id} />
            )}
        </div>
    );
};

export default ActorList;