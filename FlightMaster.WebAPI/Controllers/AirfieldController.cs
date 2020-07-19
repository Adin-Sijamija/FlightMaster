using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightMaster.Model.WinUIModels;
using FlightMaster.WebAPI.Database.ClassModels;
using FlightMaster.WebAPI.Services.AirfieldServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightMaster.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AirfieldController : ControllerBase
    {
        public IAirfieldService service;

        public AirfieldController(IAirfieldService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Authorize(Roles = Role.Employe)]
        public ActionResult<Model.Airfield> Post(Model.Airfield airfield)
        {
            Model.Airfield c = service.Insert(airfield);

            return Ok(c);
        }


        [HttpGet]
        [Route("CityAirfields")]
        public ActionResult<List<Model.Airfield>> GetByCity(int id)
        {
            return Ok(service.getByCity(id));
        }


        [HttpGet]
        public ActionResult<List<Model.Airfield>> GetAll()
        {
            List<Model.Airfield> c = service.Get();

            return Ok(c);
        }
        
        [HttpGet]
        [Route("GetAirfieldSearchs")]
        public ActionResult<List<AirfieldInfoDTO>> GetAirfieldSearchs([FromQuery] int CountryId,[FromQuery] int CityId)
        {

            List<AirfieldInfoDTO> Airfields = service.GetAirfieldSearchs(CountryId, CityId);

            return Ok(Airfields);

        }
        

        
    }
}