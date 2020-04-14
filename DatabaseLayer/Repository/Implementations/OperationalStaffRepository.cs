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
    public class OperationalStaffRepository : BaseRepository, IOperationalStaffRepository
    {
        public OperationalStaffRepository(DatabaseContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Add(OperationalStaffModel entity)
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

        public bool Update(OperationalStaffModel entity)
        {
            try
            {
                //entity.School = _dbContext.Set<SchoolModel>().AsQueryable().FirstOrDefault(x => x.SchoolId == entity.SchoolId);
                var currentEntity = _dbContext.Set<OperationalStaffModel>().AsQueryable().FirstOrDefault(x => x.OpStaffId == entity.OpStaffId);
                if (currentEntity == null)
                {
                    return false;
                }

                currentEntity.OpStaffName = entity.OpStaffName;
                currentEntity.OpStaffAddress1 = entity.OpStaffAddress1;
                currentEntity.OpStaffAddress2 = entity.OpStaffAddress2;
                currentEntity.StartDate = entity.StartDate;
                currentEntity.OpStaffRole = entity.OpStaffRole;
                //currentEntity.OpStaffEmail = entity.OpStaffEmail;
                currentEntity.OpStaffPostCode = entity.OpStaffPostCode;
                currentEntity.OpStaffTelephone = entity.OpStaffTelephone;
                //currentEntity.School = entity.School;
                currentEntity.SchoolId = entity.SchoolId;



                if (entity.ImageFileUrl != null)
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

        public void Remove(OperationalStaffModel entity)
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

        public bool Exists(Expression<Func<OperationalStaffModel, bool>> expression)
        {
            try
            {
                var result = _dbContext.Set<OperationalStaffModel>().AsQueryable().FirstOrDefault(expression);
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

        public IQueryable<OperationalStaffModel> FindOperationalStaff(Expression<Func<OperationalStaffModel, bool>> expression)
        {
            try
            {
                return _dbContext.Set<OperationalStaffModel>().AsQueryable().Where(expression);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public IQueryable<OperationalStaffDTO> GetAllOperationalStaffs()
        {
            try
            {
                //return _dbContext.Set<OperationalStaffModel>().AsQueryable();
                var LQuery = (from ops in _dbContext.OperationalStaffs
                              join
                              sch in _dbContext.Schools on ops.SchoolId equals sch.SchoolId
                              join
                              imgfilurl in _dbContext.ImageFileUrls on ops.ImageFileUrl.ImageFileUrlId equals imgfilurl.ImageFileUrlId
                              select new DTOs.OperationalStaffDTO
                              {
                                  OpStaffAddress1 = ops.OpStaffAddress1,
                                  OpStaffAddress2 = ops.OpStaffAddress2,
                                  OpStaffEmail = ops.OpStaffEmail,
                                  OpStaffId = ops.OpStaffId,
                                  OpStaffName = ops.OpStaffName,
                                  OpStaffPostCode = ops.OpStaffPostCode,
                                  OpStaffRole = ops.OpStaffRole,
                                  OpStaffTelephone = ops.OpStaffTelephone,
                                  _ImageFileUrl = imgfilurl.Url,
                                  SchoolId = sch.SchoolId,
                                  _SchoolName = sch.SchoolName,
                                  StartDate = ops.StartDate
                              }).AsQueryable();
                return LQuery;
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        public OperationalStaffModel GetSingleOrDefaultOperationalStaff(Expression<Func<OperationalStaffModel, bool>> expression)
        {
            try
            {
                return _dbContext.Set<OperationalStaffModel>().AsQueryable().FirstOrDefault(expression);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }
    }
}
