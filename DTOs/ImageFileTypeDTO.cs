using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ImageFileTypeDTO
    {
        public int ImageFileTypeId { get; set; }
        public string Type { get; set; }

        public ICollection<int> ImageFileUrlIds { get; set; }
        public ICollection<ImageFileUrlDTO> ImageFileUrls { get; set; }
    }
}
