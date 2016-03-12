using System.Collections.Generic;
using Models;

namespace Team_Temperature.Infrastructure.Queries
{
    public interface IGetAllUsersQuery
    {
        List<UserModel> Execute();
    }
}
