using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GearHunter.Core;
using GearHunter.DAL;


namespace GearHunter.BLL
{
    public class IndividualFacade
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();

        public IEnumerable<Individual> GetIndividuals()
        {
            return _unitOfWork.IndividualRepository.GetAll();
        }

        public Individual GetIndividual(int id)
        {
            return _unitOfWork.IndividualRepository.GetById(id);
        }

        public void AddIndividual(Individual individual)
        {
            
            if (!UserHelper.EmailAlreadyExists(individual.Email))
            {
                _unitOfWork.IndividualRepository.Add(individual);
                _unitOfWork.Save();
            }
            else throw new EmailAlreadyExistsException("Individual");
             
        }

        public void UpdateIndividual(Individual individual)
        {
            if (!UserHelper.EmailAlreadyExists(individual.Email))
            {
                _unitOfWork.IndividualRepository.Update(individual);
                _unitOfWork.Save();
            }
            else throw new EmailAlreadyExistsException("individual");
        }

        public void DeleteIndividual(Individual individual)
        {
            _unitOfWork.IndividualRepository.Delete(individual);
            _unitOfWork.Save();
        }

        public Task<List<Individual>> GetIndividualsAsync()
        {
            return _unitOfWork.IndividualRepository.FindAllAsync();
        }

        public Task<Individual> GetIndividualAsync(int id)
        {
            return _unitOfWork.IndividualRepository.FindByIdAsync(id);
        }

        public Individual GetByEmail(string email)
        {
            return _unitOfWork.IndividualRepository.GetByEmail(email);
        }

        public void ValidateIndividual(Individual individual, bool validate)
        {
            UserHelper.ValidateUser(individual, validate);
            _unitOfWork.IndividualRepository.Update(individual);
        }
    }
}
