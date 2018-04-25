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
    public class CategoryFacade
    {
        private readonly UnitOfWork _unitOfWork = UnitOfWork.Instance;

        public IEnumerable<Category> GetCategorys()
        {
            return _unitOfWork.CategoryRepository.GetAll();
        }

        public Category GetCategory(int id)
        {
            return _unitOfWork.CategoryRepository.GetById(id);
        }

        public void AddCategory(Category category)
        {
            _unitOfWork.CategoryRepository.Add(category);

            _unitOfWork.Context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].Categories ON;");
            _unitOfWork.Save();
            _unitOfWork.Context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].Categories OFF;");
        }

        public void UpdateCategory(Category category)
        {
            _unitOfWork.CategoryRepository.Update(category);

            _unitOfWork.Context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].Categories ON;");
            _unitOfWork.Save();
            _unitOfWork.Context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].Categories OFF;");
        }

        public void DeleteCategory(Category category)
        {
            _unitOfWork.CategoryRepository.Delete(category);

            _unitOfWork.Context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].Categories ON;");
            _unitOfWork.Save();
            _unitOfWork.Context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].Categories OFF;");
        }

        public Task<List<Category>> GetCategorysAsync()
        {
            return _unitOfWork.CategoryRepository.FindAllAsync();
        }

        public Task<Category> GetCategoryAsync(int id)
        {
            return _unitOfWork.CategoryRepository.FindByIdAsync(id);
        }
    }
}
