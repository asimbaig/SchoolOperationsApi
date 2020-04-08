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
    public class ImageFileUrlRepository : BaseRepository, IImageFileUrlRepository
    {
        //private readonly DatabaseContext _dbContext;

        public ImageFileUrlRepository(DatabaseContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Add(ImageFileUrlModel entity)
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

        public bool Update(ImageFileUrlModel entity)
        {
            try
            {
                var currentEntity = _dbContext.Set<ImageFileUrlModel>().AsQueryable().FirstOrDefault(x => x.ImageFileUrlId == entity.ImageFileUrlId);
                if (currentEntity == null)
                {
                    return false;
                }
                currentEntity.Url = entity.Url;
                currentEntity.CreateDate = entity.CreateDate;
                currentEntity.ImageFileUrlId = entity.ImageFileUrlId;
                
                return true;
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public void Remove(ImageFileUrlModel entity)
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

        public bool Exists(Expression<Func<ImageFileUrlModel, bool>> expression)
        {
            try
            {
                var result = _dbContext.Set<ImageFileUrlModel>().AsQueryable().FirstOrDefault(expression);
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

        public IQueryable<ImageFileUrlModel> FindImageFileUrl(Expression<Func<ImageFileUrlModel, bool>> expression)
        {
            try
            {
                return _dbContext.Set<ImageFileUrlModel>().AsQueryable().Where(expression);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public IQueryable<ImageFileUrlModel> GetAllImageFileUrls()
        {
            try
            {
                return _dbContext.Set<ImageFileUrlModel>().AsQueryable();
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public ImageFileUrlModel GetSingleOrDefaultImageFileUrl(Expression<Func<ImageFileUrlModel, bool>> expression)
        {
            try
            {
                return _dbContext.Set<ImageFileUrlModel>().AsQueryable().FirstOrDefault(expression);
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
