using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface ISubjectService
    {
        Task<int> AddSubjectAsync(SubjectDTO model);
        Task<SubjectDTO> UpdateSubjectAsync(SubjectDTO model);
        Task<int> RemoveSubjectAsync(int SubjectId);
        Task<List<SubjectDTO>> GetAllSubject();
        Task<SubjectDTO> SearchSingleSubjectByNameAsync(string term);
        bool IsSubjectExistsById(int SubjectId);
        List<SubjectDTO> SearchSubjectsByNameAsync(string term);
        Task<SubjectDTO> SearchSingleSubjectByIdAsync(int Id);
    }
}
