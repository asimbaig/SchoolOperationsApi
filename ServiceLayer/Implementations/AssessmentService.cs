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
    public class AssessmentService : BaseService, IAssessmentService
    {
        public AssessmentService() : base()
        {
            SetAutoMapper_Assessment();
        }

        //Add Assessment (async)
        public async Task<int> AddAssessmentAsync(AssessmentDTO modelDTO)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    if (!string.IsNullOrEmpty(modelDTO._ImageFileUrl))
                    {
                        var tempImageTypeModel = unitOfWork.ImageFileTypeRepository.GetSingleOrDefaultImageFileType(x => x.Type.Contains("AssessmentFile"));

                        ImageFileTypeDTO imageFileTypeDTO = _Mapper_ToDTO.Map<ImageFileTypeModel, ImageFileTypeDTO>(tempImageTypeModel);

                        modelDTO.ImageFileUrl = new ImageFileUrlDTO()
                        {
                            Url = modelDTO._ImageFileUrl,
                            CreateDate = DateTime.Now,
                            ImageFileTypeId = imageFileTypeDTO.ImageFileTypeId
                        };
                    }
                    else
                    {
                        modelDTO.ImageFileUrl = null;
                    }

                    AssessmentModel model = _Mapper_ToModel.Map<AssessmentDTO, AssessmentModel>(modelDTO);

                    unitOfWork.AssessmentRepository.Add(model);
                    //unitOfWork.Repository.Add<AssessmentModel>(model);
                    await unitOfWork.SaveChangesAsync();
                    return model.AssessmentId;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }

        }

        //Update Assessment (async)
        public async Task<AssessmentDTO> UpdateAssessmentAsync(AssessmentDTO modelDTO)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    if (!string.IsNullOrEmpty(modelDTO._ImageFileUrl))
                    {
                        var tempImageTypeModel = unitOfWork.ImageFileTypeRepository.GetSingleOrDefaultImageFileType(x => x.Type.Contains("AssessmentFile"));

                        ImageFileTypeDTO imageFileTypeDTO = _Mapper_ToDTO.Map<ImageFileTypeModel, ImageFileTypeDTO>(tempImageTypeModel);

                        modelDTO.ImageFileUrl = new ImageFileUrlDTO()
                        {
                            Url = modelDTO._ImageFileUrl,
                            CreateDate = DateTime.Now,
                            ImageFileTypeId = imageFileTypeDTO.ImageFileTypeId
                        };
                    }
                    else
                    {
                        modelDTO.ImageFileUrl = null;
                    }
                    
                    AssessmentModel model = _Mapper_ToModel.Map<AssessmentDTO, AssessmentModel>(modelDTO);

                    bool result = unitOfWork.AssessmentRepository.Update(model);

                    AssessmentDTO modelRTN = null;
                    if (result)
                    {
                        await unitOfWork.SaveChangesAsync();
                        modelRTN = _Mapper_ToDTO.Map<AssessmentModel, AssessmentDTO>(model);
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

        //Remove a Assessment by Id (async)
        public async Task<int> RemoveAssessmentAsync(int AssessmentId)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    var entity = unitOfWork.AssessmentRepository.GetSingleOrDefaultAssessment(x => x.AssessmentId == AssessmentId);
                    if (entity == null)
                    {
                        return 0;
                    }
                    else
                    {
                        unitOfWork.AssessmentRepository.Remove(entity);
                        await unitOfWork.SaveChangesAsync();
                        return entity.AssessmentId;
                    }

                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Get List of all Assessments (async)
        public async Task<List<AssessmentDTO>> GetAllAssessment()
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    //var models = unitOfWork.AssessmentRepository.GetAllAssessments().ToList();
                    var models = await Task.Run(() => unitOfWork.AssessmentRepository.GetAllAssessments().ToList());
                    //var temp = _Mapper_ToDTO.Map<List<AssessmentModel>, List<AssessmentDTO>>(models);
                    return models;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Find Single Assessment base on "term" (async)
        public async Task<AssessmentDTO> SearchSingleAssessmentByNameAsync(string term)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    AssessmentModel model = await Task.Run(() => unitOfWork.AssessmentRepository.GetSingleOrDefaultAssessment(x => x.AssessmentName.Contains(term)));
                    return _Mapper_ToDTO.Map<AssessmentModel, AssessmentDTO>(model);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Find Single Assessment base on "term" (async)
        public async Task<AssessmentDTO> SearchSingleAssessmentByIdAsync(int Id)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    AssessmentModel model = await Task.Run(() => unitOfWork.AssessmentRepository.GetSingleOrDefaultAssessment(x => x.AssessmentId==Id));
                    return _Mapper_ToDTO.Map<AssessmentModel, AssessmentDTO>(model);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Is Assessment Exists
        public bool IsAssessmentExistsById(int AssessmentId)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    return unitOfWork.AssessmentRepository.Exists(x => x.AssessmentId == AssessmentId);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Search Assessments based on "term/string"
        public List<AssessmentDTO> SearchAssessmentsByNameAsync(string term)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    List<AssessmentModel> models = unitOfWork.AssessmentRepository.FindAssessment(x => x.AssessmentName.Contains(term)).ToList();

                    return _Mapper_ToDTO.Map<List<AssessmentModel>, List<AssessmentDTO>>(models);
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
