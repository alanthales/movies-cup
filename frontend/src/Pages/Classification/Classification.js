import React from "react";
import Button from "@material-ui/core/Button";
import ArrowBackIcon from "@material-ui/icons/ArrowBack"
import Layout from "../../Components/Layout/Layout";
import Rank from "../../Components/Rank/Rank";
import { useFetch } from "../../Components/Fetch/withFetch";

export const Classification = ({ history, location, data, isLoading, hasError }) => (
  <Layout
    title="Resultado Final"
    subtitle="Veja o resultado final do Campeonato de filmes de forma simples e rápida."
  >
    <div style={{ marginBottom: "20px" }}>
      <Button variant="outlined" color="secondary" onClick={() => history.goBack()}>
        <ArrowBackIcon />
        Voltar
      </Button>
    </div>

    {isLoading && <p className="text-center">Carregando...</p>}

    {hasError && <p className="text-center">Opps! Algo deu errado, tente novamente.</p>}

    {!isLoading && !hasError && <Rank champion={data.campeao} vice={data.vice} />}
  </Layout>
);

const InjectedClassification = (props) => {
  const { movies } = props.location.state || [];
  const [data, isLoading, hasError] = useFetch("/api/movies/classification", {}, "post", movies);
  return (
    <Classification {...props} data={data} isLoading={isLoading} hasError={hasError} />
  );
};

export default InjectedClassification;