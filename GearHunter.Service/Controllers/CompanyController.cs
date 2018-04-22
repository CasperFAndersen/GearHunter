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
    public class CompanyController : ApiController
    {
        CompanyFacade companyFacade = new CompanyFacade();

        // GET api/company
        [Route("api/company")]
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            return Ok(await companyFacade.GetCompanysAsync());
        }

        // GET api/company/5
        [Route("api/company/{id:int}")]
        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            Company tempCompany = await companyFacade.GetCompanyAsync(id);
            return Ok(tempCompany);
        }

        [Route("api/company")]
        [HttpPost]
        // POST api/company
        //Create a new company.
        public IHttpActionResult Post([FromBody] CompanyModel company)
        {
            try
            {
                companyFacade.AddCompany(company.ToCompany());
                return Ok();
            }
            catch (Exception ex)
            {
                //TODO: Skal vi sende Ex med videre her? NEJ. Men fix efter alt virker.
                throw new CompanyWasNotAddedException("Something went wrong while trying to add your Company, try again.", ex);
            }
        }

        // PUT api/company/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/company/5
        [Route("api/company/{id:int}")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                Company tempCompany = await companyFacade.GetCompanyAsync(id);

                if (tempCompany == null)
                {
                    return NotFound();
                }

                else
                {
                    companyFacade.DeleteCompany(companyFacade.GetCompany(id));
                    return Ok();
                }

            }
            catch (Exception ex)
            {
                //TODO: Brug denne exception.
                return BadRequest("The Company could not be deleted, please try again.");
            }
        }
    }
}
