using System;
using System.Collections.Generic;
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

        public bool UpdateUser(UserModel user)
        {
            return _repository.Update(user);
        }

        public bool DeleteUser(UserModel user)
        {
            return _repository.Delete(user);
        }

        public List<UserModel> GetAllUsers()
        {
            return _repository.Find<UserModel>();
        }
    }
}
