using System;
using Models.Enums;

namespace Models
{
    public class UserModel
    {
        public UserModel()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public Priviledge Priviledge { get; set; }
        public bool Deleted { get; set; }
    }
}

