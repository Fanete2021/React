import React from 'react';
import cl from './Loader.module.css';

const Loader = function ({ children, ...props }) {
    return (
        <div className={cl.loader}>

        </div>
    );
};

export default Loader;