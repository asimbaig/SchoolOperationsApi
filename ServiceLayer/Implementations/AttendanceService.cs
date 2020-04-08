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
    public class AttendanceService : BaseService, IAttendanceService
    {
        public AttendanceService() : base()
        {
            SetAutoMapper_Attendance();
        }

        //Add Attendance (async)
        public async Task<int> AddAttendanceAsync(AttendanceDTO modelDTO)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    if (!string.IsNullOrEmpty(modelDTO._ImageFileUrl))
                    {
                        var tempImageTypeModel = unitOfWork.ImageFileTypeRepository.GetSingleOrDefaultImageFileType(x => x.Type.Contains("AttendanceImage"));

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

                    AttendanceModel model = _Mapper_ToModel.Map<AttendanceDTO, AttendanceModel>(modelDTO);

                    unitOfWork.AttendanceRepository.Add(model);
                    //unitOfWork.Repository.Add<AttendanceModel>(model);
                    await unitOfWork.SaveChangesAsync();
                    return model.AttendanceId;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }

        }

        //Update Attendance (async)
        public async Task<AttendanceDTO> UpdateAttendanceAsync(AttendanceDTO modelDTO)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    if (!string.IsNullOrEmpty(modelDTO._ImageFileUrl))
                    {
                        var tempImageTypeModel = unitOfWork.ImageFileTypeRepository.GetSingleOrDefaultImageFileType(x => x.Type.Contains("AttendanceImage"));

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

                    AttendanceModel model = _Mapper_ToModel.Map<AttendanceDTO, AttendanceModel>(modelDTO);

                    bool result  = unitOfWork.AttendanceRepository.Update(model);

                    AttendanceDTO modelRTN = null;
                    if (result)
                    {
                        await unitOfWork.SaveChangesAsync();

                        modelRTN = _Mapper_ToDTO.Map<AttendanceModel, AttendanceDTO>(model);
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

        //Remove a Attendance by Id (async)
        public async Task<int> RemoveAttendanceAsync(int AttendanceId)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    var entity = unitOfWork.AttendanceRepository.GetSingleOrDefaultAttendance(x => x.AttendanceId == AttendanceId);
                    if (entity == null)
                    {
                        return 0;
                    }
                    else
                    {
                        unitOfWork.AttendanceRepository.Remove(entity);
                        await unitOfWork.SaveChangesAsync();
                        return entity.AttendanceId;
                    }

                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Get List of all Attendances (async)
        public async Task<List<AttendanceDTO>> GetAllAttendance()
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    var models = await Task.Run(() => unitOfWork.AttendanceRepository.GetAllAttendances().ToList());
                    var temp = _Mapper_ToDTO.Map<List<AttendanceModel>, List<AttendanceDTO>>(models);
                    return temp;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Find Single Attendance base on "term" (async)
        public async Task<AttendanceDTO> SearchSingleAttendanceByStatusAsync(bool status)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    AttendanceModel model = await Task.Run(() => unitOfWork.AttendanceRepository.GetSingleOrDefaultAttendance(x => x.Present== status));
                    return _Mapper_ToDTO.Map<AttendanceModel, AttendanceDTO>(model);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Is Attendance Exists
        public bool IsAttendanceExistsById(int AttendanceId)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    return unitOfWork.AttendanceRepository.Exists(x => x.AttendanceId == AttendanceId);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Search Attendances based on "term/string"
        public List<AttendanceDTO> SearchAttendancesByStatusAsync(bool status)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    List<AttendanceModel> models = unitOfWork.AttendanceRepository.FindAttendance(x => x.Present==status).ToList();

                    return _Mapper_ToDTO.Map<List<AttendanceModel>, List<AttendanceDTO>>(models);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Find Single Attendance base on "term" (async)
        public async Task<AttendanceDTO> SearchSingleAttendanceByIdAsync(int Id)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    AttendanceModel model = await Task.Run(() => unitOfWork.AttendanceRepository.GetSingleOrDefaultAttendance(x => x.AttendanceId == Id));
                    return _Mapper_ToDTO.Map<AttendanceModel, AttendanceDTO>(model);
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
