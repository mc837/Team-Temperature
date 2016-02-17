using Models;

namespace Team_Temperature.Infrastructure.Commands
{
    public interface IEditUserCommand
    {
        bool Execute(UserModel user);
    }
}
