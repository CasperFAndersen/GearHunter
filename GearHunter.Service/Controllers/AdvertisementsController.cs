using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using GearHunter.BLL;
using GearHunter.Core;
using GearHunter.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace GearHunter.Service.Controllers
{
    [Route("api/[controller]")]
    public class AdvertisementsController : Controller
    {
        AdvertisementFacade advertisementFacade = new AdvertisementFacade();

        // GET api/advertisements
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await advertisementFacade.GetAdvertisementsAsync());
        }

        // GET api/advertisements/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try { 
            Advertisement tempAdvertisement = await advertisementFacade.GetAdvertisementAsync(id);
            return Ok(tempAdvertisement);
            }
            catch
            {
                return BadRequest("Site not found");
            }
        }

        [HttpPost]
        // POST api/advertisements
        public ActionResult Post([FromBody] AdvertisementModel advertisement)
        {
            try
            {
                advertisementFacade.AddAdvertisement(advertisement.ToAdvertisement());
                
                //Metode ToAdvertisement() istedet for understående. Se AdvertisementModel.
                //{
                //    CatchyHeader = advertisement.CatchyHeader,
                //    Brand = advertisement.Brand,
                //    Model = advertisement.Model,
                //    Price = advertisement.Price,
                //    Description = advertisement.Description,
                //    Address = advertisement.Address,
                //    Zip = advertisement.Zip,
                //    City = advertisement.City,
                //    IsDeliverable = advertisement.IsDeliverable,
                //    IsRentable = advertisement.IsRentable,
                //    Photos = advertisement.Photos,
                //    Category = advertisement.Category,
                //    User = advertisement.User
                //});

                return Ok();
            }
            catch (Exception ex)
            {
                //TODO: Skal vi sende Ex med videre her?
                throw new AdvertisementWasNotAddedException("Something went wrong while trying to add your advertisement, try again.", ex);
            }
        }

        // PUT api/advertisements/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/advertisements/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Advertisement tempAdvertisement = await advertisementFacade.GetAdvertisementAsync(id);

                if(tempAdvertisement == null)
                {
                    return NotFound();
                }

                if(tempAdvertisement.IsActive == true)
                {
                    return BadRequest("Can not delete Advertisement because it is currently active.");
                }

                else
                {
                    advertisementFacade.DeleteAdvertisement(advertisementFacade.GetAdvertisement(id));
                    return Ok();
                }

            }
            catch(Exception ex)
            {
                //TODO: Brug denne exception.
                return BadRequest("The advertisement could not be deleted, please try again.");
            }
        }
    }
}