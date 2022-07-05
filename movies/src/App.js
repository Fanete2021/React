import React, { useEffect, useState } from 'react';
import { BrowserRouter } from "react-router-dom";
import GenreService from './API/GenreService';
import AppRouter from './components/AppRouter';
import Navbar from './components/UI/Navbar/Navbar';
import { Context } from './context';
import './styles/App.css';

function App() {
    //Initialization of actors and genres data
    const [genres, setGenres] = useState([])

    const loadingGenres = async () => {
        const response = await GenreService.getGenres()
        setGenres([...genres, ...response])
    }

    useEffect(() => {
        loadingGenres()
    }, [])

    
    return (
        <Context.Provider value={{
            genres
        }}>
            <BrowserRouter>
                <Navbar/>
                <AppRouter/>
            </BrowserRouter>
        </Context.Provider>
    )
}

export default App;