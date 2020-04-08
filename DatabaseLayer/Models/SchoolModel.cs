using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Models
{
    public class SchoolModel
    {
        //[Key]
        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
        public string SchoolAddress1 { get; set; }
        public string SchoolAddress2 { get; set; }
        public string SchoolPostCode { get; set; }
        public string SchoolTelephone { get; set; }
        public string SchoolWebsite { get; set; }
        public string SchoolEmail { get; set; }
        public bool IsDeleted { get; set; }

        public string UserId { get; set; }

        public virtual ImageFileUrlModel ImageFileUrl { get; set; }
        public virtual ICollection<StandardModel> Standards { get; set; }
        public virtual ICollection<OperationalStaffModel> OperationalStaffs { get; set; }
    }
}
