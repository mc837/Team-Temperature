using Models;
using Repository;

namespace Team_Temperature.Infrastructure.Commands
{
    public class DeleteUserCommand: IDeleteUserCommand
    {
        private IUserRepository _repository;

        public DeleteUserCommand(IUserRepository repository)
        {
            _repository = repository;
        }

        public bool Execute(UserModel user)
        {
           return  _repository.DeleteUser(user);
        }
    }
}