using DTOs;
using SchoolOperationsApi.Common;
using ServiceLayer.Implementations;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;


namespace SchoolOperationsApi.Controllers
{
    [Authorize]
    public class ExceptionLoggerController : BaseController
    {
        private readonly IExceptionLoggerService ExceptionLoggerService;

        //Constructor
        public ExceptionLoggerController()
        {
            this.ExceptionLoggerService = new ExceptionLoggerService();
        }

        // Post: api/Assessment/Add
        [ResponseType(typeof(void))]
        [CustomExceptionFilter]
        [Route("api/ExceptionLogger/Add")]
        [HttpPost]
        public async Task<IHttpActionResult> AddExceptionLogger([FromBody]ExceptionLoggerDTO exceptionLoggerModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ExceptionLoggerId = await ExceptionLoggerService.AddExceptionAsync(exceptionLoggerModel);

            if (ExceptionLoggerId != 0)
                return Ok(ExceptionLoggerId);
            else
                return NotFound();
        }
    }
}