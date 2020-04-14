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
    public class StudentRepository : BaseRepository, IStudentRepository
    {
        //private readonly DatabaseContext _dbContext;

        public StudentRepository(DatabaseContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Add(StudentModel entity)
        {
            try
            {
                entity.Standard = _dbContext.Standards.FirstOrDefault(x => x.StandardId == entity.StudentId);
                _dbContext.Entry(entity).State = EntityState.Added;

            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public bool Update(StudentModel entity)
        {
            try
            {
                entity.Standard = _dbContext.Standards.FirstOrDefault(x => x.StandardId == entity.StudentId);
                var currentEntity = _dbContext.Set<StudentModel>().AsQueryable().FirstOrDefault(x => x.StudentId == entity.StudentId);
                if (currentEntity == null)
                {
                    return false;
                }

                currentEntity.St_Name = entity.St_Name;
                currentEntity.St_Address1 = entity.St_Address1;
                currentEntity.St_Address2 = entity.St_Address2;
                //currentEntity.St_Email = entity.St_Email;
                currentEntity.St_PostCode = entity.St_PostCode;
                currentEntity.St_Telephone = entity.St_Telephone;
                currentEntity.EnrolmentDate = entity.EnrolmentDate;
                currentEntity.St_Telephone = entity.St_Telephone;
                currentEntity.StandardId = entity.StandardId;

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

        public void Remove(StudentModel entity)
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

        public bool Exists(Expression<Func<StudentModel, bool>> expression)
        {
            try
            {
                var result = _dbContext.Set<StudentModel>().AsQueryable().FirstOrDefault(expression);
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

        public IQueryable<StudentModel> FindStudent(Expression<Func<StudentModel, bool>> expression)
        {
            try
            {
                return _dbContext.Set<StudentModel>().AsQueryable().Where(expression);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public IQueryable<StudentDTO> GetAllStudents()
        {
            try
            {
                //return _dbContext.Set<StudentModel>().AsQueryable();
                var LQuery = (from std in _dbContext.Students
                              join
                              stand in _dbContext.Standards on std.StandardId equals stand.StandardId
                              join
                              imgfilurl in _dbContext.ImageFileUrls on std.ImageFileUrl.ImageFileUrlId equals imgfilurl.ImageFileUrlId
                              select new DTOs.StudentDTO
                              {
                                  St_Address1 = std.St_Address1,
                                  St_Address2 = std.St_Address2,
                                  St_Email = std.St_Email,
                                  StudentId = std.StudentId,
                                  St_Name = std.St_Name,
                                  St_PostCode = std.St_PostCode,
                                  EnrolmentDate = std.EnrolmentDate,
                                  St_Telephone = std.St_Telephone,
                                  _ImageFileUrl = imgfilurl.Url,
                                  StandardId = stand.StandardId,
                                  _StandardName = stand.StandardName,
                                  _EventParticipatings = std.Events.Select(x => x.EventName).ToList(),
                                  _ParentNames = std.Parents.Select(x => x.ParentName).ToList()
                              }).AsQueryable();
                return LQuery;
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public StudentModel GetSingleOrDefaultStudent(Expression<Func<StudentModel, bool>> expression)
        {
            try
            {
                return _dbContext.Set<StudentModel>().AsQueryable().FirstOrDefault(expression);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public IQueryable<int> GetAllEventsByStudentId(int StudentId)
        {
            try
            {
                return _dbContext.Students.Where(c => c.StudentId == StudentId).SelectMany(c => c.Events).Select(x => x.EventId);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public IQueryable<int> GetAllBookTransactionsByStudentId(int StudentId)
        {
            try
            {
                return _dbContext.BookTransactions.Where(c => c.StudentId == StudentId).Select(x => x.BookTransactionId);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public IQueryable<int> GetAllAttendancesByStudentId(int StudentId)
        {
            try
            {
                return _dbContext.Attendances.Where(c => c.StudentId == StudentId).Select(x => x.AttendanceId);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public IQueryable<int> GetAllParentsByStudentId(int StudentId)
        {
            try
            {
                return _dbContext.Students.Where(c => c.StudentId == StudentId).SelectMany(c => c.Parents).Select(x => x.ParentId);
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
