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
    public class SubjectService : BaseService, ISubjectService
    {
        public SubjectService() : base()
        {
            SetAutoMapper_Subject();
        }

        //Add Subject (async)
        public async Task<int> AddSubjectAsync(SubjectDTO modelDTO)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    SubjectModel model = _Mapper_ToModel.Map<SubjectDTO, SubjectModel>(modelDTO);

                    unitOfWork.SubjectRepository.Add(model);
                    //unitOfWork.Repository.Add<SubjectModel>(model);
                    await unitOfWork.SaveChangesAsync();
                    return model.SubjectId;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }

        }

        //Update Subject (async)
        public async Task<SubjectDTO> UpdateSubjectAsync(SubjectDTO modelDTO)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    SubjectModel model = _Mapper_ToModel.Map<SubjectDTO, SubjectModel>(modelDTO);

                    bool result = unitOfWork.SubjectRepository.Update(model);

                    SubjectDTO modelRTN = null;
                    if (result)
                    {
                        await unitOfWork.SaveChangesAsync();
                        modelRTN = _Mapper_ToDTO.Map<SubjectModel, SubjectDTO>(model);

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

        //Remove a Subject by Id (async)
        public async Task<int> RemoveSubjectAsync(int SubjectId)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    var entity = unitOfWork.SubjectRepository.GetSingleOrDefaultSubject(x => x.SubjectId == SubjectId);
                    if (entity == null)
                    {
                        return 0;
                    }
                    else
                    {
                        unitOfWork.SubjectRepository.Remove(entity);
                        await unitOfWork.SaveChangesAsync();
                        return entity.SubjectId;
                    }

                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Get List of all Subjects (async)
        public async Task<List<SubjectDTO>> GetAllSubject()
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    var models = await Task.Run(() => unitOfWork.SubjectRepository.GetAllSubjects().ToList());
                    var temp = _Mapper_ToDTO.Map<List<SubjectModel>, List<SubjectDTO>>(models);
                    foreach (var m in temp)
                    {
                        m.StandardIds = unitOfWork.SubjectRepository.GetAllStandardsBySubjectId(m.SubjectId).ToList();
                        m.BookIds = unitOfWork.SubjectRepository.GetAllBooksBySubjectId(m.SubjectId).ToList();
                        m.TeacherIds = unitOfWork.SubjectRepository.GetAllTeachersBySubjectId(m.SubjectId).ToList();
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

        //Find Single Subject base on "term" (async)
        public async Task<SubjectDTO> SearchSingleSubjectByNameAsync(string term)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    SubjectModel model = await Task.Run(() => unitOfWork.SubjectRepository.GetSingleOrDefaultSubject(x => x.SubjectName.Contains(term)));
                    return _Mapper_ToDTO.Map<SubjectModel, SubjectDTO>(model);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Is Subject Exists
        public bool IsSubjectExistsById(int SubjectId)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    return unitOfWork.SubjectRepository.Exists(x => x.SubjectId == SubjectId);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Search Subjects based on "term/string"
        public List<SubjectDTO> SearchSubjectsByNameAsync(string term)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    List<SubjectModel> models = unitOfWork.SubjectRepository.FindSubject(x => x.SubjectName.Contains(term)).ToList();

                    return _Mapper_ToDTO.Map<List<SubjectModel>, List<SubjectDTO>>(models);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Find Single Subject base on "term" (async)
        public async Task<SubjectDTO> SearchSingleSubjectByIdAsync(int Id)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    SubjectModel model = await Task.Run(() => unitOfWork.SubjectRepository.GetSingleOrDefaultSubject(x => x.SubjectId == Id));
                    return _Mapper_ToDTO.Map<SubjectModel, SubjectDTO>(model);
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
