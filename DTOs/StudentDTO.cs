using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class StudentDTO
    {
        public int StudentId { get; set; }
        public string St_Name { get; set; }
        public DateTime? EnrolmentDate { get; set; }
        public string St_Address1 { get; set; }
        public string St_Address2 { get; set; }
        public string St_PostCode { get; set; }
        public string St_Telephone { get; set; }
        public string St_Email { get; set; }

        public int ImageFileUrlId { get; set; }
        public string _ImageFileUrl { get; set; }

        public string UserId { get; set; }
        public int StandardId { get; set; }
        
        public ImageFileUrlDTO ImageFileUrl { get; set; }
        public StandardDTO Standard { get; set; }

        public ICollection<int> BookTransactionIds { get; set; }
        public ICollection<int> AttendanceIds { get; set; }
        public ICollection<int> EventIds { get; set; }
        public ICollection<int> ParentIds { get; set; }

        public ICollection<BookTransactionDTO> BookTransactions { get; set; }
        public ICollection<AttendanceDTO> Attendances { get; set; }
        public ICollection<EventDTO> Events { get; set; }
        public ICollection<ParentDTO> Parents { get; set; }

        public string _StandardName { get; set; }
        public ICollection<string> _EventParticipatings { get; set; }
        public ICollection<string> _ParentNames { get; set; }
    }
}
