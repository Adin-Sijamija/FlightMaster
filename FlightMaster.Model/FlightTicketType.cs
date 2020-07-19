using System;
using System.Collections.Generic;
using System.Text;

namespace FlightMaster.Model
{
    public class FlightTicketType
    {
        public int FlightId { get; set; }

        public int Id { get; set; }

        public int TicketTypeID { get; set; }
        public string TicketTypeName { get; set; }
        public float Price { get; set; }
        public int MaxTickets { get; set; }
        public int CurrentTickets { get; set; }

    }
}
