using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GearHunter.Core;

namespace GearHunter.DAL
{
    public class GearHunterDbContext : DbContext
    {
        public GearHunterDbContext() : base("gearhunterConnection")
        {
            
        }

        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Individual> Individuals { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<User> Users { get; set; }

   
    }
}
