using DatabaseLayer.Context;
using DatabaseLayer.Models;
using DatabaseLayer.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Repository.Implementations
{
    public class EventRepository : BaseRepository, IEventRepository
    {
        //private readonly DatabaseContext _dbContext;

        public EventRepository(DatabaseContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Add(EventModel entity)
        {
            try
            {
                _dbContext.Entry(entity).State = EntityState.Added;

            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public bool Update(EventModel entity)
        {
            try
            {
                var currentEntity = _dbContext.Set<EventModel>().AsQueryable().FirstOrDefault(x => x.EventId == entity.EventId);
                if (currentEntity == null)
                {
                    return false;
                }

                currentEntity.EventName = entity.EventName;
                currentEntity.EventDate = entity.EventDate;
                if (currentEntity.ImageFileUrl != null)
                {
                    currentEntity.ImageFileUrl = entity.ImageFileUrl;
                }
                currentEntity.Location = entity.Location;

                return true;
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public void Remove(EventModel entity)
        {
            try
            {
                _dbContext.Entry(entity).State = EntityState.Deleted;

                //return await (_dbContext.SaveChangesAsync());
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public bool Exists(Expression<Func<EventModel, bool>> expression)
        {
            try
            {
                var result = _dbContext.Set<EventModel>().AsQueryable().FirstOrDefault(expression);
                if (result == null)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public IQueryable<EventModel> FindEvent(Expression<Func<EventModel, bool>> expression)
        {
            try
            {
                return _dbContext.Set<EventModel>().AsQueryable().Where(expression);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public IQueryable<EventModel> GetAllEvents()
        {
            try
            {
                return _dbContext.Set<EventModel>().AsQueryable();
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public EventModel GetSingleOrDefaultEvent(Expression<Func<EventModel, bool>> expression)
        {
            try
            {
                return _dbContext.Set<EventModel>().AsQueryable().FirstOrDefault(expression);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public IQueryable<int> GetAllStudentsByEventId(int eventId)
        {
            try
            {
                return _dbContext.Events.Where(c => c.EventId == eventId).SelectMany(c => c.Students).Select(x=>x.StudentId);
             

            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }


        //private async void LogException(Exception ex)
        //{

        //    ExceptionLogger exModel = new ExceptionLogger
        //    {
        //        ExceptionMessage = ex.Message,
        //        SourceName = ex.Source,
        //        ExceptionStackTrace = ex.StackTrace,
        //        LogTime = DateTime.Now
        //    };

        //    try
        //    {
        //        _dbContext.Entry(exModel).State = exModel.Id == 0 ? EntityState.Added : EntityState.Modified;

        //        await (_dbContext.SaveChangesAsync());
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}
    }
}
