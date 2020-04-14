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
    public class SchoolRepository : BaseRepository, ISchoolRepository
    {
        //private readonly DatabaseContext _dbContext;

        public SchoolRepository(DatabaseContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Add(SchoolModel entity)
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

        public bool Update(SchoolModel entity)
        {
            try
            {
                var currentEntity = _dbContext.Set<SchoolModel>().AsQueryable().FirstOrDefault(x => x.SchoolId == entity.SchoolId);
                if (currentEntity == null)
                {
                    return false;
                }

                currentEntity.SchoolName = entity.SchoolName;
                currentEntity.SchoolAddress1 = entity.SchoolAddress1;
                currentEntity.SchoolAddress2 = entity.SchoolAddress2;
                currentEntity.SchoolWebsite = entity.SchoolWebsite;
                currentEntity.SchoolPostCode = entity.SchoolPostCode;
                currentEntity.SchoolTelephone = entity.SchoolTelephone;

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

        public void Remove(SchoolModel entity)
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

        public bool Exists(Expression<Func<SchoolModel, bool>> expression)
        {
            try
            {
                var result = _dbContext.Set<SchoolModel>().AsQueryable().FirstOrDefault(expression);
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

        public IQueryable<SchoolModel> FindSchool(Expression<Func<SchoolModel, bool>> expression)
        {
            try
            {
                return _dbContext.Set<SchoolModel>().AsQueryable().Where(expression);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public IQueryable<SchoolDTO> GetAllSchools()
        {
            try
            {
                //return _dbContext.Set<SchoolModel>().AsQueryable();
                var LQuery = (from shl in _dbContext.Schools
                              join
                              imgfilurl in _dbContext.ImageFileUrls on shl.ImageFileUrl.ImageFileUrlId equals imgfilurl.ImageFileUrlId
                              select new DTOs.SchoolDTO
                              {
                                  SchoolAddress1 = shl.SchoolAddress1,
                                  SchoolAddress2 = shl.SchoolAddress2,
                                  SchoolWebsite = shl.SchoolWebsite,
                                  SchoolId = shl.SchoolId,
                                  SchoolName = shl.SchoolName,
                                  SchoolPostCode = shl.SchoolPostCode,
                                  SchoolTelephone = shl.SchoolTelephone,
                                  _ImageFileUrl = imgfilurl.Url,
                                  _StandardNames = shl.Standards.Select(x => x.StandardName).ToList(),
                                  _StaffNames = shl.OperationalStaffs.Select(x => x.OpStaffName).ToList()
                              }).AsQueryable();
                return LQuery;
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public SchoolModel GetSingleOrDefaultSchool(Expression<Func<SchoolModel, bool>> expression)
        {
            try
            {
                return _dbContext.Set<SchoolModel>().AsQueryable().FirstOrDefault(expression);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public IQueryable<int> GetAllStandardsBySchoolId(int SchoolId)
        {
            try
            {
                return _dbContext.Standards.Where(c => c.SchoolId == SchoolId).Select(x => x.StandardId);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public IQueryable<int> GetAllOperationalStaffsBySchoolId(int SchoolId)
        {
            try
            {
                return _dbContext.OperationalStaffs.Where(c => c.SchoolId == SchoolId).Select(x => x.OpStaffId);
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
