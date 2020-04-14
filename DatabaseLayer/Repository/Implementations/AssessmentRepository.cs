using DatabaseLayer.Context;
using DatabaseLayer.Models;
using DatabaseLayer.Repository.Interfaces;
using DTOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Repository.Implementations
{
    public class AssessmentRepository : BaseRepository, IAssessmentRepository
    {
        public AssessmentRepository(DatabaseContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Add(AssessmentModel entity)
        {
            try
            {
                entity.Standard =  _dbContext.Standards.FirstOrDefault(x=>x.StandardId==entity.StandardId);

                _dbContext.Entry(entity).State = EntityState.Added;
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public bool Update(AssessmentModel entity)
        {
            try
            {
                entity.Standard = _dbContext.Standards.FirstOrDefault(x => x.StandardId == entity.StandardId);

                var currentEntity = _dbContext.Set<AssessmentModel>().AsQueryable().FirstOrDefault(x => x.AssessmentId == entity.AssessmentId);
                if (currentEntity == null)
                {
                    return false;
                }
                currentEntity.AssessmentName = entity.AssessmentName;
                currentEntity.AssessmentDate = entity.AssessmentDate;
                
                currentEntity.StandardId = entity.StandardId;
                currentEntity.Standard = entity.Standard;

                if (entity.ImageFileUrl!=null)
                {
                    currentEntity.ImageFileUrl.Url = entity.ImageFileUrl.Url;
                }

                    return true;
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public void Remove(AssessmentModel entity)
        {
            try
            {
                _dbContext.Entry(entity).State = EntityState.Deleted;
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public bool Exists(Expression<Func<AssessmentModel, bool>> expression)
        {
            try
            {
                var result = _dbContext.Set<AssessmentModel>().AsQueryable().FirstOrDefault(expression);
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

        public IQueryable<AssessmentModel> FindAssessment(Expression<Func<AssessmentModel, bool>> expression)
        {
            try
            {
                return _dbContext.Set<AssessmentModel>().AsQueryable().Where(expression);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public IQueryable<AssessmentDTO> GetAllAssessments()
        {
            try
            {
                //return _dbContext.Set<AssessmentModel>().AsQueryable();
                var LQuery =   (from ass in _dbContext.Assessments
                              join 
                              stand in _dbContext.Standards on ass.StandardId equals stand.StandardId
                              join
                              imgfilurl in _dbContext.ImageFileUrls on ass.ImageFileUrl.ImageFileUrlId equals imgfilurl.ImageFileUrlId
                              select new DTOs.AssessmentDTO
                              {
                                  AssessmentId = ass.AssessmentId,
                                  AssessmentName = ass.AssessmentName,
                                  AssessmentDate = ass.AssessmentDate,
                                  _ImageFileUrl = imgfilurl.Url,
                                  StandardId = stand.StandardId,
                                  _StandardName = stand.StandardName
                              }).AsQueryable();
                return LQuery;


            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public AssessmentModel GetSingleOrDefaultAssessment(Expression<Func<AssessmentModel, bool>> expression)
        {
            try
            {
                return _dbContext.Set<AssessmentModel>().AsQueryable().FirstOrDefault(expression);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }
    }
}
