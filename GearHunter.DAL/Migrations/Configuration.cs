using GearHunter.Core;

namespace GearHunter.DAL.Migrations
{
    using FizzWare.NBuilder;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GearHunter.DAL.GearHunterDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GearHunterDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //var individuals = Builder<Individual>.CreateListOfSize(100)
            //    .All()
            //    .With(x => x.Name = Faker.Name.FullName())
            //    .With(x => x.Phone = Faker.Phone.Number()).Build();

            //context.Individuals.AddOrUpdate(x => x.Id, individuals.ToArray());

            Category category = new Category() { Name = "Guitar" };
            context.Categories.AddOrUpdate(x => x.Id, category);

            context.Advertisements.AddOrUpdate(x => x.Id,
                new Advertisement("Smart guitar", "Maerke1", "Model1", 1, "D1", "A1", "9000", "Aalborg", true, true, true, DateTime.Now, null, category)
                );


        }
    }
}
