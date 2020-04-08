using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Repository.Interfaces
{
    public interface IStudentRepository 
    {
        void Add(StudentModel entity);
        bool Update(StudentModel entity);
        void Remove(StudentModel entity);
        bool Exists(Expression<Func<StudentModel, bool>> expression);
        IQueryable<StudentModel> FindStudent(Expression<Func<StudentModel, bool>> expression);
        IQueryable<StudentModel> GetAllStudents();
        StudentModel GetSingleOrDefaultStudent(Expression<Func<StudentModel, bool>> expression);
        IQueryable<int> GetAllEventsByStudentId(int StudentId);
        IQueryable<int> GetAllBookTransactionsByStudentId(int StudentId);
        IQueryable<int> GetAllAttendancesByStudentId(int StudentId);
        IQueryable<int> GetAllParentsByStudentId(int StudentId);
    }
}
