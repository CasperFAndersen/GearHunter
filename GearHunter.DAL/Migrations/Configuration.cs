using GearHunter.Core.Models;

namespace GearHunter.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GearHunter.DAL.GearHunterDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GearHunter.DAL.GearHunterDbContext context)
        {
            Category category = new Category() {Name = "Guitar"};
            context.Categories.AddOrUpdate(x => x.Id, category);

            context.Advertisements.AddOrUpdate( x => x.Id,
                new Advertisement("Smart guitar", "Maerke1", "Model1", 1, "D1", "A1", "9000", "Aalborg", true, true, true, DateTime.Now, null, category)
                );

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
