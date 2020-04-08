using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Models
{
    public class ImageFileUrlModel
    {
        //[Key]
        public int ImageFileUrlId { get; set; }
        public string Url { get; set; }
        [Column(TypeName = "datetime2")]
        public Nullable<DateTime> CreateDate { get; set; }
        public bool IsDeleted { get; set; }

        public int ImageFileTypeId { get; set; }
        
        public virtual ImageFileTypeModel ImageFileType { get; set; }
        public virtual ParentModel Parent { get; set; }
        public virtual TeacherModel Teacher { get; set; }
        public virtual BookModel Book { get; set; }
        public virtual StudentModel Student { get; set; }
        public virtual SchoolModel School { get; set; }
        public virtual AssessmentModel Assessment { get; set; }
        public virtual HomeworkModel Homework { get; set; }
        public virtual EventModel Event { get; set; }
        public virtual AttendanceModel Attendance { get; set; }
        public virtual OperationalStaffModel OperationalStaff { get; set; }
    }
}
