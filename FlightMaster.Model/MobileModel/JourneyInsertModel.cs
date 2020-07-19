using FlightMaster.MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightMaster.Model.MobileModel
{
    public class JourneyInsertModel
    {
        public int UserId { get; set; }
        public List<FlightTicketsTobeAdded> ticketsTobeAddeds { get; set; }

    }
}
