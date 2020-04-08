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
    public class StandardController : BaseController
    {
        private readonly IStandardService StandardService;

        //Constructor
        public StandardController()
        {
            this.StandardService = new StandardService();
        }

        // GET: api/Standard/All
        [CustomExceptionFilter]
        [Route("api/Standard/All")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllStandards()
        {
            var collection = await (StandardService.GetAllStandard());

            if (collection != null)
                return Ok(collection);
            else
                return NotFound();
        }

        // GET: api/Standard/5
        [ResponseType(typeof(StandardModel))]
        [CustomExceptionFilter]
        [HttpGet]
        public async Task<IHttpActionResult> GetStandard(int id)
        {
            StandardDTO dto = await StandardService.SearchSingleStandardByIdAsync(id);

            if (dto != null)
                return Ok(dto);
            else
                return NotFound();
        }

        // Post: api/Standard/Add
        [ResponseType(typeof(void))]
        [CustomExceptionFilter]
        [Route("api/Standard/Add")]
        [HttpPost]
        public async Task<IHttpActionResult> AddStandard([FromBody]StandardDTO StandardModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newStandardId = await StandardService.AddStandardAsync(StandardModel);

            if (newStandardId != 0)
                return Ok(newStandardId);
            else
                return NotFound();
        }

        // PUT: api/Standard/Update
        [ResponseType(typeof(void))]
        [CustomExceptionFilter]
        [Route("api/Standard/Update")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateStandard([FromBody]StandardDTO StandardModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedStandard = await StandardService.UpdateStandardAsync(StandardModel);

            if (updatedStandard != null)
                return Ok(updatedStandard);
            else
                return NotFound();
        }

        // DELETE: api/Standard/{id}
        [ResponseType(typeof(StandardModel))]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteStandard(int id)
        {
            var Id = await StandardService.RemoveStandardAsync(id);

            if (Id != 0)
                return Ok(Id);
            else
                return NotFound();
        }

        private bool StandardModelExists(int id)
        {
            return StandardService.IsStandardExistsById(id);
        }

    }
}