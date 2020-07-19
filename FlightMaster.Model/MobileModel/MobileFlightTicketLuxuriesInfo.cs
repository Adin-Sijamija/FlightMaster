using System;
using System.Collections.Generic;
using System.Text;

namespace FlightMaster.Model.MobileModel
{
    public class MobileFlightTicketLuxuriesInfo
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public int MaxTickets { get; set; }
        public int CurrentTickets { get; set; }
        public string Name { get; set; }
        public byte[] Icon { get; set; }

        public List<Model.Luxuries> TicketLuxuries { get; set; }

    }
}
