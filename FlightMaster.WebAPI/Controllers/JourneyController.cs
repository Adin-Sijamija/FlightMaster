using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightMaster.Model.MobileModel;
using FlightMaster.WebAPI.Services.JourneyService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightMaster.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class JourneyController : ControllerBase
    {

        public IJourneyService service;

        public JourneyController(IJourneyService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("InsertNewJourney")]
        public ActionResult<bool> InsertNewJourney(JourneyInsertModel model)
        {

            var result = service.AddJourney(model);
            if (result == false)
                return BadRequest("Something went wrong");

            return Ok(result);
        }

        [HttpGet]
        [Route("GetUserFutureJourneys")]
        public ActionResult<List<UserFutureJourneysData>> GetUserFutureJourneysInfo([FromQuery] int UserId)
        {
            
            List<UserFutureJourneysData> res = service.GetFutureJourneysData(UserId);

            return Ok(res);
        }

        [HttpGet]
        [Route("GetUserPastJourneys")]
        public ActionResult<List<UserJourneyInfoModel>> GetUserPastJourneys([FromQuery] int UserId)
        {

            List<UserJourneyInfoModel> res = service.GetUserPastJourneys(UserId);

            return Ok(res);
        }
        [HttpGet]
        [Route("GetJourneyDataCheck")]
        public ActionResult<List<UserJourneyTicketsInfo>> GetJourneyDataCheck([FromQuery] int JourneyId)
        {

            List<UserJourneyTicketsInfo> res = service.GetJourneyDataCheck(JourneyId);

            return Ok(res);
        }


        [HttpGet]
        [Route("GetUserFlightTickets")]
        public ActionResult<List<UserJourneyTicketsInfo>> GetUserFlightTickets([FromQuery] int FlightId, [FromQuery] int UserId)
        {

            List<UserJourneyTicketsInfo> res = service.GetUserFlightTickets(FlightId, UserId);

            return Ok(res);
        }


        [HttpGet]
        [Route("GetUserFlightLocations")]
        public ActionResult<UserFlightLocationsDTO> GetUserFlightLocations([FromQuery] int FlightId)
        {

            UserFlightLocationsDTO res = service.GetUserFlightLocations(FlightId);

            return Ok(res);
        }
    }
}