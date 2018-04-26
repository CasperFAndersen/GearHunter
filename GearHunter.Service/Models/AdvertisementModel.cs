using GearHunter.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GearHunter.Service.Models
{
    public class AdvertisementModel
    {
        [Required]
        public int Id { get; set; }
        public string CatchyHeader { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public bool IsDeliverable { get; set; }
        public bool IsRentable { get; set; }
        //public bool IsActive { get; set; }
        //public DateTime? Created { get; set; }
        public List<Photo> Photos { get; set; }
        public Category Category { get; set; }
        public User User { get; set; }

        public AdvertisementModel()
        {

        }

        public AdvertisementModel (Advertisement advertisement)
        {
            if(advertisement == null)
            {
                return;
            }
            CatchyHeader = advertisement.CatchyHeader;
            Brand = advertisement.Brand;
            Model = advertisement.Model;
            Price = advertisement.Price;
            Description = advertisement.Description;
            Address = advertisement.Address;
            Zip = advertisement.Zip;
            City = advertisement.City;
            IsDeliverable = advertisement.IsDeliverable;
            IsRentable = advertisement.IsRentable;
            Photos = advertisement.Photos;
            Category = advertisement.Category;
            User = advertisement.User;
        }

        public Advertisement ToAdvertisement()
        {
            return new Advertisement
            {
                CatchyHeader = CatchyHeader,
                Brand = Brand,
                Model = Model,
                Price = Price,
                Description = Description,
                Address = Address,
                Zip = Zip,
                City = City,
                IsDeliverable = IsDeliverable,
                IsRentable = IsRentable,
                Photos = Photos,
                Category = Category,
                User = User
            };
        }

    }
}


