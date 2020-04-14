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
    public interface IEventRepository 
    {
        void Add(EventModel entity);
        bool Update(EventModel entity);
        void Remove(EventModel entity);
        bool Exists(Expression<Func<EventModel, bool>> expression);
        IQueryable<EventModel> FindEvent(Expression<Func<EventModel, bool>> expression);
        IQueryable<EventDTO> GetAllEvents();
        EventModel GetSingleOrDefaultEvent(Expression<Func<EventModel, bool>> expression);
        IQueryable<int> GetAllStudentsByEventId(int EventId);
    }
}
