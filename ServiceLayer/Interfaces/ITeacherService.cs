using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface ITeacherService
    {
        Task<int> AddTeacherAsync(TeacherDTO model);
        Task<TeacherDTO> UpdateTeacherAsync(TeacherDTO model);
        Task<int> RemoveTeacherAsync(int TeacherId);
        Task<List<TeacherDTO>> GetAllTeacher();
        Task<TeacherDTO> SearchSingleTeacherByNameAsync(string term);
        bool IsTeacherExistsById(int TeacherId);
        List<TeacherDTO> SearchTeachersByNameAsync(string term);
        Task<TeacherDTO> SearchSingleTeacherByIdAsync(int Id);
    }
}
