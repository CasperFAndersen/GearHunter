using GearHunter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GearHunter.Service.Models
{
    public class IndividualModel : UserModel
    {
        public IndividualModel()
        {

        }

        public IndividualModel(Individual individual)
        {
            Name = individual.Name;
            Address = individual.Address;
            Zip = individual.Zip;
            City = individual.City;
            Email = individual.Email;
            Password = individual.Password;
            Phone = individual.Phone;
        }

        public Individual ToIndividual()
        {
            return new Individual
            {
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