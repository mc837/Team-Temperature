using Models;
using Repository;

namespace Team_Temperature.Infrastructure.Commands
{
    public class AddUserCommand: IAddUserCommand
    {
        private readonly IUserRepository _repo;

        public AddUserCommand(IUserRepository repo)
        {
            _repo = repo;
        }

        public bool Execute(UserModel user)
        {
            var result = _repo.AddUser(user);

            //could log if user not added ???

            return result;
        }
    }
}