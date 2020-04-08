using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Models
{
    public class OperationalStaffModel
    {
        public int OpStaffId { get; set; }
        public string OpStaffName { get; set; }
        public string OpStaffRole { get; set; }
        public DateTime? StartDate { get; set; }
        public string OpStaffAddress1 { get; set; }
        public string OpStaffAddress2 { get; set; }
        public string OpStaffPostCode { get; set; }
        public string OpStaffTelephone { get; set; }
        public string OpStaffEmail { get; set; }
        public bool IsDeleted { get; set; }

        public string UserId { get; set; }

        public int SchoolId { get; set; }

        public virtual ImageFileUrlModel ImageFileUrl { get; set; }

        public virtual SchoolModel School { get; set; }
    }
}
