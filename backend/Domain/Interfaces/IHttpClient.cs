using System.Net.Http;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IHttpClient
    {
        HttpResponseMessage Get(string url);
        Task<HttpResponseMessage> GetAsync(string url);
    }
}