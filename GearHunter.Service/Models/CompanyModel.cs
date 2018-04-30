using GearHunter.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GearHunter.Service.Models
{
    public class CompanyModel : UserModel
    {
        [Required]
        public string CVR { get; set; }

        public CompanyModel()
        {

        }

        public CompanyModel(Company company)
        {
            CVR = company.CVR;
            Name = company.Name;
            Address = company.Address;
            Zip = company.Zip;
            City = company.City;
            Email = company.Email;
            Password = company.Password;
            Phone = company.Phone;
        }

        public Company ToCompany()
        {
            return new Company
            {
            CVR = CVR,
            Name = Name,
            Address = Address,
            Zip = Zip,
            City = City,
            Email = Email,
            Password = Password,
            Phone = Phone
        };
        }

    }
    
}