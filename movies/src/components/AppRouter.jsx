import React from 'react';
import { Route, Switch, Redirect } from "react-router-dom";
import { routes } from '../router/Routes';

const AppRouter = () => {
    return (
        <Switch>
            {routes.map(route =>
                <Route component={route.component} path={route.path} exact={route.exact} key={route.path} />
            )}
            <Redirect to='/movies' />
        </Switch>
    );
};

export default AppRouter;