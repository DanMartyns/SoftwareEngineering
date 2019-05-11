import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import * as serviceWorker from './serviceWorker';
import {HashRouter, Route, Switch} from 'react-router-dom';

import Page404 from './views/Pages/Page404/'
import Page500 from './views/Pages/Page500/'


ReactDOM.render((
  <HashRouter>
    <Switch>
      <Route exact path="/404" name="Page 404" component={Page404}/>
      <Route exact path="/500" name="Page 500" component={Page500}/>
      <Route path="/" name="Home" component={App}/>
    </Switch>
  </HashRouter>
), document.getElementById('root'));

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
