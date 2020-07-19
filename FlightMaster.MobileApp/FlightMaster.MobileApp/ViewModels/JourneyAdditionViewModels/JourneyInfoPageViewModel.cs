using FlightMaster.Model.MobileModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightMaster.MobileApp.ViewModels.JourneyAdditionViewModels
{
    public class JourneyInfoPageViewModel
    {

        public int JourneyID { get; set; }
        public double ticketCost { get; set; }
        public int TotalTickets { get; set; }
        public JourneyFlighsDTO flights { get; set; }

        public JourneyInfoPageViewModel(JourneyFlighsDTO flights)
        {
            this.flights = flights;
            JourneyID = 0;
            ticketCost = 0;
            TotalTickets = 0;
        }
        public JourneyInfoPageViewModel()
        {
            this.flights = new JourneyFlighsDTO();
            JourneyID = 0;
            ticketCost = 0;
            TotalTickets = 0;
        }
    }
}
