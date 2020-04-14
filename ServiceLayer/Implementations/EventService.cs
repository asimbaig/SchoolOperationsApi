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
    public class EventService : BaseService, IEventService
    {
        public EventService() : base()
        {
            SetAutoMapper_Event();
        }

        //Add Event (async)
        public async Task<int> AddEventAsync(EventDTO modelDTO)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    if (!string.IsNullOrEmpty(modelDTO._ImageFileUrl))
                    {
                        var tempImageTypeModel = unitOfWork.ImageFileTypeRepository.GetSingleOrDefaultImageFileType(x => x.Type.Contains("EventImage"));

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
                    //if (modelDTO._ImageFileUrls.Count() > 0)
                    //{
                    //    var tempImageType = unitOfWork.ImageFileTypeRepository.GetSingleOrDefaultImageFileType(x => x.Type.Contains("EventImage"));

                    //    foreach (var img in modelDTO._ImageFileUrls)
                    //    {
                    //        modelDTO.ImageFileUrls.Add(new ImageFileUrlDTO()
                    //        {
                    //            Url = img,
                    //            CreateDate = DateTime.Now,
                    //            ImageFileType = new ImageFileTypeDTO { ImageFileTypeId = tempImageType.ImageFileTypeId, Type = tempImageType.Type }
                    //        });
                    //    }
                    //}

                    EventModel model = _Mapper_ToModel.Map<EventDTO, EventModel>(modelDTO);

                    unitOfWork.EventRepository.Add(model);
                    //unitOfWork.Repository.Add<EventModel>(model);
                    await unitOfWork.SaveChangesAsync();
                    return model.EventId;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }

        }

        //Update Event (async)
        public async Task<EventDTO> UpdateEventAsync(EventDTO modelDTO)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    if (!string.IsNullOrEmpty(modelDTO._ImageFileUrl))
                    {
                        var tempImageTypeModel = unitOfWork.ImageFileTypeRepository.GetSingleOrDefaultImageFileType(x => x.Type.Contains("EventImage"));

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


                    EventModel model = _Mapper_ToModel.Map<EventDTO, EventModel>(modelDTO);

                    bool result = unitOfWork.EventRepository.Update(model);

                    EventDTO modelRTN = null;
                    if (result)
                    {
                        await unitOfWork.SaveChangesAsync();
                        modelRTN = _Mapper_ToDTO.Map<EventModel, EventDTO>(model);
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

        //Remove a Event by Id (async)
        public async Task<int> RemoveEventAsync(int EventId)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    var entity = unitOfWork.EventRepository.GetSingleOrDefaultEvent(x => x.EventId == EventId);
                    if (entity == null)
                    {
                        return 0;
                    }
                    else
                    {
                        unitOfWork.EventRepository.Remove(entity);
                        await unitOfWork.SaveChangesAsync();
                        return entity.EventId;
                    }

                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Get List of all Events (async)
        public async Task<List<EventDTO>> GetAllEvent()
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    var models = await Task.Run(() => unitOfWork.EventRepository.GetAllEvents().ToList());
                    //var temp = _Mapper_ToDTO.Map<List<EventModel>, List<EventDTO>>(models);

                    //foreach (var m in temp)
                    //{
                    //    m.StudentIds = unitOfWork.EventRepository.GetAllStudentsByEventId(m.EventId).ToList();
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

        //Find Single Event base on "term" (async)
        public async Task<EventDTO> SearchSingleEventByNameAsync(string term)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    EventModel model = await Task.Run(() => unitOfWork.EventRepository.GetSingleOrDefaultEvent(x => x.EventName.Contains(term)));
                    return _Mapper_ToDTO.Map<EventModel, EventDTO>(model);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Is Event Exists
        public bool IsEventExistsById(int EventId)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    return unitOfWork.EventRepository.Exists(x => x.EventId == EventId);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Search Events based on "term/string"
        public List<EventDTO> SearchEventsByEventNameAsync(string term)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    List<EventModel> models = unitOfWork.EventRepository.FindEvent(x => x.EventName.Contains(term)).ToList();

                    return _Mapper_ToDTO.Map<List<EventModel>, List<EventDTO>>(models);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Find Single Event base on "term" (async)
        public async Task<EventDTO> SearchSingleEventByIdAsync(int Id)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    EventModel model = await Task.Run(() => unitOfWork.EventRepository.GetSingleOrDefaultEvent(x => x.EventId == Id));
                    return _Mapper_ToDTO.Map<EventModel, EventDTO>(model);
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
