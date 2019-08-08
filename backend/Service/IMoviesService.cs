using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.Entities;
using Service.ViewModels;

namespace Service
{
    public interface IMoviesService
    {
        Task<IEnumerable<Filme>> GetMovies();
        IEnumerable<Filme> GetFinalists(List<Filme> filmes);
        Classificacao GetChampions(List<Filme> filmes);
    }
}
