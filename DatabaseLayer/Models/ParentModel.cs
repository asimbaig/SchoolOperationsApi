using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Models
{
    public class ParentModel
    {
       // [Key]
        public int ParentId { get; set; }
        public string ParentName { get; set; }
        public string RelationType { get; set; }//Mother or Father etc
        public string ParentAddress1 { get; set; }
        public string ParentAddress2 { get; set; }
        public string ParentPostCode { get; set; }
        public string ParentTelephone { get; set; }
        public string ParentEmail { get; set; }
        public bool IsDeleted { get; set; }

        public string UserId { get; set; }

        public virtual ImageFileUrlModel ImageFileUrl { get; set; }

        public virtual ICollection<StudentModel> Students { get; set; }
    }
}
