using Models;

namespace Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly IMongoProvider _repository;

        public UserRepository(IMongoProvider repository)
        {
            _repository = repository.ForCollection("User");
        }

        public bool AddUser(UserModel user)
        {
            return _repository.Insert(user);
        }
    }
}
