using System;
using System.Collections.Generic;
using System.Text;

namespace FlightMaster.WebAPI.Database.ClassModels

{
    public class TicketPreferences
    {

        public int TicketTypeId { get; set; }
        public TicketType TicketType{ get; set; }

        public int CustomerId { get; set; }
        public User Customer { get; set; }

        public int Rating { get; set; }
    }
}
