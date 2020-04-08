using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Models.Map
{
    public class SchoolMap : EntityTypeConfiguration<SchoolModel>
    {
        public SchoolMap()
        {
            HasKey(x => x.SchoolId);
        }
    }

    public class AssessmentMap : EntityTypeConfiguration<AssessmentModel>
    {
        public AssessmentMap()
        {
            HasKey(x => x.AssessmentId);
            HasRequired(n => n.Standard).WithMany(n => n.Assessments).HasForeignKey(n => n.StandardId).WillCascadeOnDelete(true);
        }
    }

    public class OperationalStaffMap : EntityTypeConfiguration<OperationalStaffModel>
    {
        public OperationalStaffMap()
        {
            HasKey(x => x.OpStaffId);
            HasRequired(n => n.School).WithMany(n => n.OperationalStaffs).HasForeignKey(n => n.SchoolId).WillCascadeOnDelete(true);
        }
    }

    public class AttendanceMap : EntityTypeConfiguration<AttendanceModel>
    {
        public AttendanceMap()
        {
            HasKey(x => x.AttendanceId);
            HasRequired(n => n.Student).WithMany(n => n.Attendances).HasForeignKey(n => n.StudentId).WillCascadeOnDelete(true);
        }
    }

    public class BookMap : EntityTypeConfiguration<BookModel>
    {
        public BookMap()
        {
            HasKey(x => x.BookId);
            HasRequired(n => n.Subject).WithMany(n => n.Books).HasForeignKey(n => n.SubjectId).WillCascadeOnDelete(true);
        }
    }

    public class BookTransactionMap : EntityTypeConfiguration<BookTransactionModel>
    {
        public BookTransactionMap()
        {
            HasKey(x => x.BookTransactionId);
            HasRequired(n => n.Book).WithMany(n => n.BookTransactions).HasForeignKey(n => n.BookId).WillCascadeOnDelete(true);
            HasRequired(n => n.Student).WithMany(n => n.BookTransactions).HasForeignKey(n => n.StudentId).WillCascadeOnDelete(true);
        }
    }

    public class EventMap : EntityTypeConfiguration<EventModel>
    {
        public EventMap()
        {
            HasKey(x => x.EventId);
        }
    }

    public class HomeworkMap : EntityTypeConfiguration<HomeworkModel>
    {
        public HomeworkMap()
        {
            HasKey(x => x.HomeworkId);
            HasRequired(n => n.Standard).WithMany(n => n.Homeworks).HasForeignKey(n => n.StandardId).WillCascadeOnDelete(true);
        }
    }

    public class ImageFileTypeMap : EntityTypeConfiguration<ImageFileTypeModel>
    {
        public ImageFileTypeMap()
        {
            HasKey(x => x.ImageFileTypeId);
        }
    }

    public class ImageFileUrlMap : EntityTypeConfiguration<ImageFileUrlModel>
    {
        public ImageFileUrlMap()
        {
            HasKey(x => x.ImageFileUrlId);

            HasRequired(n => n.ImageFileType).WithMany(n => n.ImageFileUrls).HasForeignKey(n => n.ImageFileTypeId).WillCascadeOnDelete(true);

            HasOptional(s => s.School).WithRequired(a => a.ImageFileUrl);

            HasOptional(s => s.Assessment).WithRequired(a => a.ImageFileUrl);

            HasOptional(s => s.Attendance).WithRequired(a => a.ImageFileUrl);

            HasOptional(s => s.Book).WithRequired(a => a.ImageFileUrl);

            HasOptional(s => s.Homework).WithRequired(a => a.ImageFileUrl);

            HasOptional(s => s.Parent).WithRequired(a => a.ImageFileUrl);

            HasOptional(s => s.Student).WithRequired(a => a.ImageFileUrl);

            HasOptional(s => s.Teacher).WithRequired(a => a.ImageFileUrl);

            HasOptional(s => s.Event).WithRequired(a => a.ImageFileUrl);

            HasOptional(s => s.OperationalStaff).WithRequired(a => a.ImageFileUrl);
        }
    }

    public class ParentMap : EntityTypeConfiguration<ParentModel>
    {
        public ParentMap()
        {
            HasKey(x => x.ParentId);
        }
    }

    public class StandardMap : EntityTypeConfiguration<StandardModel>
    {
        public StandardMap()
        {
            HasKey(x => x.StandardId);
            HasRequired(n => n.School).WithMany(n => n.Standards).HasForeignKey(n => n.SchoolId).WillCascadeOnDelete(true);
            HasRequired(n => n.Year).WithMany(n => n.Standards).HasForeignKey(n => n.YearId).WillCascadeOnDelete(true);
        }
    }

    public class StudentMap : EntityTypeConfiguration<StudentModel>
    {
        public StudentMap()
        {
            HasKey(x => x.StudentId);
            HasRequired(n => n.Standard).WithMany(n => n.Students).HasForeignKey(n => n.StandardId).WillCascadeOnDelete(true);
        }
    }

    public class SubjectMap : EntityTypeConfiguration<SubjectModel>
    {
        public SubjectMap()
        {
            HasKey(x => x.SubjectId);
        }
    }

    public class TeacherMap : EntityTypeConfiguration<TeacherModel>
    {
        public TeacherMap()
        {
            HasKey(x => x.TeacherId);
        }
    }

    public class YearMap : EntityTypeConfiguration<YearModel>
    {
        public YearMap()
        {
            HasKey(x => x.YearId);
        }
    }

    public class ExceptionLoggerMap : EntityTypeConfiguration<ExceptionLogger>
    {
        public ExceptionLoggerMap()
        {
            HasKey(x => x.Id);
        }
    }
    public class ApiLogMap : EntityTypeConfiguration<ApiLog>
    {
        public ApiLogMap()
        {
            HasKey(x => x.LogID);
        }
    }
}
