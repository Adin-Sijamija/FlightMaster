using FlightMaster.MobileApp.Services;
using FlightMaster.Model.MobileModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlightMaster.MobileApp.ViewModels.UserJourneyViewModels
{
    public class PastJourneysViewModel:BaseViewModel
    {
        ApiCaller api;
        public List<UserJourneyInfoModel> userJourneys { get; set; }

        public PastJourneysViewModel()
        {
            api = new ApiCaller();
            userJourneys = new List<UserJourneyInfoModel>();
        }


        public async Task<bool> LoadData()
        {


            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();

            int id = (int)Application.Current.Properties["ID"];
            keyValuePairs.Add("UserId", id);
            userJourneys = await api.GetQuery<List<UserJourneyInfoModel>>(keyValuePairs, "Journey", "GetUserPastJourneys");

            return true;
        }
    }
}
