using FlightMaster.WebAPI.Database.ClassModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightMaster.WebAPI.Services.PlaneServices
{
    public interface IPlaneServices
    {
        List<Model.Plane> Get();

        Model.Plane Insert(Model.WinUIModels.AirPlaneInsertModel plane);
        List<Model.Plane> Search(string search);
        Plane Update(int id, Model.Plane plane);
        bool Delete(int id);
        List<Model.Plane> GetAllCompany(int id);
    }
}
