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

namespace GearHunter.Service.Controllers
{
    //TODO - vi skal bruge models i vores webapi for validation.
    public class AdvertisementsController : ApiController
    {
        AdvertisementFacade advertisementFacade = new AdvertisementFacade();

        // GET api/advertisements
        public async Task<IEnumerable<Advertisement>> Get()
        {
            List<Advertisement> advertisements = await advertisementFacade.GetAdvertisementsAsync();
            return advertisements;
        }

        // GET api/advertisements/5
        public Advertisement Get(int id)
        {
            return advertisementFacade.GetAdvertisement(id);
        }

        // POST api/advertisements
        //Create a new advertisement.
        public void Post([FromBody] Advertisement advertisement)
        {

        }

        // PUT api/advertisements/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/advertisements/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                Advertisement tempAdvertisement = advertisementFacade.GetAdvertisement(id);

                if(tempAdvertisement == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                if(tempAdvertisement.IsActive == true)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Can not delete Advertisement because it is currently active.");
                }
                //måske ikke nødvendigt med et kald mere til databasen her? Hvor vi henter den ovenover?
                // kommer vel an på EF's måde at håndtere den på?
                //++ skulle vi ændre så delete retunere true eller false afhængig af om det virker? 
                //så kan vi bruge understående.

                //if (advertisementFacade.DeleteAdvertisement(advertisementFacade.GetAdvertisement(id))
                //{
                //    Request.CreateResponse(HttpStatusCode.Created);
                //}
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, new AdvertisementWasNotDeletedException("The advertisement could not be deleted, please try again.", ex));
            }
        }
    }
}