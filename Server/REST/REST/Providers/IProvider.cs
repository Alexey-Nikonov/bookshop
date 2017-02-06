using System.Threading.Tasks;
using System.Data;

namespace REST.Providers
{
    public interface IProvider
    {
        Task<DataTable> SelectAsync(string resource, int? id = null);
        //Task<DataTable> SelectAsync(string resource, string filter);
        Task<object> InsertAsync(string resource, object item);
        Task<object> UpdateAsync(string resource, object item, int id);
        Task<object> DeleteAsync(string resource, int id);
        //Task<object> ExpandAsync(string resource, int? id = null);
    }
}
