using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GearHunter.Core;
using GearHunter.DAL;

namespace GearHunter.BLL
{
    public class CompanyFacade
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        private UserHelper userHelper = new UserHelper();

        public IEnumerable<Company> GetCompanys()
        {
            return _unitOfWork.CompanyRepository.GetAll();
        }

        public Company GetCompany(int id)
        {
            return _unitOfWork.CompanyRepository.GetById(id);
        }

        public void AddCompany(Company company)
        {
            if (!userHelper.EmailAlreadyExists(company.Email))
            {
                _unitOfWork.CompanyRepository.Add(company);
                _unitOfWork.Save();
            }
            else throw new EmailAlreadyExistsException("Company");
        }

        public void UpdateCompany(Company company)
        {
            if (!userHelper.EmailAlreadyExists(company.Email))
            {
                _unitOfWork.CompanyRepository.Update(company);
                _unitOfWork.Save();
            }
            else throw new EmailAlreadyExistsException("Company");
        }

        public Company GetByEmail(string email)
        {
            return _unitOfWork.CompanyRepository.GetByEmail(email);
        }

        public void DeleteCompany(Company company)
        {
            _unitOfWork.CompanyRepository.Delete(company);
            _unitOfWork.Save();
        }

        public Task<List<Company>> GetCompanysAsync()
        {
            return _unitOfWork.CompanyRepository.FindAllAsync();
        }

        public Task<Company> GetCompanyAsync(int id)
        {
            return _unitOfWork.CompanyRepository.FindByIdAsync(id);
        }

        public void ValidateIndividual(Company company, bool validate)
        {
            userHelper.ValidateUser(company, validate);
            _unitOfWork.CompanyRepository.Update(company);
        }
    }
}
