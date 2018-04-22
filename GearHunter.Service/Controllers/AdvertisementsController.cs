using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using GearHunter.BLL;
using GearHunter.Core;
using GearHunter.Service.Models;

namespace GearHunter.Service.Controllers
{
    public class AdvertisementsController : ApiController
    {
        AdvertisementFacade advertisementFacade = new AdvertisementFacade();

        // GET api/advertisements
        public async Task<IHttpActionResult> Get()
        {
            return Ok(await advertisementFacade.GetAdvertisementsAsync());
        }

        // GET api/advertisements/5
        public async Task<IHttpActionResult> Get(int id)
        {
            Advertisement tempAdvertisement = await advertisementFacade.GetAdvertisementAsync(id);
            return Ok(tempAdvertisement);
        }

        // POST api/advertisements
        //Create a new advertisement.
        public IHttpActionResult Post([FromBody] AdvertisementModel advertisement)
        {
            try
            {
                advertisementFacade.AddAdvertisement(new Advertisement
                {
                    CatchyHeader = advertisement.CatchyHeader,
                    Brand = advertisement.Brand,
                    Model = advertisement.Model,
                    Price = advertisement.Price,
                    Description = advertisement.Description,
                    Address = advertisement.Address,
                    Zip = advertisement.Zip,
                    City = advertisement.City,
                    IsDeliverable = advertisement.IsDeliverable,
                    IsRentable = advertisement.IsRentable,
                    Photos = advertisement.Photos,
                    Category = advertisement.Category,
                    User = advertisement.User
                });

                return Ok();
            }
            catch (Exception ex)
            {
                //TODO: Skal vi sende Ex med videre her?
                throw new AdvertisementWasNotAddedException("Something went wrong while trying to add your advertisement, try again.", ex);
            }
        }

        // PUT api/advertisements/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/advertisements/5
        public async Task<IHttpActionResult> Delete(int id)
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