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
    public class StandardService : BaseService, IStandardService
    {
        public StandardService() : base()
        {
            SetAutoMapper_Standard();
        }

        //Add Standard (async)
        public async Task<int> AddStandardAsync(StandardDTO modelDTO)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    StandardModel model = _Mapper_ToModel.Map<StandardDTO, StandardModel>(modelDTO);

                    unitOfWork.StandardRepository.Add(model);
                    //unitOfWork.Repository.Add<StandardModel>(model);
                    await unitOfWork.SaveChangesAsync();
                    return model.StandardId;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }

        }

        //Update Standard (async)
        public async Task<StandardDTO> UpdateStandardAsync(StandardDTO modelDTO)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    StandardModel model = _Mapper_ToModel.Map<StandardDTO, StandardModel>(modelDTO);

                    bool result = unitOfWork.StandardRepository.Update(model);

                    StandardDTO modelRTN = null;
                    if (result)
                    {
                        await unitOfWork.SaveChangesAsync();
                        modelRTN = _Mapper_ToDTO.Map<StandardModel, StandardDTO>(model);

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

        //Remove a Standard by Id (async)
        public async Task<int> RemoveStandardAsync(int StandardId)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    var entity = unitOfWork.StandardRepository.GetSingleOrDefaultStandard(x => x.StandardId == StandardId);
                    if (entity == null)
                    {
                        return 0;
                    }
                    else
                    {
                        unitOfWork.StandardRepository.Remove(entity);
                        await unitOfWork.SaveChangesAsync();
                        return entity.StandardId;
                    }

                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Get List of all Standards (async)
        public async Task<List<StandardDTO>> GetAllStandard()
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    var models = await Task.Run(() => unitOfWork.StandardRepository.GetAllStandards().ToList());
                    //var temp = _Mapper_ToDTO.Map<List<StandardModel>, List<StandardDTO>>(models);
                    //foreach (var m in models)
                    //{
                    //    m.SubjectIds = unitOfWork.StandardRepository.GetAllSubjectsByStandardId(m.StandardId).ToList();
                    //    m.AssessmentIds = unitOfWork.StandardRepository.GetAllAssessmentsByStandardId(m.StandardId).ToList();
                    //    m.HomeworkIds = unitOfWork.StandardRepository.GetAllHomeworksByStandardId(m.StandardId).ToList();
                    //    m.StudentIds = unitOfWork.StandardRepository.GetAllStudentsByStandardId(m.StandardId).ToList();
                    //    m.TeacherIds = unitOfWork.StandardRepository.GetAllTeachersByStandardId(m.StandardId).ToList();
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

        //Find Single Standard base on "term" (async)
        public async Task<StandardDTO> SearchSingleStandardByNameAsync(string term)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    StandardModel model = await Task.Run(() => unitOfWork.StandardRepository.GetSingleOrDefaultStandard(x => x.StandardName.Contains(term)));
                    return _Mapper_ToDTO.Map<StandardModel, StandardDTO>(model);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Is Standard Exists
        public bool IsStandardExistsById(int StandardId)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    return unitOfWork.StandardRepository.Exists(x => x.StandardId == StandardId);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Search Standards based on "term/string"
        public List<StandardDTO> SearchStandardsByNameAsync(string term)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    List<StandardModel> models = unitOfWork.StandardRepository.FindStandard(x => x.StandardName.Contains(term)).ToList();

                    return _Mapper_ToDTO.Map<List<StandardModel>, List<StandardDTO>>(models);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Find Single Standard base on "term" (async)
        public async Task<StandardDTO> SearchSingleStandardByIdAsync(int Id)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    StandardModel model = await Task.Run(() => unitOfWork.StandardRepository.GetSingleOrDefaultStandard(x => x.StandardId == Id));
                    return _Mapper_ToDTO.Map<StandardModel, StandardDTO>(model);
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
