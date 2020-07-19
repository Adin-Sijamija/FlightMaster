using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightMaster.WebAPI.Database.ClassModels;
using FlightMaster.WebAPI.Services.PlaneServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightMaster.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class PlaneController : ControllerBase
    {
        public IPlaneServices service;

        public PlaneController(IPlaneServices service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult<List<Model.Plane>> GetAll()
        {
           return Ok(service.Get());
            
        }

        [HttpGet]
        [Route("CompanyPlanes")]

        public ActionResult<List<Model.Plane>> GetAllCompany(int id)
        {
            return Ok(service.GetAllCompany(id));

        }

        [HttpPost]
        [Authorize(Roles = Role.Employe)]
        public ActionResult<List<Model.Plane>> Insert(Model.WinUIModels.AirPlaneInsertModel model)
        {
            return Ok(service.Insert(model));

        }
    }
}