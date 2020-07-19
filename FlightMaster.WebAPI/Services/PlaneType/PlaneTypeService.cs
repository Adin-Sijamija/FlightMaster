using AutoMapper;
using FlightMaster.Model;
using FlightMaster.WebAPI.Database.ClassModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightMaster.WebAPI.Services.PlaneType
{
    public class PlaneTypeService : IPlaneTypeService
    {

        private readonly FlightMasterContext db;
        private readonly IMapper mapper;

        public PlaneTypeService(FlightMasterContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Model.PlaneType> GetAll()
        {
            var data = db.PlaneType.ToList();
            return mapper.Map<List<Model.PlaneType>>(data);
        }

        public Database.ClassModels.PlaneType getModel(Model.PlaneType data)
        {
           Database.ClassModels.PlaneType planeType = mapper.Map<Database.ClassModels.PlaneType>(data);
            return planeType;
        }

        public Model.PlaneType Insert(Model.PlaneType plane)
        {

            Database.ClassModels.PlaneType planeType = mapper.Map<Database.ClassModels.PlaneType>(plane);

            db.PlaneType.Add(planeType);
            db.SaveChanges();

            return plane;
        }

        public List<Model.PlaneType> Search(string search)
        {
            throw new NotImplementedException();
        }

        public Model.PlaneType Update(int id, Model.PlaneType plane)
        {
            throw new NotImplementedException();
        }
    }
}
