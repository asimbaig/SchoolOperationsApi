using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Repository.Interfaces
{
    public interface ISchoolRepository
    {
        void Add(SchoolModel entity);
        bool Update(SchoolModel entity);
        void Remove(SchoolModel entity);
        bool Exists(Expression<Func<SchoolModel, bool>> expression);
        IQueryable<SchoolModel> FindSchool(Expression<Func<SchoolModel, bool>> expression);
        IQueryable<SchoolModel> GetAllSchools();
        SchoolModel GetSingleOrDefaultSchool(Expression<Func<SchoolModel, bool>> expression);
        IQueryable<int> GetAllStandardsBySchoolId(int SchoolId);
        IQueryable<int> GetAllOperationalStaffsBySchoolId(int SchoolId);
    }
}
