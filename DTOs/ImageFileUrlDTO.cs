using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ImageFileUrlDTO
    {
        public int ImageFileUrlId { get; set; }
        public string Url { get; set; }
        public DateTime? CreateDate { get; set; }

        public int ImageFileTypeId { get; set; }

        public ImageFileTypeDTO ImageFileType { get; set; }
        public ParentDTO Parent { get; set; }
        public TeacherDTO Teacher { get; set; }
        public BookDTO Book { get; set; }
        public StudentDTO Student { get; set; }
        public SchoolDTO School { get; set; }
        public AssessmentDTO Assessment { get; set; }
        public HomeworkDTO Homework { get; set; }
        public EventDTO Event { get; set; }
        public AttendanceDTO Attendance { get; set; }
        public OperationalStaffDTO OperationalStaff { get; set; }
    }
}
