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
    public class TeacherService : BaseService, ITeacherService
    {
        public TeacherService() : base()
        {
            SetAutoMapper_Teacher();
        }

        //Add Teacher (async)
        public async Task<int> AddTeacherAsync(TeacherDTO modelDTO)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    if (!string.IsNullOrEmpty(modelDTO._ImageFileUrl))
                    {
                        var tempImageTypeModel = unitOfWork.ImageFileTypeRepository.GetSingleOrDefaultImageFileType(x => x.Type.Contains("TeacherImage"));

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

                    TeacherModel model = _Mapper_ToModel.Map<TeacherDTO, TeacherModel>(modelDTO);

                    //unitOfWork.TeacherRepository.Add(model);
                    unitOfWork.Repository.Add<TeacherModel>(model);
                    await unitOfWork.SaveChangesAsync();
                    return model.TeacherId;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }

        }

        //Update Teacher (async)
        public async Task<TeacherDTO> UpdateTeacherAsync(TeacherDTO modelDTO)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    if (!string.IsNullOrEmpty(modelDTO._ImageFileUrl))
                    {
                        var tempImageTypeModel = unitOfWork.ImageFileTypeRepository.GetSingleOrDefaultImageFileType(x => x.Type.Contains("TeacherImage"));

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

                    TeacherModel model = _Mapper_ToModel.Map<TeacherDTO, TeacherModel>(modelDTO);

                    bool result = unitOfWork.TeacherRepository.Update(model);

                    TeacherDTO modelRTN = null;
                    if (result)
                    {
                        await unitOfWork.SaveChangesAsync();
                        modelRTN = _Mapper_ToDTO.Map<TeacherModel, TeacherDTO>(model);

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

        //Remove a Teacher by Id (async)
        public async Task<int> RemoveTeacherAsync(int TeacherId)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    var entity = unitOfWork.TeacherRepository.GetSingleOrDefaultTeacher(x => x.TeacherId == TeacherId);
                    if (entity == null)
                    {
                        return 0;
                    }
                    else
                    {
                        unitOfWork.TeacherRepository.Remove(entity);
                        await unitOfWork.SaveChangesAsync();
                        return entity.TeacherId;
                    }

                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Get List of all Teachers (async)
        public async Task<List<TeacherDTO>> GetAllTeacher()
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    var models = await Task.Run(() => unitOfWork.TeacherRepository.GetAllTeachers().ToList());
                    //var temp = _Mapper_ToDTO.Map<List<TeacherModel>, List<TeacherDTO>>(models);
                    //foreach (var m in models)
                    //{
                    //    m.StandardIds = unitOfWork.TeacherRepository.GetAllStandardsByTeacherId(m.TeacherId).ToList();
                    //    m.SubjectIds = unitOfWork.TeacherRepository.GetAllSubjectsByTeacherId(m.TeacherId).ToList();
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

        //Find Single Teacher base on "term" (async)
        public async Task<TeacherDTO> SearchSingleTeacherByNameAsync(string term)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    TeacherModel model = await Task.Run(() => unitOfWork.TeacherRepository.GetSingleOrDefaultTeacher(x => x.TeacherName.Contains(term)));
                    return _Mapper_ToDTO.Map<TeacherModel, TeacherDTO>(model);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Is Teacher Exists
        public bool IsTeacherExistsById(int TeacherId)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    return unitOfWork.TeacherRepository.Exists(x => x.TeacherId == TeacherId);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Search Teachers based on "term/string"
        public List<TeacherDTO> SearchTeachersByNameAsync(string term)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    List<TeacherModel> models = unitOfWork.TeacherRepository.FindTeacher(x => x.TeacherName.Contains(term)).ToList();

                    return _Mapper_ToDTO.Map<List<TeacherModel>, List<TeacherDTO>>(models);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Find Single Teacher base on "term" (async)
        public async Task<TeacherDTO> SearchSingleTeacherByIdAsync(int Id)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    TeacherModel model = await Task.Run(() => unitOfWork.TeacherRepository.GetSingleOrDefaultTeacher(x => x.TeacherId == Id));
                    return _Mapper_ToDTO.Map<TeacherModel, TeacherDTO>(model);
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
