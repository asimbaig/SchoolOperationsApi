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
    public class BookRepository : BaseRepository, IBookRepository
    {
        public BookRepository(DatabaseContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Add(BookModel entity)
        {
            try
            {
                entity.Subject = _dbContext.Subjects.FirstOrDefault(x => x.SubjectId == entity.SubjectId);

                _dbContext.Entry(entity).State = EntityState.Added;

            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public bool Update(BookModel entity)
        {
            try
            {
                entity.Subject = _dbContext.Subjects.FirstOrDefault(x => x.SubjectId == entity.SubjectId);

                var currentEntity = _dbContext.Set<BookModel>().AsQueryable().FirstOrDefault(x => x.BookId == entity.BookId);
                if (currentEntity == null)
                {
                    return false;
                }
                currentEntity.BookName = entity.BookName;
                currentEntity.SerialNumber = entity.SerialNumber;
                currentEntity.SubjectId = entity.SubjectId;
                currentEntity.Subject = entity.Subject;

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

        public void Remove(BookModel entity)
        {
            try
            {
                _dbContext.Entry(entity).State = EntityState.Deleted;
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public bool Exists(Expression<Func<BookModel, bool>> expression)
        {
            try
            {
                var result = _dbContext.Set<BookModel>().AsQueryable().FirstOrDefault(expression);
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

        public IQueryable<BookModel> FindBook(Expression<Func<BookModel, bool>> expression)
        {
            try
            {
                return _dbContext.Set<BookModel>().AsQueryable().Where(expression);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public IQueryable<BookDTO> GetAllBooks()
        {
            try
            {
                //return _dbContext.Set<BookModel>().AsQueryable();
                //return _dbContext.Set<ParentModel>().AsQueryable();
                var LQuery = (from bks in _dbContext.Books
                              join
                              sub in _dbContext.Subjects on bks.SubjectId  equals sub.SubjectId
                              join
                              imgfilurl in _dbContext.ImageFileUrls on bks.ImageFileUrl.ImageFileUrlId equals imgfilurl.ImageFileUrlId
                              select new DTOs.BookDTO
                              {
                                  BookId = bks.BookId,
                                  BookName = bks.BookName,
                                  _ImageFileUrl = imgfilurl.Url,
                                  SubjectId = sub.SubjectId,
                                  _SubjectName = sub.SubjectName,
                                  _BookTransactions = bks.BookTransactions.Select(x =>"Issue: " + x.IssueDate + ", Return: " + x.ReturnDate).ToList()
                              }).AsQueryable();
                return LQuery;
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public BookModel GetSingleOrDefaultBook(Expression<Func<BookModel, bool>> expression)
        {
            try
            {
                return _dbContext.Set<BookModel>().AsQueryable().FirstOrDefault(expression);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public IQueryable<int> GetAllBookTransactionsByBookId(int BookId)
        {
            try
            {
                return _dbContext.BookTransactions.Where(c => c.BookId == BookId).Select(x => x.BookTransactionId);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }
    }
}
