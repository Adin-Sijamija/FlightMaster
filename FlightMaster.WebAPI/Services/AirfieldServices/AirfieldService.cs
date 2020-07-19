using AutoMapper;
using FlightMaster.Model;
using FlightMaster.Model.WinUIModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightMaster.WebAPI.Services.AirfieldServices
{
    public class AirfieldService:IAirfieldService
    {
        private readonly FlightMasterContext db;
        private readonly IMapper mapper;

        public AirfieldService(FlightMasterContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public List<Airfield> Get()
        {
            List<Database.ClassModels.Airfield> airfields = db.Airfields.ToList();
            return mapper.Map<List<Model.Airfield>>(airfields);

        }

        public List<AirfieldInfoDTO> GetAirfieldSearchs(int countryId, int cityId)
        {
            List<Database.ClassModels.Airfield> airfields = db.Airfields
                .Include(x=>x.City)
                .ThenInclude(x=>x.Country)
                .ToList();

            if (countryId != -1)
                airfields = airfields.Except(airfields.Where(x => x.City.CountryId != countryId)).ToList();

            if (cityId != -1)
                airfields = airfields.Except(airfields.Where(x => x.CityId != cityId)).ToList();


            return mapper.Map<List<AirfieldInfoDTO>>(airfields);
        }

        public object getByCity(int id)
        {
            List<Database.ClassModels.Airfield> airfields = db.Airfields.Where(x => x.CityId == id).ToList();
            return mapper.Map<List<Model.Airfield>>(airfields);
        }

        public List<Airfield> GetById(int id)
        {
            List<Database.ClassModels.Airfield> airfields = db.Airfields.Where(x=>x.CityId==id).ToList();
            return mapper.Map<List<Model.Airfield>>(airfields);
        }

        public Airfield Insert(Airfield airfield)
        {
            Database.ClassModels.Airfield airfield1 = new Database.ClassModels.Airfield();
            airfield1 = mapper.Map<Database.ClassModels.Airfield>(airfield);

            db.Airfields.Add(airfield1);
            db.SaveChanges();
            return mapper.Map<Model.Airfield>(airfield1);

        }
    }
}
