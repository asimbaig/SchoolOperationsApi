using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IBookService
    {
        Task<int> AddBookAsync(BookDTO model);
        Task<BookDTO> UpdateBookAsync(BookDTO model);
        Task<int> RemoveBookAsync(int BookId);
        Task<List<BookDTO>> GetAllBook();
        bool IsBookExistsById(int BookId);
        Task<BookDTO> SearchSingleBookByNameAsync(string term);
        List<BookDTO> SearchBooksByBookNameAsync(string term);
        Task<BookDTO> SearchSingleBookByIdAsync(int Id);
    }
}
