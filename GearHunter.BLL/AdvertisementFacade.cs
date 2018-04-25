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

            _unitOfWork.Context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].Advertisements ON;");
            _unitOfWork.Context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Users ON;");
            _unitOfWork.Save();
            _unitOfWork.Context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].Advertisements OFF;");
        }

        public void UpdateAdvertisement(Advertisement advertisement)
        {
            _unitOfWork.AdvertisementRepository.Update(advertisement);

            _unitOfWork.Context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].Advertisements ON;");
            _unitOfWork.Save();
            _unitOfWork.Context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].Advertisements OFF;");
        }

        public void DeleteAdvertisement(Advertisement advertisement)
        {
            _unitOfWork.AdvertisementRepository.Delete(advertisement);

            _unitOfWork.Context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].Advertisements ON;");
            _unitOfWork.Save();
            _unitOfWork.Context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].Advertisements OFF;");
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
