using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Models
{
    public class BookModel
    {
        //[Key]
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string SerialNumber { get; set; }
        public bool IsDeleted { get; set; }

        public int SubjectId { get; set; }

        public virtual ImageFileUrlModel ImageFileUrl { get; set; }
        public virtual SubjectModel Subject { get; set; }
        public virtual ICollection<BookTransactionModel> BookTransactions { get; set; }
    }
}
