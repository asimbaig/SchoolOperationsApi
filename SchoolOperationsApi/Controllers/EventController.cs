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
    public class EventController : BaseController
    {
        private readonly IEventService EventService;

        //Constructor
        public EventController()
        {
            this.EventService = new EventService();
        }

        // GET: api/Event/All
        [CustomExceptionFilter]
        [Route("api/Event/All")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllEvents()
        {
            var collection = await (EventService.GetAllEvent());

            if (collection != null)
                return Ok(collection);
            else
                return NotFound();
        }

        // GET: api/Event/5
        [ResponseType(typeof(EventModel))]
        [CustomExceptionFilter]
        [HttpGet]
        public async Task<IHttpActionResult> GetEvent(int id)
        {
            EventDTO dto = await EventService.SearchSingleEventByIdAsync(id);

            if (dto != null)
                return Ok(dto);
            else
                return NotFound();
        }

        // Post: api/Event/Add
        [ResponseType(typeof(void))]
        [CustomExceptionFilter]
        [Route("api/Event/Add")]
        [HttpPost]
        public async Task<IHttpActionResult> AddEvent([FromBody]EventDTO EventModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newEventId = await EventService.AddEventAsync(EventModel);

            if (newEventId != 0)
                return Ok(newEventId);
            else
                return NotFound();
        }

        // PUT: api/Event/Update
        [ResponseType(typeof(void))]
        [CustomExceptionFilter]
        [Route("api/Event/Update")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateEvent([FromBody]EventDTO EventModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedEvent = await EventService.UpdateEventAsync(EventModel);

            if (updatedEvent != null)
                return Ok(updatedEvent);
            else
                return NotFound();
        }

        // DELETE: api/Event/{id}
        [ResponseType(typeof(EventModel))]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteEvent(int id)
        {
            var Id = await EventService.RemoveEventAsync(id);

            if (Id != 0)
                return Ok(Id);
            else
                return NotFound();
        }

        private bool EventModelExists(int id)
        {
            return EventService.IsEventExistsById(id);
        }

    }
}