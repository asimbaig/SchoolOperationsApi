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
    public class HomeworkRepository : BaseRepository, IHomeworkRepository
    {
        //private readonly DatabaseContext _dbContext;

        public HomeworkRepository(DatabaseContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Add(HomeworkModel entity)
        {
            try
            {
                entity.Standard = _dbContext.Standards.FirstOrDefault(x => x.StandardId == entity.StandardId);
                _dbContext.Entry(entity).State = EntityState.Added;

            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public bool Update(HomeworkModel entity)
        {
            try
            {
                entity.Standard = _dbContext.Standards.FirstOrDefault(x => x.StandardId == entity.StandardId);
                var currentEntity = _dbContext.Set<HomeworkModel>().AsQueryable().FirstOrDefault(x => x.HomeworkId == entity.HomeworkId);
                if (currentEntity == null)
                {
                    return false;
                }
                currentEntity.HomeworkName = entity.HomeworkName;
                currentEntity.IssueDate = entity.IssueDate;
                currentEntity.DueDate = entity.DueDate;
                currentEntity.StandardId = entity.StandardId;
                currentEntity.Standard = entity.Standard;

                if (entity.ImageFileUrl != null)
                {
                    currentEntity.ImageFileUrl.Url = entity.ImageFileUrl.Url;
                }

                return true;
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public void Remove(HomeworkModel entity)
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

        public bool Exists(Expression<Func<HomeworkModel, bool>> expression)
        {
            try
            {
                var result = _dbContext.Set<HomeworkModel>().AsQueryable().FirstOrDefault(expression);
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

        public IQueryable<HomeworkModel> FindHomework(Expression<Func<HomeworkModel, bool>> expression)
        {
            try
            {
                return _dbContext.Set<HomeworkModel>().AsQueryable().Where(expression);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public IQueryable<HomeworkDTO> GetAllHomeworks()
        {
            try
            {
                //return _dbContext.Set<HomeworkModel>().AsQueryable();
                var LQuery = (from hm in _dbContext.Homeworks
                              join
                              stand in _dbContext.Standards on hm.StandardId equals stand.StandardId
                              join
                              imgfilurl in _dbContext.ImageFileUrls on hm.ImageFileUrl.ImageFileUrlId equals imgfilurl.ImageFileUrlId
                              select new DTOs.HomeworkDTO
                              {
                                  HomeworkId = hm.HomeworkId,
                                  HomeworkName = hm.HomeworkName,
                                  IssueDate = hm.IssueDate,
                                  DueDate = hm.DueDate,
                                  _ImageFileUrl = imgfilurl.Url,
                                  StandardId = stand.StandardId,
                                  _StandardName = stand.StandardName
                              }).AsQueryable();
                return LQuery;
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public HomeworkModel GetSingleOrDefaultHomework(Expression<Func<HomeworkModel, bool>> expression)
        {
            try
            {
                return _dbContext.Set<HomeworkModel>().AsQueryable().FirstOrDefault(expression);
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
