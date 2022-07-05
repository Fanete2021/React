import React from 'react';
import cl from './Form.module.css';

const FormChoiceActors = function ({ actors, changeActors, visible, setVisible, query }) {
    const rootClasses = [cl.form]

    if (visible) {
        rootClasses.push(cl.active);
    }

    return (
        <div className={rootClasses.join(' ')}>
            {actors.map(actor =>
                <div key={actor.id} className={cl.item} onClick={() => changeActors(actor, setVisible, query)}>
                    {actor.name} {actor.surname}
                </div>
            )}
        </div >
    );
};
export default FormChoiceActors;