using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Core.Entities
{
    public class User
    {
        public User(int id,string? name, string? email, string? phone)
        {
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
        }
        public User()
        {

        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}
