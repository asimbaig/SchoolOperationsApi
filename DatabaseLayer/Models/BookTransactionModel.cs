using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Models
{
    public class BookTransactionModel
    {
        ///[Key]
        public int BookTransactionId { get; set; }
        [Column(TypeName = "datetime2")]
        public Nullable<DateTime> IssueDate { get; set; }
        [Column(TypeName = "datetime2")]
        public Nullable<DateTime> ReturnDate { get; set; }
        public bool IsDeleted { get; set; }

        public int BookId { get; set; }
        public int StudentId { get; set; }

        public virtual BookModel Book { get; set; }
        public virtual StudentModel Student { get; set; }
    }
}
