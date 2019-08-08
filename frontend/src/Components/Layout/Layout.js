import React from "react";
import Grid from "@material-ui/core/Grid";
import Header from "../Header/Header";

const Layout = ({ title, subtitle, children }) => (
  <Grid container direction="column" spacing={2}>
    <Grid item>
      <Header title={title} subtitle={subtitle} />
    </Grid>

    <Grid item>
      {children}
    </Grid>
  </Grid>
);

export default Layout;