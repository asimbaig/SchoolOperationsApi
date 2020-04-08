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
    public class SchoolService : BaseService, ISchoolService
    {
        public SchoolService() : base()
        {
            SetAutoMapper_School();
        }

        //Add School (async)
        public async Task<int> AddSchoolAsync(SchoolDTO modelDTO)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {

                    if (!string.IsNullOrEmpty(modelDTO._ImageFileUrl))
                    {
                        var tempImageTypeModel = unitOfWork.ImageFileTypeRepository.GetSingleOrDefaultImageFileType(x => x.Type.Contains("SchoolImage"));

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

                    SchoolModel model = _Mapper_ToModel.Map<SchoolDTO, SchoolModel>(modelDTO);

                    unitOfWork.SchoolRepository.Add(model);
                    //unitOfWork.Repository.Add<SchoolModel>(model);
                    await unitOfWork.SaveChangesAsync();
                    return model.SchoolId;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }

        }

        //Update School (async)
        public async Task<SchoolDTO> UpdateSchoolAsync(SchoolDTO modelDTO)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    if (!string.IsNullOrEmpty(modelDTO._ImageFileUrl))
                    {
                        var tempImageTypeModel = unitOfWork.ImageFileTypeRepository.GetSingleOrDefaultImageFileType(x => x.Type.Contains("SchoolImage"));

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

                    SchoolModel model = _Mapper_ToModel.Map<SchoolDTO, SchoolModel>(modelDTO);

                    bool result = unitOfWork.SchoolRepository.Update(model);

                    SchoolDTO modelRTN = null;
                    if (result)
                    {
                        await unitOfWork.SaveChangesAsync();
                        modelRTN = _Mapper_ToDTO.Map<SchoolModel, SchoolDTO>(model);

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

        //Remove a School by Id (async)
        public async Task<int> RemoveSchoolAsync(int SchoolId)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    var entity = unitOfWork.SchoolRepository.GetSingleOrDefaultSchool(x => x.SchoolId == SchoolId);
                    if (entity == null)
                    {
                        return 0;
                    }
                    else
                    {
                        unitOfWork.SchoolRepository.Remove(entity);
                        await unitOfWork.SaveChangesAsync();
                        return entity.SchoolId;
                    }

                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Get List of all Schools (async)
        public async Task<List<SchoolDTO>> GetAllSchool()
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    var models = await Task.Run(() => unitOfWork.SchoolRepository.GetAllSchools().ToList());
                    var temp = _Mapper_ToDTO.Map<List<SchoolModel>, List<SchoolDTO>>(models);
                    foreach (var m in temp)
                    {
                        m.StandardIds = unitOfWork.SchoolRepository.GetAllStandardsBySchoolId(m.SchoolId).ToList();
                        m.OperationalStaffIds = unitOfWork.SchoolRepository.GetAllOperationalStaffsBySchoolId(m.SchoolId).ToList();
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

        //Find Single School base on "term" (async)
        public async Task<SchoolDTO> SearchSingleSchoolByNameAsync(string term)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    SchoolModel model = await Task.Run(() => unitOfWork.SchoolRepository.GetSingleOrDefaultSchool(x => x.SchoolName.Contains(term)));
                    return _Mapper_ToDTO.Map<SchoolModel, SchoolDTO>(model);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Is School Exists
        public bool IsSchoolExistsById(int SchoolId)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    return unitOfWork.SchoolRepository.Exists(x => x.SchoolId == SchoolId);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Search Schools based on "term/string"
        public List<SchoolDTO> SearchSchoolsByNameAsync(string term)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    List<SchoolModel> models = unitOfWork.SchoolRepository.FindSchool(x => x.SchoolName.Contains(term)).ToList();

                    return _Mapper_ToDTO.Map<List<SchoolModel>, List<SchoolDTO>>(models);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Find Single School base on "term" (async)
        public async Task<SchoolDTO> SearchSingleSchoolByIdAsync(int Id)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    SchoolModel model = await Task.Run(() => unitOfWork.SchoolRepository.GetSingleOrDefaultSchool(x => x.SchoolId == Id));
                    return _Mapper_ToDTO.Map<SchoolModel, SchoolDTO>(model);
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
