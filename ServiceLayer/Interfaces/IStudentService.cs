using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IStudentService
    {
        Task<int> AddStudentAsync(StudentDTO model);
        Task<StudentDTO> UpdateStudentAsync(StudentDTO model);
        Task<int> RemoveStudentAsync(int StudentId);
        Task<List<StudentDTO>> GetAllStudent();
        Task<StudentDTO> SearchSingleStudentByNameAsync(string term);
        bool IsStudentExistsById(int StudentId);
        List<StudentDTO> SearchStudentsByNameAsync(string term);
        Task<StudentDTO> SearchSingleStudentByIdAsync(int Id);
    }
}
