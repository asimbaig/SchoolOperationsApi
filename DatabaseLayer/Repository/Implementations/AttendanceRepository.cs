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
    public class AttendanceRepository : BaseRepository, IAttendanceRepository
    {
        public AttendanceRepository(DatabaseContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Add(AttendanceModel entity)
        {
            try
            {
                entity.Student = _dbContext.Students.FirstOrDefault(x => x.StudentId == entity.StudentId);

                _dbContext.Entry(entity).State = EntityState.Added;
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public bool Update(AttendanceModel entity)
        {
            try
            {
                entity.Student = _dbContext.Students.FirstOrDefault(x => x.StudentId == entity.StudentId);

                var currentEntity = _dbContext.Set<AttendanceModel>().AsQueryable().FirstOrDefault(x => x.AttendanceId == entity.AttendanceId);
                if (currentEntity == null)
                {
                    return false;
                }
                currentEntity.Present = entity.Present;
                currentEntity.AttendanceDate = entity.AttendanceDate;
                currentEntity.StudentId = entity.StudentId;
                currentEntity.Student = entity.Student;

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

        public void Remove(AttendanceModel entity)
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

        public bool Exists(Expression<Func<AttendanceModel, bool>> expression)
        {
            try
            {
                var result = _dbContext.Set<AttendanceModel>().AsQueryable().FirstOrDefault(expression);
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

        public IQueryable<AttendanceModel> FindAttendance(Expression<Func<AttendanceModel, bool>> expression)
        {
            try
            {
                return _dbContext.Set<AttendanceModel>().AsQueryable().Where(expression);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public IQueryable<AttendanceModel> GetAllAttendances()
        {
            try
            {
                return _dbContext.Set<AttendanceModel>().AsQueryable();
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public AttendanceModel GetSingleOrDefaultAttendance(Expression<Func<AttendanceModel, bool>> expression)
        {
            try
            {
                return _dbContext.Set<AttendanceModel>().AsQueryable().FirstOrDefault(expression);
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
