using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightMaster.Model;

namespace FlightMaster.WebAPI.Services
{
    public interface ITicketTypeService
    {
        List<Model.TicketType> Get();
        Model.TicketType Insert(Model.TicketType ticketType);
        bool Delete(int id);
        object GetModel(TicketType ticketType);
        Model.TicketType Update(TicketType ticketType);
        bool SetFlightTicketDiscount(FlightTicketType ticketType);
        bool ChangeTicketDiscount(FlightTicketType ticketType);
    }
}
