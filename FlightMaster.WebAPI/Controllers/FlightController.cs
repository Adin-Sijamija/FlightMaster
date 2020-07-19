using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightMaster.Model;
using FlightMaster.Model.MobileModel;
using FlightMaster.Model.WinUIModels;
using FlightMaster.WebAPI.Database.ClassModels;
using FlightMaster.WebAPI.Services.Flight;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightMaster.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class FlightController : ControllerBase
    {

        public IFlightService service;

        public FlightController(IFlightService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("GenerateData")]
        [Authorize(Roles = Role.Employe)]
        public ActionResult<bool> Test(int number, DateTime min, DateTime max)
        {

            return Ok(service.GenerateData(number, min, max));

        }


        [HttpPost]
        [Route("GetFlightInfo")]
        public ActionResult<List<FlightInfoClass>> GetFLightInfo([FromBody] FlightSearchModel flightSearchModel)
        {

            return Ok(service.GetFlightInfo(flightSearchModel));

        }



        [HttpDelete]
        [Route("DeleteAll")]
        [Authorize(Roles = Role.Employe)]
        public ActionResult<bool> DeleteAll()
        {

            return Ok(service.DeleteAll());

        }



        [HttpPost]
        [Route("CreateFlight")]
        [Authorize(Roles = Role.Employe)]
        public ActionResult<FlightInsertModel> InsertFlight(FlightInsertModel flightInsertModel)
        {

            return Ok(service.InsertFlight(flightInsertModel));

        }

        [HttpDelete]
        [Route("RemoveFlight")][Authorize(Roles = Role.Employe)]
        public ActionResult<FlightInsertModel> DeleteFlight(int id)
        {

            return Ok(service.DeleteFlight(id));

        }


        [Route("InsertFlightTicket")]
        [HttpPost]
        public ActionResult<Model.FlightTicketType> InsertFlightTicket(Model.FlightTicketType flightTikcetType)
        {

            var result = service.InsertFlightTicket(flightTikcetType);

            return Ok(result);

        }


        [Route("GetFlightTicketTypes")]
        [HttpGet]
        public ActionResult<List<Model.FlightTicketType>> GetFlightTicketTypes(int id)
        {

            var result = service.GetFlightTicketTypes(id);

            return Ok(result);

        }


        [HttpPost]
        [Route("CreatFlightTicket")]
        public ActionResult<FlightInsertModel> InsertFlightTicket(FlightInsertModel flightInsertModel)
        {

            return Ok();

        }

        [HttpDelete]
        [Route("RemoveFlightTicket")]
        public ActionResult<bool> DeleteFlightTicket(int id)
        {

            return Ok(service.DeleteTicketType(id));
        }


        [HttpPost]
        [Route("AdvancedUserSearch")]
        public ActionResult<List<JourneyFlighsDTO>> InsertAdvancedUserSearch(AdvancedSearchDataModel data)
        {

            List<JourneyFlighsDTO> res = service.AdvancedUserSearch(data);

            return Ok(true);
        }

        [HttpGet]
        [Route("AdvancedUserSearchv2")]
        public ActionResult<List<JourneyFlighsDTO>> InsertAdvancedUserSearch([FromQuery] int depcity, [FromQuery] int arrcity, [FromQuery] DateTime mindate, [FromQuery] DateTime maxDate,[FromQuery] string LuxIds,[FromQuery] int page)
        {

            AdvancedSearchDataModel data = new AdvancedSearchDataModel(page, LuxIds, mindate,maxDate,depcity,arrcity);

           var res = service.AdvancedUserSearch(data);
          
            return Ok(res);
        }

        [HttpGet]
        [Route("GetMobileFlightInfo")]
        public ActionResult<MobileFlightInfoDTO> GetMobileFlightInfo([FromQuery] int flightId)
        {


            MobileFlightInfoDTO data= service.GetMobileFlightInfo(flightId);
            return Ok(data);
        }


        [HttpGet]
        [Route("GetUserJourneys")]
        public ActionResult<MobileFlightInfoDTO> GetUserJourneys([FromQuery] int flightId)
        {


            MobileFlightInfoDTO data = service.GetMobileFlightInfo(flightId);
            return Ok(data);
        }


        [HttpGet]
        [Route("GetUserRecommendedFlights")]
        public ActionResult<MobileFlightInfoDTO> GetUserRecommendedFlights([FromQuery] int UserId, [FromQuery] int Page)
        {
            List<JourneyFlighsDTO> data = service.GetUserRecommendedFlights(UserId,Page);
            return Ok(data);
        }


        [HttpGet]
        [Route("GetFlightInfo")]
        public ActionResult<Model.Flight> GetFlightInfo([FromQuery] int FlightId)
        {
            Model.Flight data = service.GetFlightInfo(FlightId);
            return Ok(data);
        }

        [HttpGet]
        [Route("GetTicketInfo")]
        public ActionResult<TicketInfoModel> GetTicketInfo([FromQuery] string TicketCode)
        {
            TicketInfoModel data = service.GetTicketInfo(TicketCode);

           
            return Ok(data);
        }

        [HttpPut]
        [Route("CheckInTicket")]
        [Authorize(Roles = Role.Employe)]
        public ActionResult<bool> GetTicketInfo(Model.Ticket ticket)
        {
            bool succes = service.CheckInTicket(ticket);


            return Ok(succes);
        }


        [HttpPut]
        [Route("UpdateFlightStatus")]
        [Authorize(Roles = Role.Employe)]
        public ActionResult<Model.Flight> UpdateFlightStatus(Model.Flight flight)
        {
            Model.Flight succes = service.UpdateFlightStatus(flight);


            return Ok(succes);
        }
    }
}