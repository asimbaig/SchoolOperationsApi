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
    public class ParentController : BaseController
    {
        private readonly IParentService ParentService;

        //Constructor
        public ParentController()
        {
            this.ParentService = new ParentService();
        }

        // GET: api/Parent/All
        [CustomExceptionFilter]
        [Route("api/Parent/All")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllParents()
        {
            var collection = await (ParentService.GetAllParent());

            if (collection != null)
                return Ok(collection);
            else
                return NotFound();
        }

        // GET: api/Parent/5
        [ResponseType(typeof(ParentModel))]
        [CustomExceptionFilter]
        [HttpGet]
        public async Task<IHttpActionResult> GetParent(int id)
        {
            ParentDTO dto = await ParentService.SearchSingleParentByIdAsync(id);

            if (dto != null)
                return Ok(dto);
            else
                return NotFound();
        }

        // Post: api/Parent/Add
        [ResponseType(typeof(void))]
        [CustomExceptionFilter]
        [Route("api/Parent/Add")]
        [HttpPost]
        public async Task<IHttpActionResult> AddParent([FromBody]ParentDTO ParentModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newParentId = await ParentService.AddParentAsync(ParentModel);

            if (newParentId != 0)
                return Ok(newParentId);
            else
                return NotFound();
        }

        // PUT: api/Parent/Update
        [ResponseType(typeof(void))]
        [CustomExceptionFilter]
        [Route("api/Parent/Update")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateParent([FromBody]ParentDTO ParentModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedParent = await ParentService.UpdateParentAsync(ParentModel);

            if (updatedParent != null)
                return Ok(updatedParent);
            else
                return NotFound();
        }

        // DELETE: api/Parent/{id}
        [ResponseType(typeof(ParentModel))]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteParent(int id)
        {
            var Id = await ParentService.RemoveParentAsync(id);

            if (Id != 0)
                return Ok(Id);
            else
                return NotFound();
        }

        private bool ParentModelExists(int id)
        {
            return ParentService.IsParentExistsById(id);
        }

    }
}