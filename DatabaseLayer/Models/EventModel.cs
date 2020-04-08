using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Models
{
    public class EventModel
    {
        //[Key]
        public int EventId { get; set; }
        public string EventName { get; set; }
        [Column(TypeName = "datetime2")]
        public Nullable<DateTime> EventDate { get; set; }
        public string Location { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ImageFileUrlModel ImageFileUrl { get; set; }
        //public virtual ICollection<ImageFileUrlModel> ImageFileUrls { get; set; }
        public virtual ICollection<StudentModel> Students { get; set; }
    }
}
