using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Team_Temperature.Controllers.API
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        //post add
        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add([FromBody] string user)
        {
            Console.WriteLine(user);
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

        [HttpGet]
        [Route("all")]
        public string All()
        {
            return Guid.NewGuid().ToString();
        }

    }
}
