using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Repository.Interfaces
{
    public interface IParentRepository 
    {
        void Add(ParentModel entity);
        bool Update(ParentModel entity);
        void Remove(ParentModel entity);
        bool Exists(Expression<Func<ParentModel, bool>> expression);
        IQueryable<ParentModel> FindParent(Expression<Func<ParentModel, bool>> expression);
        IQueryable<ParentModel> GetAllParents();
        ParentModel GetSingleOrDefaultParent(Expression<Func<ParentModel, bool>> expression);
        IQueryable<int> GetAllStudentsByParentId(int ParentId);
    }
}
