using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ParentDTO
    {
        public int ParentId { get; set; }
        public string ParentName { get; set; }
        public string RelationType { get; set; }//Mother or Father etc
        public string ParentAddress1 { get; set; }
        public string ParentAddress2 { get; set; }
        public string ParentPostCode { get; set; }
        public string ParentTelephone { get; set; }
        public string ParentEmail { get; set; }

        public string UserId { get; set; }

        public string _ImageFileUrl { get; set; }
        public int ImageFileUrlId { get; set; }
        public ImageFileUrlDTO ImageFileUrl { get; set; }

        public ICollection<int> StudentIds { get; set; }
        public ICollection<StudentDTO> Students { get; set; }
    }
}
