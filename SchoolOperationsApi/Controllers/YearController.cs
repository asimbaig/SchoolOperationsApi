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
    public class YearController : BaseController
    {
        private readonly IYearService YearService;

        //Constructor
        public YearController()
        {
            this.YearService = new YearService();
        }

        // GET: api/Year/All
        [CustomExceptionFilter]
        [Route("api/Year/All")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllYears()
        {
            var collection = await (YearService.GetAllYear());

            if (collection != null)
                return Ok(collection);
            else
                return NotFound();
        }

        // GET: api/Year/5
        [ResponseType(typeof(YearModel))]
        [CustomExceptionFilter]
        [HttpGet]
        public async Task<IHttpActionResult> GetYear(int id)
        {
            YearDTO dto = await YearService.SearchSingleYearByIdAsync(id);

            if (dto != null)
                return Ok(dto);
            else
                return NotFound();
        }

        // Post: api/Year/Add
        [ResponseType(typeof(void))]
        [CustomExceptionFilter]
        [Route("api/Year/Add")]
        [HttpPost]
        public async Task<IHttpActionResult> AddYear([FromBody]YearDTO YearModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newYearId = await YearService.AddYearAsync(YearModel);

            if (newYearId != 0)
                return Ok(newYearId);
            else
                return NotFound();
        }

        // PUT: api/Year/Update
        [ResponseType(typeof(void))]
        [CustomExceptionFilter]
        [Route("api/Year/Update")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateYear([FromBody]YearDTO YearModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedYear = await YearService.UpdateYearAsync(YearModel);

            if (updatedYear != null)
                return Ok(updatedYear);
            else
                return NotFound();
        }

        // DELETE: api/Year/{id}
        [ResponseType(typeof(YearModel))]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteYear(int id)
        {
            var Id = await YearService.RemoveYearAsync(id);

            if (Id != 0)
                return Ok(Id);
            else
                return NotFound();
        }

        private bool YearModelExists(int id)
        {
            return YearService.IsYearExistsById(id);
        }

    }
}