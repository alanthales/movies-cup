using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Repository
{
    public class MoviesRepository : IApiRepository<Filme>
    {
        private readonly IHttpClient api;

        public MoviesRepository(IHttpClient api)
        {
            this.api = api;
        }

        public async Task<IEnumerable<Filme>> Get()
        {
            using(var response = await this.api.GetAsync("api/filmes"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IEnumerable<Filme>>(result);
                }

                throw new HttpException((int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}