import React from "react";
import Grid from "@material-ui/core/Grid";
import Button from "@material-ui/core/Button";

export const MAX_LIST = 8;

const MoviesCount = ({ value, onGenerate }) => (
  <Grid container justify="space-between" alignItems="center" className="movies-component-count">
    <Grid item>
      <h4>Selecionados</h4>
      <p>{`${value} de ${MAX_LIST}`}</p>
    </Grid>
    <Grid item>
      <Button size="large" variant="contained" color="secondary" onClick={onGenerate}>Gerar Meu Campeonato</Button>
    </Grid>
  </Grid>
);

export default MoviesCount;