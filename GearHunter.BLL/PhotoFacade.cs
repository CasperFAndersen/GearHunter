using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GearHunter.Core;
using GearHunter.DAL;
using Microsoft.EntityFrameworkCore;

namespace GearHunter.BLL
{
    public class PhotoFacade
    {
        private readonly UnitOfWork _unitOfWork = UnitOfWork.Instance;

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

            _unitOfWork.Context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].Photos ON;");
            _unitOfWork.Save();
            _unitOfWork.Context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].Photos OFF;");
        }

        public void UpdatePhoto(Photo photo)
        {
            _unitOfWork.PhotoRepository.Update(photo);

            _unitOfWork.Context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].Photos ON;");
            _unitOfWork.Save();
            _unitOfWork.Context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].Photos OFF;");
        }

        public void DeletePhoto(Photo photo)
        {
            _unitOfWork.PhotoRepository.Delete(photo);

            _unitOfWork.Context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].Photos ON;");
            _unitOfWork.Save();
            _unitOfWork.Context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].Photos OFF;");
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
