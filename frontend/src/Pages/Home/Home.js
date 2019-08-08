import React from "react";
import Snackbar from "@material-ui/core/Snackbar";
import Layout from "../../Components/Layout/Layout";
import { MoviesList, MoviesCount, MAX_LIST } from "../../Components/Movies";
import withFetch from "../../Components/Fetch/withFetch";

export class Home extends React.Component {
  state = {
    moviesSelecteds: [],
    selectedsCount: 0,
    notes: null
  }

  handleSelect(event, checked) {
    let movie = this.props.data.find(x => x.id === event.target.value);

    this.setState((state) => {
      if (checked) {
        return {
          selectedsCount: state.selectedsCount + 1,
          moviesSelecteds: [...state.moviesSelecteds, movie]
        };
      }

      return {
        selectedsCount: state.selectedsCount - 1,
        moviesSelecteds: state.moviesSelecteds.filter(x => x.id !== movie.id)
      };
    });
  }

  handleGenerate() {
    if (this.props.hasError) return;
    
    if (this.state.selectedsCount !== MAX_LIST) {
      this.setState({ notes: "Você deve selecionar 8 filmes" });
      return;
    }

    const { moviesSelecteds: movies } = this.state;
    this.props.history.push("/classification", { movies });
  }

  render() {
    const { selectedsCount, notes } = this.state,
      { data, isLoading, hasError } = this.props;

    return (
      <div>
        <Layout
          title="Fase de Seleção"
          subtitle="Selecione 8 filmes que você deseja que entre na competição e depois pressione o botão Gerar Meu Campeonato para prosseguir."
        >
          <MoviesCount value={selectedsCount} onGenerate={this.handleGenerate.bind(this)} />

          {isLoading && <p className="text-center">Carregando...</p>}

          {hasError && <p className="text-center">Opps! Algo deu errado, tente recarregar a página.</p>}

          {!isLoading && !hasError && (
            <MoviesList movies={data} onSelect={this.handleSelect.bind(this)} />
          )}
        </Layout>

        <Snackbar
          anchorOrigin={{
            vertical: 'bottom',
            horizontal: 'right',
          }}
          open={!!notes}
          autoHideDuration={5000}
          onClose={() => this.setState({ notes: null })}
          message={notes}
        />
      </div>
    );
  }
}

const fetchOptions = { url: "/api/movies" };
const hocHome = withFetch(fetchOptions)(Home);

export default hocHome;