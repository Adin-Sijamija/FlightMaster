using FlightMaster.MobileApp.ViewModels;
using FlightMaster.Model.MobileModel;
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
    public partial class FlightRecomenderPage : ContentPage
    {
        FlightRecomenderViewModel model;
        public FlightRecomenderPage()
        {
            this.Title = "Recommended Flights";
            InitializeComponent();
            BindingContext = model = new FlightRecomenderViewModel();
            LoadData();
        }

        private async void LoadData()
        {
            await model.LoadFirstCall();
            RecommenderLoader.IsVisible = false;
            ReccomendListView.IsVisible = true;
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            JourneyFlighsDTO journey = (JourneyFlighsDTO)ReccomendListView.SelectedItem;
            await Navigation.PushAsync(new JourneyAdditionTabPage(journey));

        }

        private void ListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            var item = (JourneyFlighsDTO)e.Item;
            bool IsLastItem = model.IsLastItem(item);

            if (IsLastItem)
                model.LoadNextPageCall();

        }
    }
}