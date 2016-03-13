using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Models;
using Team_Temperature.Infrastructure.Commands;
using Team_Temperature.Infrastructure.Queries;

namespace Team_Temperature.Controllers.API
{
    [System.Web.Http.RoutePrefix("api/user")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        private readonly IAddUserCommand _addUserCommand;
        private readonly IEditUserCommand _editUserCommand;
        private readonly IDeleteUserCommand _deleteUserCommand;
        private readonly IGetAllUsersQuery _getAllUsersQuery;

        public UserController(IAddUserCommand addUserCommand, IEditUserCommand editUserCommand, IDeleteUserCommand deleteUserCommand, IGetAllUsersQuery getAllUsersQuery)
        {
            _addUserCommand = addUserCommand;
            _editUserCommand = editUserCommand;
            _deleteUserCommand = deleteUserCommand;
            _getAllUsersQuery = getAllUsersQuery;
        }

        //post add
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("add")]
        public HttpResponseMessage Add(UserModel user)
        {
            if (_addUserCommand.Execute(user))
            {
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            return new HttpResponseMessage(HttpStatusCode.NotImplemented);
        }

        //post edit
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("edit")]
        public HttpResponseMessage Edit(UserModel user)
        {
            if (_editUserCommand.Execute(user))
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.NotImplemented);
        }

        //post delete
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("delete")]
        public HttpResponseMessage Delete(UserModel user)
        {
            if (_deleteUserCommand.Execute(user))
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.NotImplemented);
        }

        //get users
        [System.Web.Http.Route("allusers")]
        public UsersResponseModel AllUsers()
        {
            var users = _getAllUsersQuery.Execute();

            return new UsersResponseModel
            {
                UserCount = users.Count,
                Users = users
            };
        }

        //get users
        [System.Web.Http.Route("allvalidusers")]
        public UsersResponseModel AllValidUsers()
        {
            var users = _getAllUsersQuery.Execute().Where(d => d.Deleted == false).ToList();

            return new UsersResponseModel
            {
                UserCount = users.Count,
                Users = users
            };
        }
    }

    public class UsersResponseModel
    {
        public int UserCount { get; set; }
        public List<UserModel> Users { get; set; }
    }
}
