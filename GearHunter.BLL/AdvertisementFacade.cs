using System.Collections.Generic;
using System.Threading.Tasks;
using GearHunter.Core;
using GearHunter.DAL;

namespace GearHunter.BLL
{
    public class AdvertisementFacade
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();

        public IEnumerable<Advertisement> GetAdvertisements()
        {
            return _unitOfWork.AdvertisementRepository.GetAll();
        }

        public Advertisement GetAdvertisement(int id)
        {
            return _unitOfWork.AdvertisementRepository.GetById(id);
        }

        public void AddAdvertisement(Advertisement advertisement)
        {
            _unitOfWork.AdvertisementRepository.Add(advertisement);
            _unitOfWork.Save();
        }

        public void UpdateAdvertisement(Advertisement advertisement)
        {
            _unitOfWork.AdvertisementRepository.Update(advertisement);
            _unitOfWork.Save();
        }

        public void DeleteAdvertisement(Advertisement advertisement)
        {
            _unitOfWork.AdvertisementRepository.Delete(advertisement);
            _unitOfWork.Save();
        }

        public Task<List<Advertisement>> GetAdvertisementsAsync()
        {
            return _unitOfWork.AdvertisementRepository.FindAllAsync();
        }

        public Task<Advertisement> GetAdvertisementAsync(int id)
        {
            return _unitOfWork.AdvertisementRepository.FindByIdAsync(id);
        }
    }
}
