using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class SchoolDTO
    {
        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
        public string SchoolAddress1 { get; set; }
        public string SchoolAddress2 { get; set; }
        public string SchoolPostCode { get; set; }
        public string SchoolTelephone { get; set; }
        public string SchoolWebsite { get; set; }

        public string _ImageFileUrl { get; set; }
        public int ImageFileUrlId { get; set; }
        public ImageFileUrlDTO ImageFileUrl { get; set; }

        public ICollection<int> StandardIds { get; set; }
        public ICollection<int> OperationalStaffIds { get; set; }
        public ICollection<StandardDTO> Standards { get; set; }
        public ICollection<OperationalStaffDTO> OperationalStaffs { get; set; }

        public ICollection<string> _StandardNames { get; set; }
        public ICollection<string> _StaffNames { get; set; }
    }
}
