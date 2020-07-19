using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightMaster.Model;
using FlightMaster.Model.MobileModel;
using FlightMaster.Model.WinUIModels;
using FlightMaster.WebAPI.Database.ClassModels;
using FlightMaster.WebAPI.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightMaster.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {

        private FlightMasterContext db { get; set; }

        private IUserService _userService;

        public UsersController(FlightMasterContext db, IUserService userService)
        {
            this.db = db;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticateModel model)
        {
            var user = _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return Ok(null);

            return Ok(user);
        }


        [AllowAnonymous]
        [HttpPost("RegisterEmployee")]
        public ActionResult<Model.User> RegisterEmployee([FromBody] EmployeRegisterModel model)
        {
            var user = _userService.RegisterEmployee(model);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }


        [AllowAnonymous]
        [HttpPost("RegisterUser")]
        public ActionResult<Model.User> RegisterEmployee([FromBody] UserRegistrationModel model)
        {
            var user = _userService.RegisterUser(model);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }



        [Authorize(Roles = Role.Employe)]
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var users = _userService.Test();
            return Ok(users);
        }




        [HttpPatch("SetUserCity")]
        public ActionResult<bool> SetUserCity(UserCityUpdateModel data)
        {
            var succes = _userService.UpdateUserCity(data);

            if (succes == false)
                return BadRequest(new { message = "Something went wrong" });

            return Ok(succes);
        }

        [HttpGet("GetUserTicketPreferences")]
        public ActionResult<List<Model.TicketPreferences>> GetUserTicketPreferences([FromQuery] int UserId)
        {
            var succes = _userService.GetUserTicketPreferences(UserId);

      
            return Ok(succes);
        }

        [HttpPost("SetUserTicketPreferences")]
        public ActionResult<bool> SetUserTicketPreferences(List<Model.TicketPreferences> ticketPreferences)
        {
            var succes = _userService.SetUserTicketPreferences(ticketPreferences);

            if (succes == false)
                return BadRequest(new { message = "Something went wrong" });

            return Ok(succes);
        }


        [HttpGet("GetUserLuxuriesPreferences")]
        public ActionResult<List<Model.LuxuryPreferences>> GetUserLuxuriesPreferences([FromQuery] int UserId)
        {
            var succes = _userService.GetUserLuxuriesPreferences(UserId);

            return Ok(succes);
        }

        [HttpPost("SetUserLuxuriesPreferences")]
        public ActionResult<bool> SetUserLuxuriesPreferences(List<Model.LuxuryPreferences> luxuryPreferences)
        {
            var succes = _userService.SetUserLuxuriesPreferences(luxuryPreferences);

            if (succes == false)
                return BadRequest(new { message = "Something went wrong" });

            return Ok(succes);
        }


        [AllowAnonymous]
        [HttpGet("UserNameExsists")]
        public ActionResult<bool> UserNameExsists([FromQuery] string UserName)
        {
            var succes = _userService.UserNameExsists(UserName);
            return Ok(succes);
        }

     
    }
}