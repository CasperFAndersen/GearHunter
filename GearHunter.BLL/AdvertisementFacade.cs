using System.Collections.Generic;
using System.Threading.Tasks;
using GearHunter.Core;
using GearHunter.DAL;
using Microsoft.EntityFrameworkCore;

namespace GearHunter.BLL
{
    public class AdvertisementFacade
    {
        private readonly UnitOfWork _unitOfWork = UnitOfWork.Instance;

        public Task<IEnumerable<Advertisement>> GetAdvertisements()
        {
            return _unitOfWork.AdvertisementRepository.Get();
        }

        public IEnumerable<Advertisement> GetAdvertisementsByUserId(int id)
        {
            return _unitOfWork.AdvertisementRepository.Get(advertisement => advertisement.User.Id == id).Result;
        }

        public IEnumerable<Advertisement> GetAdvertisementsByCategoryId(int id)
        {
            return _unitOfWork.AdvertisementRepository.Get(advertisement => advertisement.Category.Id == id).Result;
        }

        public Task<Advertisement> GetAdvertisement(int id)
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

    }
}
