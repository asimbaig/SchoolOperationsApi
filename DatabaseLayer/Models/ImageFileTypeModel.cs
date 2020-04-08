using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Models
{
    public class ImageFileTypeModel
    {
        //[Key]
        public int ImageFileTypeId { get; set; }
        public string Type { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<ImageFileUrlModel> ImageFileUrls { get; set; }
    }
}
