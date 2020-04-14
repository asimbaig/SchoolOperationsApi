using AutoMapper;
using DatabaseLayer.Models;
using DatabaseLayer.UnitOfWork;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Implementations
{
    public class BaseService
    {
        public IUnitOfWorkFactory unitOfWorkFactory;
        public IMapper _Mapper_ToModel, _Mapper_ToDTO;

        public BaseService()
        {
            this.unitOfWorkFactory = new UnitOfWorkFactory();
        }
        public async void LogException(Exception ex)
        {
            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                ExceptionLogger exModel = new ExceptionLogger
                {
                    ExceptionMessage = ex.Message,
                    SourceName = ex.Source,
                    ExceptionStackTrace = ex.StackTrace,
                    LogTime = DateTime.Now
                };
                unitOfWork.ExceptionLoggerRepository.Add(exModel);
                await unitOfWork.SaveChangesAsync();
            }
        }
        public void SetAutoMapper_ExceptionLogger()
        {
            MapperConfiguration _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ExceptionLoggerDTO, ExceptionLogger>();
            });
            _Mapper_ToModel = _mapperConfig.CreateMapper();
        }
        public void SetAutoMapper_Year()
        {
            MapperConfiguration _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<YearDTO, YearModel>();
            });
            _Mapper_ToModel = _mapperConfig.CreateMapper();

            MapperConfiguration _mapperConfigDTO = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;

                cfg.CreateMap<YearModel, YearDTO>()
                    .ForMember(d => d.YearId, s => s.MapFrom(m => m.YearId))
                    .ForMember(d => d.year, s => s.MapFrom(m => m.year))
                    //.ForMember(d => d.StandardIds, s => s.MapFrom(m => m.Standards.Where(x=>x.YearId==m.YearId).ToList()))
                    .ForAllOtherMembers(c => c.Ignore());
            });
            _Mapper_ToDTO = _mapperConfigDTO.CreateMapper();
        }
        public void SetAutoMapper_Teacher()
        {
            MapperConfiguration _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TeacherDTO, TeacherModel>();
                cfg.CreateMap<ImageFileUrlDTO, ImageFileUrlModel>();
                cfg.CreateMap<ImageFileTypeDTO, ImageFileTypeModel>();
            });
            _Mapper_ToModel = _mapperConfig.CreateMapper();

            MapperConfiguration _mapperConfigDTO = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;

                cfg.CreateMap<TeacherModel, TeacherDTO>()
                    .ForMember(d => d.TeacherId, s => s.MapFrom(m => m.TeacherId))
                    .ForMember(d => d.TeacherName, s => s.MapFrom(m => m.TeacherName))
                    .ForMember(d => d.StartDate, s => s.MapFrom(m => m.StartDate))
                    .ForMember(d => d.Tr_Address1, s => s.MapFrom(m => m.Tr_Address1))
                    .ForMember(d => d.Tr_Address2, s => s.MapFrom(m => m.Tr_Address2))
                    .ForMember(d => d.Tr_PostCode, s => s.MapFrom(m => m.Tr_PostCode))
                    .ForMember(d => d.Tr_Email, s => s.MapFrom(m => m.Tr_Email))
                    .ForMember(d => d.Tr_Telephone, s => s.MapFrom(m => m.Tr_Telephone))
                    .ForMember(d => d._ImageFileUrl, s => s.MapFrom(m => m.ImageFileUrl.Url))
                    .ForMember(d => d.UserId, s => s.MapFrom(m => m.UserId))
                    .ForAllOtherMembers(c => c.Ignore());
                cfg.CreateMap<ImageFileTypeModel, ImageFileTypeDTO>()
                                 .ForMember(dest => dest.ImageFileUrls, opt => opt.Ignore());
            });
            _Mapper_ToDTO = _mapperConfigDTO.CreateMapper();
        }
        public void SetAutoMapper_Subject()
        {
            MapperConfiguration _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SubjectDTO, SubjectModel>();
            });
            _Mapper_ToModel = _mapperConfig.CreateMapper();

            MapperConfiguration _mapperConfigDTO = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;

                cfg.CreateMap<SubjectModel, SubjectDTO>()
                                .ForMember(d => d.SubjectId, s => s.MapFrom(m => m.SubjectId))
                                .ForMember(d => d.SubjectName, s => s.MapFrom(m => m.SubjectName))
                                .ForAllOtherMembers(c => c.Ignore());
            });
            _Mapper_ToDTO = _mapperConfigDTO.CreateMapper();
        }
        public void SetAutoMapper_Student()
        {
            MapperConfiguration _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StudentDTO, StudentModel>();
                cfg.CreateMap<ImageFileUrlDTO, ImageFileUrlModel>();
                cfg.CreateMap<ImageFileTypeDTO, ImageFileTypeModel>();
            });
            _Mapper_ToModel = _mapperConfig.CreateMapper();

            MapperConfiguration _mapperConfigDTO = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;

                cfg.CreateMap<StudentModel, StudentDTO>()
                                .ForMember(d => d.StudentId, s => s.MapFrom(m => m.StudentId))
                                .ForMember(d => d.St_Name, s => s.MapFrom(m => m.St_Name))
                                .ForMember(d => d.EnrolmentDate, s => s.MapFrom(m => m.EnrolmentDate))
                                .ForMember(d => d.St_Address1, s => s.MapFrom(m => m.St_Address1))
                                .ForMember(d => d.St_Address2, s => s.MapFrom(m => m.St_Address2))
                                .ForMember(d => d.St_PostCode, s => s.MapFrom(m => m.St_PostCode))
                                .ForMember(d => d.St_Email, s => s.MapFrom(m => m.St_Email))
                                .ForMember(d => d.St_Telephone, s => s.MapFrom(m => m.St_Telephone))
                                .ForMember(d => d._ImageFileUrl, s => s.MapFrom(m => m.ImageFileUrl.Url))
                                .ForMember(d => d.StandardId, s => s.MapFrom(m => m.StandardId))
                                .ForMember(d => d.UserId, s => s.MapFrom(m => m.UserId))
                                .ForAllOtherMembers(c => c.Ignore());
                cfg.CreateMap<ImageFileTypeModel, ImageFileTypeDTO>()
                                 .ForMember(dest => dest.ImageFileUrls, opt => opt.Ignore());

            });
            _Mapper_ToDTO = _mapperConfigDTO.CreateMapper();
        }
        public void SetAutoMapper_Standard()
        {
            MapperConfiguration _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StandardDTO, StandardModel>();
            });
            _Mapper_ToModel = _mapperConfig.CreateMapper();

            MapperConfiguration _mapperConfigDTO = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;

                cfg.CreateMap<StandardModel, StandardDTO>()
                                .ForMember(d => d.StandardId, s => s.MapFrom(m => m.StandardId))
                                .ForMember(d => d.StandardName, s => s.MapFrom(m => m.StandardName))
                                .ForMember(d => d.SchoolId, s => s.MapFrom(m => m.SchoolId))
                                .ForMember(d => d.YearId, s => s.MapFrom(m => m.YearId))
                                .ForAllOtherMembers(c => c.Ignore());
            });
            _Mapper_ToDTO = _mapperConfigDTO.CreateMapper();
        }
        public void SetAutoMapper_ImageFileType()
        {
            MapperConfiguration _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ImageFileTypeDTO, ImageFileTypeModel>();
            });
            _Mapper_ToModel = _mapperConfig.CreateMapper();

            MapperConfiguration _mapperConfigDTO = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.CreateMap<ImageFileTypeModel, ImageFileTypeDTO>()
                                    .ForMember(d => d.ImageFileTypeId, s => s.MapFrom(m => m.ImageFileTypeId))
                                    .ForMember(d => d.Type, s => s.MapFrom(m => m.Type))
                                    .ForAllOtherMembers(c => c.Ignore());
            });
            _Mapper_ToDTO = _mapperConfigDTO.CreateMapper();
        }
        public void SetAutoMapper_ImageFileUrl()
        {
            MapperConfiguration _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ImageFileUrlDTO, ImageFileUrlModel>();
            });
            _Mapper_ToModel = _mapperConfig.CreateMapper();

            MapperConfiguration _mapperConfigDTO = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;

                cfg.CreateMap<ImageFileUrlModel, ImageFileUrlDTO>()
                                       .ForMember(d => d.ImageFileUrlId, s => s.MapFrom(m => m.ImageFileUrlId))
                                       .ForMember(d => d.CreateDate, s => s.MapFrom(m => m.CreateDate))
                                       .ForMember(d => d.ImageFileTypeId, s => s.MapFrom(m => m.ImageFileTypeId))
                                       .ForMember(d => d.Url, s => s.MapFrom(m => m.Url))
                                       .ForAllOtherMembers(c => c.Ignore());
            });
            _Mapper_ToDTO = _mapperConfigDTO.CreateMapper();
        }
        public void SetAutoMapper_Homework()
        {
            MapperConfiguration _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<HomeworkDTO, HomeworkModel>();
                cfg.CreateMap<ImageFileUrlDTO, ImageFileUrlModel>();
                cfg.CreateMap<ImageFileTypeDTO, ImageFileTypeModel>();
            });
            _Mapper_ToModel = _mapperConfig.CreateMapper();

            MapperConfiguration _mapperConfigDTO = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;

                cfg.CreateMap<HomeworkModel, HomeworkDTO>()
                                .ForMember(d => d.HomeworkId, s => s.MapFrom(m => m.HomeworkId))
                                .ForMember(d => d.HomeworkName, s => s.MapFrom(m => m.HomeworkName))
                                .ForMember(d => d.IssueDate, s => s.MapFrom(m => m.IssueDate))
                                .ForMember(d => d.DueDate, s => s.MapFrom(m => m.DueDate))
                                .ForMember(d => d._ImageFileUrl, s => s.MapFrom(m => m.ImageFileUrl.Url))
                                .ForMember(d => d.StandardId, s => s.MapFrom(m => m.StandardId))
                                .ForAllOtherMembers(c => c.Ignore());
                cfg.CreateMap<ImageFileTypeModel, ImageFileTypeDTO>()
                                    .ForMember(dest => dest.ImageFileUrls, opt => opt.Ignore());
            });
            _Mapper_ToDTO = _mapperConfigDTO.CreateMapper();
        }
        public void SetAutoMapper_Event()
        {
            MapperConfiguration _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EventDTO, EventModel>();
                cfg.CreateMap<ImageFileUrlDTO, ImageFileUrlModel>();
                cfg.CreateMap<ImageFileTypeDTO, ImageFileTypeModel>();
            });
            _Mapper_ToModel = _mapperConfig.CreateMapper();

            MapperConfiguration _mapperConfigDTO = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;

                cfg.CreateMap<EventModel, EventDTO>()
                            .ForMember(d => d.EventId, s => s.MapFrom(m => m.EventId))
                            .ForMember(d => d.EventName, s => s.MapFrom(m => m.EventName))
                            .ForMember(d => d.EventDate, s => s.MapFrom(m => m.EventDate))
                            .ForMember(d => d.Location, s => s.MapFrom(m => m.Location))
                            .ForMember(d => d._ImageFileUrl, s => s.MapFrom(m => m.ImageFileUrl.Url))
                            .ForAllOtherMembers(c => c.Ignore());
                cfg.CreateMap<ImageFileTypeModel, ImageFileTypeDTO>()
                                    .ForMember(dest => dest.ImageFileUrls, opt => opt.Ignore());

            });
            _Mapper_ToDTO = _mapperConfigDTO.CreateMapper();
        }
        public void SetAutoMapper_BookTransaction()
        {
            MapperConfiguration _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BookTransactionDTO, BookTransactionModel>();
            });
            _Mapper_ToModel = _mapperConfig.CreateMapper();

            MapperConfiguration _mapperConfigDTO = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;

                cfg.CreateMap<BookTransactionModel, BookTransactionDTO>()
                                    .ForMember(d => d.BookTransactionId, s => s.MapFrom(m => m.BookTransactionId))
                                    .ForMember(d => d.IssueDate, s => s.MapFrom(m => m.IssueDate))
                                    .ForMember(d => d.ReturnDate, s => s.MapFrom(m => m.ReturnDate))
                                    .ForMember(d => d.StudentId, s => s.MapFrom(m => m.StudentId))
                                    .ForMember(d => d.BookId, s => s.MapFrom(m => m.BookId))
                                    .ForAllOtherMembers(c => c.Ignore());
            });
            _Mapper_ToDTO = _mapperConfigDTO.CreateMapper();
        }
        public void SetAutoMapper_Book()
        {
            MapperConfiguration _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BookDTO, BookModel>();
                cfg.CreateMap<ImageFileUrlDTO, ImageFileUrlModel>();
                cfg.CreateMap<ImageFileTypeDTO, ImageFileTypeModel>();
            });
            _Mapper_ToModel = _mapperConfig.CreateMapper();

            MapperConfiguration _mapperConfigDTO = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;

                cfg.CreateMap<BookModel, BookDTO>()
                                    .ForMember(d => d.BookId, s => s.MapFrom(m => m.BookId))
                                    .ForMember(d => d.BookName, s => s.MapFrom(m => m.BookName))
                                    .ForMember(d => d.SubjectId, s => s.MapFrom(m => m.SubjectId))
                                    .ForMember(d => d._ImageFileUrl, s => s.MapFrom(m => m.ImageFileUrl.Url))
                                    .ForAllOtherMembers(c => c.Ignore());
                cfg.CreateMap<ImageFileTypeModel, ImageFileTypeDTO>()
                                    .ForMember(dest => dest.ImageFileUrls, opt => opt.Ignore());
            });
            _Mapper_ToDTO = _mapperConfigDTO.CreateMapper();
        }
        public void SetAutoMapper_Attendance()
        {
            MapperConfiguration _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AttendanceDTO, AttendanceModel>();
                cfg.CreateMap<ImageFileUrlDTO, ImageFileUrlModel>();
                cfg.CreateMap<ImageFileTypeDTO, ImageFileTypeModel>();
            });
            _Mapper_ToModel = _mapperConfig.CreateMapper();

            MapperConfiguration _mapperConfigDTO = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;

                cfg.CreateMap<AttendanceModel, AttendanceDTO>()
                            .ForMember(d => d.AttendanceId, s => s.MapFrom(m => m.AttendanceId))
                            .ForMember(d => d.AttendanceDate, s => s.MapFrom(m => m.AttendanceDate))
                            .ForMember(d => d.Present, s => s.MapFrom(m => m.Present))
                            .ForMember(d => d.StudentId, s => s.MapFrom(m => m.StudentId))
                            .ForMember(d => d._ImageFileUrl, s => s.MapFrom(m => m.ImageFileUrl.Url))
                            .ForAllOtherMembers(c => c.Ignore());
                cfg.CreateMap<ImageFileTypeModel, ImageFileTypeDTO>()
                                    .ForMember(dest => dest.ImageFileUrls, opt => opt.Ignore());
            });
            _Mapper_ToDTO = _mapperConfigDTO.CreateMapper();
        }
        public void SetAutoMapper_Assessment()
        {
            MapperConfiguration _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AssessmentDTO, AssessmentModel>();
                cfg.CreateMap<ImageFileUrlDTO, ImageFileUrlModel>();
                cfg.CreateMap<ImageFileTypeDTO, ImageFileTypeModel>();
            });
            _Mapper_ToModel = _mapperConfig.CreateMapper();

            MapperConfiguration _mapperConfigDTO = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;

                cfg.CreateMap<AssessmentModel, AssessmentDTO>()
                            .ForMember(d => d.AssessmentId, c => c.MapFrom(m => m.AssessmentId))
                            .ForMember(d => d.AssessmentName, c => c.MapFrom(m => m.AssessmentName))
                            .ForMember(d => d.AssessmentDate, c => c.MapFrom(m => m.AssessmentDate))
                            .ForMember(d => d.StandardId, c => c.MapFrom(m => m.StandardId))
                            .ForMember(d => d._ImageFileUrl, c => c.MapFrom(m => m.ImageFileUrl.Url))
                            .ForAllOtherMembers(c => c.Ignore());
                cfg.CreateMap<ImageFileTypeModel, ImageFileTypeDTO>()
                                    .ForMember(dest => dest.ImageFileUrls, opt => opt.Ignore());
            });
            _Mapper_ToDTO = _mapperConfigDTO.CreateMapper();
        }
        public void SetAutoMapper_Parent()
        {
            MapperConfiguration _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ParentDTO, ParentModel>();
                cfg.CreateMap<ImageFileUrlDTO, ImageFileUrlModel>();
                cfg.CreateMap<ImageFileTypeDTO, ImageFileTypeModel>();
            });
            _Mapper_ToModel = _mapperConfig.CreateMapper();

            MapperConfiguration _mapperConfigDTO = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;

                cfg.CreateMap<ParentModel, ParentDTO>()
                            .ForMember(d => d.ParentId, s => s.MapFrom(m => m.ParentId))
                            .ForMember(d => d.ParentName, s => s.MapFrom(m => m.ParentName))
                            .ForMember(d => d.ParentAddress1, s => s.MapFrom(m => m.ParentAddress1))
                            .ForMember(d => d.ParentAddress2, s => s.MapFrom(m => m.ParentAddress2))
                            .ForMember(d => d.ParentPostCode, s => s.MapFrom(m => m.ParentPostCode))
                            .ForMember(d => d.ParentEmail, s => s.MapFrom(m => m.ParentEmail))
                            .ForMember(d => d.ParentTelephone, s => s.MapFrom(m => m.ParentTelephone))
                            .ForMember(d => d.RelationType, s => s.MapFrom(m => m.RelationType))
                            .ForMember(d => d._ImageFileUrl, s => s.MapFrom(m => m.ImageFileUrl.Url))
                            .ForMember(d => d.UserId, s => s.MapFrom(m => m.UserId))
                            .ForAllOtherMembers(c => c.Ignore());
                cfg.CreateMap<ImageFileTypeModel, ImageFileTypeDTO>()
                                .ForMember(dest => dest.ImageFileUrls, opt => opt.Ignore());
            });
            _Mapper_ToDTO = _mapperConfigDTO.CreateMapper();
        }
        public void SetAutoMapper_School()
        {
            MapperConfiguration _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SchoolDTO, SchoolModel>();
                cfg.CreateMap<ImageFileUrlDTO, ImageFileUrlModel>();
                cfg.CreateMap<ImageFileTypeDTO, ImageFileTypeModel>();
            });
            _Mapper_ToModel = _mapperConfig.CreateMapper();

            MapperConfiguration _mapperConfigDTO = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;

                cfg.CreateMap<SchoolModel, SchoolDTO>()
                            .ForMember(d => d.SchoolId, s => s.MapFrom(m => m.SchoolId))
                            .ForMember(d => d.SchoolName, s => s.MapFrom(m => m.SchoolName))
                            .ForMember(d => d.SchoolAddress1, s => s.MapFrom(m => m.SchoolAddress1))
                            .ForMember(d => d.SchoolAddress2, s => s.MapFrom(m => m.SchoolAddress2))
                            .ForMember(d => d.SchoolPostCode, s => s.MapFrom(m => m.SchoolPostCode))
                            .ForMember(d => d.SchoolTelephone, s => s.MapFrom(m => m.SchoolTelephone))
                            .ForMember(d => d.SchoolWebsite, s => s.MapFrom(m => m.SchoolWebsite))
                            .ForMember(d => d._ImageFileUrl, s => s.MapFrom(m => m.ImageFileUrl.Url))
                            .ForAllOtherMembers(c => c.Ignore());
                cfg.CreateMap<ImageFileTypeModel, ImageFileTypeDTO>()
                                    .ForMember(dest => dest.ImageFileUrls, opt => opt.Ignore());
            });
            _Mapper_ToDTO = _mapperConfigDTO.CreateMapper();
        }
        public void SetAutoMapper_ApiLog()
        {
            MapperConfiguration _mapperConfig = new MapperConfiguration(cfg => {
                cfg.CreateMap<ApiLogDTO, ApiLog>().MaxDepth(1);
            });
            _Mapper_ToModel = _mapperConfig.CreateMapper();
            MapperConfiguration _mapperConfig_ToDTO = new MapperConfiguration(cfg => {
                cfg.CreateMap<ApiLog, ApiLogDTO>().MaxDepth(1);
            });
            _Mapper_ToDTO = _mapperConfig_ToDTO.CreateMapper();
        }
        public void SetAutoMapper_OperationalStaff()
        {
            MapperConfiguration _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OperationalStaffDTO, OperationalStaffModel>();
                cfg.CreateMap<ImageFileUrlDTO, ImageFileUrlModel>();
                cfg.CreateMap<ImageFileTypeDTO, ImageFileTypeModel>();
            });
            _Mapper_ToModel = _mapperConfig.CreateMapper();

            MapperConfiguration _mapperConfigDTO = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;

                cfg.CreateMap<OperationalStaffModel, OperationalStaffDTO>()
                                    .ForMember(d => d.OpStaffId, s => s.MapFrom(m => m.OpStaffId))
                                    .ForMember(d => d.OpStaffName, s => s.MapFrom(m => m.OpStaffName))
                                    .ForMember(d => d.OpStaffRole, s => s.MapFrom(m => m.OpStaffRole))
                                    .ForMember(d => d.OpStaffAddress1, s => s.MapFrom(m => m.OpStaffAddress1))
                                    .ForMember(d => d.OpStaffAddress2, s => s.MapFrom(m => m.OpStaffAddress2))
                                    .ForMember(d => d.OpStaffPostCode, s => s.MapFrom(m => m.OpStaffPostCode))
                                    .ForMember(d => d.OpStaffTelephone, s => s.MapFrom(m => m.OpStaffTelephone))
                                    .ForMember(d => d.OpStaffEmail, s => s.MapFrom(m => m.OpStaffEmail))
                                    .ForMember(d => d.SchoolId, s => s.MapFrom(m => m.SchoolId))
                                    .ForMember(d => d.StartDate, s => s.MapFrom(m => m.StartDate))
                                    .ForMember(d => d._ImageFileUrl, s => s.MapFrom(m => m.ImageFileUrl.Url))
                                    .ForMember(d => d.UserId, s => s.MapFrom(m => m.UserId))
                                    .ForAllOtherMembers(c => c.Ignore());
                cfg.CreateMap<ImageFileTypeModel, ImageFileTypeDTO>()
                                    .ForMember(dest => dest.ImageFileUrls, opt => opt.Ignore());
            });
            _Mapper_ToDTO = _mapperConfigDTO.CreateMapper();
        }
    }
}