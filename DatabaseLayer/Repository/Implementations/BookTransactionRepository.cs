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
    public class BookTransactionRepository : BaseRepository, IBookTransactionRepository
    {
        //private readonly DatabaseContext _dbContext;

        public BookTransactionRepository(DatabaseContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Add(BookTransactionModel entity)
        {
            try
            {
                entity.Book = _dbContext.Books.FirstOrDefault(x => x.BookId == entity.BookId);
                entity.Student = _dbContext.Students.FirstOrDefault(x => x.StudentId == entity.StudentId);

                _dbContext.Entry(entity).State = EntityState.Added;

            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public bool Update(BookTransactionModel entity)
        {
            try
            {
                entity.Book = _dbContext.Books.FirstOrDefault(x => x.BookId == entity.BookId);
                entity.Student = _dbContext.Students.FirstOrDefault(x => x.StudentId == entity.StudentId);

                var currentEntity = _dbContext.Set<BookTransactionModel>().AsQueryable().FirstOrDefault(x => x.BookTransactionId == entity.BookTransactionId);
                if (currentEntity == null)
                {
                    return false;
                }

                currentEntity.IssueDate = entity.IssueDate;
                currentEntity.ReturnDate = entity.ReturnDate;
                currentEntity.StudentId = entity.StudentId;
                currentEntity.Student = entity.Student;
                currentEntity.BookId = entity.BookId;
                currentEntity.Book = entity.Book;

                return true;
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public void Remove(BookTransactionModel entity)
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

        public bool Exists(Expression<Func<BookTransactionModel, bool>> expression)
        {
            try
            {
                var result = _dbContext.Set<BookTransactionModel>().AsQueryable().FirstOrDefault(expression);
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

        public IQueryable<BookTransactionModel> FindBookTransaction(Expression<Func<BookTransactionModel, bool>> expression)
        {
            try
            {
                return _dbContext.Set<BookTransactionModel>().AsQueryable().Where(expression);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public IQueryable<BookTransactionModel> GetAllBookTransactions()
        {
            try
            {
                return _dbContext.Set<BookTransactionModel>().AsQueryable();
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public BookTransactionModel GetSingleOrDefaultBookTransaction(Expression<Func<BookTransactionModel, bool>> expression)
        {
            try
            {
                return _dbContext.Set<BookTransactionModel>().AsQueryable().FirstOrDefault(expression);
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
