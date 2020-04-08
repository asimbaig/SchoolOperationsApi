using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IStandardService
    {
        Task<int> AddStandardAsync(StandardDTO model);
        Task<StandardDTO> UpdateStandardAsync(StandardDTO model);
        Task<int> RemoveStandardAsync(int StandardId);
        Task<List<StandardDTO>> GetAllStandard();
        Task<StandardDTO> SearchSingleStandardByNameAsync(string term);
        bool IsStandardExistsById(int StandardId);
        List<StandardDTO> SearchStandardsByNameAsync(string term);
        Task<StandardDTO> SearchSingleStandardByIdAsync(int Id);
    }
}
