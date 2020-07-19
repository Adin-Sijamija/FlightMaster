using System;
using System.Collections.Generic;
using System.Text;

namespace FlightMaster.Model.MobileModel
{
    public class UserFutureJourneysData
    {
        public Journey Journey { get; set; }
        public List<Model.Flight> Flights { get; set; }
        public int TotalTickets { get; set; }

    }
}
