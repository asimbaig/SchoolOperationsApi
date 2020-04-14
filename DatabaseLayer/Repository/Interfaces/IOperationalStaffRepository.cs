using DatabaseLayer.Models;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Repository.Interfaces
{
    public interface IOperationalStaffRepository
    {
        void Add(OperationalStaffModel entity);
        bool Update(OperationalStaffModel entity);
        void Remove(OperationalStaffModel entity);
        bool Exists(Expression<Func<OperationalStaffModel, bool>> expression);
        IQueryable<OperationalStaffModel> FindOperationalStaff(Expression<Func<OperationalStaffModel, bool>> expression);
        IQueryable<OperationalStaffDTO> GetAllOperationalStaffs();
        OperationalStaffModel GetSingleOrDefaultOperationalStaff(Expression<Func<OperationalStaffModel, bool>> expression);
    }
}
