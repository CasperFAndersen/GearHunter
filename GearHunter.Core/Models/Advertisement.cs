using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearHunter.Core.Models
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

        public Advertisement()
        {
            
        }

        public Advertisement(string catchyHeader, string brand, string model, double price, string description, 
            string address, string zip, string city, bool isDeliverable, bool isRentable, bool isActive, DateTime? created, 
            List<Photo> photos, Category category)
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
            this.IsActive = isActive;
            this.Created = created;
            this.Photos = photos;
            this.Category = category;
        }
    }
}
