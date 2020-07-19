using FlightMaster.Model.MobileModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightMaster.WebAPI.Services.JourneyService
{
    public interface IJourneyService
    {
        bool AddJourney(JourneyInsertModel model);
        List<UserJourneyInfoModel> GetFutureUserJourneys(int userId);
        List<UserJourneyTicketsInfo> GetJourneyDataCheck(int journeyId);
        List<UserJourneyInfoModel> GetUserPastJourneys(int userId);
        List<UserFutureJourneysData> GetFutureJourneysData(int userId);
        List<UserJourneyTicketsInfo> GetUserFlightTickets(int flightId, int userId);
        UserFlightLocationsDTO GetUserFlightLocations(int flightId);
    }
}
