using FlightMaster.MobileApp.Services;
using FlightMaster.Model.MobileModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FlightMaster.MobileApp.ViewModels
{
    public class FlightRecomenderViewModel : BaseViewModel
    {

        int page;
        ApiCaller api;
        public List<JourneyFlighsDTO> NewData;
        ObservableCollection<JourneyFlighsDTO> journeys;
        public ObservableCollection<JourneyFlighsDTO> Journeys { get { return journeys; } }
        public Command LoadStartPage { get; set; }
        public Command LoadNextPage { get; set; }

        public FlightRecomenderViewModel()
        {
            page = 1;
            api = new ApiCaller();
            NewData = new List<JourneyFlighsDTO>();
            journeys = new ObservableCollection<JourneyFlighsDTO>();
            LoadStartPage = new Command(async () => await LoadFirstPage());
            LoadNextPage = new Command(async () => await NextPageLoad());
        }

        public async Task<bool> LoadFirstCall()
        {
            await LoadFirstPage();
            return true;
        }

        private async Task NextPageLoad()
        {
            ++page;
            Dictionary<string, object> param = new Dictionary<string, object>();
            int id = (int)Application.Current.Properties["ID"];
            param.Add("UserId", id);
            param.Add("Page", page);
           
            NewData = await api.GetQuery<List<JourneyFlighsDTO>>(param, "Flight", "GetUserRecommendedFlights");
            foreach (var item in NewData)
            {
                journeys.Add(item);
            }
            NewData.Clear();
        }

        public async void LoadNextPageCall() { await NextPageLoad(); }
        private async Task LoadFirstPage()
        {
            page = 1;
            Dictionary<string, object> param = new Dictionary<string, object>();
            int id = (int)Application.Current.Properties["ID"];
            param.Add("UserId", id);
            param.Add("Page", page);
          
            NewData = await api.GetQuery<List<JourneyFlighsDTO>>(param, "Flight", "GetUserRecommendedFlights");
            foreach (var item in NewData)
            {
                journeys.Add(item);
            }
            NewData.Clear();
        }

        internal bool IsLastItem(JourneyFlighsDTO item)
        {
            if (journeys[journeys.Count - 1] == item)
                return true;
            return false;
        }
    }
}
