using System;
using System.Linq;
using GearHunter.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GearHunter.BLL.Tests
{
    [TestClass]
    public class IndividualFacadeTest
    {
        private IndividualFacade individualFacade = new IndividualFacade();
        private PhotoFacade photoFacade = new PhotoFacade();
        private AdvertisementFacade advertisementFacade = new AdvertisementFacade();


        //TODO: uncomment this shit.
     /*   [TestMethod]
        public void GetByEmailTest()
        {
            Individual individualByEmail = individualFacade.GetByEmail("Casper@fakemail.dk");

            Assert.IsNotNull(individualByEmail);
            Assert.AreEqual(individualByEmail.Name, "Casper Froberg");
            Assert.AreEqual(individualByEmail.Email, "Casper@fakemail.dk");
        } */

        [TestMethod]
        public void AddIndividualTest()
        {
            Individual individual = new Individual() { Name = "AddIndividualTest", Email = "AddIndividualTest@test.test" };
            int beforeInsert = individualFacade.GetIndividuals().Result.ToList().Count;
            individualFacade.AddIndividual(individual);
            int AfterInsert = individualFacade.GetIndividuals().Result.ToList().Count;

            Assert.AreEqual(AfterInsert - 1, beforeInsert);

            Individual individualByEmail = individualFacade.GetByEmail("AddIndividualTest@test.test");

            Assert.IsNotNull(individualByEmail);
            Assert.AreEqual(individualByEmail.Name, "AddIndividualTest");
            Assert.AreEqual(individualByEmail.Email, "AddIndividualTest@test.test");
            individualFacade.DeleteIndividual(individual);
        }

        [TestMethod]
        public void UpdateIndividualTest()
        {
            Individual individual = new Individual() { Name = "UpdateIndividualTest", Email = "TestUpdate@email.com" };
            individualFacade.AddIndividual(individual);
            Individual temp = new Individual() { Name = individual.Name };

            Individual individualFromEmail = individualFacade.GetByEmail("TestUpdate@email.com");

            individualFromEmail.Name = "UpdatedNameTest";

            individualFacade.UpdateIndividual(individualFromEmail);

            Individual individualAfterUpdate = individualFacade.GetByEmail("TestUpdate@email.com");

            Assert.IsNotNull(individualAfterUpdate);
            Assert.AreEqual(individualAfterUpdate.Name, "UpdatedNameTest");
            Assert.AreEqual(individualAfterUpdate.Email, "TestUpdate@email.com");
            Assert.AreEqual(individualFromEmail.Id, individualAfterUpdate.Id);
            Assert.AreNotEqual(temp.Name, individualAfterUpdate.Name);

            individualFacade.DeleteIndividual(individualAfterUpdate);
        }

        [TestMethod]
        public void UpdateIndividualEmailTest()
        {
            Individual individual = new Individual() { Name = "UpdateIndividualEmailTester", Email = "updateIndividualTest@tester.testdk" };
            individualFacade.AddIndividual(individual);
            Individual temp = new Individual() { Name = individual.Name, Email = individual.Email };

            Individual individualFromEmail = individualFacade.GetByEmail("updateIndividualTest@tester.testdk");

            individualFromEmail.Name = "UpdatedEmailTest";
            individualFromEmail.Email = "UpdateIndividualEmail@gmail.com";

            individualFacade.UpdateIndividualsEmail(individualFromEmail, temp.Email);

            Individual individualAfterUpdate = individualFacade.GetByEmail(individualFromEmail.Email);

            Assert.IsNotNull(individualAfterUpdate);
            Assert.AreEqual(individualAfterUpdate.Name, "UpdatedEmailTest");
            Assert.AreEqual(individualAfterUpdate.Email, "UpdateIndividualEmail@gmail.com");
            Assert.AreEqual(individualFromEmail.Id, individualAfterUpdate.Id);
            Assert.AreNotEqual(temp.Name, individualAfterUpdate.Name);
            Assert.AreNotEqual(temp.Email, individualAfterUpdate.Email);

            individualFacade.DeleteIndividual(individualAfterUpdate);
        }

        [TestMethod]
        public void DeleteTestFromfacade()
        {
            Advertisement advertisement = new Advertisement
            {
                CatchyHeader = "CatchyHeaderTest",
                Created = DateTime.Now,
                IsActive = false,
                IsDeliverable = false,
                IsRentable = false,
                Category = new Category { Name = "CategoryTest" },
                User = new Individual
                {
                    Name = "deleteTestUser",
                    IsActive = false,
                    IsAdmin = false,
                },
            };
            advertisementFacade.AddAdvertisement(advertisement);



            int beforeDelete = advertisementFacade.GetAdvertisements().Result.ToList().Count;

            Advertisement advertisementFromDB = advertisementFacade.GetAdvertisements().Result.Last();

            Assert.IsNotNull(advertisementFromDB);
            Assert.AreEqual(advertisement.User.Name, advertisementFromDB.User.Name);

            advertisementFacade.DeleteAdvertisement(advertisement);

            int AfterDelete = advertisementFacade.GetAdvertisements().Result.ToList().Count;

            Assert.AreEqual(AfterDelete, beforeDelete - 1);
        }
    }
}

