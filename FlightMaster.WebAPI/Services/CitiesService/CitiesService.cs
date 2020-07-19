using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FlightMaster.Model;
using FlightMaster.WebAPI.Database;
using FlightMaster.WebAPI.Database.ClassModels;

namespace FlightMaster.WebAPI.Services.CitiesService
{
    public class CitiesService : ICitiesService
    {
        private readonly FlightMasterContext db;
        private readonly IMapper mapper;

        public CitiesService(FlightMasterContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public List<Model.City> GetCountriesCities(int id)
        {

            List<Database.ClassModels.City> cities = new List<Database.ClassModels.City>();
            cities = db.Cities.Where(x => x.CountryId == id).ToList();
            return mapper.Map<List<Model.City>>(cities);

        }

        public List<Model.City> GetPagination(int page, int id = 0)
        {
            List<Database.ClassModels.City> cities = new List<Database.ClassModels.City>();

            if (id != 0)
            {
                cities = db.Cities.Where(x => x.CountryId == id).ToList();
                PaginationList<Database.ClassModels.City> PagedData = new PaginationList<Database.ClassModels.City>(cities,10);
                cities = PagedData.GetPage(page);

                return mapper.Map<List<Model.City>>(cities);
            }
            else
            {
                cities = db.Cities.ToList();
                PaginationList<Database.ClassModels.City> PagedData = new PaginationList<Database.ClassModels.City>(cities, 10);
                cities = PagedData.GetPage(page);

                return mapper.Map<List<Model.City>>(cities);
            }
        }

        public List<Model.City> GetPaginationSearch(int page, string search, int id)
        {
            
            if(id!=0)
            {
                List<Database.ClassModels.City> cities = db.Cities.Where(x => x.CountryId == id).ToList();
                if (search != "" && search != null)
                    cities = cities.Where(x => x.Name.ToLower().Contains(search.ToLower())).ToList();


                PaginationList<Database.ClassModels.City> PagedData = new PaginationList<Database.ClassModels.City>(cities, 10);
                cities = PagedData.GetPage(page);
                return mapper.Map<List<Model.City>>(cities);
            }
            else
            {
                List<Database.ClassModels.City> cities = db.Cities.ToList();
                if (search != "" && search != null)
                    cities = cities.Where(x => x.Name.ToLower().Contains(search.ToLower())).ToList();


                PaginationList<Database.ClassModels.City> PagedData = new PaginationList<Database.ClassModels.City>(cities, 10);
                cities = PagedData.GetPage(page);
                return mapper.Map<List<Model.City>>(cities);
            }


         


        }

        public Model.City Insert(Model.City city)
        {
            Database.ClassModels.City city1 = mapper.Map<Database.ClassModels.City>(city);

            db.Cities.Add(city1);
            db.SaveChanges();

            return mapper.Map<Model.City>(city1);
        }
    }
}
