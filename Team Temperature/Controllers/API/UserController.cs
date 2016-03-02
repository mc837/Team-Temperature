using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Models;
using Team_Temperature.Infrastructure.Commands;

namespace Team_Temperature.Controllers.API
{
    [RoutePrefix("api/user")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        private readonly IAddUserCommand _addUserCommand;
        private readonly IEditUserCommand _editUserCommand;
        private readonly IDeleteUserCommand _deleteUserCommand;

        public UserController(IAddUserCommand addUserCommand, IEditUserCommand editUserCommand, IDeleteUserCommand deleteUserCommand)
        {
            _addUserCommand = addUserCommand;
            _editUserCommand = editUserCommand;
            _deleteUserCommand = deleteUserCommand;
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

        //post edit
        [HttpPost]
        [Route("edit")]
        public HttpResponseMessage Edit(UserModel user)
        {
            if (_editUserCommand.Execute(user))
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.NotImplemented);
        }

        //post delete
        [HttpPost]
        [Route("delete")]
        public HttpResponseMessage Delete(UserModel user)
        {
            if (_deleteUserCommand.Execute(user))
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.NotImplemented);
        }




//
//        [HttpGet]
//        [Route("all")]
//        public HttpResponseMessage All(UserModel user)
//        {
//            Console.WriteLine(user);
//            if (user != null)
//            {
//                return new HttpResponseMessage(HttpStatusCode.Accepted);
//
//            }
//            return new HttpResponseMessage(HttpStatusCode.BadRequest);
//        }
//
//        [HttpGet]
//        [Route("test")]
//        public string Test()
//        {
//            return Guid.NewGuid().ToString();
//        }
    }
}
