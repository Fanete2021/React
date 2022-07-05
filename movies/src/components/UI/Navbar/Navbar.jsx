import React from 'react';
import { Link } from 'react-router-dom';

const Navbar = function (props) {
    return (
        <div className="navbar">
            <div>
                <Link className="navbar__links" to="/movies">Movies</Link>
                <Link className="navbar__links" to="/actors">Actors</Link>
            </div>
        </div>
    );
};

export default Navbar;