using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLayer.Models;
using DTOs;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Implementations
{
    public class ImageFileUrlService : BaseService, IImageFileUrlService
    {
        public ImageFileUrlService() : base()
        {
            SetAutoMapper_ImageFileUrl();
        }

        //Add ImageFileUrl (async)
        public async Task<int> AddImageFileUrlAsync(ImageFileUrlDTO modelDTO)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    //var tempImageType = await unitOfWork.ImageFileTypeRepository.GetSingleOrDefaultAsync(x => x.Type.Contains("BookImage"));

                    //modelDTO.ImageFileUrl = new ImageFileUrlDTO()
                    //{
                    //    Url = modelDTO._ImageFileUrl,
                    //    CreateDate = DateTime.Now,
                    //    ImageFileType = new ImageFileTypeDTO { ImageFileTypeId = tempImageType.ImageFileTypeId, Type = tempImageType.Type }
                    //};

                    ImageFileUrlModel model = _Mapper_ToModel.Map<ImageFileUrlDTO, ImageFileUrlModel>(modelDTO);

                    unitOfWork.ImageFileUrlRepository.Add(model);
                    //unitOfWork.Repository.Add<ImageFileUrlModel>(model);
                    await unitOfWork.SaveChangesAsync();
                    return model.ImageFileUrlId;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }

        }

        //Update ImageFileUrl (async)
        public async Task<ImageFileUrlDTO> UpdateImageFileUrlAsync(ImageFileUrlDTO modelDTO)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    //var tempImageType = await unitOfWork.ImageFileTypeRepository.GetSingleOrDefaultAsync(x => x.Type.Contains("BookImage"));

                    //modelDTO.ImageFileUrl = new ImageFileUrlDTO()
                    //{
                    //    Url = modelDTO._ImageFileUrl,
                    //    CreateDate = DateTime.Now,
                    //    ImageFileType = new ImageFileTypeDTO { ImageFileTypeId = tempImageType.ImageFileTypeId, Type = tempImageType.Type }
                    //};

                    ImageFileUrlModel model = _Mapper_ToModel.Map<ImageFileUrlDTO, ImageFileUrlModel>(modelDTO);

                    unitOfWork.ImageFileUrlRepository.Update(model);

                    bool result = unitOfWork.ImageFileUrlRepository.Update(model);

                    ImageFileUrlDTO modelRTN = null;
                    if (result)
                    {
                        await unitOfWork.SaveChangesAsync();
                        modelRTN = _Mapper_ToDTO.Map<ImageFileUrlModel, ImageFileUrlDTO>(model);
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

        //Remove a ImageFileUrl by Id (async)
        public async Task<int> RemoveImageFileUrlAsync(int ImageFileUrlId)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    var entity = unitOfWork.ImageFileUrlRepository.GetSingleOrDefaultImageFileUrl(x => x.ImageFileUrlId == ImageFileUrlId);
                    if (entity == null)
                    {
                        return 0;
                    }
                    else
                    {
                        unitOfWork.ImageFileUrlRepository.Remove(entity);
                        await unitOfWork.SaveChangesAsync();
                        return entity.ImageFileUrlId;
                    }

                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Get List of all ImageFileUrls (async)
        public async Task<List<ImageFileUrlDTO>> GetAllImageFileUrl()
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    var models = await Task.Run(() => unitOfWork.ImageFileUrlRepository.GetAllImageFileUrls().ToList());
                    var temp = _Mapper_ToDTO.Map<List<ImageFileUrlModel>, List<ImageFileUrlDTO>>(models);
                    return temp;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Find Single ImageFileUrl base on "term" (async)
        public async Task<ImageFileUrlDTO> SearchSingleImageFileUrlByUrlAsync(string term)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    ImageFileUrlModel model = await Task.Run(() => unitOfWork.ImageFileUrlRepository.GetSingleOrDefaultImageFileUrl(x => x.Url.Contains(term)));
                    return _Mapper_ToDTO.Map<ImageFileUrlModel, ImageFileUrlDTO>(model);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Is ImageFileUrl Exists
        public bool IsImageFileUrlExistsById(int ImageFileUrlId)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    return unitOfWork.ImageFileUrlRepository.Exists(x => x.ImageFileUrlId == ImageFileUrlId);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Search ImageFileUrls based on "term/string"
        public List<ImageFileUrlDTO> SearchImageFileUrlsByUrlAsync(string term)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    List<ImageFileUrlModel> models = unitOfWork.ImageFileUrlRepository.FindImageFileUrl(x => x.Url.Contains(term)).ToList();

                    return _Mapper_ToDTO.Map<List<ImageFileUrlModel>, List<ImageFileUrlDTO>>(models);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Find Single Homework base on "term" (async)
        public async Task<ImageFileUrlDTO> SearchSingleImageFileUrlByIdAsync(int Id)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    ImageFileUrlModel model = await Task.Run(() => unitOfWork.ImageFileUrlRepository.GetSingleOrDefaultImageFileUrl(x => x.ImageFileUrlId == Id));
                    return _Mapper_ToDTO.Map<ImageFileUrlModel, ImageFileUrlDTO>(model);
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
