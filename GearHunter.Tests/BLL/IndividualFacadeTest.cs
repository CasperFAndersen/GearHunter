using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GearHunter.BLL;
using GearHunter.Core;

namespace GearHunter.Tests.BLL
{
    [TestClass]
    public class IndividualFacadeTest
    {
        private IndividualFacade individualFacade = new IndividualFacade();

        [TestMethod]
        public void GetByEmailTest()
        {
           // Individual Casper = new Individual("Casper Froberg", "DenDerVej 1", "9400", "Noerresundby", "Casper@fakemail.dk", "password1", "11111111", true, true, true)
            Individual individual = individualFacade.GetByEmail("Casper@fakemail.dk");

            Assert.IsNotNull(individual);
            Assert.IsTrue(individual.IsActive);
            Assert.AreEqual(individual.Name, "Casper Froberg");
            Assert.AreEqual(individual.Email, "Casper@fakemail.dk");
        }
    }
}
