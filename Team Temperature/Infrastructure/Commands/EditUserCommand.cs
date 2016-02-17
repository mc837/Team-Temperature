using Models;
using Repository;

namespace Team_Temperature.Infrastructure.Commands
{
    public class EditUserCommand: IEditUserCommand
    {
        private readonly IUserRepository _repo;

        public EditUserCommand(IUserRepository repo)
        {
            _repo = repo;
        }

        public bool Execute(UserModel user)
        {
            var result = _repo.UpdateUser(user);

            //could log if user not added ???

            return result;
        }
    }
}