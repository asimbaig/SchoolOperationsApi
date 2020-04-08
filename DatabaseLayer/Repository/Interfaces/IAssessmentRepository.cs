using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Repository.Interfaces
{
    public interface IAssessmentRepository 
    {
        void Add(AssessmentModel entity);
        bool Update(AssessmentModel entity);
        void Remove(AssessmentModel entity);
        bool Exists(Expression<Func<AssessmentModel, bool>> expression);
        IQueryable<AssessmentModel> FindAssessment(Expression<Func<AssessmentModel, bool>> expression);
        IQueryable<AssessmentModel> GetAllAssessments();
        AssessmentModel GetSingleOrDefaultAssessment(Expression<Func<AssessmentModel, bool>> expression);
    }
}
