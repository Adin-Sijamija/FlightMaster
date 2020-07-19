using FlightMaster.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightMaster.WebAPI.Services.CitiesService
{
    public interface ICitiesService
    {

        public List<Model.City> GetPagination(int page, int id = 0);

        public Model.City Insert(Model.City city);
        List<City> GetCountriesCities(int id);
        List<City> GetPaginationSearch(int page, string search, int id);
    }
}
