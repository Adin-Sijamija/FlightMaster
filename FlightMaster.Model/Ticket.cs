using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FlightMaster.Model
{
    public class Ticket
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public int FlightId { get; set; }

        public int FlightTicketTypeId { get; set; }
        public string TicketStatus { get; set; }
        public int JourneyId { get; set; }
    }
}
