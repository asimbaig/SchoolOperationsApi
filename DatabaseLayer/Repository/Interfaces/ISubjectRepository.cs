using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Repository.Interfaces
{
    public interface ISubjectRepository 
    {
        void Add(SubjectModel entity);
        bool Update(SubjectModel entity);
        void Remove(SubjectModel entity);
        bool Exists(Expression<Func<SubjectModel, bool>> expression);
        IQueryable<SubjectModel> FindSubject(Expression<Func<SubjectModel, bool>> expression);
        IQueryable<SubjectModel> GetAllSubjects();
        SubjectModel GetSingleOrDefaultSubject(Expression<Func<SubjectModel, bool>> expression);
        IQueryable<int> GetAllStandardsBySubjectId(int SubjectId);
        IQueryable<int> GetAllBooksBySubjectId(int SubjectId);
        IQueryable<int> GetAllTeachersBySubjectId(int SubjectId);
    }
}
