using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FlightMaster.WebAPI.Database.ClassModels;
using FlightMaster.WebAPI.Services.CountriesService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightMaster.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class CountriesController : ControllerBase
    {
        private readonly ICountriesService service;

        public CountriesController(ICountriesService service)
        {
            this.service = service;
        }


        [HttpGet]
        public ActionResult<IList<Model.Country>> Get()
        {

            return Ok(service.Get());
        }



        [HttpPost]
        [Authorize(Roles = Role.Employe)]
        public ActionResult<Model.Country> Post(Model.Country country)
        {
            country.Name.ToUpper();
            country.ShortName.ToUpper();
            Model.Country c = service.Add(country);

            return Ok(c);
        }

        [HttpGet]
        [Route("Search")]
        public ActionResult<List<Model.Country>> Search(string search)
        {
            List<Model.Country> filtered = service.Search(search);
            return Ok(filtered);
        }

        [HttpPut]
        [Authorize(Roles = Role.Employe)]
        public ActionResult<Model.Country> Edit(Model.Country edited)
        {
            Database.ClassModels.Country model = service.GetModel(edited);
            if (!TryValidateModel(model))
            {
                return BadRequest(ModelState);
            }
            return Ok(service.Edit(edited));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Employe)]
        public ActionResult<bool> Remove(int id)
        {
            if (service.Remove(id))
            {
                return Ok(true);
            }
            return BadRequest();
            
        }
    
    }
}