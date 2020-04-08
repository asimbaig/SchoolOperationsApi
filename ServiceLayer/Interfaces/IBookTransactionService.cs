using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IBookTransactionService
    {
        Task<int> AddBookTransactionAsync(BookTransactionDTO model);
        Task<BookTransactionDTO> UpdateBookTransactionAsync(BookTransactionDTO model);
        Task<int> RemoveBookTransactionAsync(int BookTransactionId);
        Task<List<BookTransactionDTO>> GetAllBookTransaction();
        //Task<BookTransactionDTO> SearchSingleBookTransactionByNameAsync(string term);
        bool IsBookTransactionExistsById(int BookTransactionId);
        //List<BookTransactionDTO> SearchBookTransactionsByNameAsync(string term);
        Task<BookTransactionDTO> SearchSingleBookTransactionByIdAsync(int Id);
    }
}
