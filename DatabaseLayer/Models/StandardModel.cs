using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Models
{
    public class StandardModel
    {
        //[Key]
        public int StandardId { get; set; }
        public string StandardName { get; set; }
        public bool IsDeleted { get; set; }

        public int SchoolId { get; set; }
        public int YearId { get; set; }

        public virtual SchoolModel School { get; set; }
        public virtual YearModel Year { get; set; }

        public virtual ICollection<SubjectModel> Subjects { get; set; }
        public virtual ICollection<AssessmentModel> Assessments { get; set; }
        public virtual ICollection<HomeworkModel> Homeworks { get; set; }
        public virtual ICollection<StudentModel> Students { get; set; }
        public virtual ICollection<TeacherModel> Teachers { get; set; }
    }
}
