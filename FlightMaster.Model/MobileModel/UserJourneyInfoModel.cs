using System;
using System.Collections.Generic;
using System.Text;

namespace FlightMaster.Model.MobileModel
{
    public class UserJourneyInfoModel
    {
        public Journey Journey { get; set; }
        public List<UserJourneyTicketsInfo>  ticketsInfos { get; set; }


    }
}
