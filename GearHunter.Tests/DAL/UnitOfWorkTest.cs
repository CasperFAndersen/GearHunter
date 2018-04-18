using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GearHunter.DAL;
using GearHunter.Core;

namespace GearHunter.Tests.DAL
{
    [TestClass]
    public class UnitOfWorkTest
    {
        UnitOfWork unitOfWork = new UnitOfWork();


        [TestMethod]
        public void AddUserTest()
        {
            Individual individual = new Individual
            {
                Id = 99999,
                Name = "individualTestName",
                Password = "idvidualTestPassword",
                Address = "individualAdressTest",
                IsActive = false,
                IsAdmin = false,
                IsValidated = false
            };

            unitOfWork.IndividualRepository.Add(individual);

            Individual individualFromDB = unitOfWork.IndividualRepository.GetById(99999);

            Assert.IsNotNull(individualFromDB);
            Assert.AreEqual(individual.Name, individualFromDB.Name);
            Assert.IsFalse(individualFromDB.IsActive);

        }

        [TestMethod]
        public void GetAllTest()
        {
            int beforeInsert = unitOfWork.IndividualRepository.GetAll().Count;


            Individual individual = new Individual{ Id = 000000, Name = "individualTestNavn", Password = "idvidualTestKode",
                                                    Address = "individualVejTest25", IsActive = false, IsAdmin = false, IsValidated = false };
            unitOfWork.IndividualRepository.Add(individual);
            unitOfWork.Save();

            int afterInsert = unitOfWork.IndividualRepository.GetAll().Count;

            Assert.AreEqual(beforeInsert, afterInsert - 1);

            unitOfWork.IndividualRepository.Delete(individual);
            unitOfWork.Save();
        }

        [TestMethod]
        public void GetByIdTest()
        {
            Category category = new Category { Id = 999999, Name = "CategoryTest" };
            unitOfWork.CategoryRepository.Add(category);
            
            Category categoryFromDb = unitOfWork.CategoryRepository.GetById(999999);

            Assert.IsNotNull(categoryFromDb);
            Assert.AreEqual(category, categoryFromDb);

            unitOfWork.CategoryRepository.Delete(category);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Individual individual = new Individual
            {
                Name = "deleteTestUser",
                IsActive = false,
                IsAdmin = false,
                IsValidated = false,
                Id = 199999
            };

            Advertisement advertisement = new Advertisement
            {
                Id = 99999,
                CatchyHeader = "CatchyHeaderTest",
                Created = DateTime.Now,
                IsActive = false,
                IsDeliverable = false,
                IsRentable = false,
                Category = new Category { Name = "CategoryTest" },
                User = individual,
            };

            unitOfWork.AdvertisementRepository.Add(advertisement);


            Assert.IsNotNull(unitOfWork.AdvertisementRepository.GetById(99999));

            unitOfWork.AdvertisementRepository.Delete(advertisement);
            unitOfWork.IndividualRepository.Delete(individual);

            Advertisement adFromDB = unitOfWork.AdvertisementRepository.GetById(99999);

            Assert.AreNotEqual(advertisement.CatchyHeader, adFromDB.CatchyHeader);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Company company = new Company { Id = 99999, Name = "CompanyNameTest", IsActive = false, IsAdmin = false, CVR = "CVRTest"};

            unitOfWork.CompanyRepository.Add(company);

            Assert.AreEqual("CompanyNameTest", company.Name);
            Assert.IsFalse(company.IsActive);

            company.Name = "UpdatedCompanyNameTest";
            company.IsActive = true;

            unitOfWork.CompanyRepository.Update(company);

            company = unitOfWork.CompanyRepository.GetById(99999);

            Assert.AreEqual("UpdatedCompanyNameTest", company.Name);
            Assert.IsTrue(company.IsActive);

            unitOfWork.CompanyRepository.Delete(company);
        }


        [TestMethod]
        public void FindAllAsyncTest()
        {
            int beforeInsert = unitOfWork.IndividualRepository.FindAllAsync().Result.Count;

            Individual individual = new Individual { Name = "individualTestNavn", Password = "idvidualTestKode", Address = "individualVejTest25", IsActive = false, IsAdmin = false, IsValidated = false };

            unitOfWork.IndividualRepository.Add(individual);
            unitOfWork.Save();

            int afterInsert = unitOfWork.IndividualRepository.FindAllAsync().Result.Count;

            Assert.AreEqual(beforeInsert, afterInsert - 1);

            unitOfWork.IndividualRepository.Delete(individual);
            unitOfWork.Save();
        }

        [TestMethod]
        public void FindByIdAsyncTest()
        {
            Category category = new Category { Id = 999999, Name = "CategoryTest" };
            unitOfWork.CategoryRepository.Add(category);

            Category categoryFromDb = unitOfWork.CategoryRepository.FindByIdAsync(999999).Result;

            Assert.IsNotNull(categoryFromDb);
            Assert.AreEqual(category, categoryFromDb);

            unitOfWork.CategoryRepository.Delete(category);
        }
    }
}
