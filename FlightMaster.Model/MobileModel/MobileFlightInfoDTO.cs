using System;
using System.Collections.Generic;
using System.Text;

namespace FlightMaster.Model.MobileModel
{
    public class MobileFlightInfoDTO
    {

        public byte[] CompanyLogo { get; set; }
        public string CompanyName { get; set; }
        public string AirplaneName { get; set; }
        public string AirplaneType { get; set; }

        public List<MobileFlightTicketLuxuriesInfo> tickets { get; set; }
    }
}
