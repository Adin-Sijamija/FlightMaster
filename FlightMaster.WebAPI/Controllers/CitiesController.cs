using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightMaster.WebAPI.Database.ClassModels;
using FlightMaster.WebAPI.Services.CitiesService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightMaster.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class CitiesController : ControllerBase
    {
        public ICitiesService service;

        public CitiesController(ICitiesService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("GetPagination")]
        public ActionResult<List<Model.City>> GetPage(int page, int id = 0)
        {
            List<Model.City> pagedata = service.GetPagination(page, id);
            return Ok(pagedata);
        }


        [HttpGet]
        [Route("GetPaginationSearch")]
        public ActionResult<List<Model.City>> GetPageSearch([FromQuery] int page, [FromQuery] string search, [FromQuery] int id = 0)
        {
            List<Model.City> pagedata = service.GetPaginationSearch(page,search, id);

            return Ok(pagedata);
        }


        [HttpPost]
        [Authorize(Roles = Role.Employe)]
        public ActionResult<Model.City> GetPageSearch(Model.City city)
        {
            city.ShortName.ToUpper();
            city.Name.ToUpper();
            return Ok(service.Insert(city));
        }


        [HttpGet]
        [Route("CountriesCities")]
        public ActionResult<List<Model.City>> GetCountriesCities(int id)
        {
            List<Model.City> cities = service.GetCountriesCities( id);
            return Ok(cities);
        }


    }
}