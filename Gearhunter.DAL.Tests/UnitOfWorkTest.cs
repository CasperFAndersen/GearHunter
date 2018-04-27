using System;
using System.Linq;
using GearHunter.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GearHunter.DAL.Tests
{
    [TestClass]
    public class UnitOfWorkTest
    {
        private readonly UnitOfWork unitOfWork = UnitOfWork.Instance;


        [TestMethod]
        public void AddUserTest()
        {
            Individual individual = new Individual
            {
                Name = "individualTestName",
                Password = "idvidualTestPassword",
                Address = "individualAdressTest",
                IsActive = false,
                IsAdmin = false
            };

            unitOfWork.IndividualRepository.Add(individual);
            unitOfWork.Save();

            Individual individualFromDB = unitOfWork.IndividualRepository.GetById(unitOfWork.IndividualRepository.Get().Last().Id);

            Assert.IsNotNull(individualFromDB);
            Assert.AreEqual(individual.Name, individualFromDB.Name);
            Assert.IsFalse(individualFromDB.IsActive);

            unitOfWork.IndividualRepository.Delete(individual);
            unitOfWork.Save();

        }

        [TestMethod]
        public void GetAllTest()
        {
            int beforeInsert = unitOfWork.IndividualRepository.Get().Count();


            Individual individual = new Individual
            {
                Id = 000000,
                Name = "individualTestNavn",
                Password = "idvidualTestKode",
                Address = "individualVejTest25",
                IsActive = false,
                IsAdmin = false,
            };
            unitOfWork.IndividualRepository.Add(individual);
            unitOfWork.Save();

            int afterInsert = unitOfWork.IndividualRepository.Get().Count();

            Assert.AreEqual(beforeInsert, afterInsert - 1);

            unitOfWork.IndividualRepository.Delete(individual);
            unitOfWork.Save();
        }

        [TestMethod]
        public void GetByIdTest()
        {
            Category category = new Category { Name = "CategoryTest" };
            unitOfWork.CategoryRepository.Add(category);
            unitOfWork.Save();

            Category categoryFromDb = unitOfWork.CategoryRepository.GetById(unitOfWork.CategoryRepository.Get().Last().Id);

            Assert.IsNotNull(categoryFromDb);
            Assert.AreEqual(category, categoryFromDb);

            unitOfWork.CategoryRepository.Delete(category);
            unitOfWork.Save();
        }




        [TestMethod]
        public void DeleteTest()
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

            unitOfWork.AdvertisementRepository.Add(advertisement);
            unitOfWork.Save();


            int beforeDelete = unitOfWork.AdvertisementRepository.Get().Count();

            Advertisement advertisementFromDB = unitOfWork.AdvertisementRepository.GetById(unitOfWork.AdvertisementRepository.Get().Last().Id);

            Assert.IsNotNull(advertisementFromDB);
            Assert.AreEqual(advertisement.User.Name, advertisementFromDB.User.Name);

            unitOfWork.AdvertisementRepository.Delete(advertisement);
            unitOfWork.Save();


            int AfterDelete = unitOfWork.AdvertisementRepository.Get().Count();

            Assert.AreEqual(AfterDelete, beforeDelete - 1);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Company company = new Company { Name = "CompanyNameTest", IsActive = false, IsAdmin = false, CVR = "CVRTest" };

            unitOfWork.CompanyRepository.Add(company);
            unitOfWork.Save();

            Assert.AreEqual("CompanyNameTest", company.Name);
            Assert.IsFalse(company.IsActive);

            company.Name = "UpdatedCompanyNameTest";
            company.IsActive = true;

            unitOfWork.CompanyRepository.Update(company);
            unitOfWork.Save();

            company = unitOfWork.CompanyRepository.GetById(unitOfWork.CompanyRepository.Get().Last().Id);

            Assert.AreEqual("UpdatedCompanyNameTest", company.Name);
            Assert.IsTrue(company.IsActive);

            unitOfWork.CompanyRepository.Delete(company);
        }

        [TestMethod]
        public void FindAllAsyncTest()
        {
            int beforeInsert = unitOfWork.IndividualRepository.Get().Count();

            Individual individual = new Individual { Name = "individualTestNavn", Password = "idvidualTestKode", Address = "individualVejTest25", IsActive = false, IsAdmin = false };

            unitOfWork.IndividualRepository.Add(individual);
            unitOfWork.Save();

            int afterInsert = unitOfWork.IndividualRepository.Get().Count();

            Assert.AreEqual(beforeInsert, afterInsert - 1);

            unitOfWork.IndividualRepository.Delete(individual);
            unitOfWork.Save();
        }

        [TestMethod]
        public void FindByIdAsyncTest()
        {
            Category category = new Category { Name = "CategoryTest" };

            unitOfWork.CategoryRepository.Add(category);
            unitOfWork.Save();

            Category categoryFromDb = unitOfWork.CategoryRepository.GetById(unitOfWork.CategoryRepository.Get().Last().Id);

            Assert.IsNotNull(categoryFromDb);
            Assert.AreEqual(category.Name, categoryFromDb.Name);

            unitOfWork.CategoryRepository.Delete(category);
        }

    }
}
