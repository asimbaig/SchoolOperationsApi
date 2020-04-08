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
    public class SubjectRepository : BaseRepository, ISubjectRepository
    {
        //private readonly DatabaseContext _dbContext;

        public SubjectRepository(DatabaseContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Add(SubjectModel entity)
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

        public bool Update(SubjectModel entity)
        {
            try
            {
                var currentEntity = _dbContext.Set<SubjectModel>().AsQueryable().FirstOrDefault(x => x.SubjectId == entity.SubjectId);
                if (currentEntity == null)
                {
                    return false;
                }

                currentEntity.SubjectName = entity.SubjectName;

                return true;
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public void Remove(SubjectModel entity)
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

        public bool Exists(Expression<Func<SubjectModel, bool>> expression)
        {
            try
            {
                var result = _dbContext.Set<SubjectModel>().AsQueryable().FirstOrDefault(expression);
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

        public IQueryable<SubjectModel> FindSubject(Expression<Func<SubjectModel, bool>> expression)
        {
            try
            {
                return _dbContext.Set<SubjectModel>().AsQueryable().Where(expression);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public IQueryable<SubjectModel> GetAllSubjects()
        {
            try
            {
                return _dbContext.Set<SubjectModel>().AsQueryable();
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public SubjectModel GetSingleOrDefaultSubject(Expression<Func<SubjectModel, bool>> expression)
        {
            try
            {
                return _dbContext.Set<SubjectModel>().AsQueryable().FirstOrDefault(expression);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public IQueryable<int> GetAllStandardsBySubjectId(int SubjectId)
        {
            try
            {
                return _dbContext.Subjects.Where(c => c.SubjectId == SubjectId).SelectMany(c => c.Standards).Select(x => x.StandardId);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public IQueryable<int> GetAllBooksBySubjectId(int SubjectId)
        {
            try
            {
                return _dbContext.Books.Where(c => c.SubjectId == SubjectId).Select(x => x.BookId);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public IQueryable<int> GetAllTeachersBySubjectId(int SubjectId)
        {
            try
            {
                return _dbContext.Subjects.Where(c => c.SubjectId == SubjectId).SelectMany(c => c.Teachers).Select(x => x.TeacherId);
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
