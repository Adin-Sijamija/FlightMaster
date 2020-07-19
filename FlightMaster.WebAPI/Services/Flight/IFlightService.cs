using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightMaster.Model;
using FlightMaster.Model.MobileModel;
using FlightMaster.Model.WinUIModels;

namespace FlightMaster.WebAPI.Services.Flight
{
    public interface IFlightService
    {
        Model.WinUIModels.FlightInsertModel InsertFlight(Model.WinUIModels.FlightInsertModel flightInsertModel);
        bool  DeleteFlight(int id);
        FlightTicketType InsertFlightTicket(FlightTicketType flightTikcetType);
        List<FlightTicketType> GetFlightTicketTypes(int id);
        List<FlightMaster.Model.Flight> GetAll();
        bool DeleteTicketType(int id);
        List<FlightInfoClass> GetFlightInfo(FlightSearchModel flightSearchModel);
        bool GenerateData(int number, DateTime min,DateTime max);
        bool DeleteAll();
        List<JourneyFlighsDTO>  AdvancedUserSearch(AdvancedSearchDataModel data);
        MobileFlightInfoDTO GetMobileFlightInfo(int flightId);
        List<JourneyFlighsDTO> GetUserRecommendedFlights(int userId,int page);
        Model.Flight GetFlightInfo(int flightId);
        TicketInfoModel GetTicketInfo(string ticketCode);
        bool CheckInTicket(Ticket ticket);
        Model.Flight UpdateFlightStatus(Model.Flight flight);
    }
}
