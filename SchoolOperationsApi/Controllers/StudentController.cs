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
    public class StudentController : BaseController
    {
        private readonly IStudentService StudentService;

        //Constructor
        public StudentController()
        {
            this.StudentService = new StudentService();
        }

        // GET: api/Student/All
        [CustomExceptionFilter]
        [Route("api/Student/All")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllStudents()
        {
            var collection = await (StudentService.GetAllStudent());

            if (collection != null)
                return Ok(collection);
            else
                return NotFound();
        }

        // GET: api/Student/5
        [ResponseType(typeof(StudentModel))]
        [CustomExceptionFilter]
        [HttpGet]
        public async Task<IHttpActionResult> GetStudent(int id)
        {
            StudentDTO dto = await StudentService.SearchSingleStudentByIdAsync(id);

            if (dto != null)
                return Ok(dto);
            else
                return NotFound();
        }

        // Post: api/Student/Add
        [ResponseType(typeof(void))]
        [CustomExceptionFilter]
        [Route("api/Student/Add")]
        [HttpPost]
        public async Task<IHttpActionResult> AddStudent([FromBody]StudentDTO StudentModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newStudentId = await StudentService.AddStudentAsync(StudentModel);

            if (newStudentId != 0)
                return Ok(newStudentId);
            else
                return NotFound();
        }

        // PUT: api/Student/Update
        [ResponseType(typeof(void))]
        [CustomExceptionFilter]
        [Route("api/Student/Update")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateStudent([FromBody]StudentDTO StudentModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedStudent = await StudentService.UpdateStudentAsync(StudentModel);

            if (updatedStudent != null)
                return Ok(updatedStudent);
            else
                return NotFound();
        }

        // DELETE: api/Student/{id}
        [ResponseType(typeof(StudentModel))]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteStudent(int id)
        {
            var Id = await StudentService.RemoveStudentAsync(id);

            if (Id != 0)
                return Ok(Id);
            else
                return NotFound();
        }

        private bool StudentModelExists(int id)
        {
            return StudentService.IsStudentExistsById(id);
        }

    }
}