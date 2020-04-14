using DatabaseLayer.Context;
using DatabaseLayer.Models;
using DatabaseLayer.Repository.Interfaces;
using DTOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Repository.Implementations
{
    public class YearRepository : BaseRepository, IYearRepository
    {
        //private readonly DatabaseContext _dbContext;

        public YearRepository(DatabaseContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Add(YearModel entity)
        {
            try
            {
                _dbContext.Entry(entity).State = EntityState.Added;

            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public bool Update(YearModel entity)
        {
            try
            {
                var currentEntity = _dbContext.Set<YearModel>().AsQueryable().FirstOrDefault(x => x.YearId == entity.YearId);
                if (currentEntity == null)
                {
                    return false;
                }

                currentEntity.year = entity.year;

                return true;
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public void Remove(YearModel entity)
        {
            try
            {
                _dbContext.Entry(entity).State = EntityState.Deleted;

                //return await (_dbContext.SaveChangesAsync());
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public bool Exists(Expression<Func<YearModel, bool>> expression)
        {
            try
            {
                var result = _dbContext.Set<YearModel>().AsQueryable().FirstOrDefault(expression);
                if (result == null)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public IQueryable<YearModel> FindYear(Expression<Func<YearModel, bool>> expression)
        {
            try
            {
                return _dbContext.Set<YearModel>().AsQueryable().Where(expression);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public IQueryable<YearDTO> GetAllYears()
        {
            try
            {
                //return _dbContext.Set<YearModel>().AsQueryable();
                var LQuery = (from yrs in _dbContext.Years
                              select new DTOs.YearDTO
                              {
                                  YearId = yrs.YearId,
                                  year = yrs.year,
                                  _StandardNames = yrs.Standards.Select(x => x.StandardName).ToList()
                              }).AsQueryable();
                return LQuery;
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public YearModel GetSingleOrDefaultYear(Expression<Func<YearModel, bool>> expression)
        {
            try
            {
                return _dbContext.Set<YearModel>().AsQueryable().FirstOrDefault(expression);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public IQueryable<int> GetAllStandardsByYearId(int YearId)
        {
            try
            {
                return _dbContext.Standards.Where(c => c.YearId == YearId).Select(x => x.StandardId);
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
