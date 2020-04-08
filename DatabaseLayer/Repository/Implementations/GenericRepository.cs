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
    public class GenericRepository : BaseRepository, IGenericRepository
    {
        //private readonly DatabaseContext _dbContext;
        //private ExceptionLoggerRepository _ExceptionLoggerRepository = null;
        
        //public GenericRepository()
        //{
        //    this._dbContext = new DatabaseContext();
        //    this._ExceptionLoggerRepository = new ExceptionLoggerRepository(this._dbContext);


        //}

        public GenericRepository(DatabaseContext databaseContext)
        {
            this._dbContext = databaseContext;
            //this._ExceptionLoggerRepository = new ExceptionLoggerRepository(this._dbContext);
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : class
        {
            try
            {
                return await _dbContext.Set<T>().ToListAsync();
            }
            catch(Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public async Task<IEnumerable<T>> FindAsync<T>(Expression<Func<T, bool>> expression) where T : class
        {
            try
            {
                return await _dbContext.Set<T>().Where(expression).ToListAsync();
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public async Task<T> SingleOrDefaultAsync<T>(Expression<Func<T, bool>> expression) where T : class
        {
            try
            {
                return await _dbContext.Set<T>().SingleOrDefaultAsync(expression);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public void Add<T>(T entity) where T : class
        {
            try
            {
                _dbContext.Set<T>().Add(entity);
                //await _dbContext.SaveChangesAsync();
                //return entity;
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public void Update<T>(T entity) where T : class
        {
            try
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public void Remove<T>(T entity) where T : class
        {
            try
            {
                _dbContext.Set<T>().Remove(entity);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public  bool Exists<T>(T entity) where T : class
        {
            try
            {
                return _dbContext.Set<T>().Local.Any(e => e == entity);

            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //public virtual IList<T> GetAll<T>(params Expression<Func<T, object>>[] navigationProperties) where T : class
        //{
        //    try
        //    {
        //        List<T> list;
        //        IQueryable<T> dbQuery = _dbContext.Set<T>();

        //        //Apply eager loading
        //        foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
        //            dbQuery = dbQuery.Include<T, object>(navigationProperty);

        //        list = dbQuery
        //            .AsNoTracking()
        //            .ToList<T>();
        //        return list;
        //    }
        //    catch (Exception ex)
        //    {
        //        LogException(ex);
        //        throw ex;
        //    }
        //}

        //public virtual IList<T> GetList<T>(Func<T, bool> where,
        //     params Expression<Func<T, object>>[] navigationProperties) where T : class
        //{
        //    try
        //    {
        //        List<T> list;
        //        IQueryable<T> dbQuery = _dbContext.Set<T>();

        //        //Apply eager loading
        //        foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
        //            dbQuery = dbQuery.Include<T, object>(navigationProperty);

        //        list = dbQuery
        //            .AsNoTracking()
        //            .Where(where)
        //            .ToList<T>();
        //        return list;
        //    }
        //    catch (Exception ex)
        //    {
        //        LogException(ex);
        //        throw ex;
        //    }
        //}

        //public virtual T GetSingle<T>(Func<T, bool> where,
        //     params Expression<Func<T, object>>[] navigationProperties) where T : class
        //{
        //    try
        //    {
        //        T item = null;
        //        IQueryable<T> dbQuery = _dbContext.Set<T>();

        //        //Apply eager loading
        //        foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
        //            dbQuery = dbQuery.Include<T, object>(navigationProperty);

        //        item = dbQuery
        //            .AsNoTracking() //Don't track any changes for the selected item
        //            .FirstOrDefault(where); //Apply where clause
        //        return item;
        //    }
        //    catch (Exception ex)
        //    {
        //        LogException(ex);
        //        throw ex;
        //    }
        //}

        //public virtual void AddEntity<T>(params T[] items) where T : class
        //{
        //    try
        //    {
        //        foreach (T item in items)
        //        {
        //            _dbContext.Set<T>().Add(item);
        //            _dbContext.SaveChangesAsync();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogException(ex);
        //        throw ex;
        //    }
        //}

        //public virtual void UpdateEntity<T>(params T[] items) where T : class
        //{
        //    try
        //    {
        //        foreach (T item in items)
        //        {
        //            _dbContext.Entry(item).State = EntityState.Modified;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogException(ex);
        //        throw ex;
        //    }
        //}

        //public virtual void RemoveEntity<T>(params T[] items) where T : class
        //{
        //    try
        //    {
        //        foreach (T item in items)
        //        {
        //            _dbContext.Set<T>().Remove(item);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogException(ex);
        //        throw ex;
        //    }
        //}

        //private async void LogException(Exception ex)
        //{
           
        //        ExceptionLogger exModel = new ExceptionLogger
        //        {
        //            ExceptionMessage = ex.Message,
        //            SourceName = ex.Source,
        //            ExceptionStackTrace = ex.StackTrace,
        //            //LogTime = DateTime.Now
        //        };
        //        _ExceptionLoggerRepository.Add(exModel);
        //        await _dbContext.SaveChangesAsync();
        //}
    }
}
