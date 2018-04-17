using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GearHunter.Core;

namespace GearHunter.DAL
{
    public class UnitOfWork : IDisposable
    {
        private GearHunterDbContext context = new GearHunterDbContext();
        private GenericRepository<Advertisement> advertisementRepository;
        private GenericRepository<Category> categoryRepository;
        private CompanyRepository companyRepository;
        private IndividualRepository individualRepository;
        private GenericRepository<Photo> photoRepository;
        private GenericRepository<User> userRepository;

        public GenericRepository<Advertisement> AdvertisementRepository
        {
            get
            {
                return this.advertisementRepository ?? new GenericRepository<Advertisement>(context);
            }
        }

        public GenericRepository<Category> CategoryRepository
        {
            get
            {
                return this.categoryRepository ?? new GenericRepository<Category>(context);
            }
        }

        public CompanyRepository CompanyRepository
        {
            get
            {
                return this.companyRepository ?? new CompanyRepository(context);
            }
        }

        public IndividualRepository IndividualRepository
        {
            get
            {
                return this.individualRepository ?? new IndividualRepository(context);
            }
        }

        public GenericRepository<Photo> PhotoRepository
        {
            get
            {
                return this.photoRepository ?? new GenericRepository<Photo>(context);
            }
        }

        public GenericRepository<User> UserRepository
        {
            get
            {
                return this.userRepository ?? new GenericRepository<User>(context);
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void SaveAsync()
        {
           context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
