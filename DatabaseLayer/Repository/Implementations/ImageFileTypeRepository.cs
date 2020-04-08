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
    public class ImageFileTypeRepository : BaseRepository, IImageFileTypeRepository
    {
        //private readonly DatabaseContext _dbContext;

        public ImageFileTypeRepository(DatabaseContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Add(ImageFileTypeModel entity)
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

        public bool Update(ImageFileTypeModel entity)
        {
            try
            {
                var currentEntity = _dbContext.Set<ImageFileTypeModel>().AsQueryable().FirstOrDefault(x => x.ImageFileTypeId == entity.ImageFileTypeId);
                if (currentEntity == null)
                {
                    return false;
                }
                currentEntity.Type = entity.Type;

                return true;
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public void Remove(ImageFileTypeModel entity)
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

        public bool Exists(Expression<Func<ImageFileTypeModel, bool>> expression)
        {
            try
            {
                var result = _dbContext.Set<ImageFileTypeModel>().AsQueryable().FirstOrDefault(expression);
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

        public IQueryable<ImageFileTypeModel> FindImageFileType(Expression<Func<ImageFileTypeModel, bool>> expression)
        {
            try
            {
                return _dbContext.Set<ImageFileTypeModel>().AsQueryable().Where(expression);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public IQueryable<ImageFileTypeModel> GetAllImageFileTypes()
        {
            try
            {
                return _dbContext.Set<ImageFileTypeModel>().AsQueryable();
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public ImageFileTypeModel GetSingleOrDefaultImageFileType(Expression<Func<ImageFileTypeModel, bool>> expression)
        {
            try
            {
                return _dbContext.Set<ImageFileTypeModel>().AsQueryable().FirstOrDefault(expression);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public IQueryable<int> GetAllImageFileUrlsByImageFileTypeId(int ImageFileTypeId)
        {
            try
            {
                return _dbContext.ImageFileUrls.Where(c => c.ImageFileTypeId == ImageFileTypeId).Select(x => x.ImageFileUrlId);
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
