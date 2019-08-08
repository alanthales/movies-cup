import React from 'react';
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";
import Container from "@material-ui/core/Container";
import Home from "./Pages/Home/Home";
import Classification from "./Pages/Classification/Classification";
import NotFound from "./Pages/NotFound/NotFound";

const App = () => (
  <Router>
    <Container maxWidth="lg" style={{ marginTop: "50px" }}>
      <Switch>
        <Route path="/" exact component={Home} />
        <Route path="/classification" component={Classification} />
        <Route component={NotFound} />
      </Switch>
    </Container>
  </Router>
);

export default App;
