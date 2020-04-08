using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IHomeworkService
    {
        Task<int> AddHomeworkAsync(HomeworkDTO model);
        Task<HomeworkDTO> UpdateHomeworkAsync(HomeworkDTO model);
        Task<int> RemoveHomeworkAsync(int HomeworkId);
        Task<List<HomeworkDTO>> GetAllHomework();
        Task<HomeworkDTO> SearchSingleHomeworkByNameAsync(string term);
        bool IsHomeworkExistsById(int HomeworkId);
        List<HomeworkDTO> SearchHomeworksByNameAsync(string term);
        Task<HomeworkDTO> SearchSingleHomeworkByIdAsync(int Id);
    }

}