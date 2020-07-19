using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightMaster.Model.WinUIModels;
using FlightMaster.WebAPI.Database.ClassModels;
using FlightMaster.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightMaster.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LuxuriesController : ControllerBase
    {

        public ILuxuryService service;

        public LuxuriesController(ILuxuryService luxuryService)
        {
            this.service = luxuryService;
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<List<Model.Luxuries>> GetAll()
        {
            return Ok(service.GetAll());
        }



        [HttpGet]
        [Route("GetAllTicketLuxuries")]
        public ActionResult<TicketLuxuriesDTF> AvailabelLuxuries(int id)
        {
            return Ok(service.GetTicketLuxuries(id));
        }

        [HttpPost]
        [Route("AddTicketLuxuries")]
        [Authorize(Roles = Role.Employe)]
        public ActionResult<TicketLuxuriesDTF> AddTicketLuxuries(Model.FlightTicketLuxuries flightTicketLuxuries)
        {
            return Ok(service.AddTicketLuxuries(flightTicketLuxuries));
        }

        [HttpDelete]
        [Authorize(Roles = Role.Employe)]
        [Route("RemoveTicketLuxuries")]
        public ActionResult<bool> RemoveTicketLuxuries(Model.FlightTicketLuxuries flightTicketLuxuries)
        {
            return Ok(service.RemoveTicketLuxuries(flightTicketLuxuries));
        }






        [HttpGet]
        [Route("GetByFlightTicketId")]

        public ActionResult<List<Model.Luxuries>> GetAllById(int id)
        {
            return Ok();
        }

        [HttpPost]
        [Authorize(Roles = Role.Employe)]
        public ActionResult<Model.Luxuries> Insert(Model.Luxuries luxuries)
        {
            return Ok(service.Insert(luxuries));
        }
        [HttpPut]
        [Authorize(Roles = Role.Employe)]
        public ActionResult<Model.Luxuries> Update(Model.Luxuries luxuries)
        {
            return Ok(service.Update(luxuries));
        }
        [HttpDelete]
        [Authorize(Roles = Role.Employe)]
        public ActionResult<List<Model.Luxuries>> Delete(int id)
        {
            return Ok(service.Delete(id));
        }
    }
}