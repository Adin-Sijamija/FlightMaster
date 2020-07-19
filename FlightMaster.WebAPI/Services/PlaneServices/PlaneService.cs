using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FlightMaster.Model;
using FlightMaster.WebAPI.Database.ClassModels;

namespace FlightMaster.WebAPI.Services.PlaneServices
{
    public class PlaneService : IPlaneServices
    {

        private readonly FlightMasterContext db;
        private readonly IMapper mapper;

        public PlaneService(FlightMasterContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Model.Plane> Get()
        {
            List<Database.ClassModels.Plane> planes = db.Planes.ToList();
            return mapper.Map<List<Model.Plane>>(planes);
        }

        public List<Model.Plane> GetAllCompany(int id)
        {

            List<Database.ClassModels.Plane> planes = db.Planes.Where(x=>x.CompanyId==id).ToList();
            return mapper.Map<List<Model.Plane>>(planes);
        }

        public Model.Plane Insert(Model.WinUIModels.AirPlaneInsertModel plane)
        {
            Database.ClassModels.Plane newly = new Database.ClassModels.Plane()
            {
                Name = plane.plane.Name,
                PlaneTypeId = plane.PlaneTypeId,
                CompanyId = plane.CompanyId

            };
            db.Planes.Add(newly);
            db.SaveChanges();
            return mapper.Map<Model.Plane>(newly);
            
        }

        public List<Model.Plane> Search(string search)
        {
            throw new NotImplementedException();
        }

        public Database.ClassModels.Plane Update(int id, Model.Plane plane)
        {
            throw new NotImplementedException();
        }
    }
}
