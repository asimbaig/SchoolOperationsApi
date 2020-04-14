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
    public class ParentRepository : BaseRepository, IParentRepository
    {
        //private readonly DatabaseContext _dbContext;

        public ParentRepository(DatabaseContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Add(ParentModel entity)
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

        public bool Update(ParentModel entity)
        {
            try
            {

                var currentEntity = _dbContext.Set<ParentModel>().AsQueryable().FirstOrDefault(x => x.ParentId == entity.ParentId);
                if (currentEntity == null)
                {
                    return false;
                }

                currentEntity.ParentName = entity.ParentName;
                currentEntity.ParentAddress1 = entity.ParentAddress1;
                currentEntity.ParentAddress2 = entity.ParentAddress2;
                //currentEntity.ParentEmail = entity.ParentEmail;
                currentEntity.ParentPostCode = entity.ParentPostCode;
                currentEntity.ParentTelephone = entity.ParentTelephone;

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

        public void Remove(ParentModel entity)
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

        public bool Exists(Expression<Func<ParentModel, bool>> expression)
        {
            try
            {
                var result = _dbContext.Set<ParentModel>().AsQueryable().FirstOrDefault(expression);
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

        public IQueryable<ParentModel> FindParent(Expression<Func<ParentModel, bool>> expression)
        {
            try
            {
                return _dbContext.Set<ParentModel>().AsQueryable().Where(expression);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public IQueryable<ParentDTO> GetAllParents()
        {
            try
            {
                //return _dbContext.Set<ParentModel>().AsQueryable();
                var LQuery = (from pts in _dbContext.Parents
                              join
                              imgfilurl in _dbContext.ImageFileUrls on pts.ImageFileUrl.ImageFileUrlId equals imgfilurl.ImageFileUrlId
                              select new DTOs.ParentDTO
                              {
                                  ParentAddress1 = pts.ParentAddress1,
                                  ParentAddress2 = pts.ParentAddress2,
                                  ParentEmail = pts.ParentEmail,
                                  ParentId = pts.ParentId,
                                  ParentName = pts.ParentName,
                                  ParentPostCode = pts.ParentPostCode,
                                  RelationType = pts.RelationType,
                                  ParentTelephone = pts.ParentTelephone,
                                  _ImageFileUrl = imgfilurl.Url,
                                  ChildrenNames = pts.Students.Select(x=>x.St_Name).ToList()
                              }).AsQueryable();
                return LQuery;
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public ParentModel GetSingleOrDefaultParent(Expression<Func<ParentModel, bool>> expression)
        {
            try
            {
                return _dbContext.Set<ParentModel>().AsQueryable().FirstOrDefault(expression);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public IQueryable<int> GetAllStudentsByParentId(int ParentId)
        {
            try
            {
                return _dbContext.Parents.Where(c => c.ParentId == ParentId).SelectMany(c => c.Students).Select(x => x.StudentId);
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
