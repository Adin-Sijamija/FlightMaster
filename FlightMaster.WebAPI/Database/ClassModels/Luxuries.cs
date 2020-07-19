using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FlightMaster.WebAPI.Database.ClassModels

{
    public class Luxuries
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public byte[] Icon { get; set; }

        public List<LuxuryPreferences> LuxuryPreferences { get; set; }
        public List<FlightTicketLuxuries> FlightTicketLuxuries { get; set; }

    }
}
