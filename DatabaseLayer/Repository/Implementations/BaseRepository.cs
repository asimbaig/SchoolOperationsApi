using DatabaseLayer.Context;
using DatabaseLayer.Models;
using DatabaseLayer.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Repository.Implementations
{
    public class BaseRepository
    {
        public IExceptionLoggerRepository ExceptionLoggerRepository;
        public  DatabaseContext _dbContext;

        public BaseRepository()
        {
           // this.ExceptionLoggerRepository = new ExceptionLoggerRepository();
        }
        public BaseRepository(DatabaseContext _dbContext)
        {
            this.ExceptionLoggerRepository = new ExceptionLoggerRepository(_dbContext);
        }

        public async void LogException(Exception ex)
        {
            ExceptionLogger exModel = new ExceptionLogger
            {
                ExceptionMessage = ex.Message,
                SourceName = ex.Source,
                ExceptionStackTrace = ex.StackTrace,
                LogTime = DateTime.Now
            };

            try
            {
                ExceptionLoggerRepository.Add(exModel);
                
                await (_dbContext.SaveChangesAsync());
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
