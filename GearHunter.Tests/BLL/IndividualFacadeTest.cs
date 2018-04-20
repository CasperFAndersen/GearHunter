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
    }
}
