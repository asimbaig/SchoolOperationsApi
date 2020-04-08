using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class BookDTO
    {
        public int BookId { get; set; }
        [Required]
        public string BookName { get; set; }

        [Required]
        public int SubjectId { get; set; }
        public SubjectDTO Subject { get; set; }

        public int ImageFileUrlId { get; set; }
        public string _ImageFileUrl { get; set; }
        public ImageFileUrlDTO ImageFileUrl { get; set; }

        public ICollection<int> BookTransactionIds { get; set; }
        public ICollection<BookTransactionDTO> BookTransactions { get; set; }
    }
}
