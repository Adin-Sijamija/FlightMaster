using System;
using System.Collections.Generic;
using System.Text;

namespace FlightMaster.Model.WinUIModels
{
    public class FlightInfoClass
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string FlightDate { get; set; }

        public string Duration { get; set; }
        public string Status { get; set; }

        public string PlaneName { get; set; }
        public string PlaneType { get; set; }
        public string Company { get; set; }

        public int Capacity { get; set; }
        public int TicketsSold{ get; set; }


        public string DepLocation { get; set; }
        public string ArrLocation { get; set; }

        public string DepCountry { get; set; }
        public string DepCity{ get; set; }
        public string DepAirfield { get; set; }
        public string ArrCountry { get; set; }
        public string ArrCity { get; set; }
        public string ArrAirfield { get; set; }


    }
}
