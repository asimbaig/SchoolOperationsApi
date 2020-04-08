using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class AssessmentDTO
    {
        public AssessmentDTO() { }
        public int AssessmentId { get; set; }
        [Required]
        public string AssessmentName { get; set; }
        public DateTime? AssessmentDate { get; set; }

        public int ImageFileUrlId { get; set; }
        public string _ImageFileUrl { get; set; }
        public ImageFileUrlDTO ImageFileUrl { get; set; }

        [Required]
        public int StandardId { get; set; }
        public StandardDTO Standard { get; set; }
    }
}
