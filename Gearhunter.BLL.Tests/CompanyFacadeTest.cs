using GearHunter.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GearHunter.BLL.Tests
{
    [TestClass]
    public class CompanyFacadeTest
    {
        CompanyFacade companyFacade = new CompanyFacade();

        [TestMethod]
        public void AddCompanyTest()
        {
            Company company = new Company() {Name = "AddCompanyTest", Email = "AddCompanyTest@test.dk",
                                             isValidated = false, IsActive = false, IsAdmin = true };

            int beforeInsert = companyFacade.GetCompanysAsync().Result.Count;
            companyFacade.AddCompany(company);
            int afterInsert = companyFacade.GetCompanysAsync().Result.Count;

            Assert.AreEqual(afterInsert - 1, beforeInsert);
            companyFacade.DeleteCompany(company);
        }

        [TestMethod]
        public void UpdateCompanyTest()
        {
            Company company = new Company()
            {
                Name = "UpdateCompanyTest",
                Email = "UpdateCompanyTest@test.dk",
                isValidated = false,
                IsActive = false,
                IsAdmin = true
            };

            Company temp = new Company() { Name = company.Name, Email = company.Email, IsAdmin = company.IsAdmin };

            companyFacade.AddCompany(company);

            Company companyFromEmail = companyFacade.GetByEmail(company.Email);

            Assert.AreEqual(companyFromEmail.Name, company.Name);
            Assert.IsTrue(companyFromEmail.IsAdmin);

            companyFromEmail.Name = "UpdatedName";
            companyFromEmail.IsAdmin = false;

            companyFacade.UpdateCompany(companyFromEmail);

            Company companyAfterUpdate = companyFacade.GetByEmail(companyFromEmail.Email);

            Assert.AreEqual(companyAfterUpdate.Email, temp.Email);
            Assert.AreEqual(companyAfterUpdate.Id, companyFromEmail.Id);
            Assert.AreEqual(companyAfterUpdate.Name, "UpdatedName");
            Assert.IsFalse(companyAfterUpdate.IsAdmin);
            Assert.AreNotEqual(companyAfterUpdate.Name, temp.Name);

            companyFacade.DeleteCompany(company);
        }

        [TestMethod]
        public void UpdateCompaniesEmailTest()
        {
            Company company = new Company()
            {
                Name = "UpdateCompaniesEmailTest",
                Email = "UpdateCompaniesEmailTest@tester.test",
                isValidated = false,
                IsActive = false,
                IsAdmin = true
            };

            Company temp = new Company() { Name = company.Name, Email = company.Email, IsAdmin = company.IsAdmin };

            companyFacade.AddCompany(company);

            Company companyFromEmail = companyFacade.GetByEmail(company.Email);

            Assert.AreEqual(companyFromEmail.Name, company.Name);
            Assert.IsTrue(companyFromEmail.IsAdmin);

            companyFromEmail.Name = "UpdatedName";
            companyFromEmail.Email = "UpdatedEmail@mail.test";
            companyFromEmail.IsAdmin = false;

            companyFacade.UpdateCompaniesEmail(companyFromEmail, temp.Email);

            Company companyAfterUpdate = companyFacade.GetByEmail(companyFromEmail.Email);

            Assert.AreEqual(companyAfterUpdate.Id, companyFromEmail.Id);
            Assert.AreEqual(companyAfterUpdate.Name, "UpdatedName");
            Assert.AreEqual(companyAfterUpdate.Email, "UpdatedEmail@mail.test");
            Assert.IsFalse(companyAfterUpdate.IsAdmin);
            Assert.AreNotEqual(companyAfterUpdate, temp.Name);
            Assert.AreNotEqual(companyAfterUpdate.Email, temp.Email);

            companyFacade.DeleteCompany(company);
        }
    }
}
