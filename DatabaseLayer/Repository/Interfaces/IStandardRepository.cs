using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Repository.Interfaces
{
    public interface IStandardRepository 
    {
        void Add(StandardModel entity);
        bool Update(StandardModel entity);
        void Remove(StandardModel entity);
        bool Exists(Expression<Func<StandardModel, bool>> expression);
        IQueryable<StandardModel> FindStandard(Expression<Func<StandardModel, bool>> expression);
        IQueryable<StandardModel> GetAllStandards();
        StandardModel GetSingleOrDefaultStandard(Expression<Func<StandardModel, bool>> expression);
        IQueryable<int> GetAllSubjectsByStandardId(int StandardId);
        IQueryable<int> GetAllAssessmentsByStandardId(int StandardId);
        IQueryable<int> GetAllHomeworksByStandardId(int StandardId);
        IQueryable<int> GetAllStudentsByStandardId(int StandardId);
        IQueryable<int> GetAllTeachersByStandardId(int StandardId);
    }
}
