using FlightMaster.MobileApp.Services;
using FlightMaster.Model.MobileModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace FlightMaster.MobileApp.ViewModels.UserJourneyViewModels
{
    public class UserJourneysFlightTicketsViewModel:BaseViewModel
    {

        ApiCaller api = new ApiCaller();
        private int JourneyId = 0;

        ObservableCollection<UserJourneyTicketsInfo> tickets = new ObservableCollection<UserJourneyTicketsInfo>();
        public ObservableCollection<UserJourneyTicketsInfo> Tickets { get { return tickets; } }


        public UserJourneysFlightTicketsViewModel()
        {


        }

        public UserJourneysFlightTicketsViewModel(UserJourneyInfoModel data)
        {
            JourneyId = data.Journey.Id;
            foreach (var item in data.ticketsInfos)
            {
                tickets.Add(item);

            }
            CHeckDataChange();
        }


        public void CHeckDataChange()
        {
            Device.StartTimer(TimeSpan.FromSeconds(15), () =>
            {
                Device.BeginInvokeOnMainThread(() => refreshTicketData());
                return true;
            });

        }

        private async void refreshTicketData()
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("JourneyId", JourneyId);
            List<UserJourneyTicketsInfo> newData = await api.GetQuery<List<UserJourneyTicketsInfo>>(param, "Journey", "GetJourneyDataCheck");

            foreach (var item in newData)
            {
                UserJourneyTicketsInfo oldTicket = tickets.SingleOrDefault(x => x.TicketId == item.TicketId);

                if (oldTicket.TicketStatus != item.TicketStatus || oldTicket.FlightStatus==item.FlightStatus)
                {
                    int oldIndex = tickets.IndexOf(oldTicket);
                    tickets[oldIndex] = item;
                   
                }
            }
        }
    }
}
