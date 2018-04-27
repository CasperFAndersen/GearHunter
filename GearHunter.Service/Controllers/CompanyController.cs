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
    [Route("api/company")]
    public class CompanyController : Controller
    {
        CompanyFacade companyFacade = new CompanyFacade();

        // GET api/company
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(companyFacade.GetCompanies());
        }

        // GET api/company/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Company tempCompany = companyFacade.GetCompany(id);
            return Ok(tempCompany);
        }

        // POST api/company
        [HttpPost]
        public IActionResult Post([FromBody] CompanyModel company)
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
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/company/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Company tempCompany = companyFacade.GetCompany(id);

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
