using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Models
{
    public class ApiLog
    {
        [Key]
        public int LogID { get; set; }
        public string Host { get; set; }
        public string Headers { get; set; }
        public string StatusCode { get; set; }
        [Column(TypeName = "datetime2")]
        public Nullable<DateTime> TimeUtc { get; set; }
        public string RequestBody { get; set; }
        public string RequestedMethod { get; set; }
        public string UserHostAddress { get; set; }
        public string Useragent { get; set; }
        public string AbsoluteUri { get; set; }
        public string RequestType { get; set; }
    }
}
