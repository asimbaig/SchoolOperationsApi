using DatabaseLayer.Models;
using DTOs;
using SchoolOperationsApi.Common;
using ServiceLayer.Implementations;
using ServiceLayer.Interfaces;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace SchoolOperationsApi.Controllers
{
    [Authorize]
    public class BookController : BaseController
    {
        private readonly IBookService BookService;

        //Constructor
        public BookController()
        {
            this.BookService = new BookService();
        }

        // GET: api/Book/All
        [CustomExceptionFilter]
        [Route("api/Book/All")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllBooks()
        {
            var collection = await (BookService.GetAllBook());

            if (collection != null)
                return Ok(collection);
            else
                return NotFound();
        }

        // GET: api/Book/5
        [ResponseType(typeof(BookModel))]
        [CustomExceptionFilter]
        [HttpGet]
        public async Task<IHttpActionResult> GetBook(int id)
        {
            BookDTO dto = await BookService.SearchSingleBookByIdAsync(id);

            if (dto != null)
                return Ok(dto);
            else
                return NotFound();
        }

        // Post: api/Book/Add
        [ResponseType(typeof(void))]
        [CustomExceptionFilter]
        [Route("api/Book/Add")]
        [HttpPost]
        public async Task<IHttpActionResult> AddBook([FromBody]BookDTO BookModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newBookId = await BookService.AddBookAsync(BookModel);

            if (newBookId != 0)
                return Ok(newBookId);
            else
                return NotFound();
        }

        // PUT: api/Book/Update
        [ResponseType(typeof(void))]
        [CustomExceptionFilter]
        [Route("api/Book/Update")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateBook([FromBody]BookDTO BookModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedBook = await BookService.UpdateBookAsync(BookModel);

            if (updatedBook != null)
                return Ok(updatedBook);
            else
                return NotFound();
        }

        // DELETE: api/Book/{id}
        [ResponseType(typeof(BookModel))]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteBook(int id)
        {
            var Id = await BookService.RemoveBookAsync(id);

            if (Id != 0)
                return Ok(Id);
            else
                return NotFound();
        }

        private bool BookModelExists(int id)
        {
            return BookService.IsBookExistsById(id);
        }

    }
}