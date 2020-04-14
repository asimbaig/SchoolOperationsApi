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
    public class StudentService : BaseService, IStudentService
    {
        public StudentService() : base()
        {
            SetAutoMapper_Student();
        }

        //Add Student (async)
        public async Task<int> AddStudentAsync(StudentDTO modelDTO)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    //var tempStandard = unitOfWork.StandardRepository.GetSingleOrDefaultStandard(x => x.StandardId == modelDTO.Standard_StandardId);

                    //modelDTO.Standard = _Mapper_ToDTO.Map<StandardModel, StandardDTO>(tempStandard);

                    if (!string.IsNullOrEmpty(modelDTO._ImageFileUrl))
                    {
                        var tempImageTypeModel = unitOfWork.ImageFileTypeRepository.GetSingleOrDefaultImageFileType(x => x.Type.Contains("StudentImage"));

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

                    StudentModel model = _Mapper_ToModel.Map<StudentDTO, StudentModel>(modelDTO);

                    unitOfWork.StudentRepository.Add(model);
                    //unitOfWork.Repository.Add<StudentModel>(model);
                    await unitOfWork.SaveChangesAsync();
                    return model.StudentId;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }

        }

        //Update Student (async)
        public async Task<StudentDTO> UpdateStudentAsync(StudentDTO modelDTO)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    //var tempStandard = unitOfWork.StandardRepository.GetSingleOrDefaultStandard(x => x.StandardId == modelDTO.Standard_StandardId);

                    //modelDTO.Standard = _Mapper_ToDTO.Map<StandardModel, StandardDTO>(tempStandard);

                    if (!string.IsNullOrEmpty(modelDTO._ImageFileUrl))
                    {
                        var tempImageTypeModel = unitOfWork.ImageFileTypeRepository.GetSingleOrDefaultImageFileType(x => x.Type.Contains("StudentImage"));

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

                    StudentModel model = _Mapper_ToModel.Map<StudentDTO, StudentModel>(modelDTO);

                    bool result = unitOfWork.StudentRepository.Update(model);

                    StudentDTO modelRTN = null;
                    if (result)
                    {
                        await unitOfWork.SaveChangesAsync();
                        modelRTN = _Mapper_ToDTO.Map<StudentModel, StudentDTO>(model);

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

        //Remove a Student by Id (async)
        public async Task<int> RemoveStudentAsync(int StudentId)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    var entity = unitOfWork.StudentRepository.GetSingleOrDefaultStudent(x => x.StudentId == StudentId);
                    if (entity == null)
                    {
                        return 0;
                    }
                    else
                    {
                        unitOfWork.StudentRepository.Remove(entity);
                        await unitOfWork.SaveChangesAsync();
                        return entity.StudentId;
                    }

                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Get List of all Students (async)
        public async Task<List<StudentDTO>> GetAllStudent()
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    var models = await Task.Run(() => unitOfWork.StudentRepository.GetAllStudents().ToList());
                    //var temp = _Mapper_ToDTO.Map<List<StudentModel>, List<StudentDTO>>(models);
                    //foreach (var m in models)
                    //{
                    //    m.EventIds = unitOfWork.StudentRepository.GetAllEventsByStudentId(m.StudentId).ToList();
                    //    m.BookTransactionIds = unitOfWork.StudentRepository.GetAllBookTransactionsByStudentId(m.StudentId).ToList();
                    //    m.AttendanceIds = unitOfWork.StudentRepository.GetAllAttendancesByStudentId(m.StudentId).ToList();
                    //    m.ParentIds = unitOfWork.StudentRepository.GetAllParentsByStudentId(m.StudentId).ToList();
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

        //Find Single Student base on "term" (async)
        public async Task<StudentDTO> SearchSingleStudentByNameAsync(string term)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    StudentModel model = await Task.Run(() => unitOfWork.StudentRepository.GetSingleOrDefaultStudent(x => x.St_Name.Contains(term)));
                    return _Mapper_ToDTO.Map<StudentModel, StudentDTO>(model);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Is Student Exists
        public bool IsStudentExistsById(int StudentId)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    return unitOfWork.StudentRepository.Exists(x => x.StudentId == StudentId);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Search Students based on "term/string"
        public List<StudentDTO> SearchStudentsByNameAsync(string term)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    List<StudentModel> models = unitOfWork.StudentRepository.FindStudent(x => x.St_Name.Contains(term)).ToList();

                    return _Mapper_ToDTO.Map<List<StudentModel>, List<StudentDTO>>(models);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Find Single Student base on "term" (async)
        public async Task<StudentDTO> SearchSingleStudentByIdAsync(int Id)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    StudentModel model = await Task.Run(() => unitOfWork.StudentRepository.GetSingleOrDefaultStudent(x => x.StudentId == Id));
                    return _Mapper_ToDTO.Map<StudentModel, StudentDTO>(model);
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
