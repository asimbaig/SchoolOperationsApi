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
    public class ExceptionLoggerRepository : IExceptionLoggerRepository
    {
        private readonly DatabaseContext _dbContext;

        public ExceptionLoggerRepository(DatabaseContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Add(ExceptionLogger entity)
        {
                _dbContext.Entry(entity).State = entity.Id == 0 ? EntityState.Added : EntityState.Modified;
        }

        public void Update(ExceptionLogger entity)
        {
                var currentEntity = _dbContext.Set<ExceptionLogger>().AsQueryable().FirstOrDefault(x => x.Id == entity.Id);
                if (currentEntity == null)
                {
                    return;
                }
                _dbContext.Entry(currentEntity).CurrentValues.SetValues(entity);
        }

        public void Remove(ExceptionLogger entity)
        {
               _dbContext.Entry(entity).State = EntityState.Deleted;
        }

        public bool Exists(Expression<Func<ExceptionLogger, bool>> expression)
        {
                var result = _dbContext.Set<ExceptionLogger>().AsQueryable().FirstOrDefault(expression);
                if (result == null)
                    return false;
                else
                    return true;
        }

        public IQueryable<ExceptionLogger> FindExceptionLogger(Expression<Func<ExceptionLogger, bool>> expression)
        {
                return _dbContext.Set<ExceptionLogger>().AsQueryable().Where(expression);
        }

        public IQueryable<ExceptionLogger> GetAllExceptionLoggers()
        {
                return _dbContext.Set<ExceptionLogger>().AsQueryable();
        }

        public ExceptionLogger GetSingleOrDefaultExceptionLogger(Expression<Func<ExceptionLogger, bool>> expression)
        {
               return _dbContext.Set<ExceptionLogger>().AsQueryable().FirstOrDefault(expression);
        }
    }
}
