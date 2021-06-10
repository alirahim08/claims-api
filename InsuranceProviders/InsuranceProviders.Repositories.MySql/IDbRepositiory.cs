using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;

namespace InsuranceProviders.Repositories.MySql
{
    public interface IDbRepositiory
    {
        Task<IEnumerable<T>> GetListAsync<T>(string query, object parameters = null);
        Task<T> GetFirstOrDefaultAsync<T>(string query, DynamicParameters parameters = null);
        Task<int> ExecuteAsync<T>(string query, DynamicParameters parameters = null);


    }
}