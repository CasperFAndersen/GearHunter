using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GearHunter.Core
{
  public  class Advertisement
    {

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
        public bool IsActive { get; set; }
        public DateTime? Created { get; set; }
        public List<Photo> Photos { get; set; }
        public Category Category { get; set; }
        public User User { get; set; }
 

        public Advertisement()
        {
            
        }

        public Advertisement(string catchyHeader, string brand, string model, double price, string description, 
            string address, string zip, string city, bool isDeliverable, bool isRentable, 
            List<Photo> photos, Category category, User user)
        {
            this.CatchyHeader = catchyHeader;
            this.Brand = brand;
            this.Model = model;
            this.Price = price;
            this.Description = description;
            this.Address = address;
            this.Zip = zip;
            this.City = city;
            this.IsDeliverable = isDeliverable;
            this.IsRentable = isRentable;
            this.IsActive = true;
            this.Created = DateTime.Now;
            this.Photos = photos;
            this.Category = category;
            this.User = user;
        }

        public Advertisement(int id, string catchyHeader, string brand, string model, double price, string description,
            string address, string zip, string city, bool isDeliverable, bool isRentable, DateTime? created,
            List<Photo> photos, Category category, User user)
        {
            this.Id = id;
            this.CatchyHeader = catchyHeader;
            this.Brand = brand;
            this.Model = model;
            this.Price = price;
            this.Description = description;
            this.Address = address;
            this.Zip = zip;
            this.City = city;
            this.IsDeliverable = isDeliverable;
            this.IsRentable = isRentable;
            this.IsActive = true;
            this.Created = created;
            this.Photos = photos;
            this.Category = category;
            this.User = user;
        }
    }
}
