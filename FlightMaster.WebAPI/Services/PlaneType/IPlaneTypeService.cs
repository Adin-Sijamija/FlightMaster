using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightMaster.WebAPI.Services.PlaneType
{
    public interface IPlaneTypeService
    {

        List<Model.PlaneType> GetAll();
        Model.PlaneType Insert(Model.PlaneType plane);
        List<Model.PlaneType> Search(string search);
        Model.PlaneType Update(int id, Model.PlaneType plane);
        bool Delete(int id);

        Database.ClassModels.PlaneType getModel(Model.PlaneType data);
    }
}
