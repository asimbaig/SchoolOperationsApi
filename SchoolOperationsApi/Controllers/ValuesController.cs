using SchoolOperationsApi.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolOperationsApi.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        [CustomExceptionFilter]
        // GET api/values
        public IEnumerable<string> Get()
        {
            
            return new string[] { "value1", "value2" };
        }

        [CustomExceptionFilter]
        // GET api/values/5
        public string Get(int id)
        {
            if (id == 1)
            {

                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent("Value doesn't exist.", System.Text.Encoding.UTF8, "text/plain"),
                    StatusCode = HttpStatusCode.NotFound
                };
                //throw new Exception("An Exception Occured in Values Controller, Action Get(id)");
                //
                int temp1 = 1;
                int temp2 = 0;
                int result = temp1 / temp2;

                //try
                //{
         
                //    //throw new DivideByZeroException();
                //    //throw new HttpResponseException(response);
                //    //throw new Exception("An Exception Occured in Values Controller, Action Get(id)");
                //}
                //catch (Exception ex)
                //{
                //}

            }
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
