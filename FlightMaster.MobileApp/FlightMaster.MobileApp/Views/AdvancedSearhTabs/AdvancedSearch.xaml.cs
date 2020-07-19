using FlightMaster.MobileApp.ViewModels.AdvancedSearchModels;
using FlightMaster.MobileApp.Views.AdvancedSearhTabs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlightMaster.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdvancedSearch : TabbedPage
    {

        

        AdvancedSearchMainModel model;

        public AdvancedSearch()
        {

            model = new AdvancedSearchMainModel();

            
            this.Title = "Advanced Search";

            InitializeComponent();

            Departures departures = new Departures(model.departure);
            departures.Title = "Departures";

            Destinations destinations = new Destinations(model.destination);
            destinations.Title = "Destinations";


            TravelTime travelTime  = new TravelTime(model.travel);
            travelTime.Title = "Travel Time";

            Luxuries luxuries = new Luxuries(model.luxuriesmodel);
            luxuries.Title = "Luxuries";

            Children.Add(departures);
            Children.Add(destinations);
            Children.Add(travelTime);
            Children.Add(luxuries);



        }


        public async void SetSearchFilter()
        {
            // destinations

            if (model.departure.CityId == 0)
            {
                await DisplayAlert("Error", "Departure city required", "Ok");
                return;
            }

            if (model.destination.CityId == 0)
            {
                await DisplayAlert("Error", "Destination city required", "Ok");
                return;
            }

            if (model.departure.CityId == model.destination.CityId)
            {
                await DisplayAlert("Error","Departure and Destination can not be the same city","Ok");
                return;
            }

            if (model.travel.MinDate.Date == model.travel.MaxDate.Date)
            {
                await DisplayAlert("Error", "Please select travel dates", "Ok");
                return;
            }

            if (model.travel.MinDate.Date > model.travel.MaxDate.Date)
            {
                await DisplayAlert("Error", "Start date cant be bigger than end date", "Ok");
                return;
            }

            DateTime date = DateTime.Now;
            if (model.travel.MaxDate.Date<date.Date || model.travel.MinDate.Date<date.Date)
            {
                await DisplayAlert("Error", "Time span can not be earlier that current", "Ok");
                return;
            }

            if (model.travel.MaxDate.Date < model.travel.MinDate.Date)
            {
                DateTime holder = model.travel.MaxDate;
                model.travel.MaxDate = model.travel.MinDate;
                model.travel.MinDate = holder;
            }

          
            model.SetFlightSearchData();

            await Navigation.PushAsync(new AdvancedSearchResults(model.flightSearch));
        }

    }
}