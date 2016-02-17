using Models;

namespace Team_Temperature.Infrastructure.Commands
{
    public interface IDeleteUserCommand
    {
        bool Execute(UserModel user);
    }
}
