import Actors from '../pages/Actors';
import Movies from '../pages/Movies';

export const routes = [
    { path: '/movies', component: Movies, exact: true },
    { path: '/actors', component: Actors, exact: true }
]
