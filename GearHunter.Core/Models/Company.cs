using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearHunter.Core.Models
{
    public class Company : User
    {
        public string CVR { get; set; }

        public Company(string name, string address, string zip, string city, string email, string password, bool isAdmin, string cvr) 
            : base(name, address, zip, city, email, password, isAdmin)
        {
            this.CVR = cvr;
        }
    }



}
