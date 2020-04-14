using DatabaseLayer.Models;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Repository.Interfaces
{
    public interface IBookTransactionRepository
    {
        void Add(BookTransactionModel entity);
        bool Update(BookTransactionModel entity);
        void Remove(BookTransactionModel entity);
        bool Exists(Expression<Func<BookTransactionModel, bool>> expression);
        IQueryable<BookTransactionModel> FindBookTransaction(Expression<Func<BookTransactionModel, bool>> expression);
        IQueryable<BookTransactionDTO> GetAllBookTransactions();
        BookTransactionModel GetSingleOrDefaultBookTransaction(Expression<Func<BookTransactionModel, bool>> expression);
    }
}
