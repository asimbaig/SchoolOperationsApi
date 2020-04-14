using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Models
{
    public class AssessmentModel
    {
        [Key]
        public int AssessmentId { get;  set; }
        public string AssessmentName { get; set; }
        [Column(TypeName = "datetime2")]
        public Nullable<DateTime> AssessmentDate { get; set; }
        public bool IsDeleted { get; set; }

        public int StandardId { get; set; }

        public virtual ImageFileUrlModel ImageFileUrl { get; set; }
        public virtual StandardModel Standard { get; set; }
    }
}
