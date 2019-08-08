import React from "react";
import Grid from "@material-ui/core/Grid";
import Checkbox from "@material-ui/core/Checkbox";

class MoviesList extends React.PureComponent {
  renderItem(item, index) {
    return (
      <Grid key={index} item className="movies-component-list-item">
        <Grid container alignItems="center">
          <Grid item>
            <Checkbox color="secondary" onChange={this.props.onSelect} value={item.id} />
          </Grid>
          <Grid item>
            <h5>{item.titulo}</h5>
            <p>{item.ano}</p>
          </Grid>
        </Grid>
      </Grid>
    );
  }

  render() {
    const { movies = [] } = this.props;

    return (
      <Grid container justify="space-between" className="movies-component-list">
        {movies.map(this.renderItem.bind(this))}
      </Grid>
    );
  }
}

export default MoviesList;