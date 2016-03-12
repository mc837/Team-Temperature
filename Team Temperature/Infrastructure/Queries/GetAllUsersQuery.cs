using System.Collections.Generic;
using Models;
using Repository;

namespace Team_Temperature.Infrastructure.Queries
{
    public class GetAllUsersQuery: IGetAllUsersQuery
    {
        private readonly IUserRepository _repo;

        public GetAllUsersQuery(IUserRepository repo)
        {
            _repo = repo;
        }

        public List<UserModel> Execute()
        {
            return _repo.GetAllUsers();
        }
    }
}