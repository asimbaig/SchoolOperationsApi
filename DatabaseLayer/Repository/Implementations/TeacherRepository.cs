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
    public class TeacherRepository : BaseRepository, ITeacherRepository
    {
        //private readonly DatabaseContext _dbContext;

        public TeacherRepository(DatabaseContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Add(TeacherModel entity)
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

        public bool Update(TeacherModel entity)
        {
            try
            {
                var currentEntity = _dbContext.Set<TeacherModel>().AsQueryable().FirstOrDefault(x => x.TeacherId == entity.TeacherId);
                if (currentEntity == null)
                {
                    return false;
                }

                currentEntity.TeacherName = entity.TeacherName;
                currentEntity.StartDate = entity.StartDate;
                currentEntity.Tr_Address1 = entity.Tr_Address1;
                currentEntity.Tr_Address2 = entity.Tr_Address2;
                currentEntity.Tr_PostCode = entity.Tr_PostCode;
                currentEntity.Tr_Telephone = entity.Tr_Telephone;

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

        public void Remove(TeacherModel entity)
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

        public bool Exists(Expression<Func<TeacherModel, bool>> expression)
        {
            try
            {
                var result = _dbContext.Set<TeacherModel>().AsQueryable().FirstOrDefault(expression);
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

        public IQueryable<TeacherModel> FindTeacher(Expression<Func<TeacherModel, bool>> expression)
        {
            try
            {
                return _dbContext.Set<TeacherModel>().AsQueryable().Where(expression);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public IQueryable<TeacherDTO> GetAllTeachers()
        {
            try
            {
                //return _dbContext.Set<TeacherModel>().AsQueryable();
                var LQuery = (from tr in _dbContext.Teachers
                              join
                              imgfilurl in _dbContext.ImageFileUrls on tr.ImageFileUrl.ImageFileUrlId equals imgfilurl.ImageFileUrlId
                              select new DTOs.TeacherDTO
                              {
                                  Tr_Address1 = tr.Tr_Address1,
                                  Tr_Address2 = tr.Tr_Address2,
                                  Tr_Email = tr.Tr_Email,
                                  TeacherId = tr.TeacherId,
                                  TeacherName = tr.TeacherName,
                                  StartDate = tr.StartDate,
                                  Tr_PostCode = tr.Tr_PostCode,
                                  Tr_Telephone = tr.Tr_Telephone,
                                  _ImageFileUrl = imgfilurl.Url,
                                  _StandardNames = tr.Standards.Select(x => x.StandardName).ToList(),
                                  _SubjectNames = tr.Subjects.Select(x => x.SubjectName).ToList()
                              }).AsQueryable();
                return LQuery;
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public TeacherModel GetSingleOrDefaultTeacher(Expression<Func<TeacherModel, bool>> expression)
        {
            try
            {
                return _dbContext.Set<TeacherModel>().AsQueryable().FirstOrDefault(expression);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public IQueryable<int> GetAllStandardsByTeacherId(int TeacherId)
        {
            try
            {
                return _dbContext.Teachers.Where(c => c.TeacherId == TeacherId).SelectMany(c => c.Standards).Select(x => x.StandardId);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public IQueryable<int> GetAllSubjectsByTeacherId(int TeacherId)
        {
            try
            {
                return _dbContext.Teachers.Where(c => c.TeacherId == TeacherId).SelectMany(c => c.Subjects).Select(x => x.SubjectId);
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
