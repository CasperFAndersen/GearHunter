using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GearHunter.BLL;
using GearHunter.Core;

namespace GearHunter.Tests.BLL
{
    [TestClass]
    public class IndividualFacadeTest
    {
        private IndividualFacade individualFacade = new IndividualFacade();
        private PhotoFacade photoFacade = new PhotoFacade();
        private AdvertisementFacade advertisementFacade = new AdvertisementFacade();

        [TestMethod]
        public void GetByEmailTest()
        {
            Individual individualByEmail = individualFacade.GetByEmail("Casper@fakemail.dk");

            Assert.IsNotNull(individualByEmail);
            Assert.AreEqual(individualByEmail.Name, "Casper Froberg");
            Assert.AreEqual(individualByEmail.Email, "Casper@fakemail.dk");
        }

        [TestMethod]
        public void AddIndividualTestTest()
        {
            Individual individual = new Individual() { Name = "AddIndividualTest", Email = "AddIndividualTest@test.test" };
            int beforeInsert = individualFacade.GetIndividuals().ToList().Count;
            individualFacade.AddIndividual(individual);
            int AfterInsert = individualFacade.GetIndividuals().ToList().Count;

            Assert.AreEqual(AfterInsert - 1, beforeInsert);

            Individual individualByEmail = individualFacade.GetByEmail("AddIndividualTest@test.test");

            Assert.IsNotNull(individualByEmail);
            Assert.AreEqual(individualByEmail.Name, "AddIndividualTest");
            Assert.AreEqual(individualByEmail.Email, "AddIndividualTest@test.test");
            individualFacade.DeleteIndividual(individual);
        }
    }
}

