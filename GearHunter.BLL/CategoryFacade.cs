using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GearHunter.Core;
using GearHunter.DAL;

namespace GearHunter.BLL
{
    public class CategoryFacade
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();

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
            _unitOfWork.Save();
        }

        public void UpdateCategory(Category category)
        {
            _unitOfWork.CategoryRepository.Update(category);
            _unitOfWork.Save();
        }

        public void DeleteCategory(Category category)
        {
            _unitOfWork.CategoryRepository.Delete(category);
            _unitOfWork.Save();
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
