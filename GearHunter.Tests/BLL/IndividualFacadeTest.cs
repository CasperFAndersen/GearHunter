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
            // Individual Casper = new Individual("Casper Froberg", "DenDerVej 1", "9400", "Noerresundby", "Casper@fakemail.dk", "password1", "11111111", true, true, true)
            Individual individual = new Individual() { Name = "GetByEmailTest", Email = "test@tester.dk" };
            individualFacade.AddIndividual(individual);


            Individual individualByEmail = individualFacade.GetByEmail("test@tester.dk");

            Assert.IsNotNull(individualByEmail);
            Assert.AreEqual(individualByEmail.Name, "GetByEmailTest");
            Assert.AreEqual(individualByEmail.Email, "test@tester.dk");

            individualFacade.DeleteIndividual(individualByEmail);
        }

        [TestMethod]
        public void getAllTest()
        {
            Assert.AreEqual(0, individualFacade.GetIndividuals().Count());
        }

        [TestMethod]
        public void getAllPhotosTest()
        {
            Assert.AreEqual(0, photoFacade.GetPhotos().Count());
        }

        [TestMethod]
        public void getAllAdvertisementsTest()
        {
            Assert.AreEqual(0, advertisementFacade.GetAdvertisements().Count());
        }
    }
}
