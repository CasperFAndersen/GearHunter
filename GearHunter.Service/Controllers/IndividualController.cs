﻿using GearHunter.BLL;
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
    [Route("api/[controller]")]
    public class IndividualController : Controller
    {
        IndividualFacade individualFacade = new IndividualFacade();

        // GET api/individual
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(individualFacade.GetIndividuals());
        }

        // GET api/individual/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Individual tempIndividual = individualFacade.GetIndividual(id);
            return Ok(tempIndividual);
        }

        // POST api/individual
        [HttpPost]
        public IActionResult Post([FromBody] IndividualModel Individual)
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
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/individual/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Individual tempIndividual = individualFacade.GetIndividual(id);

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
