using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Models
{
    public class StudentModel
    {
        //[Key]
        public int StudentId { get; set; }
        public string St_Name { get; set; }
        [Column(TypeName = "datetime2")]
        public Nullable<DateTime> EnrolmentDate { get; set; }
        public string St_Address1 { get; set; }
        public string St_Address2 { get; set; }
        public string St_PostCode { get; set; }
        public string St_Telephone { get; set; }
        public string St_Email { get; set; }
        public bool IsDeleted { get; set; }

        public string UserId { get; set; }

        public virtual ImageFileUrlModel ImageFileUrl { get; set; }
        public int StandardId { get; set; }
        public virtual StandardModel Standard { get; set; }
        
        public virtual ICollection<BookTransactionModel> BookTransactions { get; set; }
        public virtual ICollection<AttendanceModel> Attendances { get; set; }
        public virtual ICollection<EventModel> Events { get; set; }
        public virtual ICollection<ParentModel> Parents { get; set; }
    }
}
