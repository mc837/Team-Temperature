using Models;

namespace Team_Temperature.Infrastructure.Commands
{
    public interface IAddUserCommand
    {
        bool Execute(UserModel user);
    }
}
