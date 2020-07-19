using FlightMaster.Model;
using FlightMaster.Model.WinUIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightMaster.WebAPI.Services.AirfieldServices
{
    public interface IAirfieldService
    {

        public Model.Airfield Insert(Model.Airfield airfield);

        public List<Model.Airfield> Get();
        public List<Model.Airfield> GetById(int id);
        object getByCity(int id);
        List<AirfieldInfoDTO> GetAirfieldSearchs(int countryId, int cityId);
    }
}
