using GearHunter.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GearHunter.Service.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public CategoryModel()
        {

        }

        public CategoryModel(Category category)
        {
            if(category == null)
            {
                return;
            }
            Name = category.Name;
        }

        public Category ToCategory()
        {
            return new Category
            {
                Name = Name
            };
        }
    }
}