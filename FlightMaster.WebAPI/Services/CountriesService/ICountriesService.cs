using FlightMaster.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightMaster.WebAPI.Services.CountriesService
{
    public interface ICountriesService
    {
        List<Model.Country> Get();
        Model.Country Add(Country country);
        List<Country> Search(string search);
        Model.Country Edit(Country country);

        bool Remove(int id);

        Database.ClassModels.Country GetModel(Country country);
                
    }
}
