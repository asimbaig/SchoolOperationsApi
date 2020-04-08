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
    public class BookTransactionController : BaseController
    {
        private readonly IBookTransactionService BookTransactionService;

        //Constructor
        public BookTransactionController()
        {
            this.BookTransactionService = new BookTransactionService();
        }

        // GET: api/BookTransaction/All
        [CustomExceptionFilter]
        [Route("api/BookTransaction/All")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllBookTransactions()
        {
            var collection = await (BookTransactionService.GetAllBookTransaction());

            if (collection != null)
                return Ok(collection);
            else
                return NotFound();
        }

        // GET: api/BookTransaction/5
        [ResponseType(typeof(BookTransactionModel))]
        [CustomExceptionFilter]
        [HttpGet]
        public async Task<IHttpActionResult> GetBookTransaction(int id)
        {
            BookTransactionDTO dto = await BookTransactionService.SearchSingleBookTransactionByIdAsync(id);

            if (dto != null)
                return Ok(dto);
            else
                return NotFound();
        }

        // Post: api/BookTransaction/Add
        [ResponseType(typeof(void))]
        [CustomExceptionFilter]
        [Route("api/BookTransaction/Add")]
        [HttpPost]
        public async Task<IHttpActionResult> AddBookTransaction([FromBody]BookTransactionDTO BookTransactionModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newBookTransactionId = await BookTransactionService.AddBookTransactionAsync(BookTransactionModel);

            if (newBookTransactionId != 0)
                return Ok(newBookTransactionId);
            else
                return NotFound();
        }

        // PUT: api/BookTransaction/Update
        [ResponseType(typeof(void))]
        [CustomExceptionFilter]
        [Route("api/BookTransaction/Update")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateBookTransaction([FromBody]BookTransactionDTO BookTransactionModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedBookTransaction = await BookTransactionService.UpdateBookTransactionAsync(BookTransactionModel);

            if (updatedBookTransaction != null)
                return Ok(updatedBookTransaction);
            else
                return NotFound();
        }

        // DELETE: api/BookTransaction/{id}
        [ResponseType(typeof(BookTransactionModel))]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteBookTransaction(int id)
        {
            var Id = await BookTransactionService.RemoveBookTransactionAsync(id);

            if (Id != 0)
                return Ok(Id);
            else
                return NotFound();
        }

        private bool BookTransactionModelExists(int id)
        {
            return BookTransactionService.IsBookTransactionExistsById(id);
        }

    }
}