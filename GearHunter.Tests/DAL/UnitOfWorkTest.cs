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
        public void GetAllTest()
        {
            int beforeInsert = unitOfWork.IndividualRepository.GetAll().Count;

            Assert.AreEqual(0, beforeInsert);

            Individual individual = new Individual{ Id = 000000, Name = "individualTestNavn", Password = "idvidualTestKode", Address = "individualVejTest25", IsActive = false, IsAdmin = false, IsValidated = false };
            unitOfWork.IndividualRepository.Add(individual);
            unitOfWork.Save();

            int afterInsert = unitOfWork.IndividualRepository.GetAll().Count;

            Assert.AreEqual(0, afterInsert - 1);

            unitOfWork.IndividualRepository.Delete(individual);
            unitOfWork.Save();
        }

        [TestMethod]
        public void GetAllAdvertisements()
        {
            Assert.AreNotEqual(0, unitOfWork.AdvertisementRepository.GetAll().Count);
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
            Advertisement advertisement = new Advertisement
            {
                Id = 99999,
                CatchyHeader = "CatchyHeaderTest",
                Created = DateTime.Now,
                IsActive = false,
                IsDeliverable = false,
                IsRentable = false,
                Category = new Category { Name = "CategoryTest" }
            };

            unitOfWork.AdvertisementRepository.Add(advertisement);


            Assert.IsNotNull(unitOfWork.AdvertisementRepository.GetById(99999));

            unitOfWork.AdvertisementRepository.Delete(advertisement);

            Assert.IsNull(unitOfWork.AdvertisementRepository.GetById(99999));


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
