using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GearHunter.Core;
using GearHunter.DAL;

namespace GearHunter.BLL
{
    class IndividualFacade
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
            _unitOfWork.IndividualRepository.Add(individual);
        }

        public void UpdateIndividual(Individual individual)
        {
            _unitOfWork.IndividualRepository.Update(individual);
        }

        public void DeleteIndividual(Individual individual)
        {
            _unitOfWork.IndividualRepository.Delete(individual);
        }

        public Task<List<Individual>> GetIndividualsAsync()
        {
            return _unitOfWork.IndividualRepository.FindAllAsync();
        }

        public Task<Individual> GetIndividualAsync(int id)
        {
            return _unitOfWork.IndividualRepository.FindByIdAsync(id);
        }
    }
}
