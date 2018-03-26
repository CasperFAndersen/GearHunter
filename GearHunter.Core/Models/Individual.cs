using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearHunter.Core.Models
{
    public class Individual : User
    {
        public int Id { get; set; }
        public bool IsValidated { get; set; }

        public Individual(int id, string name, string address, string zip, string city, string email, string password, bool isAdmin, bool isActive, bool isValidated) 
            : base(id, name, address, zip, city, email, password, isAdmin, isActive)
        {
            Id = id;
            IsValidated = isValidated;
        }
    }
}
