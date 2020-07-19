using System;
using System.Collections.Generic;
using System.Text;

namespace FlightMaster.Model.MobileModel
{
    public class JourneyFlighsDTO
    {

        public int TotalFlights { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TravelTime { get; set; }
        public string StartAirfield { get; set; }
        public string EndAirfield { get; set; }
        public double AvarageCost { get; set; }
        public int LuxuriesAvailabel { get; set; }
        public List<Model.Flight> Journeyflights { get; set; }

        public JourneyFlighsDTO()
        {
        }
    }
}
