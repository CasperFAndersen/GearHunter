using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using GearHunter.BLL;
using GearHunter.Core;

namespace GearHunter.Service.Controllers
{
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
        public void Post([FromBody]string value)
        {
        }

        // PUT api/advertisements/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/advertisements/5
        public void Delete(int id)
        {
        }
    }
}