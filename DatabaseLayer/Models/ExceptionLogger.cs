using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Models
{
    public class ExceptionLogger
    {
        //[Key]
        public int Id { get; set; }
        public string ExceptionMessage { get; set; }
        public string ControllerName { get; set; }
        public string SourceName { get; set; }
        public string ExceptionStackTrace { get; set; }
        [Column(TypeName = "datetime2")]
        public Nullable<DateTime> LogTime { get; set; }
        
    }
}
