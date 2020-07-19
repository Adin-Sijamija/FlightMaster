using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FlightMaster.WebAPI.Database.ClassModels

{
    public class FlightTicketType
    {
        [Key]
        public int Id { get; set; }

        public int FlightId { get; set; }
        [ForeignKey("FlightId")]
        public Flight Flight { get; set; }

        public int TicketTypeID { get; set; }
        [ForeignKey("TicketTypeID")]

        public TicketType TicketType { get; set; }

        public List<FlightTicketLuxuries> FlightTicketLuxuries { get; set; }

        public float Price { get; set; }
        public int MaxTickets { get; set; }

        public int CurrentTickets { get; set; }
    }
}
