import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Portfolio } from './components/portfolio/Portfolio';

export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <Layout>
        <Route exact path='/' component={Portfolio} />
        <Route path='/portfolio' component={Portfolio} />
      </Layout>
    );
  }
}
