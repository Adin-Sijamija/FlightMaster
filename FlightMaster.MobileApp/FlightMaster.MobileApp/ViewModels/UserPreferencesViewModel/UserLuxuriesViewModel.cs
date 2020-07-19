using FlightMaster.MobileApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlightMaster.MobileApp.ViewModels.UserPreferencesViewModel
{
    public class UserLuxuriesViewModel:BaseViewModel
    {
        private ApiCaller api;
        public List<Model.LuxuryPreferences> userLuxuryPreferences;
        public List<Model.Luxuries> luxuriesTypes;
        public bool isNewAccount = false;

        public UserLuxuriesViewModel(bool isNewAccount)
        {
            api = new ApiCaller();
            userLuxuryPreferences = new List<Model.LuxuryPreferences>();
            luxuriesTypes = new List<Model.Luxuries>();
            this.isNewAccount = isNewAccount;
        }
        public async Task<bool> LoadTickets()
        {
            luxuriesTypes = await api.GetAll<List<Model.Luxuries>>("Luxuries", "GetAll");

            if (!isNewAccount)
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                int iD = (int)Application.Current.Properties["ID"];
                param.Add("UserId", iD);
                userLuxuryPreferences = await api.GetQuery<List<Model.LuxuryPreferences>>(param, "Users", "GetUserLuxuriesPreferences");
                return true;

            }
            int id = (int)Application.Current.Properties["ID"];
            foreach (var item in luxuriesTypes)
            {
                userLuxuryPreferences.Add(new Model.LuxuryPreferences()
                {
                    CustomerId = id,
                    LuxuriesId= item.Id,
                    Rating = 1
                });
            }


            return true;
        }



        internal void UpdateTicketPref(int sliderValue, int LuxTypeId)
        {

            Model.LuxuryPreferences tickpref = userLuxuryPreferences.SingleOrDefault(x => x.LuxuriesId == LuxTypeId);

            if (tickpref != null)
            {
                int index = userLuxuryPreferences.IndexOf(tickpref);
                userLuxuryPreferences[index].Rating = sliderValue;
                return;
            }


        }

        public async Task<bool> SaveData()
        {

            var res = await api.Insert<bool>(userLuxuryPreferences, "Users", "SetUserLuxuriesPreferences");

            return true;
        }
    }
}
