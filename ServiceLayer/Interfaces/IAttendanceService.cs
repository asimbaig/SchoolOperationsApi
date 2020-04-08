using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IAttendanceService
    {
        Task<int> AddAttendanceAsync(AttendanceDTO model);
        Task<AttendanceDTO> UpdateAttendanceAsync(AttendanceDTO model);
        Task<int> RemoveAttendanceAsync(int AttendanceId);
        Task<List<AttendanceDTO>> GetAllAttendance();
        Task<AttendanceDTO> SearchSingleAttendanceByStatusAsync(bool status);
        bool IsAttendanceExistsById(int AttendanceId);
        List<AttendanceDTO> SearchAttendancesByStatusAsync(bool status);
        Task<AttendanceDTO> SearchSingleAttendanceByIdAsync(int Id);
    }
}
