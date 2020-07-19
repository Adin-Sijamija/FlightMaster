using System;
using System.Collections.Generic;
using System.Text;

namespace FlightMaster.MobileApp.ViewModels.AdvancedSearchModels
{
    public class TravelTimeViewModel:BaseViewModel
    {
        public DateTime MinDate = new DateTime();
        public DateTime MaxDate=new DateTime();

        public TravelTimeViewModel()
        {
        }
    }
}
