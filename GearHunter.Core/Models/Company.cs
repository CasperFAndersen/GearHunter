using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearHunter.Core.Models
{
    public class Company : User
    {
        public int Id { get; set; }
        public string CVR { get; set; }

        public Company(int id, string name, string address, string zip, string city, string email, string password, bool isAdmin, bool isActive, string cvr) 
            : base(id, name, address, zip, city, email, password, isAdmin, isActive)
        {
            Id = id;
            CVR = cvr;
        }
    }



}
