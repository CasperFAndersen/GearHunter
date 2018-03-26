using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearHunter.Core.Models
{
    public class Individual : User
    {
        public bool IsValidated { get; set; }

        public Individual(string name, string address, string zip, string city, string email, string password, bool isAdmin, bool isValidated) 
            : base(name, address, zip, city, email, password, isAdmin)
        {
            this.IsValidated = isValidated;
        }
    }
}
