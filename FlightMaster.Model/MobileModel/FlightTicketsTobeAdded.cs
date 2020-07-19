using System;
using System.Collections.Generic;
using System.Text;

namespace FlightMaster.MobileApp.Models
{
    public class FlightTicketsTobeAdded
    {

        public int FlightId { get; set; }
        public int FlightTicketTypeID { get; set; }
        public int TicketCount { get; set; }
        public double Price{ get; set; }


    }
}
