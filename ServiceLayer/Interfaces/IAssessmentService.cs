using DatabaseLayer.Models;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IAssessmentService
    {
        Task<int> AddAssessmentAsync(AssessmentDTO model);
        Task<AssessmentDTO> UpdateAssessmentAsync(AssessmentDTO model);
        Task<int> RemoveAssessmentAsync(int AssessmentId);
        Task<List<AssessmentDTO>> GetAllAssessment();
        Task<AssessmentDTO> SearchSingleAssessmentByNameAsync(string term);
        bool IsAssessmentExistsById(int AssessmentId);
        List<AssessmentDTO> SearchAssessmentsByNameAsync(string term);
        Task<AssessmentDTO> SearchSingleAssessmentByIdAsync(int Id);
    }
}
