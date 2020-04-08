using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class StandardDTO
    {
        public int StandardId { get; set; }
        public string StandardName { get; set; }

        public int SchoolId { get; set; }
        public int YearId { get; set; }

        public SchoolDTO School { get; set; }
        public YearDTO Year { get; set; }

        public ICollection<int> SubjectIds { get; set; }
        public ICollection<int> AssessmentIds { get; set; }
        public ICollection<int> HomeworkIds { get; set; }
        public ICollection<int> StudentIds { get; set; }
        public ICollection<int> TeacherIds { get; set; }

        public ICollection<SubjectDTO> Subjects { get; set; }
        public ICollection<AssessmentDTO> Assessments { get; set; }
        public ICollection<HomeworkDTO> Homeworks { get; set; }
        public ICollection<StudentDTO> Students { get; set; }
        public ICollection<TeacherDTO> Teachers { get; set; }
    }
}
