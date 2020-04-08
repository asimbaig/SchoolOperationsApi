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
    public class SubjectController : BaseController
    {
        private readonly ISubjectService SubjectService;

        //Constructor
        public SubjectController()
        {
            this.SubjectService = new SubjectService();
        }

        // GET: api/Subject/All
        [CustomExceptionFilter]
        [Route("api/Subject/All")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllSubjects()
        {
            var collection = await (SubjectService.GetAllSubject());

            if (collection != null)
                return Ok(collection);
            else
                return NotFound();
        }

        // GET: api/Subject/5
        [ResponseType(typeof(SubjectModel))]
        [CustomExceptionFilter]
        [HttpGet]
        public async Task<IHttpActionResult> GetSubject(int id)
        {
            SubjectDTO dto = await SubjectService.SearchSingleSubjectByIdAsync(id);

            if (dto != null)
                return Ok(dto);
            else
                return NotFound();
        }

        // Post: api/Subject/Add
        [ResponseType(typeof(void))]
        [CustomExceptionFilter]
        [Route("api/Subject/Add")]
        [HttpPost]
        public async Task<IHttpActionResult> AddSubject([FromBody]SubjectDTO SubjectModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newSubjectId = await SubjectService.AddSubjectAsync(SubjectModel);

            if (newSubjectId != 0)
                return Ok(newSubjectId);
            else
                return NotFound();
        }

        // PUT: api/Subject/Update
        [ResponseType(typeof(void))]
        [CustomExceptionFilter]
        [Route("api/Subject/Update")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateSubject([FromBody]SubjectDTO SubjectModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedSubject = await SubjectService.UpdateSubjectAsync(SubjectModel);

            if (updatedSubject != null)
                return Ok(updatedSubject);
            else
                return NotFound();
        }

        // DELETE: api/Subject/{id}
        [ResponseType(typeof(SubjectModel))]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteSubject(int id)
        {
            var Id = await SubjectService.RemoveSubjectAsync(id);

            if (Id != 0)
                return Ok(Id);
            else
                return NotFound();
        }

        private bool SubjectModelExists(int id)
        {
            return SubjectService.IsSubjectExistsById(id);
        }

    }
}