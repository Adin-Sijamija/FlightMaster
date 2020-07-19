using FlightMaster.MobileApp.Services;
using FlightMaster.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlightMaster.MobileApp.ViewModels.UserPreferencesViewModel
{
    public class UserTicketPreferencesViewModel : BaseViewModel
    {

        private ApiCaller api;
        public List<Model.TicketPreferences> userTicketPreferences;
        public List<Model.TicketType> ticketTypes;
        public bool isNewAccount = false;

        public UserTicketPreferencesViewModel(bool isNewAccount)
        {
            api = new ApiCaller();
            userTicketPreferences = new List<Model.TicketPreferences>();
            ticketTypes = new List<Model.TicketType>();
            this.isNewAccount = isNewAccount;
        }

        public async Task<bool> LoadTickets()
        {
            ticketTypes = await api.GetAll<List<FlightMaster.Model.TicketType>>("TicketType");

            if (!isNewAccount)
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                int iD = (int)Application.Current.Properties["ID"];
                param.Add("UserId", iD);
                userTicketPreferences = await api.GetQuery<List<Model.TicketPreferences>>(param, "Users", "GetUserTicketPreferences");
                return true;

            }
            int id = (int)Application.Current.Properties["ID"];
            foreach (var item in ticketTypes)
            {
                userTicketPreferences.Add(new Model.TicketPreferences()
                {
                    CustomerId = id,
                    TicketTypeId = item.Id,
                    Rating = 1
                });
            }


            return true;
        }

        internal void UpdateTicketPref(int sliderValue, int ticketTypeId)
        {

            TicketPreferences tickpref = userTicketPreferences.SingleOrDefault(x => x.TicketTypeId == ticketTypeId);

            if (tickpref != null)
            {
                int index = userTicketPreferences.IndexOf(tickpref);
                userTicketPreferences[index].Rating = sliderValue;
                return;
            }


        }

        public async Task<bool> SaveData()
        {

            var res =await api.Insert<bool>(userTicketPreferences, "Users", "SetUserTicketPreferences");

            return true;
        }
    }
}
