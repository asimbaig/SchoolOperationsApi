using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Models
{
    public class SubjectModel
    {
        //[Key]
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<StandardModel> Standards { get; set; }
        public virtual ICollection<BookModel> Books { get; set; }
        public virtual ICollection<TeacherModel> Teachers { get; set; }
    }
}
