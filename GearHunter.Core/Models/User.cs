using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearHunter.Core.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public User(string name, string address, string zip, string city, string email, string password, bool isAdmin)
        {
            this.Name = name;
            this.Address = address;
            this.Zip = zip;
            this.City = city;
            this.Email = email;
            this.Password = password;
            this.IsAdmin = isAdmin;
        }
    }
}
