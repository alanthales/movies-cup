using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Repository.Providers
{
    public class MoviesApi : IHttpClient
    {
        private readonly HttpClient _client;

        public MoviesApi()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://copadosfilmes.azurewebsites.net/");
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
        }

        public HttpResponseMessage Get(string url)
        {
            return _client.GetAsync(url).Result;
        }

        public Task<HttpResponseMessage> GetAsync(string url)
        {
            return _client.GetAsync(url);
        }
    }
}