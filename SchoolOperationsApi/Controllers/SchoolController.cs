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
    [Authorize(Roles = "SuperAdmin")]
    //[Authorize]
    public class SchoolController : BaseController
    {
        private readonly ISchoolService SchoolService;

        //Constructor
        public SchoolController()
        {
            this.SchoolService = new SchoolService();
        }

        // GET: api/School/All
        [CustomExceptionFilter]
        [Route("api/School/All")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllSchools()
        {
            var collection = await (SchoolService.GetAllSchool());

            //if (collection != null)
            //    return Ok(collection);
            //else
                return NotFound();
        }

        // GET: api/School/5
        [ResponseType(typeof(SchoolModel))]
        [CustomExceptionFilter]
        [HttpGet]
        public async Task<IHttpActionResult> GetSchool(int id)
        {
            SchoolDTO dto = await SchoolService.SearchSingleSchoolByIdAsync(id);

            if (dto != null)
                return Ok(dto);
            else
                return NotFound();
        }

        // Post: api/School/Add
        [ResponseType(typeof(void))]
        [CustomExceptionFilter]
        [Route("api/School/Add")]
        [HttpPost]
        public async Task<IHttpActionResult> AddSchool([FromBody]SchoolDTO SchoolModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newSchoolId = await SchoolService.AddSchoolAsync(SchoolModel);

            if (newSchoolId != 0)
                return Ok(newSchoolId);
            else
                return NotFound();
        }

        // PUT: api/School/Update
        [ResponseType(typeof(void))]
        [CustomExceptionFilter]
        [Route("api/School/Update")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateSchool([FromBody]SchoolDTO SchoolModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedSchool = await SchoolService.UpdateSchoolAsync(SchoolModel);

            if (updatedSchool != null)
                return Ok(updatedSchool);
            else
                return NotFound();
        }

        // DELETE: api/School/{id}
        [ResponseType(typeof(SchoolModel))]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteSchool(int id)
        {
            var Id = await SchoolService.RemoveSchoolAsync(id);

            if (Id != 0)
                return Ok(Id);
            else
                return NotFound();
        }

        private bool SchoolModelExists(int id)
        {
            return SchoolService.IsSchoolExistsById(id);
        }

    }
}