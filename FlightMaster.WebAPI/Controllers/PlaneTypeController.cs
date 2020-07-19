using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightMaster.WebAPI.Database.ClassModels;
using FlightMaster.WebAPI.Services.PlaneType;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightMaster.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class PlaneTypeController : ControllerBase
    {
        private readonly IPlaneTypeService service;

        public PlaneTypeController(IPlaneTypeService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult<List<Model.PlaneType>> GetAll() {

            List <Model.PlaneType> data=service.GetAll();
           
                return Ok(data);
        
        }

        [HttpPost]
        [Authorize(Roles = Role.Employe)]
        public ActionResult<Model.PlaneType> Insert(Model.PlaneType data)
        {

             Database.ClassModels.PlaneType model= service.getModel(data);

            if (!TryValidateModel(model))
                return BadRequest(ModelState);

            return service.Insert(data);
            
            
        }
}
    }
