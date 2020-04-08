using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Repository.Interfaces
{
    public interface IHomeworkRepository 
    {
        void Add(HomeworkModel entity);
        bool Update(HomeworkModel entity);
        void Remove(HomeworkModel entity);
        bool Exists(Expression<Func<HomeworkModel, bool>> expression);
        IQueryable<HomeworkModel> FindHomework(Expression<Func<HomeworkModel, bool>> expression);
        IQueryable<HomeworkModel> GetAllHomeworks();
        HomeworkModel GetSingleOrDefaultHomework(Expression<Func<HomeworkModel, bool>> expression);
    }
}
