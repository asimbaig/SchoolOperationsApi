using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Repository.Interfaces
{
    public interface IAttendanceRepository 
    {
        void Add(AttendanceModel entity);
        bool Update(AttendanceModel entity);
        void Remove(AttendanceModel entity);
        bool Exists(Expression<Func<AttendanceModel, bool>> expression);
        IQueryable<AttendanceModel> FindAttendance(Expression<Func<AttendanceModel, bool>> expression);
        IQueryable<AttendanceModel> GetAllAttendances();
        AttendanceModel GetSingleOrDefaultAttendance(Expression<Func<AttendanceModel, bool>> expression);
    }
}
