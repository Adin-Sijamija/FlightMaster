using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FlightMaster.WebAPI.Database.ClassModels

{
    public class TicketType
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public byte[] Icon { get; set; }

        public List<TicketPreferences> TicketPreferences { get; set; }
        public List<FlightTicketType> PlaneTicketType { get; set; }
        public List<FlightTicketLuxuries> PlaneTicketLuxuries { get; set; }

    }
}
