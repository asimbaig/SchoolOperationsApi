using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Models
{
    public class YearModel
    {
        //[Key]
        public int YearId { get; set; }
        public string year { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<StandardModel> Standards { get; set; }
    }
}
