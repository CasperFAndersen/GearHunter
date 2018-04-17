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
        // GET api/advertisements
        public async Task<IEnumerable<Advertisement>> Get()
        {
            List<Advertisement> advertisements = await new AdvertisementFacade().GetAdvertisementsAsync();
            return advertisements;
        }

        // GET api/advertisements/5
        public string Get(int id)
        {
            return "value";
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