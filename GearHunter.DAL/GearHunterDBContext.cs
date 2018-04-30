using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GearHunter.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GearHunter.DAL
{
    public class GearHunterDbContext : DbContext
    {
        public static string ConnectionString { get; set; }

        public GearHunterDbContext() { }

        public GearHunterDbContext(DbContextOptions<GearHunterDbContext> options)
            :base(options) { }

        //This solution is inspired by https://code.msdn.microsoft.com/How-to-using-Entity-1464feea
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //If optionsBuilder is not configured, a test-database is used
            if (!optionsBuilder.IsConfigured && ConnectionString == null)
            {
                optionsBuilder.UseSqlServer(@"Data Source=.\SQLExpress;Initial Catalog=GearHunterTestDatabase;Integrated Security=True");
            }
            else
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Individual> Individuals { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<User> Users { get; set; }

   
    }
}
