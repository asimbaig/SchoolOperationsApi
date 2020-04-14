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
    public class StandardRepository : BaseRepository, IStandardRepository
    {
        //private readonly DatabaseContext _dbContext;

        public StandardRepository(DatabaseContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Add(StandardModel entity)
        {
            try
            {
                entity.School = _dbContext.Schools.FirstOrDefault(x => x.SchoolId == entity.SchoolId);

                entity.Year = _dbContext.Years.FirstOrDefault(x => x.YearId == entity.YearId);

                _dbContext.Entry(entity).State = EntityState.Added;

            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public bool Update(StandardModel entity)
        {
            try
            {
                entity.School = _dbContext.Schools.FirstOrDefault(x => x.SchoolId == entity.SchoolId);

                entity.Year = _dbContext.Years.FirstOrDefault(x => x.YearId == entity.YearId);

                var currentEntity = _dbContext.Set<StandardModel>().AsQueryable().FirstOrDefault(x => x.StandardId == entity.StandardId);
                if (currentEntity == null)
                {
                    return false;
                }

                currentEntity.StandardName = entity.StandardName;
                currentEntity.SchoolId = entity.SchoolId;
                currentEntity.School = entity.School;
                currentEntity.YearId = entity.YearId;
                currentEntity.Year = entity.Year;

                return true;
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public void Remove(StandardModel entity)
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

        public bool Exists(Expression<Func<StandardModel, bool>> expression)
        {
            try
            {
                var result = _dbContext.Set<StandardModel>().AsQueryable().FirstOrDefault(expression);
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

        public IQueryable<StandardModel> FindStandard(Expression<Func<StandardModel, bool>> expression)
        {
            try
            {
                return _dbContext.Set<StandardModel>().AsQueryable().Where(expression);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public IQueryable<StandardDTO> GetAllStandards()
        {
            try
            {
                //return _dbContext.Set<StandardModel>().AsQueryable();
                var LQuery = (from std in _dbContext.Standards
                              join
                              sch in _dbContext.Schools on std.SchoolId equals sch.SchoolId
                              join
                              yrs in _dbContext.Years on std.YearId equals yrs.YearId
                              select new DTOs.StandardDTO
                              {
                                  StandardId = std.StandardId,
                                  StandardName = std.StandardName,
                                  SchoolId = sch.SchoolId,
                                  _NameSchool = sch.SchoolName,
                                  YearId = yrs.YearId,
                                  _NameYear = yrs.year,
                                  _NameAssessments = std.Assessments.Select(x => x.AssessmentName).ToList(),
                                  _NameHomeworks = std.Homeworks.Select(x => x.HomeworkName).ToList(),
                                  _NameStudents = std.Students.Select(x => x.St_Name).ToList(),
                                  _NameSubjects = std.Subjects.Select(x => x.SubjectName).ToList(),
                                  _NameTeachers = std.Teachers.Select(x => x.TeacherName).ToList()
                              }).AsQueryable();
                return LQuery;
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public StandardModel GetSingleOrDefaultStandard(Expression<Func<StandardModel, bool>> expression)
        {
            try
            {
                return _dbContext.Set<StandardModel>().AsQueryable().FirstOrDefault(expression);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public IQueryable<int> GetAllSubjectsByStandardId(int StandardId)
        {
            try
            {
                return _dbContext.Standards.Where(c => c.StandardId == StandardId).SelectMany(c => c.Subjects).Select(x => x.SubjectId);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public IQueryable<int> GetAllAssessmentsByStandardId(int StandardId)
        {
            try
            {
                return _dbContext.Assessments.Where(c => c.StandardId == StandardId).Select(x => x.AssessmentId);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public IQueryable<int> GetAllHomeworksByStandardId(int StandardId)
        {
            try
            {
                return _dbContext.Homeworks.Where(c => c.StandardId == StandardId).Select(x => x.HomeworkId);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public IQueryable<int> GetAllStudentsByStandardId(int StandardId)
        {
            try
            {
                return _dbContext.Standards.Where(c => c.StandardId == StandardId).SelectMany(c => c.Students).Select(x => x.StudentId);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public IQueryable<int> GetAllTeachersByStandardId(int StandardId)
        {
            try
            {
                return _dbContext.Standards.Where(c => c.StandardId == StandardId).SelectMany(c => c.Teachers).Select(x => x.TeacherId);
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
