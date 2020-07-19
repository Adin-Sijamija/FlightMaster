using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightMaster.Model;
using FlightMaster.Model.WinUIModels;
using FlightMaster.WebAPI.Database.ClassModels;
using FlightMaster.WebAPI.Services.Companies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightMaster.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class CompaniesController : ControllerBase
    {

        private readonly ICompanyService service;

        public CompaniesController(ICompanyService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult<IList<Model.Company>> Get() {


            return Ok(service.Get());
        }

        [HttpPost]
        [Authorize(Roles = Role.Employe)]
        public ActionResult<Model.Company> Insert([FromBody] Model.Company company)
        {
            return Ok(service.Insert(company));
        }

        [Route("PlanesData")]
        [HttpGet]
        public ActionResult<List<CompanyPlaneInfoData>>GetPlanesData(int id)
        {

            return Ok(service.getPlaneData(id));
        }


        [Route("TEST")]
        [HttpGet]
        public ActionResult<TestClass> TEST()
        {

            return Ok(service.test());
        }


        [Route("Search")]
        [HttpGet]
        public ActionResult<List<Model.Company>> Search([FromQuery]int page = 1, string search = "")
        {
            var results = service.Search(page, search);
            return Ok(results);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = Role.Employe)]
        public ActionResult<Model.Company> Update(int id, [FromBody] Model.Company company)
        {
            var results = service.Update(id, company);
            return Ok(results);
        }

         


        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Employe)]
        public ActionResult<bool> Delete(int id)
        {
            return Ok(service.Delete(id));
        }
        
    }
}