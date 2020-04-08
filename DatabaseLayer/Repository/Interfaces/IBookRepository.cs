using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Repository.Interfaces
{
    public interface IBookRepository
    {
        void Add(BookModel entity);
        bool Update(BookModel entity);
        void Remove(BookModel entity);
        bool Exists(Expression<Func<BookModel, bool>> expression);
        IQueryable<BookModel> FindBook(Expression<Func<BookModel, bool>> expression);
        IQueryable<BookModel> GetAllBooks();
        BookModel GetSingleOrDefaultBook(Expression<Func<BookModel, bool>> expression);
        IQueryable<int> GetAllBookTransactionsByBookId(int BookId);
    }
}