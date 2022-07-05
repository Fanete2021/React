import React from 'react';
import cl from './Button.module.css';

const Button = function ({ children, ...props }) {
    return (
        <button {...props} className={cl.btn}>
            {children}
        </button>
    );
};

export default Button;