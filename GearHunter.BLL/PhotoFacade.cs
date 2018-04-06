using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GearHunter.Core;
using GearHunter.DAL;

namespace GearHunter.BLL
{
    class PhotoFacade
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();

        public IEnumerable<Photo> GetPhotos()
        {
            return _unitOfWork.PhotoRepository.GetAll();
        }

        public Photo GetPhoto(int id)
        {
            return _unitOfWork.PhotoRepository.GetById(id);
        }

        public void AddPhoto(Photo photo)
        {
            _unitOfWork.PhotoRepository.Add(photo);
        }

        public void UpdatePhoto(Photo photo)
        {
            _unitOfWork.PhotoRepository.Update(photo);
        }

        public void DeletePhoto(Photo photo)
        {
            _unitOfWork.PhotoRepository.Delete(photo);
        }

        public Task<List<Photo>> GetPhotosAsync()
        {
            return _unitOfWork.PhotoRepository.FindAllAsync();
        }

        public Task<Photo> GetPhotoAsync(int id)
        {
            return _unitOfWork.PhotoRepository.FindByIdAsync(id);
        }
    }
}
