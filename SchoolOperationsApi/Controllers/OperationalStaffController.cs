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
    public class OperationalStaffController : BaseController
    {
        private readonly IOperationalStaffService OperationalStaffService;

        //Constructor
        public OperationalStaffController()
        {
            this.OperationalStaffService = new OperationalStaffService();
        }

        // GET: api/OperationalStaff/All
        [CustomExceptionFilter]
        [Route("api/OperationalStaff/All")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllOperationalStaffs()
        {
            var collection = await (OperationalStaffService.GetAllOperationalStaff());

            if (collection != null)
                return Ok(collection);
            else
                return NotFound();
        }

        // GET: api/OperationalStaff/5
        [ResponseType(typeof(OperationalStaffModel))]
        [CustomExceptionFilter]
        [HttpGet]
        public async Task<IHttpActionResult> GetOperationalStaff(int id)
        {
            OperationalStaffDTO dto = await OperationalStaffService.SearchSingleOperationalStaffByIdAsync(id);

            if (dto != null)
                return Ok(dto);
            else
                return NotFound();
        }

        // Post: api/OperationalStaff/Add
        [ResponseType(typeof(void))]
        [CustomExceptionFilter]
        [Route("api/OperationalStaff/Add")]
        [HttpPost]
        public async Task<IHttpActionResult> AddOperationalStaff([FromBody]OperationalStaffDTO OperationalStaffModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newOperationalStaffId = await OperationalStaffService.AddOperationalStaffAsync(OperationalStaffModel);

            if (newOperationalStaffId != 0)
                return Ok(newOperationalStaffId);
            else
                return NotFound();
        }

        // PUT: api/OperationalStaff/Update
        [ResponseType(typeof(void))]
        [CustomExceptionFilter]
        [Route("api/OperationalStaff/Update")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateOperationalStaff([FromBody]OperationalStaffDTO OperationalStaffModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedOperationalStaff = await OperationalStaffService.UpdateOperationalStaffAsync(OperationalStaffModel);

            if (updatedOperationalStaff != null)
                return Ok(updatedOperationalStaff);
            else
                return NotFound();
        }

        // DELETE: api/OperationalStaff/{id}
        [ResponseType(typeof(OperationalStaffModel))]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteOperationalStaff(int id)
        {
            var Id = await OperationalStaffService.RemoveOperationalStaffAsync(id);

            if (Id != 0)
                return Ok(Id);
            else
                return NotFound();
        }

        private bool OperationalStaffModelExists(int id)
        {
            return OperationalStaffService.IsOperationalStaffExistsById(id);
        }

    }
}