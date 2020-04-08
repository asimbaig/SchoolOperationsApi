using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class EventDTO
    {
        public int EventId { get; set; } 
        [Required]
        public string EventName { get; set; }
        [Required]
        public DateTime? EventDate { get; set; }
        public string Location { get; set; }

        public int ImageFileUrlId { get; set; }
        public string _ImageFileUrl { get; set; }
        public ImageFileUrlDTO ImageFileUrl { get; set; }

        public ICollection<int> StudentIds { get; set; }
        public ICollection<StudentDTO> Students { get; set; }
    }
}
