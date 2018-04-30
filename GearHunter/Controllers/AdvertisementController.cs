using GearHunter.BLL;
using GearHunter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GearHunter.Service.Controllers
{
    public class AdvertisementController : ApiController
    {

        private AdvertisementFacade advertisementFacade = new AdvertisementFacade();

        // GET api/<controller>
        public async Task<IEnumerable<Advertisement>> Get()
        {
            List<Advertisement> listOfAdvertisements = await (advertisementFacade.GetAdvertisementsAsync());
            return listOfAdvertisements;
            //return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}