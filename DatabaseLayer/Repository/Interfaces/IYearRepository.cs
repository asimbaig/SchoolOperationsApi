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
    public interface IYearRepository 
    {
        void Add(YearModel entity);
        bool Update(YearModel entity);
        void Remove(YearModel entity);
        bool Exists(Expression<Func<YearModel, bool>> expression);
        IQueryable<YearModel> FindYear(Expression<Func<YearModel, bool>> expression);
        IQueryable<YearDTO> GetAllYears();
        YearModel GetSingleOrDefaultYear(Expression<Func<YearModel, bool>> expression);
        IQueryable<int> GetAllStandardsByYearId(int YearId);
    }
}
