using DatabaseLayer.Context;
using DatabaseLayer.Models;
using DatabaseLayer.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Repository.Implementations
{
    public class ApiLogRepository : BaseRepository, IApiLogRepository
    {
        public ApiLogRepository(DatabaseContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public void Add(ApiLog entity)
        {
            try
            {
                _dbContext.Entry(entity).State = entity.LogID == 0 ? EntityState.Added : EntityState.Modified;

                //return await(_dbContext.SaveChangesAsync());
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public async Task<int> Update(ApiLog entity)
        {
            try
            {
                _dbContext.Entry(entity).State = entity.LogID == 0 ? EntityState.Added : EntityState.Modified;

                return await(_dbContext.SaveChangesAsync());
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public async Task<int> Remove(ApiLog entity)
        {
            try
            {
                _dbContext.Entry(entity).State = EntityState.Deleted;

                return await(_dbContext.SaveChangesAsync());
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public bool Exists(ApiLog entity)
        {
            try
            {
                return _dbContext.Set<ApiLog>().Local.Any(e => e == entity);

            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public async Task<IEnumerable<ApiLog>> FindAsync(Expression<Func<ApiLog, bool>> expression)
        {
            try
            {
                return await _dbContext.Set<ApiLog>().Where(expression).ToListAsync();
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public async Task<List<ApiLog>> GetAllAsync()
        {
            try
            {
                return await _dbContext.Set<ApiLog>().ToListAsync();
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public async Task<ApiLog> GetSingleOrDefaultAsync(Expression<Func<ApiLog, bool>> expression)
        {
            try
            {
                return await _dbContext.Set<ApiLog>().SingleOrDefaultAsync(expression);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //private async void LogException(Exception ex)
        //{

        //    ExceptionLogger exModel = new ExceptionLogger
        //    {
        //        ExceptionMessage = ex.Message,
        //        SourceName = ex.Source,
        //        ExceptionStackTrace = ex.StackTrace,
        //        LogTime = DateTime.Now
        //    };

        //    try
        //    {
        //        _dbContext.Entry(exModel).State = exModel.Id == 0 ? EntityState.Added : EntityState.Modified;

        //        await (_dbContext.SaveChangesAsync());
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}

     }
}
