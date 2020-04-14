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
    public class OperationalStaffService : BaseService, IOperationalStaffService
    {
        public OperationalStaffService() : base()
        {
            SetAutoMapper_OperationalStaff();
        }

        //Add OperationalStaff (async)
        public async Task<int> AddOperationalStaffAsync(OperationalStaffDTO modelDTO)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    if (!string.IsNullOrEmpty(modelDTO._ImageFileUrl))
                    {
                        var tempImageTypeModel = unitOfWork.ImageFileTypeRepository.GetSingleOrDefaultImageFileType(x => x.Type.Contains("OperationalStaffImage"));

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

                    OperationalStaffModel model = _Mapper_ToModel.Map<OperationalStaffDTO, OperationalStaffModel>(modelDTO);

                    unitOfWork.OperationalStaffRepository.Add(model);
                    //unitOfWork.Repository.Add<OperationalStaffModel>(model);
                    await unitOfWork.SaveChangesAsync();
                    return model.OpStaffId;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }

        }

        //Update OperationalStaff (async)
        public async Task<OperationalStaffDTO> UpdateOperationalStaffAsync(OperationalStaffDTO modelDTO)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    if (!string.IsNullOrEmpty(modelDTO._ImageFileUrl))
                    {
                        var tempImageTypeModel = unitOfWork.ImageFileTypeRepository.GetSingleOrDefaultImageFileType(x => x.Type.Contains("OperationalStaffImage"));

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

                    OperationalStaffModel model = _Mapper_ToModel.Map<OperationalStaffDTO, OperationalStaffModel>(modelDTO);

                    bool result = unitOfWork.OperationalStaffRepository.Update(model);

                    OperationalStaffDTO modelRTN = null;
                    if (result)
                    {
                        await unitOfWork.SaveChangesAsync();
                        modelRTN = _Mapper_ToDTO.Map<OperationalStaffModel, OperationalStaffDTO>(model);

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

        //Remove a OperationalStaff by Id (async)
        public async Task<int> RemoveOperationalStaffAsync(int OperationalStaffId)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    var entity = unitOfWork.OperationalStaffRepository.GetSingleOrDefaultOperationalStaff(x => x.OpStaffId == OperationalStaffId);
                    if (entity == null)
                    {
                        return 0;
                    }
                    else
                    {
                        unitOfWork.OperationalStaffRepository.Remove(entity);
                        await unitOfWork.SaveChangesAsync();
                        return entity.OpStaffId;
                    }

                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Get List of all OperationalStaffs (async)
        public async Task<List<OperationalStaffDTO>> GetAllOperationalStaff()
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    var models = await Task.Run(() => unitOfWork.OperationalStaffRepository.GetAllOperationalStaffs().ToList());
                    ///var temp = _Mapper_ToDTO.Map<List<OperationalStaffModel>, List<OperationalStaffDTO>>(models);
                    return models;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Find Single OperationalStaff base on "term" (async)
        public async Task<OperationalStaffDTO> SearchSingleOperationalStaffByNameAsync(string term)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    OperationalStaffModel model = await Task.Run(() => unitOfWork.OperationalStaffRepository.GetSingleOrDefaultOperationalStaff(x => x.OpStaffName.Contains(term)));
                    return _Mapper_ToDTO.Map<OperationalStaffModel, OperationalStaffDTO>(model);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Is OperationalStaff Exists
        public bool IsOperationalStaffExistsById(int OperationalStaffId)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    return unitOfWork.OperationalStaffRepository.Exists(x => x.OpStaffId == OperationalStaffId);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Search OperationalStaffs based on "term/string"
        public List<OperationalStaffDTO> SearchOperationalStaffsByNameAsync(string term)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    List<OperationalStaffModel> models = unitOfWork.OperationalStaffRepository.FindOperationalStaff(x => x.OpStaffName.Contains(term)).ToList();

                    return _Mapper_ToDTO.Map<List<OperationalStaffModel>, List<OperationalStaffDTO>>(models);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Find Single OperationalStaff base on "term" (async)
        public async Task<OperationalStaffDTO> SearchSingleOperationalStaffByIdAsync(int Id)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    OperationalStaffModel model = await Task.Run(() => unitOfWork.OperationalStaffRepository.GetSingleOrDefaultOperationalStaff(x => x.OpStaffId == Id));
                    return _Mapper_ToDTO.Map<OperationalStaffModel, OperationalStaffDTO>(model);
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
