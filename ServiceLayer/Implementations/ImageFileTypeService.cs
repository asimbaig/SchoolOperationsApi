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
    public class ImageFileTypeService : BaseService, IImageFileTypeService
    {
        public ImageFileTypeService() : base()
        {
            SetAutoMapper_ImageFileType();
        }

        //Add ImageFileType (async)
        public async Task<int> AddImageFileTypeAsync(ImageFileTypeDTO modelDTO)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    ImageFileTypeModel model = _Mapper_ToModel.Map<ImageFileTypeDTO, ImageFileTypeModel>(modelDTO);

                    unitOfWork.ImageFileTypeRepository.Add(model);
                    //unitOfWork.Repository.Add<ImageFileTypeModel>(model);
                    await unitOfWork.SaveChangesAsync();
                    return model.ImageFileTypeId;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }

        }

        //Update ImageFileType (async)
        public async Task<ImageFileTypeDTO> UpdateImageFileTypeAsync(ImageFileTypeDTO modelDTO)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    ImageFileTypeModel model = _Mapper_ToModel.Map<ImageFileTypeDTO, ImageFileTypeModel>(modelDTO);

                    bool result = unitOfWork.ImageFileTypeRepository.Update(model);

                    ImageFileTypeDTO modelRTN = null;
                    if (result)
                    {
                        await unitOfWork.SaveChangesAsync();
                        modelRTN = _Mapper_ToDTO.Map<ImageFileTypeModel, ImageFileTypeDTO>(model);
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

        //Remove a ImageFileType by Id (async)
        public async Task<int> RemoveImageFileTypeAsync(int ImageFileTypeId)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    var entity = unitOfWork.ImageFileTypeRepository.GetSingleOrDefaultImageFileType(x => x.ImageFileTypeId == ImageFileTypeId);
                    if (entity == null)
                    {
                        return 0;
                    }
                    else
                    {
                        unitOfWork.ImageFileTypeRepository.Remove(entity);
                        await unitOfWork.SaveChangesAsync();
                        return entity.ImageFileTypeId;
                    }

                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Get List of all ImageFileTypes (async)
        public async Task<List<ImageFileTypeDTO>> GetAllImageFileType()
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    var models = await Task.Run(() => unitOfWork.ImageFileTypeRepository.GetAllImageFileTypes().ToList());
                    var temp = _Mapper_ToDTO.Map<List<ImageFileTypeModel>, List<ImageFileTypeDTO>>(models);
                    foreach (var m in temp)
                    {
                        m.ImageFileUrlIds = unitOfWork.ImageFileTypeRepository.GetAllImageFileUrlsByImageFileTypeId(m.ImageFileTypeId).ToList();
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

        //Find Single ImageFileType base on "term" (async)
        public async Task<ImageFileTypeDTO> SearchSingleImageFileTypeByTypeAsync(string term)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    ImageFileTypeModel model = await Task.Run(() => unitOfWork.ImageFileTypeRepository.GetSingleOrDefaultImageFileType(x => x.Type.Contains(term)));
                    return _Mapper_ToDTO.Map<ImageFileTypeModel, ImageFileTypeDTO>(model);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Find Single ImageFileType base on "term" (async)
        public async Task<ImageFileTypeDTO> SearchSingleImageFileTypeByIdAsync(int Id)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    ImageFileTypeModel model = await Task.Run(() => unitOfWork.ImageFileTypeRepository.GetSingleOrDefaultImageFileType(x => x.ImageFileTypeId == Id));
                    return _Mapper_ToDTO.Map<ImageFileTypeModel, ImageFileTypeDTO>(model);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Is ImageFileType Exists
        public bool IsImageFileTypeExistsById(int ImageFileTypeId)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    return unitOfWork.ImageFileTypeRepository.Exists(x => x.ImageFileTypeId == ImageFileTypeId);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Search ImageFileTypes based on "term/string"
        public List<ImageFileTypeDTO> SearchImageFileTypesByTypeAsync(string term)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    List<ImageFileTypeModel> models = unitOfWork.ImageFileTypeRepository.FindImageFileType(x => x.Type.Contains(term)).ToList();

                    return _Mapper_ToDTO.Map<List<ImageFileTypeModel>, List<ImageFileTypeDTO>>(models);
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
