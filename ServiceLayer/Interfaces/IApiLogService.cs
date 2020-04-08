using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IApiLogService
    {
        Task<int> AddApiLogAsync(ApiLogDTO modelDTO);
        Task<List<ApiLogDTO>> GetAllApiLog();
    }
}
