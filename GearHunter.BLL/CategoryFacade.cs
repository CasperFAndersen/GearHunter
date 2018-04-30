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

        public Task<IEnumerable<Category>> GetCategories()
        {
            return _unitOfWork.CategoryRepository.Get();
        }

        public Task<Category> GetCategory(int id)
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

    }
}
