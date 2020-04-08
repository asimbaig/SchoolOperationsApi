using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Models
{
    public class AttendanceModel
    {
        [Key]
        public int AttendanceId { get; set; }
        public bool Present { get; set; }
        [Column(TypeName = "datetime2")]
        public Nullable<DateTime> AttendanceDate { get; set; }
        public bool IsDeleted { get; set; }

        public int StudentId { get; set; }

        public virtual ImageFileUrlModel ImageFileUrl { get; set; }
        public virtual StudentModel Student { get; set; }
    }
}
