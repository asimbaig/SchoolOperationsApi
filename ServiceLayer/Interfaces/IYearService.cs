using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IYearService
    {
        Task<int> AddYearAsync(YearDTO model);
        Task<YearDTO> UpdateYearAsync(YearDTO model);
        Task<int> RemoveYearAsync(int YearId);
        Task<List<YearDTO>> GetAllYear();
        Task<YearDTO> SearchSingleYearByNameAsync(string term);
        bool IsYearExistsById(int YearId);
        List<YearDTO> SearchYearsByNameAsync(string term);
        Task<YearDTO> SearchSingleYearByIdAsync(int Id);
    }
}
