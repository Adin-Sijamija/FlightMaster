using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightMaster.WebAPI.Database.ClassModels;
using FlightMaster.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightMaster.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class TicketTypeController : ControllerBase
    {
        public ITicketTypeService service;

        public TicketTypeController(ITicketTypeService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult<List<Model.TicketType>> Get()
        {
            return Ok(service.Get());
        }


        [HttpDelete]
        [Authorize(Roles = Role.Employe)]

        public ActionResult Delete(int id)
        { 
            return Ok(service.Delete(id));
        }


        [HttpPut]
        [Authorize(Roles = Role.Employe)]

        public ActionResult<Model.TicketType> Update(Model.TicketType ticketType)
        {
            var model = service.GetModel(ticketType);
            if (!TryValidateModel(model))
                return BadRequest(ModelState);

            return Ok(service.Update(ticketType));
        }
        [HttpPost]
        [Authorize(Roles = Role.Employe)]
        public ActionResult<Model.TicketType> Insert(Model.TicketType ticketType)
        {
            var model = service.GetModel(ticketType);
            if (!TryValidateModel(model))
                return BadRequest(ModelState);

            return Ok(service.Insert(ticketType));
        }



        [HttpPost]
        [Authorize(Roles = Role.Employe)]
        [Route("SetFlightTicketDiscount")]
        public ActionResult<bool> SetFlightTicketDiscount(Model.FlightTicketType ticketType)
        {
            var res = service.SetFlightTicketDiscount(ticketType);

            return Ok(res);
        }
        [HttpPut]
        [Authorize(Roles = Role.Employe)]
        [Route("ChangeTicketDiscount")]
        public ActionResult<bool> ChangeTicketDiscount(Model.FlightTicketType ticketType)
        {
            var res = service.ChangeTicketDiscount(ticketType);

            return Ok(res);
        }

    }
}