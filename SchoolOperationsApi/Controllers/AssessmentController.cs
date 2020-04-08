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
    public class AssessmentController : BaseController
    {
        private readonly IAssessmentService AssessmentService;

        //Constructor
        public AssessmentController()
        {
            this.AssessmentService = new AssessmentService();
        }

        // GET: api/Assessment/All
        [CustomExceptionFilter]
        [Route("api/Assessment/All")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllAssessments()
        {
            var collection = await(AssessmentService.GetAllAssessment());

            if (collection != null)
                return Ok(collection);
            else
                return NotFound();
        }

        // GET: api/Assessment/5
        [ResponseType(typeof(AssessmentModel))]
        [CustomExceptionFilter]
        [HttpGet]
        public async Task<IHttpActionResult> GetAssessment(int id)
        {
            AssessmentDTO dto = await AssessmentService.SearchSingleAssessmentByIdAsync(id);

            if (dto != null)
                return Ok(dto);
            else
                return NotFound();
        }

        // Post: api/Assessment/Add
        [ResponseType(typeof(void))]
        [CustomExceptionFilter]
        [Route("api/Assessment/Add")]
        [HttpPost]
        public async Task<IHttpActionResult> AddAssessment([FromBody]AssessmentDTO assessmentModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newAssessmentId = await AssessmentService.AddAssessmentAsync(assessmentModel);

            if (newAssessmentId != 0)
                return Ok(newAssessmentId);
            else
                return NotFound();
        }

        // PUT: api/Assessment/Update
        [ResponseType(typeof(void))]
        [CustomExceptionFilter]
        [Route("api/Assessment/Update")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateAssessment([FromBody]AssessmentDTO assessmentModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedAssessment = await AssessmentService.UpdateAssessmentAsync(assessmentModel);

            if (updatedAssessment != null)
                return Ok(updatedAssessment);
            else
                return NotFound();
        }

        // DELETE: api/Assessment/{id}
        [ResponseType(typeof(AssessmentModel))]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteAssessment(int id)
        {
            var Id = await AssessmentService.RemoveAssessmentAsync(id);

            if (Id != 0)
                return Ok(Id);
            else
                return NotFound();
        }

        private bool AssessmentModelExists(int id)
        {
            return AssessmentService.IsAssessmentExistsById(id);
        }

    }
}