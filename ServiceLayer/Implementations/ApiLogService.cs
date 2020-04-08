using AutoMapper;
using DatabaseLayer.Models;
using DatabaseLayer.UnitOfWork;
using DTOs;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Implementations
{
    public class ApiLogService : BaseService, IApiLogService
    {
        //private readonly IUnitOfWorkFactory unitOfWorkFactory;
        //private IMapper _Mapper_ToModel, _Mapper_ToDTO;

        public ApiLogService() : base()
        {
            SetAutoMapper_ApiLog();
        }

        //public ApiLogService(IUnitOfWorkFactory unitOfWorkFactory)
        //{
        //    this.unitOfWorkFactory = unitOfWorkFactory;
        //    MapperConfiguration _mapperConfig = new MapperConfiguration(cfg => {
        //        cfg.CreateMap<ApiLogDTO, ApiLog>();
        //    });
        //    _Mapper = _mapperConfig.CreateMapper();

        //    MapperConfiguration _mapperConfig_ToDTO = new MapperConfiguration(cfg => {
        //        cfg.CreateMap<ApiLog, ApiLogDTO>();
        //    });
        //    _Mapper_ToDTO = _mapperConfig_ToDTO.CreateMapper();
        //}

        //Add School (generic and async)
        public async Task<int> AddApiLogAsync(ApiLogDTO modelDTO)
        {
            try
            {
                ApiLog model = _Mapper_ToModel.Map<ApiLogDTO, ApiLog>(modelDTO);

                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    unitOfWork.ApiLogRepository.Add(model);
                    return await unitOfWork.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }

        }

        public async Task<List<ApiLogDTO>> GetAllApiLog()
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    var models = await unitOfWork.ApiLogRepository.GetAllAsync();
                    var temp = _Mapper_ToDTO.Map<List<ApiLog>, List<ApiLogDTO>>(models);
                    return temp;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }
        ////Add School/Schools (generic & Async)
        //public async void AddNewSchool(params SchoolDTO[] modelDTOs)
        //{
        //    try
        //    {
        //        List<SchoolModel> models = _Mapper.Map<List<SchoolModel>>(modelDTOs);

        //        using (var unitOfWork = unitOfWorkFactory.Create())
        //        {
        //            unitOfWork.SchoolRepository.AddEntity(models);
        //            await unitOfWork.SaveChangesAsync();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogException(ex);
        //        throw ex;
        //    }
        //}

        ////Update School (generic and async)
        //public async Task<int> UpdateSchoolAsync(SchoolDTO modelDTO)
        //{
        //    try
        //    {
        //        SchoolModel model = _Mapper.Map<SchoolModel>(modelDTO);

        //        using (var unitOfWork = unitOfWorkFactory.Create())
        //        {
        //            unitOfWork.SchoolRepository.Update(model);
        //            await unitOfWork.SaveChangesAsync();
        //            return model.SchoolId;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogException(ex);
        //        throw ex;
        //    }
        //}

        ////Update School/Schools (generic & async)
        //public async void UpdateSchool(params SchoolDTO[] modelDTOs)
        //{
        //    try
        //    {
        //        List<SchoolModel> models = _Mapper.Map<List<SchoolModel>>(modelDTOs);

        //        using (var unitOfWork = unitOfWorkFactory.Create())
        //        {
        //            unitOfWork.SchoolRepository.UpdateEntity(models);
        //            await unitOfWork.SaveChangesAsync();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogException(ex);
        //        throw ex;
        //    }
        //}

        ////Remove School (generic and async)
        //public async Task<int> RemoveSchoolAsync(SchoolDTO modelDTO)
        //{
        //    try
        //    {
        //        SchoolModel model = _Mapper.Map<SchoolModel>(modelDTO);

        //        using (var unitOfWork = unitOfWorkFactory.Create())
        //        {
        //            unitOfWork.SchoolRepository.Remove(model);
        //            await unitOfWork.SaveChangesAsync();
        //            return model.SchoolId;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogException(ex);
        //        throw ex;
        //    }
        //}

        ////Remove School/Schools (generic & async)
        //public async void RemoveSchool(params SchoolDTO[] modelDTOs)
        //{
        //    try
        //    {
        //        List<SchoolModel> models = _Mapper.Map<List<SchoolModel>>(modelDTOs);

        //        using (var unitOfWork = unitOfWorkFactory.Create())
        //        {
        //            unitOfWork.SchoolRepository.RemoveEntity(models);
        //            await unitOfWork.SaveChangesAsync();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogException(ex);
        //        throw ex;
        //    }
        //}

        ////Get All Schools (generic and async)
        //public async Task<List<SchoolDTO>> GetAllSchoolAsync()
        //{
        //    try
        //    {
        //        using (var unitOfWork = unitOfWorkFactory.Create())
        //        {
        //            IEnumerable<SchoolModel> models = await unitOfWork.SchoolRepository.GetAllAsync<SchoolModel>();
        //            return _Mapper.Map<IEnumerable<SchoolDTO>>(models).ToList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogException(ex);
        //        throw ex;
        //    }
        //}

        ////Get all School (generic only)
        //public IList<SchoolDTO> GetAllSchool()
        //{
        //    try
        //    {
        //        using (var unitOfWork = unitOfWorkFactory.Create())
        //        {
        //            IList<SchoolModel> models = unitOfWork.SchoolRepository.GetAll<SchoolModel>();
        //            return _Mapper.Map<IEnumerable<SchoolDTO>>(models).ToList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogException(ex);
        //        throw ex;
        //    }
        //}

        ////Find Single School base on "term" (generic and async)
        //public async Task<SchoolDTO> SearchSingleSchoolAsync(string term)
        //{
        //    try
        //    {
        //        using (var unitOfWork = unitOfWorkFactory.Create())
        //        {
        //            SchoolModel model = await unitOfWork.SchoolRepository.SingleOrDefaultAsync<SchoolModel>(x => x.SchoolName.Contains(term));
        //            return _Mapper.Map<SchoolDTO>(model);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogException(ex);
        //        throw ex;
        //    }
        //}

        ////Find Single School base on "term" (generic only)
        //public SchoolDTO SearchSingleSchool(string schoolName)
        //{
        //    try
        //    {
        //        using (var unitOfWork = unitOfWorkFactory.Create())
        //        {
        //            SchoolModel model = unitOfWork.SchoolRepository.GetSingle<SchoolModel>(d => d.SchoolName.Equals(schoolName), d => d.Standards);
        //            return _Mapper.Map<SchoolDTO>(model);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogException(ex);
        //        throw ex;
        //    }
        //}

        ////Is School Exist (generic only)
        //public bool IsSchoolExists(SchoolDTO modelDTO)
        //{
        //    try
        //    {
        //        SchoolModel model = _Mapper.Map<SchoolModel>(modelDTO);

        //        using (var unitOfWork = unitOfWorkFactory.Create())
        //        {
        //            return unitOfWork.SchoolRepository.Exists(model);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogException(ex);
        //        throw ex;
        //    }
        //}

        ////Search Schools based on "term/string" (generic and async)
        //public async Task<List<SchoolDTO>> SearchSchoolsAsync(string term)
        //{
        //    try
        //    {
        //        using (var unitOfWork = unitOfWorkFactory.Create())
        //        {
        //            IEnumerable<SchoolModel> models = await unitOfWork.SchoolRepository.FindAsync<SchoolModel>(x => x.SchoolName.Contains(term));

        //            return _Mapper.Map<IEnumerable<SchoolDTO>>(models).ToList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogException(ex);
        //        throw ex;
        //    }
        //}

        private async void LogException(Exception ex)
        {
            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                ExceptionLogger exModel = new ExceptionLogger
                {
                    ExceptionMessage = ex.Message,
                    SourceName = ex.Source,
                    ExceptionStackTrace = ex.StackTrace,
                    LogTime = DateTime.Now
                };
                unitOfWork.ExceptionLoggerRepository.Add(exModel);
                await unitOfWork.SaveChangesAsync();

            }
        }
    }
}
