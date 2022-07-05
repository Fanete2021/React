import React from 'react';
import Button from '../Button/Button';
import cl from './Actor.module.css';

const ActorItem = function (props) {
    return (
        <div className={cl.actor}>
            <div className={cl.actor__content}>
                <strong>{props.actor.name} {props.actor.surname}</strong>
            </div>
            <div>
                <Button onClick={() => props.remove(props.actor)}>
                    Delete
                </Button>
            </div>
        </div>
    );
};

export default ActorItem;