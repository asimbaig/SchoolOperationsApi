using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Repository.Interfaces
{
    public interface IGenericRepository
    {
        Task<IEnumerable<T>> GetAllAsync<T>() where T : class;
        Task<IEnumerable<T>> FindAsync<T>(Expression<Func<T, bool>> expression) where T : class;
        Task<T> SingleOrDefaultAsync<T>(Expression<Func<T, bool>> expression) where T : class;
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Remove<T>(T entity) where T : class;

        bool Exists<T>(T entity) where T : class;

        //IList<T> GetAll<T>(params Expression<Func<T, object>>[] navigationProperties) where T : class;
        //IList<T> GetList<T>(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties) where T : class;
        //T GetSingle<T>(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties) where T : class;
        //void AddEntity<T>(params T[] items) where T : class;
        //void UpdateEntity<T>(params T[] items) where T : class;
        //void RemoveEntity<T>(params T[] items) where T : class;

    }
}
