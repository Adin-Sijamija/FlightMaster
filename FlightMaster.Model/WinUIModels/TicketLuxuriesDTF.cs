using System;
using System.Collections.Generic;
using System.Text;

namespace FlightMaster.Model.WinUIModels
{
    public class TicketLuxuriesDTF
    {

        public int id { get; set; }
        public List<Luxuries> AvailabelLuxuries { get; set; }
        public List<Luxuries> TakenLuxuries { get; set; }
    }
}
