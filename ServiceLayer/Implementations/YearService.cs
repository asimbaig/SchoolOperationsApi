using DatabaseLayer.Models;
using DTOs;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Implementations
{
    public class YearService : BaseService, IYearService
    {
        public YearService() : base()
        {
            SetAutoMapper_Year();
        }

        //Add Year (async)
        public async Task<int> AddYearAsync(YearDTO modelDTO)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    YearModel model = _Mapper_ToModel.Map<YearDTO, YearModel>(modelDTO);

                    unitOfWork.YearRepository.Add(model);
                    //unitOfWork.Repository.Add<YearModel>(model);
                    await unitOfWork.SaveChangesAsync();
                    return model.YearId;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }

        }

        //Update Year (async)
        public async Task<YearDTO> UpdateYearAsync(YearDTO modelDTO)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    YearModel model = _Mapper_ToModel.Map<YearDTO, YearModel>(modelDTO);

                    bool result = unitOfWork.YearRepository.Update(model);

                    YearDTO modelRTN = null;
                    if (result)
                    {
                        await unitOfWork.SaveChangesAsync();
                        modelRTN = _Mapper_ToDTO.Map<YearModel, YearDTO>(model);

                    }
                    return modelRTN;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Remove a Year by Id (async)
        public async Task<int> RemoveYearAsync(int YearId)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    var entity = unitOfWork.YearRepository.GetSingleOrDefaultYear(x => x.YearId == YearId);
                    if (entity == null)
                    {
                        return 0;
                    }
                    else
                    {
                        unitOfWork.YearRepository.Remove(entity);
                        await unitOfWork.SaveChangesAsync();
                        return entity.YearId;
                    }

                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Get List of all Years (async)
        public async Task<List<YearDTO>> GetAllYear()
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    var models = await Task.Run(() => unitOfWork.YearRepository.GetAllYears().ToList());
                    //var temp = _Mapper_ToDTO.Map<List<YearModel>, List<YearDTO>>(models);
                    //foreach (var m in temp)
                    //{
                    //    m.StandardIds = unitOfWork.YearRepository.GetAllStandardsByYearId(m.YearId).ToList();
                    //}
                    return models;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Find Single Year base on "term" (async)
        public async Task<YearDTO> SearchSingleYearByNameAsync(string term)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    YearModel model = await Task.Run(() => unitOfWork.YearRepository.GetSingleOrDefaultYear(x => x.year.Contains(term)));
                    return _Mapper_ToDTO.Map<YearModel, YearDTO>(model);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Is Year Exists
        public bool IsYearExistsById(int YearId)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    return unitOfWork.YearRepository.Exists(x => x.YearId == YearId);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Search Years based on "term/string"
        public List<YearDTO> SearchYearsByNameAsync(string term)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    List<YearModel> models = unitOfWork.YearRepository.FindYear(x => x.year.Contains(term)).ToList();

                    return _Mapper_ToDTO.Map<List<YearModel>, List<YearDTO>>(models);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Find Single Year base on "term" (async)
        public async Task<YearDTO> SearchSingleYearByIdAsync(int Id)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    YearModel model = await Task.Run(() => unitOfWork.YearRepository.GetSingleOrDefaultYear(x => x.YearId == Id));
                    return _Mapper_ToDTO.Map<YearModel, YearDTO>(model);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }
    }
}
