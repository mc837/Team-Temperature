using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models;
using Team_Temperature.Infrastructure.Commands;

namespace Team_Temperature.Controllers.API
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private readonly IAddUserCommand _addUserCommand;

        public UserController(IAddUserCommand addUserCommand)
        {
            _addUserCommand = addUserCommand;
        }

        //post add
        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(UserModel user)
        {
            if (_addUserCommand.Execute(user))
            {
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            return new HttpResponseMessage(HttpStatusCode.NotImplemented);
        }

        [HttpGet]
        [Route("all")]
        public HttpResponseMessage All(UserModel user)
        {
            Console.WriteLine(user);
            if (user != null)
            {
                return new HttpResponseMessage(HttpStatusCode.Accepted);

            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        [HttpGet]
        [Route("test")]
        public string Test()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
