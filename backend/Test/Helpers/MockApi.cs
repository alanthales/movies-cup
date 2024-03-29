using System.Net.Http;
using System.Threading.Tasks;
using Domain.Exceptions;
using Domain.Interfaces;

namespace Test.Helpers
{
    public class MockApi : IHttpClient
    {
        private readonly string _movies =
            @"[
              {""id"":""tt3606756"",""titulo"":""Os Incríveis 2"",""ano"":2018,""nota"":8.5},
              {""id"":""tt4881806"",""titulo"":""Jurassic World: Reino Ameaçado"",""ano"":2018,""nota"":6.7},
              {""id"":""tt5164214"",""titulo"":""Oito Mulheres e um Segredo"",""ano"":2018,""nota"":6.3},
              {""id"":""tt7784604"",""titulo"":""Hereditário"",""ano"":2018,""nota"":7.8},
              {""id"":""tt4154756"",""titulo"":""Vingadores: Guerra Infinita"",""ano"":2018,""nota"":8.8},
              {""id"":""tt5463162"",""titulo"":""Deadpool 2"",""ano"":2018,""nota"":8.1},
              {""id"":""tt3778644"",""titulo"":""Han Solo: Uma História Star Wars"",""ano"":2018,""nota"":7.2},
              {""id"":""tt3501632"",""titulo"":""Thor: Ragnarok"",""ano"":2017,""nota"":7.9}
            ]";

        public HttpResponseMessage Get(string url)
        {
            return GetAsync(url).Result;
        }

        public Task<HttpResponseMessage> GetAsync(string url)
        {
            var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            response.Content = new StringContent(_movies);
            return Task.FromResult(response);
        }
    }

    public class MockApiError : IHttpClient
    {
        public HttpResponseMessage Get(string url)
        {
            return GetAsync(url).Result;
        }

        public Task<HttpResponseMessage> GetAsync(string url)
        {
            throw new HttpException(500, "Testing exception");
        }
    }
}