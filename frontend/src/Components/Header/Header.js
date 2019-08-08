import "./Header.css";
import React from "react";
import Box from "@material-ui/core/Box";
import Grid from "@material-ui/core/Grid";

const Header = ({ title, subtitle }) => (
  <Box bgcolor="primary.main">
    <Grid container justify="center" className="header-component">
      <Grid item xs={8}>
        <h4>CAMPEONATO DE FILMES</h4>
        <h1>{title}</h1>
        <hr style={{ width: "50px" }} />
        <p>{subtitle}</p>
      </Grid>
    </Grid>
  </Box>
);

export default Header;