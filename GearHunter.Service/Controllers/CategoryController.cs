using GearHunter.BLL;
using GearHunter.Core;
using GearHunter.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GearHunter.Service.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        CategoryFacade categoryFacade = new CategoryFacade();

        // GET api/category
        [HttpGet]
        public IActionResult Get()
        {
            return Ok( categoryFacade.GetCategories().Result);
        }

        // GET api/category/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Category tempCategory = categoryFacade.GetCategory(id).Result;
            return Ok(tempCategory);
        }

        [HttpPost]
        // POST api/category
        public IActionResult Post([FromBody] CategoryModel category)
        {
            try
            {
                categoryFacade.AddCategory(category.ToCategory());
                return Ok();
            }
            catch (Exception ex)
            {
                //TODO: Skal vi sende Ex med videre her?
                throw new CategoryWasNotAddedException("Something went wrong while trying to add your Category, try again.", ex);
            }
        }

        // PUT api/category/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/category/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Category tempCategory = categoryFacade.GetCategory(id).Result;

                if (tempCategory == null)
                {
                    return NotFound();
                }

                else
                {
                    categoryFacade.DeleteCategory(categoryFacade.GetCategory(id).Result);
                    return Ok();
                }

            }
            catch (Exception ex)
            {
                //TODO: Brug denne exception.
                return BadRequest("The category could not be deleted, please try again.");
            }
        }
    }
}
