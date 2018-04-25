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
    public class IndividualController : ApiController
    {
        IndividualFacade individualFacade = new IndividualFacade();

        // GET api/individual
        [Route("api/individual")]
        [System.Web.Http.HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            return Ok(await individualFacade.GetIndividualsAsync());
        }

        // GET api/individual/5
        [Route("api/individual/{id:int}")]
        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            Individual tempIndividual = await individualFacade.GetIndividualAsync(id);
            return Ok(tempIndividual);
        }

        [Route("api/individual")]
        [HttpPost]
        // POST api/individual
        //Create a new individual.
        public IHttpActionResult Post([FromBody] IndividualModel Individual)
        {
            try
            {
                individualFacade.AddIndividual(Individual.ToIndividual());
                return Ok();
            }
            catch (Exception ex)
            {
                //TODO: Skal vi sende Ex med videre her?
                throw new IndividualWasNotAddedException("Something went wrong while trying to add your Individual, try again.", ex);
            }
        }

        // PUT api/individual/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/individual/5
        [Route("api/individual/{id:int}")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                Individual tempIndividual = await individualFacade.GetIndividualAsync(id);

                if (tempIndividual == null)
                {
                    return NotFound();
                }

                else
                {
                    individualFacade.DeleteIndividual(individualFacade.GetIndividual(id));
                    return Ok();
                }

            }
            catch (Exception ex)
            {
                //TODO: Brug denne exception.
                return BadRequest("The individual could not be deleted, please try again.");
            }
        }
    }
}
