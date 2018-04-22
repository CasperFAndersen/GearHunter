using GearHunter.BLL;
using GearHunter.Core;
using GearHunter.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GearHunter.Service.Controllers
{
    public class CategoryController : ApiController
    {
        CategoryFacade categoryFacade = new CategoryFacade();

        // GET api/category
        [Route("api/category")]
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            return Ok(await categoryFacade.GetCategorysAsync());
        }

        // GET api/category/5
        [Route("api/category/{id:int}")]
        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            Category tempCategory = await categoryFacade.GetCategoryAsync(id);
            return Ok(tempCategory);
        }

        [Route("api/category")]
        [HttpPost]
        // POST api/category
        //Create a new category.
        public IHttpActionResult Post([FromBody] CategoryModel category)
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
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/category/5
        [Route("api/category/{id:int}")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                Category tempCategory = await categoryFacade.GetCategoryAsync(id);

                if (tempCategory == null)
                {
                    return NotFound();
                }

                else
                {
                    categoryFacade.DeleteCategory(categoryFacade.GetCategory(id));
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
