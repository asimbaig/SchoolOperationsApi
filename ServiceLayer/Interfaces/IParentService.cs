using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IParentService
    {
        Task<int> AddParentAsync(ParentDTO model);
        Task<ParentDTO> UpdateParentAsync(ParentDTO model);
        Task<int> RemoveParentAsync(int ParentId);
        Task<List<ParentDTO>> GetAllParent();
        Task<ParentDTO> SearchSingleParentByNameAsync(string term);
        bool IsParentExistsById(int ParentId);
        List<ParentDTO> SearchParentsByNameAsync(string term);
        Task<ParentDTO> SearchSingleParentByIdAsync(int Id);
    }
}
