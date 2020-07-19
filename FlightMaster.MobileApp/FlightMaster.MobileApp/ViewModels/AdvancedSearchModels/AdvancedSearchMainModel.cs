using System;
using System.Collections.Generic;
using System.Text;

namespace FlightMaster.MobileApp.ViewModels.AdvancedSearchModels
{
    public class AdvancedSearchMainModel
    {

        public DeparturesViewModel departure;
        public DestinationViewModel destination;
        public TravelTimeViewModel travel;
        public LuxuriesViewModel luxuriesmodel;
        public FlightSearchData flightSearch;


        public class FlightSearchData
        {
            public string luxuiresId;
            public DateTime Mindate;
            public DateTime MaxDate;
            public int depCityId;
            public int arrCityId;
        }

        public AdvancedSearchMainModel()
        {
            departure = new DeparturesViewModel();
            destination = new DestinationViewModel();
            travel = new TravelTimeViewModel();
            luxuriesmodel = new LuxuriesViewModel();
            flightSearch = new FlightSearchData();
        }

        internal void SetFlightSearchData()
        {

            flightSearch.luxuiresId = string.Join(";", luxuriesmodel.LuxuryIds.ToArray());
            flightSearch.arrCityId = destination.CityId;
            flightSearch.depCityId = departure.CityId;
            flightSearch.Mindate = travel.MinDate;
            flightSearch.MaxDate= travel.MaxDate;
        }
    }
}
