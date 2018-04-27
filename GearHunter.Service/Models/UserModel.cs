using GearHunter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GearHunter.Service.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        //public bool IsAdmin { get; set; }
        //public bool IsActive { get; set; }
        public bool IsValidated { get; set; }

        public UserModel()
        {
        }

        //TODO: I think we should type convert like this, 
        public static explicit operator UserModel(User user)
        {
            UserModel userModel = new UserModel();
            userModel.Id = user.Id;
            return userModel;
        }


        public UserModel(User user)
        {
            if (user == null)
            {
                return;
            }

            Id = user.Id;
            Name = user.Name;
            Address = user.Address;
            Zip = user.Zip;
            City = user.City;
            Email = user.Email;
            Password = user.Password;
            Phone = user.Phone;
        }



        public User ToUser()
        {
            return new User
            {
                Id = Id,
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