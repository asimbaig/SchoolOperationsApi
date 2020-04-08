using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Repository.Interfaces
{
    public interface ITeacherRepository 
    {
        void Add(TeacherModel entity);
        bool Update(TeacherModel entity);
        void Remove(TeacherModel entity);
        bool Exists(Expression<Func<TeacherModel, bool>> expression);
        IQueryable<TeacherModel> FindTeacher(Expression<Func<TeacherModel, bool>> expression);
        IQueryable<TeacherModel> GetAllTeachers();
        TeacherModel GetSingleOrDefaultTeacher(Expression<Func<TeacherModel, bool>> expression);
        IQueryable<int> GetAllStandardsByTeacherId(int TeacherId);
        IQueryable<int> GetAllSubjectsByTeacherId(int TeacherId);
    }
}
