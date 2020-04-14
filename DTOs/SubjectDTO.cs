using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class SubjectDTO
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }

        public ICollection<int> StandardIds { get; set; }
        public ICollection<int> BookIds { get; set; }
        public ICollection<int> TeacherIds { get; set; }

        public ICollection<StandardDTO> Standards { get; set; }
        public ICollection<BookDTO> Books { get; set; }
        public ICollection<TeacherDTO> Teachers { get; set; }

        public ICollection<string> _StandardNames { get; set; }
        public ICollection<string> _BookNames { get; set; }
        public ICollection<string> _TeacherNames { get; set; }
    }
}
