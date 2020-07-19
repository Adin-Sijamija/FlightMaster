using System;
using System.Collections.Generic;
using System.Text;

namespace FlightMaster.Model.WinUIModels
{
   public class TicketInfoModel
    {
        public int TicketId { get; set; }
        public string TicketStatus { get; set; }
        public string FlightTicketType { get; set; }


        public string UserName { get; set; }
        public byte[] UserIcon { get; set; }
        public byte[] FlightproviderIcon { get; set; }


        public string FlightProvider { get; set; }
        public string FlightStatus { get; set; }
        public string Duration { get; set; }
        public string Destination { get; set; }
        public string Departure { get; set; }
        public string DepartureTime { get; set; }


    }
}
