using System;
using System.Collections;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Threading.Tasks;
using System.Configuration;
using REST.Providers;
using REST.Extensions;
using System.Web.Http.Cors;

namespace REST.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ApiController : System.Web.Http.ApiController, IAsyncREST
    {
        DataTable table; // вспомогательная таблица для манипулирования данными
        IProvider provider; // интерфейс провайдера

        public ApiController()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MssqlConStr"].ConnectionString;
            this.provider = new MssqlProvider(connectionString);
        }

        // GET: api/resource
        public async Task<HttpResponseMessage> GetAsync([FromUri] string resource)
        {
            try
            {
                resource = resource.CorrectTableName(); // корректировка названия таблицы для последующего использования в запросах
                this.table = await this.provider.SelectAsync(resource);
                IEnumerable list = this.table.ToList(resource); // преобразование DataTable в составной объект для возможности сериализации контроллером

                return Request.CreateResponse(HttpStatusCode.OK, list);
            }
            catch (Exception exception)
            {
                return Request.CreateResponse(exception);
            }
        }

        // GET: api/resource/id
        public async Task<HttpResponseMessage> GetAsync([FromUri] string resource, [FromUri] int id)
        {
            try
            {
                resource = resource.CorrectTableName();
                this.table = await this.provider.SelectAsync(resource, id);
                var item = this.table.ToItem(resource);

                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch (Exception exception)
            {
                return Request.CreateResponse(exception);
            }
        }

        // POST: api/resource
        public async Task<HttpResponseMessage> PostAsync([FromUri] string resource, [FromBody] object item)
        {
            try
            {
                resource = resource.CorrectTableName();
                var returnedItem = await this.provider.InsertAsync(resource, item);

                return returnedItem == null ?
                    Request.CreateResponse(HttpStatusCode.InternalServerError, "Not added") :
                    Request.CreateResponse(HttpStatusCode.OK, returnedItem);
            }
            catch (Exception exception)
            {
                return Request.CreateResponse(exception);
            }
        }

        // PUT: api/resource/id
        public async Task<HttpResponseMessage> PutAsync([FromUri] string resource, [FromUri] int id, [FromBody] object item)
        {
            try
            {
                resource = resource.CorrectTableName();
                var reternedItem = await this.provider.UpdateAsync(resource, item, id);

                return reternedItem == null ?
                    Request.CreateResponse(HttpStatusCode.InternalServerError, "Not modified") :
                    Request.CreateResponse(HttpStatusCode.OK, reternedItem);
            }
            catch (Exception exception)
            {
                return Request.CreateResponse(exception);
            }
        }

        // DELETE: api/resource/id
        public async Task<HttpResponseMessage> DeleteAsync([FromUri] string resource, [FromUri] int id)
        {
            try
            {
                resource = resource.CorrectTableName();
                var reternedItem = await this.provider.DeleteAsync(resource, id);

                return reternedItem == null ?
                    Request.CreateResponse(HttpStatusCode.InternalServerError, "Not deleted") :
                    Request.CreateResponse(HttpStatusCode.OK, reternedItem);
            }
            catch (Exception exception)
            {
                return Request.CreateResponse(exception);
            }
        }
    }
}