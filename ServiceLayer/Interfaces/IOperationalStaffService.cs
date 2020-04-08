using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IOperationalStaffService
    {
        Task<int> AddOperationalStaffAsync(OperationalStaffDTO model);
        Task<OperationalStaffDTO> UpdateOperationalStaffAsync(OperationalStaffDTO model);
        Task<int> RemoveOperationalStaffAsync(int OperationalStaffId);
        Task<List<OperationalStaffDTO>> GetAllOperationalStaff();
        Task<OperationalStaffDTO> SearchSingleOperationalStaffByNameAsync(string term);
        bool IsOperationalStaffExistsById(int OperationalStaffId);
        List<OperationalStaffDTO> SearchOperationalStaffsByNameAsync(string term);
        Task<OperationalStaffDTO> SearchSingleOperationalStaffByIdAsync(int Id);
    }
}
