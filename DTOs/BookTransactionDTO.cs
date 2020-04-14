using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class BookTransactionDTO
    {
        public int BookTransactionId { get; set; }
        [Required]
        public DateTime? IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        [Required]
        public int BookId { get; set; }
        [Required]
        public int StudentId { get; set; }

        public BookDTO Book { get; set; }
        public StudentDTO Student { get; set; }

        public string _BookName { get; set; }
        public string _StudentName { get; set; }
    }
}
