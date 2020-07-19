using FlightMaster.MobileApp.Services;
using FlightMaster.Model.MobileModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace FlightMaster.MobileApp.ViewModels.AdvancedSearchModels
{
    public class FlightSearchViewModel : BaseViewModel
    {

        ApiCaller api;
        AdvancedSearchDataModel flightSearch;
        private List<object> resuluts;
        public ObservableCollection<JourneyFlighsDTO> SearchData;
        private int page;

        public FlightSearchViewModel(AdvancedSearchMainModel.FlightSearchData data)
        {
            flightSearch = new AdvancedSearchDataModel(1, data.luxuiresId, data.Mindate, data.MaxDate, data.depCityId, data.arrCityId);
            page = 1;
            api = new ApiCaller();
            ObservableCollection<JourneyFlighsDTO> SearchData = new ObservableCollection<JourneyFlighsDTO>();

        }

        public FlightSearchViewModel()
        {
        }

        public async Task<bool> LoadData()
        {



            Dictionary<string, object> queryParams = new Dictionary<string, object>();
            queryParams.Add("depcity", flightSearch.depCityId);
            queryParams.Add("arrcity", flightSearch.arrCityId);
            queryParams.Add("mindate", flightSearch.Mindate);
            queryParams.Add("maxDate", flightSearch.MaxDate);
            queryParams.Add("LuxIds", flightSearch.luxuiresId);
            queryParams.Add("page", page);

            var test = await api.GetQuery<List<JourneyFlighsDTO>>(queryParams, "Flight", "AdvancedUserSearchv2");

            if (SearchData == null)
                SearchData = new ObservableCollection<JourneyFlighsDTO>();

            foreach (var item in test)
            {
                SearchData.Add(item);
            }

            return true;
        }

        internal async void LoadNextPage()
        {

            if (SearchData.Count > 20)
            {


                ++page;
                Dictionary<string, object> queryParams = new Dictionary<string, object>();
                queryParams.Add("depcity", flightSearch.depCityId);
                queryParams.Add("arrcity", flightSearch.arrCityId);
                queryParams.Add("mindate", flightSearch.Mindate);
                queryParams.Add("maxDate", flightSearch.MaxDate);
                queryParams.Add("LuxIds", flightSearch.luxuiresId);
                queryParams.Add("page", page);

                var test = await api.GetQuery<List<JourneyFlighsDTO>>(queryParams, "Flight", "AdvancedUserSearchv2");

                if (SearchData == null)
                    SearchData = new ObservableCollection<JourneyFlighsDTO>();

                foreach (var item in test)
                {
                    SearchData.Add(item);
                }
            }

        }

        internal bool IsLastItem(JourneyFlighsDTO journey)
        {
            if (SearchData[SearchData.Count - 1] == journey)
                return true;
            return false;
        }
    }
}
