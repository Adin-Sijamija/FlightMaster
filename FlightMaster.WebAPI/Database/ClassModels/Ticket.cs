using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FlightMaster.WebAPI.Database.ClassModels

{
    public class Ticket
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public Flight Flight { get; set; }
        public int FlightId { get; set; }

        public int FlightTicketTypeId { get; set; }
        public FlightTicketType FlightTicketType { get; set; }

        public string TicketStatus { get; set; }

        public int JourneyId { get; set; }
        public Journey Journey { get; set; }
    }
}
