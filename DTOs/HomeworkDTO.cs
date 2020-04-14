using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class HomeworkDTO
    {
        public int HomeworkId { get; set; }
        [Required]
        public string HomeworkName { get; set; }
        [Required]
        public DateTime? IssueDate { get; set; }
        public DateTime? DueDate { get; set; }

        public int ImageFileUrlId { get; set; }
        public string _ImageFileUrl { get; set; }
        public ImageFileUrlDTO ImageFileUrl { get; set; }

        public int StandardId { get; set; }
        public StandardDTO Standard { get; set; }
        public string _StandardName { get; set; }
    }
}
