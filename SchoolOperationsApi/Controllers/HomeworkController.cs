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
    public class HomeworkController : BaseController
    {
        private readonly IHomeworkService HomeworkService;

        //Constructor
        public HomeworkController()
        {
            this.HomeworkService = new HomeworkService();
        }

        // GET: api/Homework/All
        [CustomExceptionFilter]
        [Route("api/Homework/All")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllHomeworks()
        {
            var collection = await (HomeworkService.GetAllHomework());

            if (collection != null)
                return Ok(collection);
            else
                return NotFound();
        }

        // GET: api/Homework/5
        [ResponseType(typeof(HomeworkModel))]
        [CustomExceptionFilter]
        [HttpGet]
        public async Task<IHttpActionResult> GetHomework(int id)
        {
            HomeworkDTO dto = await HomeworkService.SearchSingleHomeworkByIdAsync(id);

            if (dto != null)
                return Ok(dto);
            else
                return NotFound();
        }

        // Post: api/Homework/Add
        [ResponseType(typeof(void))]
        [CustomExceptionFilter]
        [Route("api/Homework/Add")]
        [HttpPost]
        public async Task<IHttpActionResult> AddHomework([FromBody]HomeworkDTO HomeworkModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newHomeworkId = await HomeworkService.AddHomeworkAsync(HomeworkModel);

            if (newHomeworkId != 0)
                return Ok(newHomeworkId);
            else
                return NotFound();
        }

        // PUT: api/Homework/Update
        [ResponseType(typeof(void))]
        [CustomExceptionFilter]
        [Route("api/Homework/Update")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateHomework([FromBody]HomeworkDTO HomeworkModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedHomework = await HomeworkService.UpdateHomeworkAsync(HomeworkModel);

            if (updatedHomework != null)
                return Ok(updatedHomework);
            else
                return NotFound();
        }

        // DELETE: api/Homework/{id}
        [ResponseType(typeof(HomeworkModel))]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteHomework(int id)
        {
            var Id = await HomeworkService.RemoveHomeworkAsync(id);

            if (Id != 0)
                return Ok(Id);
            else
                return NotFound();
        }

        private bool HomeworkModelExists(int id)
        {
            return HomeworkService.IsHomeworkExistsById(id);
        }

    }
}