import React from 'react';
import cl from './Creator.module.css';

const Creator = ({ children, setVisible }) => {
    const rootClasses = [cl.creator, cl.active]

    return (
        <div className={rootClasses.join(' ')} onClick={() => setVisible(false)}>
            <div className={cl.creatorContent} onClick={(e) => e.stopPropagation()}>
                {children}
            </div>
        </div>
    );
};

export default Creator;