using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Repository.Interfaces
{
    public interface IExceptionLoggerRepository
    {
        void Add(ExceptionLogger entity);
        void Update(ExceptionLogger entity);
        void Remove(ExceptionLogger entity);
        bool Exists(Expression<Func<ExceptionLogger, bool>> expression);
        IQueryable<ExceptionLogger> FindExceptionLogger(Expression<Func<ExceptionLogger, bool>> expression);
        IQueryable<ExceptionLogger> GetAllExceptionLoggers();
        ExceptionLogger GetSingleOrDefaultExceptionLogger(Expression<Func<ExceptionLogger, bool>> expression);
    }
}
