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
    public class AttendanceController : BaseController
    {
        private readonly IAttendanceService AttendanceService;

        //Constructor
        public AttendanceController()
        {
            this.AttendanceService = new AttendanceService();
        }

        // GET: api/Attendance/All
        [CustomExceptionFilter]
        [Route("api/Attendance/All")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllAttendances()
        {
            var collection = await (AttendanceService.GetAllAttendance());

            if (collection != null)
                return Ok(collection);
            else
                return NotFound();
        }

        // GET: api/Attendance/5
        [ResponseType(typeof(AttendanceModel))]
        [CustomExceptionFilter]
        [HttpGet]
        public async Task<IHttpActionResult> GetAttendance(int id)
        {
            AttendanceDTO dto = await AttendanceService.SearchSingleAttendanceByIdAsync(id);

            if (dto != null)
                return Ok(dto);
            else
                return NotFound();
        }

        // Post: api/Attendance/Add
        [ResponseType(typeof(void))]
        [CustomExceptionFilter]
        [Route("api/Attendance/Add")]
        [HttpPost]
        public async Task<IHttpActionResult> AddAttendance([FromBody]AttendanceDTO AttendanceModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newAttendanceId = await AttendanceService.AddAttendanceAsync(AttendanceModel);

            if (newAttendanceId != 0)
                return Ok(newAttendanceId);
            else
                return NotFound();
        }

        // PUT: api/Attendance/Update
        [ResponseType(typeof(void))]
        [CustomExceptionFilter]
        [Route("api/Attendance/Update")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateAttendance([FromBody]AttendanceDTO AttendanceModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedAttendance = await AttendanceService.UpdateAttendanceAsync(AttendanceModel);

            if (updatedAttendance != null)
                return Ok(updatedAttendance);
            else
                return NotFound();
        }

        // DELETE: api/Attendance/{id}
        [ResponseType(typeof(AttendanceModel))]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteAttendance(int id)
        {
            var Id = await AttendanceService.RemoveAttendanceAsync(id);

            if (Id != 0)
                return Ok(Id);
            else
                return NotFound();
        }

        private bool AttendanceModelExists(int id)
        {
            return AttendanceService.IsAttendanceExistsById(id);
        }

    }
}