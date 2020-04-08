using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Repository.Interfaces
{
    public interface IApiLogRepository 
    {
        void Add(ApiLog entity);
        Task<int> Update(ApiLog entity);
        Task<int> Remove(ApiLog entity);
        bool Exists(ApiLog entity);
        Task<IEnumerable<ApiLog>> FindAsync(Expression<Func<ApiLog, bool>> expression);
        Task<List<ApiLog>> GetAllAsync();
        Task<ApiLog> GetSingleOrDefaultAsync(Expression<Func<ApiLog, bool>> expression);
    }
}
