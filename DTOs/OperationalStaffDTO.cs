using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public class OperationalStaffDTO
    {
        public int OpStaffId { get; set; }
        [Required]
        public string OpStaffName { get; set; }
        [Required]
        public string OpStaffRole { get; set; }
        public DateTime? StartDate { get; set; }
        public string OpStaffAddress1 { get; set; }
        public string OpStaffAddress2 { get; set; }
        public string OpStaffPostCode { get; set; }
        public string OpStaffTelephone { get; set; }
        public string OpStaffEmail { get; set; }
        public bool IsDeleted { get; set; }

        public int ImageFileUrlId { get; set; }
        public string _ImageFileUrl { get; set; }
        public virtual ImageFileUrlDTO ImageFileUrl { get; set; }

        public string UserId { get; set; }
        [Required]
        public int SchoolId { get; set; }
        public virtual SchoolDTO School { get; set; }
    }
}
