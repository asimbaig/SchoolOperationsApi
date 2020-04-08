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
    public class TeacherController : BaseController
    {
        private readonly ITeacherService TeacherService;

        //Constructor
        public TeacherController()
        {
            this.TeacherService = new TeacherService();
        }

        // GET: api/Teacher/All
        [CustomExceptionFilter]
        [Route("api/Teacher/All")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllTeachers()
        {
            var collection = await (TeacherService.GetAllTeacher());

            if (collection != null)
                return Ok(collection);
            else
                return NotFound();
        }

        // GET: api/Teacher/5
        [ResponseType(typeof(TeacherModel))]
        [CustomExceptionFilter]
        [HttpGet]
        public async Task<IHttpActionResult> GetTeacher(int id)
        {
            TeacherDTO dto = await TeacherService.SearchSingleTeacherByIdAsync(id);

            if (dto != null)
                return Ok(dto);
            else
                return NotFound();
        }

        // Post: api/Teacher/Add
        [ResponseType(typeof(void))]
        [CustomExceptionFilter]
        [Route("api/Teacher/Add")]
        [HttpPost]
        public async Task<IHttpActionResult> AddTeacher([FromBody]TeacherDTO TeacherModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newTeacherId = await TeacherService.AddTeacherAsync(TeacherModel);

            if (newTeacherId != 0)
                return Ok(newTeacherId);
            else
                return NotFound();
        }

        // PUT: api/Teacher/Update
        [ResponseType(typeof(void))]
        [CustomExceptionFilter]
        [Route("api/Teacher/Update")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateTeacher([FromBody]TeacherDTO TeacherModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedTeacher = await TeacherService.UpdateTeacherAsync(TeacherModel);

            if (updatedTeacher != null)
                return Ok(updatedTeacher);
            else
                return NotFound();
        }

        // DELETE: api/Teacher/{id}
        [ResponseType(typeof(TeacherModel))]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteTeacher(int id)
        {
            var Id = await TeacherService.RemoveTeacherAsync(id);

            if (Id != 0)
                return Ok(Id);
            else
                return NotFound();
        }

        private bool TeacherModelExists(int id)
        {
            return TeacherService.IsTeacherExistsById(id);
        }

    }
}