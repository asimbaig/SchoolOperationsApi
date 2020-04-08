using DatabaseLayer.Models;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface ISchoolService
    {
        Task<int> AddSchoolAsync(SchoolDTO model);
        Task<SchoolDTO> UpdateSchoolAsync(SchoolDTO model);
        Task<int> RemoveSchoolAsync(int SchoolId);
        Task<List<SchoolDTO>> GetAllSchool();
        Task<SchoolDTO> SearchSingleSchoolByNameAsync(string term);
        bool IsSchoolExistsById(int SchoolId);
        List<SchoolDTO> SearchSchoolsByNameAsync(string term);
        Task<SchoolDTO> SearchSingleSchoolByIdAsync(int Id);
    }
}
