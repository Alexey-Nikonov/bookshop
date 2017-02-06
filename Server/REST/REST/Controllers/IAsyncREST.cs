using System.Threading.Tasks;
using System.Net.Http;

namespace REST.Controllers
{
    public interface IAsyncREST
    {
        Task<HttpResponseMessage> GetAsync(string resource);
        Task<HttpResponseMessage> GetAsync(string resource, int id);
        Task<HttpResponseMessage> PostAsync(string resource, object item);
        Task<HttpResponseMessage> PutAsync(string resource, int id, object item);
        Task<HttpResponseMessage> DeleteAsync(string resource, int id);
    }
}
