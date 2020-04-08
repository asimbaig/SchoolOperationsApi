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
    public class ParentService : BaseService, IParentService
    {
        public ParentService() : base()
        {
            SetAutoMapper_Parent();
        }

        //Add Parent (async)
        public async Task<int> AddParentAsync(ParentDTO modelDTO)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    if (!string.IsNullOrEmpty(modelDTO._ImageFileUrl))
                    {
                        var tempImageTypeModel = unitOfWork.ImageFileTypeRepository.GetSingleOrDefaultImageFileType(x => x.Type.Contains("ParentImage"));

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

                    ParentModel model = _Mapper_ToModel.Map<ParentDTO, ParentModel>(modelDTO);

                    unitOfWork.ParentRepository.Add(model);
                    //unitOfWork.Repository.Add<ParentModel>(model);
                    await unitOfWork.SaveChangesAsync();
                    return model.ParentId;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }

        }

        //Update Parent (async)
        public async Task<ParentDTO> UpdateParentAsync(ParentDTO modelDTO)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    if (!string.IsNullOrEmpty(modelDTO._ImageFileUrl))
                    {
                        var tempImageTypeModel = unitOfWork.ImageFileTypeRepository.GetSingleOrDefaultImageFileType(x => x.Type.Contains("ParentImage"));

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

                    ParentModel model = _Mapper_ToModel.Map<ParentDTO, ParentModel>(modelDTO);

                    bool result = unitOfWork.ParentRepository.Update(model);

                    ParentDTO modelRTN = null;
                    if (result)
                    {
                        await unitOfWork.SaveChangesAsync();
                        modelRTN = _Mapper_ToDTO.Map<ParentModel, ParentDTO>(model);

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

        //Remove a Parent by Id (async)
        public async Task<int> RemoveParentAsync(int ParentId)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    var entity = unitOfWork.ParentRepository.GetSingleOrDefaultParent(x => x.ParentId == ParentId);
                    if (entity == null)
                    {
                        return 0;
                    }
                    else
                    {
                        unitOfWork.ParentRepository.Remove(entity);
                        await unitOfWork.SaveChangesAsync();
                        return entity.ParentId;
                    }

                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Get List of all Parents (async)
        public async Task<List<ParentDTO>> GetAllParent()
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    var models = await Task.Run(() => unitOfWork.ParentRepository.GetAllParents().ToList());
                    var temp = _Mapper_ToDTO.Map<List<ParentModel>, List<ParentDTO>>(models);
                    foreach (var m in temp)
                    {
                        m.StudentIds = unitOfWork.ParentRepository.GetAllStudentsByParentId(m.ParentId).ToList();
                    }
                    return temp;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Find Single Parent base on "term" (async)
        public async Task<ParentDTO> SearchSingleParentByNameAsync(string term)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    ParentModel model = await Task.Run(() => unitOfWork.ParentRepository.GetSingleOrDefaultParent(x => x.ParentName.Contains(term)));
                    return _Mapper_ToDTO.Map<ParentModel, ParentDTO>(model);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Is Parent Exists
        public bool IsParentExistsById(int ParentId)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    return unitOfWork.ParentRepository.Exists(x => x.ParentId == ParentId);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Search Parents based on "term/string"
        public List<ParentDTO> SearchParentsByNameAsync(string term)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    List<ParentModel> models = unitOfWork.ParentRepository.FindParent(x => x.ParentName.Contains(term)).ToList();

                    return _Mapper_ToDTO.Map<List<ParentModel>, List<ParentDTO>>(models);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Find Single Parent base on "term" (async)
        public async Task<ParentDTO> SearchSingleParentByIdAsync(int Id)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    ParentModel model = await Task.Run(() => unitOfWork.ParentRepository.GetSingleOrDefaultParent(x => x.ParentId == Id));
                    return _Mapper_ToDTO.Map<ParentModel, ParentDTO>(model);
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
