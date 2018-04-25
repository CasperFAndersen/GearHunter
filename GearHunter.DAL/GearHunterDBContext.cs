using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GearHunter.Core;
using Microsoft.EntityFrameworkCore;

namespace GearHunter.DAL
{
    public class GearHunterDbContext : DbContext
    {

        public GearHunterDbContext() { }

        public GearHunterDbContext(DbContextOptions<GearHunterDbContext> options)
            :base(options) { }

        //TODO: Connection string needs to be added to the Gearhunter.Service appsettings.json file.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=kraka.ucn.dk;Database=dmab0916_1062358;User ID=dmab0916_1062358; Password=Password1!;");
        }

        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Individual> Individuals { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<User> Users { get; set; }

   
    }
}
