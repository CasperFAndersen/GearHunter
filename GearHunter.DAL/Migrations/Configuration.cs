using GearHunter.Core;

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
           // AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GearHunter.DAL.GearHunterDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //var individuals = Builder<Individual>.CreateListOfSize(100)
            //    .All()
            //    .With(x => x.Name = Faker.Name.FullName())
            //    .With(x => x.Phone = Faker.Phone.Number()).Build();

            //context.Individuals.AddOrUpdate(x => x.Id, individuals.ToArray());


            //Categories
            Category categoryGuitar = new Category() { Id = 1, Name = "Guitar" };
            Category categoryBass = new Category() { Id = 2, Name = "Bass" };
            Category categoryKlaver = new Category() { Id = 3, Name = "Klaver" };
            Category categoryTilbehoer = new Category() { Id = 4, Name = "Tilbehoer" };

            context.Categories.AddOrUpdate(x => x.Id, categoryGuitar, categoryBass, categoryKlaver, categoryTilbehoer);


            //Users

            //Individuals
            Individual Casper = new Individual(1, "Casper Froberg", "DenDerVej 1", "9400", "Noerresundby", "Casper@fakemail.dk", "password1", "11111111", true, true);
            Individual Stefan = new Individual(2,"Stefan Krabbe", "DenDerVej 2", "9220", "Aalborg Oest", "Stefan@fakemail.dk", "password2", "22222222", true, false);
            Individual Mikkel = new Individual(3, "Mikkel Paulsen", "DenDerVej 3", "9000", "Aalborg", "Mikkel@fakemail.dk", "password3", "33333333", true, true);
            Individual Anders = new Individual(4, "Anders Andersen", "DenDerVej 4", "9000", "Aalborg", "Anders@fakemail.dk", "password4", "44444444", true, false);
            Individual Bent = new Individual(5, "Bent Bentsen", "DenDerVej 5", "9000", "Aalborg", "Bent@fakemail.dk", "password5", "55555555", true, true);

            context.Individuals.AddOrUpdate(x => x.Id, Casper, Stefan, Mikkel, Anders, Bent);

            //Companies

            Company MusikUdlejningAps = new Company(6, "Musik Udlejning Aps", "DenDerVej 6", "9400", "Noerresundby", "MU@fakemail.dk", "password5", "11111111", false, true, "MusikUdlejningCVR");
            Company MejelarmIvs = new Company(7, "MejeLarm IVS", "DenDerVej 7", "9400", "Noerresundby", "ML@fakemail.dk", "password5", "22222222", false, true, "MejeLarmCVR");
            Company MusikLageretAps = new Company(8, "Musik Lageret Aps", "DenDerVej 8", "9400", "Noerresundby", "ML@fakemail.dk", "password5", "33333333", false, true, "MusikLageretCVR");
            context.Companies.AddOrUpdate(x => x.Id, MusikUdlejningAps, MejelarmIvs, MusikLageretAps);

            //Advertisements
            context.Advertisements.AddOrUpdate(x => x.Id,
                new Advertisement(1, "Smart guitar1", "Maerke1", "Model1", 1, "D1", "A1", "9000", "Aalborg", true, true, DateTime.Now, null, categoryGuitar, Casper),
                new Advertisement(2, "Lang guitar2", "Maerke2", "Model2", 1, "D2", "A2", "9200", "Aalborg", true, true, DateTime.Now, null, categoryGuitar, Stefan),
                new Advertisement(3, "Lille bass3", "Maerke3", "Model3", 1, "D3", "A3", "9440", "Aalborg", true, true, DateTime.Now, null, categoryBass, Mikkel),
                new Advertisement(4, "Stor bass4", "Maerke4", "Model4", 1, "D4", "A4", "9000", "Aalborg", true, true, DateTime.Now, null, categoryBass, Anders),
                new Advertisement(5, "Dyrt Klaver5", "Maerke5", "Model5", 1, "D5", "A5", "9200", "Aalborg", true, true, DateTime.Now, null, categoryKlaver, Bent),
                new Advertisement(6, "Billigt Klaver6", "Maerke6", "Model6", 1, "D6", "A6", "9440", "Aalborg", true, true, DateTime.Now, null, categoryKlaver, MusikUdlejningAps),
                new Advertisement(7, "Langt Keyboard7", "Maerke7", "Model7", 1, "D7", "A7", "9000", "Aalborg", true, true, DateTime.Now, null, categoryKlaver, MejelarmIvs),
                new Advertisement(8, "Kort Keyboard8", "Maerke8", "Model8", 1, "D8", "A8", "9200", "Aalborg", true, true, DateTime.Now, null, categoryKlaver, MusikLageretAps),
                new Advertisement(9, "Tromme stikker", "Maerke9", "Model9", 1, "D9", "A9", "9400", "Aalborg", true, true, DateTime.Now, null, categoryTilbehoer, MusikLageretAps)
                );
        }
    }
}
