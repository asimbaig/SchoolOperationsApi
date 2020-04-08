using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class TeacherDTO
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string Tr_Address1 { get; set; }
        public string Tr_Address2 { get; set; }
        public string Tr_PostCode { get; set; }
        public string Tr_Telephone { get; set; }
        public string Tr_Email { get; set; }

        public string UserId { get; set; }

        public int ImageFileUrlId { get; set; }
        public string _ImageFileUrl { get; set; }
        public ImageFileUrlDTO ImageFileUrl { get; set; }

        public ICollection<int> StandardIds { get; set; }
        public ICollection<int> SubjectIds { get; set; }

        public ICollection<StandardDTO> Standards { get; set; }
        public ICollection<SubjectDTO> Subjects { get; set; }
    }
}
