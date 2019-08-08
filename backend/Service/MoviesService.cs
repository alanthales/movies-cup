using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Service.ViewModels;

namespace Service
{
    public class MoviesService : IMoviesService
    {
        private const int MOVIES_TO_COMPARE = 8;

        private readonly IApiRepository<Filme> _repository;

        public MoviesService(IApiRepository<Filme> repository)
        {
            this._repository = repository;
        }

        public async Task<IEnumerable<Filme>> GetMovies()
        {
            return await _repository.Get();
        }

        public Classificacao GetChampions(List<Filme> filmes)
        {
            var result = new Classificacao();
            var finalistas = GetFinalists(filmes).ToList();
            var winners = GetWinners(finalistas).ToList();

            result.Campeao = Compare(winners[0], winners[1]);
            result.Vice = winners.First(x => x.Id != result.Campeao.Id);

            return result;
        }

        public IEnumerable<Filme> GetFinalists(List<Filme> filmes)
        {
            if (filmes.Count != MOVIES_TO_COMPARE)
            {
                throw new HttpException(400, "Bad request");
            }

            var orderedList = filmes.OrderBy(x => x.Titulo).ToArray();

            int last = orderedList.Length - 1;
            int total = orderedList.Length / 2;

            for (int i = 0; i < total; i++)
            {
                yield return Compare(orderedList[i], orderedList[last-i]);
            }
        }

        private IEnumerable<Filme> GetWinners(List<Filme> filmes)
        {
            for (int i = 0; i < filmes.Count; i += 2)
            {
                yield return Compare(filmes[i], filmes[i+1]);
            }
        }

        private Filme Compare(Filme a, Filme b)
        {
            if (a.Nota == b.Nota)
            {
                var lista = new List<Filme>(2);

                lista.Add(a);
                lista.Add(b);
                
                return lista.OrderBy(x => x.Titulo).First();
            }

            return a.Nota > b.Nota ? a : b;
        }
    }
}