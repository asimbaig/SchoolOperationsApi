using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class AttendanceDTO
    {
        public int AttendanceId { get; set; }
        [Required]
        public bool Present { get; set; }
        public DateTime? AttendanceDate { get; set; }

        public int ImageFileUrlId { get; set; }
        public string _ImageFileUrl { get; set; }
        public ImageFileUrlDTO ImageFileUrl { get; set; }

        [Required]
        public int StudentId { get; set; }
        public StudentDTO Student { get; set; }
        public string _StudentName { get; set; }
    }
}
