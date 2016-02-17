using System;
using Models.Enums;

namespace Models
{
    public class UserModel
    {
        public UserModel()
        {
            Id = 1;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public Priviledge Priviledge { get; set; }
    }
}

