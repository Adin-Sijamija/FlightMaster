using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FlightMaster.Model;
using FlightMaster.WebAPI.Database.ClassModels;
using FlightMaster.WebAPI.Mapper;

namespace FlightMaster.WebAPI.Services.CountriesService
{
    public class CountriesService : ICountriesService
    {
        private readonly FlightMasterContext db;
        private readonly IMapper mapper;

        public CountriesService(FlightMasterContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public Model.Country Add(Model.Country country)
        {
            Database.ClassModels.Country c = mapper.Map<Database.ClassModels.Country>(country);

            db.Countries.Add(c);
            db.SaveChanges();

            return mapper.Map<Model.Country>(c);

        }

        public Model.Country Edit(Model.Country country)
        {
            Database.ClassModels.Country edit= mapper.Map<Database.ClassModels.Country>(country);
            db.Countries.Update(edit);
            db.SaveChanges();
            return mapper.Map<Model.Country>(edit);

        }

        public List<Model.Country> Get()
        {

            var List = db.Countries.ToList();

            return mapper.Map<List<Model.Country>>(List);
        }

        public Database.ClassModels.Country GetModel(Model.Country country)
        {
            return mapper.Map<Database.ClassModels.Country>(country);
        }

        public bool Remove(int id)
        {
            try
            {

                Database.ClassModels.Country country = db.Countries.Where(x => x.Id == id).SingleOrDefault();
                db.Countries.Remove(country);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public List<Model.Country> Search(string search)
        {
            List<Database.ClassModels.Country> data = db.Countries.Where(x => x.Name.Contains(search)).ToList();

            return mapper.Map<List<Model.Country>>(data);

        }
    }
}
