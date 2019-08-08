import "./Rank.css";
import React from "react";
import Box from "@material-ui/core/Box";
import Grid from "@material-ui/core/Grid";

const RankItem = ({ movie, position }) => (
  <Grid item className="champions">
    <Box bgcolor="secondary.main" className="position">{position}º</Box>
    <div className="title">
      <h4>{movie.titulo}</h4>
    </div>
  </Grid>
);

const Rank = ({ champion, vice }) => (
  <Grid container direction="column" className="rank-component">
    <RankItem movie={champion} position={1} />
    <RankItem movie={vice} position={2} />
  </Grid>
);

export default Rank;