using Models;

namespace Repository
{
    public interface IUserRepository
    {
        bool AddUser(UserModel user);
    }
}
