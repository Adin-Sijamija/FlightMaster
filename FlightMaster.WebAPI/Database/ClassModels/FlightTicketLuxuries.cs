using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FlightMaster.WebAPI.Database.ClassModels

{
    public class FlightTicketLuxuries
    {
        [Key]
        public int Id { get; set; }
        public int FlightTicketTypeID { get; set; }
        public FlightTicketType FlightTicketType { get; set; }
        public int LuxuriesID { get; set; }
        public Luxuries Luxuries { get; set; }


    }
}


