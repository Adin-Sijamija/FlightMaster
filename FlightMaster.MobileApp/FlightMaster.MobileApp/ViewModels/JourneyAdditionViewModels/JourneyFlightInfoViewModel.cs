using FlightMaster.MobileApp.Models;
using FlightMaster.MobileApp.Services;
using FlightMaster.Model;
using FlightMaster.Model.MobileModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlightMaster.MobileApp.ViewModels.JourneyAdditionViewModels
{
    public class JourneyFlightInfoViewModel : BaseViewModel
    {

        private ApiCaller api;
        public Flight flight;
        public byte[] CompanyLogo;
        public ImageSource CompanyLogoImage { get; set; }



        private string companyName = "Loading..:";
        public string CompanyName
        {
            set { SetProperty(ref companyName, value); }
            get { return companyName; }
        }

        private string airplaneName = "Loading..:";
        public string AirplaneName
        {
            set { SetProperty(ref airplaneName, value); }
            get { return airplaneName; }
        }

        private string airplaneType = "Loading..:";
        public string AirplaneType
        {
            set { SetProperty(ref airplaneType, value); }
            get { return airplaneType; }
        }

        private DateTime startDate = new DateTime();
        public DateTime StartDate
        {
            set { SetProperty(ref startDate, value); }
            get { return startDate; }
        }

        private DateTime endDate = new DateTime();
        public DateTime EndDate
        {
            set { SetProperty(ref endDate, value); }
            get { return endDate; }
        }

        private string duration = "Loading..:";
        public string Duration
        {
            set { SetProperty(ref duration, value); }
            get { return duration; }
        }   
        private bool HasTicketsAdded = false;

        public List<FlightTicketsTobeAdded> UserTickets = new List<FlightTicketsTobeAdded>();

        public List<MobileFlightTicketLuxuriesInfo> ticketLuxuriesInfos = new List<MobileFlightTicketLuxuriesInfo>();


        public JourneyFlightInfoViewModel()
        {

            api = new ApiCaller();
            ticketLuxuriesInfos = new List<MobileFlightTicketLuxuriesInfo>();
            flight = new Model.Flight();
            EndDate = flight.EndDate;
            StartDate = flight.StartDate;
            Duration = flight.Duration;


        }

        public JourneyFlightInfoViewModel(Flight flight)
        {
            this.flight = flight;
            EndDate = flight.EndDate;
            StartDate = flight.StartDate;
            Duration = flight.Duration;
            if (api == null)
                api = new ApiCaller();
            if (ticketLuxuriesInfos == null)
                ticketLuxuriesInfos = new List<MobileFlightTicketLuxuriesInfo>();
        }

        public async Task<bool> LoadData()
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("flightId", flight.Id);
            MobileFlightInfoDTO dTO = await api.GetQuery<MobileFlightInfoDTO>(param, "Flight", "GetMobileFlightInfo");

            AirplaneName = dTO.AirplaneName;
            AirplaneType = dTO.AirplaneType;
            CompanyLogoImage= ImageSource.FromStream(() => new MemoryStream(dTO.CompanyLogo));
            CompanyName= dTO.CompanyName;

            foreach (var item in dTO.tickets)
            {
                ticketLuxuriesInfos.Add(item);
            }
            ticketLuxuriesInfos = dTO.tickets;
            EndDate = flight.EndDate;
            StartDate = flight.StartDate;
            Duration = flight.Duration;

            return true;
        }

        


    }
}
