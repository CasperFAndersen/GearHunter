using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GearHunter.Core;

namespace GearHunter.DAL
{
    class UnitOfWork : IDisposable
    {
        private GearHunterDbContext context = new GearHunterDbContext();
        private Repository<Advertisement> advertisementRepository;
        private Repository<Category> categoryRepository;
        private Repository<Company> companyRepository;
        private Repository<Individual> individualRepository;
        private Repository<Photo> photoRepository;
        private Repository<User> userRepository;

        //Repository for the Advertisement
        public Repository<Advertisement> AdvertisementRepository
        {
            get
            {
                return this.advertisementRepository ?? new Repository<Advertisement>(context);
            }
        }

        //Repository for the category
        public Repository<Category> CategoryRepository
        {
            get
            {
                return this.categoryRepository ?? new Repository<Category>(context);
            }
        }

        //Repository for the company
        public Repository<Company> CompanyRepository
        {
            get
            {
                return this.companyRepository ?? new Repository<Company>(context);
            }
        }

        //Repository for the Individual
        public Repository<Individual> IndividualRepository
        {
            get
            {
                return this.individualRepository ?? new Repository<Individual>(context);
            }
        }

        //Repository for the Photos
        public Repository<Photo> PhotoRepository
        {
            get
            {
                return this.photoRepository ?? new Repository<Photo>(context);
            }
        }

        //Repository for the Users
        public Repository<User> UserRepository
        {
            get
            {
                return this.userRepository ?? new Repository<User>(context);
            }
        }

        public void Save()
        {
            context.SaveChanges();
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
