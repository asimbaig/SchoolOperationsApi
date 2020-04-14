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
    public class HomeworkService : BaseService, IHomeworkService
    {
        public HomeworkService() : base()
        {
            SetAutoMapper_Homework();
        }

        //Add Homework (async)
        public async Task<int> AddHomeworkAsync(HomeworkDTO modelDTO)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    if (!string.IsNullOrEmpty(modelDTO._ImageFileUrl))
                    {
                        var tempImageTypeModel = unitOfWork.ImageFileTypeRepository.GetSingleOrDefaultImageFileType(x => x.Type.Contains("HomeworkFile"));

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

                    HomeworkModel model = _Mapper_ToModel.Map<HomeworkDTO, HomeworkModel>(modelDTO);

                    unitOfWork.HomeworkRepository.Add(model);
                    //unitOfWork.Repository.Add<HomeworkModel>(model);
                    await unitOfWork.SaveChangesAsync();
                    return model.HomeworkId;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }

        }

        //Update Homework (async)
        public async Task<HomeworkDTO> UpdateHomeworkAsync(HomeworkDTO modelDTO)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    if (!string.IsNullOrEmpty(modelDTO._ImageFileUrl))
                    {
                        var tempImageTypeModel = unitOfWork.ImageFileTypeRepository.GetSingleOrDefaultImageFileType(x => x.Type.Contains("HomeworkFile"));

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

                    HomeworkModel model = _Mapper_ToModel.Map<HomeworkDTO, HomeworkModel>(modelDTO);

                    bool result = unitOfWork.HomeworkRepository.Update(model);

                    HomeworkDTO modelRTN = null;
                    if (result)
                    {
                        await unitOfWork.SaveChangesAsync();
                        modelRTN = _Mapper_ToDTO.Map<HomeworkModel, HomeworkDTO>(model);
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

        //Remove a Homework by Id (async)
        public async Task<int> RemoveHomeworkAsync(int HomeworkId)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    var entity = unitOfWork.HomeworkRepository.GetSingleOrDefaultHomework(x => x.HomeworkId == HomeworkId);
                    if (entity == null)
                    {
                        return 0;
                    }
                    else
                    {
                        unitOfWork.HomeworkRepository.Remove(entity);
                        await unitOfWork.SaveChangesAsync();
                        return entity.HomeworkId;
                    }

                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Get List of all Homeworks (async)
        public async Task<List<HomeworkDTO>> GetAllHomework()
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    var models = await Task.Run(() => unitOfWork.HomeworkRepository.GetAllHomeworks().ToList());
                    //var temp = _Mapper_ToDTO.Map<List<HomeworkModel>, List<HomeworkDTO>>(models);
                    return models;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Find Single Homework base on "term" (async)
        public async Task<HomeworkDTO> SearchSingleHomeworkByNameAsync(string term)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    HomeworkModel model = await Task.Run(() => unitOfWork.HomeworkRepository.GetSingleOrDefaultHomework(x => x.HomeworkName.Contains(term)));
                    return _Mapper_ToDTO.Map<HomeworkModel, HomeworkDTO>(model);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Find Single Homework base on "term" (async)
        public async Task<HomeworkDTO> SearchSingleHomeworkByIdAsync(int Id)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    HomeworkModel model = await Task.Run(() => unitOfWork.HomeworkRepository.GetSingleOrDefaultHomework(x => x.HomeworkId == Id));
                    return _Mapper_ToDTO.Map<HomeworkModel, HomeworkDTO>(model);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Is Homework Exists
        public bool IsHomeworkExistsById(int HomeworkId)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    return unitOfWork.HomeworkRepository.Exists(x => x.HomeworkId == HomeworkId);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Search Homeworks based on "term/string"
        public List<HomeworkDTO> SearchHomeworksByNameAsync(string term)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    List<HomeworkModel> models = unitOfWork.HomeworkRepository.FindHomework(x => x.HomeworkName.Contains(term)).ToList();

                    return _Mapper_ToDTO.Map<List<HomeworkModel>, List<HomeworkDTO>>(models);
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
