using FlightMaster.Model.WinUIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightMaster.WebAPI.Services
{
    public interface ILuxuryService
    {
        Model.Luxuries Insert(Model.Luxuries luxuries);

        Model.Luxuries Update(Model.Luxuries luxuries);
        List<Model.Luxuries> GetAll();
        bool Delete(int id);
        TicketLuxuriesDTF GetTicketLuxuries(int id);

        Model.FlightTicketLuxuries AddTicketLuxuries(Model.FlightTicketLuxuries flightTicketLuxuries);
        bool RemoveTicketLuxuries(Model.FlightTicketLuxuries flightTicketLuxuries);
    }
}
