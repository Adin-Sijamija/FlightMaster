using FlightMaster.MobileApp.Services;
using FlightMaster.Model.MobileModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlightMaster.MobileApp.ViewModels.UserJourneyViewModels
{
    public class FutureJourneyFlightVIewModel:BaseViewModel
    {

        ApiCaller api;
        public int FlightId { get; set; }

        ObservableCollection<UserJourneyTicketsInfo> tickets = new ObservableCollection<UserJourneyTicketsInfo>();
        public ObservableCollection<UserJourneyTicketsInfo> Tickets { get { return tickets; } }
        public Model.Flight FlightData = new Model.Flight();

        string FlightName = "";
        public string _FlightName {
            get { return FlightName; }
            set { SetProperty(ref FlightName, value); }
        }

        string FlightStartDate = "";
        public string _FlightStartDate
        {
            get { return FlightStartDate; }
            set { SetProperty(ref FlightStartDate, value); }
        }
        string FlightEndDate = "";
        public string _FlightEndDate
        {
            get { return FlightEndDate; }
            set { SetProperty(ref FlightEndDate, value); }
        }
        string FlightDuration = "";
        public string _FlightDuration
        {
            get { return FlightDuration; }
            set { SetProperty(ref FlightDuration, value); }
        }
        string FlightStatus = "";
        public string _FlightStatus
        {
            get { return FlightStatus; }
            set { SetProperty(ref FlightStatus, value); }
        }


        string DepartureLocation = "";
        public string _DepartureLocation
        {
            get { return DepartureLocation; }
            set { SetProperty(ref DepartureLocation, value); }
        }

        string ArrivalLocation = "";
        public string _ArrivalLocation
        {
            get { return ArrivalLocation; }
            set { SetProperty(ref ArrivalLocation, value); }
        }


        private FlightStatusEnum FlightStatusEnumId;
        public FutureJourneyFlightVIewModel(Model.Flight flight)
        {
            api = new ApiCaller();
            FlightId = flight.Id;
            FlightName = flight.Name;
            FlightStartDate = flight.StartDate.ToString();
            FlightEndDate = flight.EndDate.ToString();
            FlightDuration = flight.Duration;
            FlightStatusEnumId = (FlightStatusEnum)flight.Status;
            _FlightStatus = FlightStatusEnumId.ToString();
            FlightData = flight;
        }

        public FutureJourneyFlightVIewModel()
        {
            api = new ApiCaller();
        }

        public async Task<bool> LoadData()
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("FlightId", FlightId);
            var LocData = await api.GetQuery<UserFlightLocationsDTO>(param, "Journey", "GetUserFlightLocations");
            _DepartureLocation = LocData.DepartureLocation;
            _ArrivalLocation= LocData.ArrivalLocation;

            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
            keyValuePairs.Add("FlightId", FlightId);
            int userid=(int)Application.Current.Properties["ID"];
            keyValuePairs.Add("UserId", userid);
            var res = await api.GetQuery<List<UserJourneyTicketsInfo>>(keyValuePairs, "Journey", "GetUserFlightTickets");

            foreach (var item in res)
            {
                tickets.Add(item);
            }





            CHeckDataChange();
            return true;
        }


        public void CHeckDataChange()
        {
            Device.StartTimer(TimeSpan.FromSeconds(15), () =>
            {
                Device.BeginInvokeOnMainThread(() => refreshTicketData());
                Device.BeginInvokeOnMainThread(() => refreshFlightData());
                return true;
            });

        }

        private async void refreshFlightData()
        {
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
            keyValuePairs.Add("FlightId", FlightId);
            int userid = (int)Application.Current.Properties["ID"];
            var res = await api.GetQuery<Model.Flight>(keyValuePairs, "Flight", "GetFlightInfo");

            if (res.Duration != FlightDuration)
                FlightDuration = res.Duration;
            
            if (res.StartDate != FlightData.StartDate)
            {
                _FlightStartDate = res.StartDate.ToString();
                FlightData.StartDate = res.StartDate;
                CalculateNewDuration();

            }

            if (res.EndDate != FlightData.EndDate)
            {
                FlightData.EndDate = res.EndDate;
                _FlightEndDate = res.EndDate.ToString();
                CalculateNewDuration();
            }

            int oldStatus = (int)FlightStatusEnumId;
            int newStatus = res.Status;

            if (oldStatus != newStatus)
            {
                FlightStatusEnumId = (FlightStatusEnum)newStatus;
                _FlightStatus = FlightStatusEnumId.ToString();
            }
        }

        private void CalculateNewDuration()
        {
            TimeSpan flightduration = (FlightData.EndDate - FlightData.StartDate);
            string Duration = string.Format("{0:00}:{1:00}", (int)flightduration.TotalHours, flightduration.Minutes);
            FlightData.Duration = Duration;
            _FlightDuration = Duration;
        }

        private async void refreshTicketData()
        {

            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
            keyValuePairs.Add("FlightId", FlightId);
            int userid = (int)Application.Current.Properties["ID"];
            keyValuePairs.Add("UserId", userid);
            var res = await api.GetQuery<List<UserJourneyTicketsInfo>>(keyValuePairs, "Journey", "GetUserFlightTickets");

            foreach (var item in res)
            {
                UserJourneyTicketsInfo oldTicket = tickets.SingleOrDefault(x => x.TicketId == item.TicketId);

                if (oldTicket.TicketStatus != item.TicketStatus || oldTicket.FlightStatus == item.FlightStatus)
                {
                    int oldIndex = tickets.IndexOf(oldTicket);
                    tickets[oldIndex] = item;

                }
            }
        }


        public enum FlightStatusEnum
        {
            OnTime = 0,
            LateDeparture,
            LateArrival,
            DepartureDelayed,
            PostPoned,
            Rescheduled,
            Canceled,

        }

    }
}
