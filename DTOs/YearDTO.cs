using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class YearDTO
    {
        public int YearId { get; set; }
        public string year { get; set; }

        public ICollection<int> StandardIds { get; set; }
        public ICollection<StandardDTO> Standards { get; set; }

        public ICollection<string> _StandardNames { get; set; }
    }
}
