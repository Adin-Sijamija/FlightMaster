using System;
using System.Collections.Generic;
using System.Text;

namespace FlightMaster.WebAPI.Database.ClassModels

{
    public class LuxuryPreferences
    {
        public int LuxuriesId { get; set; }
        public Luxuries Luxuries { get; set; }

        public int CustomerId { get; set; }
        public User Customer { get; set; }

        public int Rating { get; set; }

    }
}
