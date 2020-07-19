using FlightMaster.MobileApp.Services;
using FlightMaster.Model.MobileModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlightMaster.MobileApp.ViewModels.UserJourneyViewModels
{
    public class FutureJourneyViewModel:BaseViewModel
    {

        ApiCaller api;
        public List<UserFutureJourneysData> userJourneys { get; set; }

        public FutureJourneyViewModel()
        {
            api = new ApiCaller();
            userJourneys = new List<UserFutureJourneysData>();
        }


        public async Task<bool> LoadData()
        {


            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();


            int id =(int) Application.Current.Properties["ID"];
            keyValuePairs.Add("UserId", id);
            userJourneys = await api.GetQuery<List<UserFutureJourneysData>>(keyValuePairs,"Journey", "GetUserFutureJourneys");

            return true;
        }
    }
}
