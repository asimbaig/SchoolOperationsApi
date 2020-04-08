using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Models
{
    public class TeacherModel
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public Nullable<DateTime> StartDate { get; set; }
        public string Tr_Address1 { get; set; }
        public string Tr_Address2 { get; set; }
        public string Tr_PostCode { get; set; }
        public string Tr_Telephone { get; set; }
        public string Tr_Email { get; set; }
        public bool IsDeleted { get; set; }

        public string UserId { get; set; }

        public virtual ImageFileUrlModel ImageFileUrl { get; set; }

        public virtual ICollection<StandardModel> Standards { get; set; }
        public virtual ICollection<SubjectModel> Subjects { get; set; }
    }
}
