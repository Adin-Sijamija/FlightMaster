using FlightMaster.MobileApp.ViewModels.AdvancedSearchModels;
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
    public partial class AdvancedSearchResults : ContentPage
    {

        FlightSearchViewModel model;
        public AdvancedSearchResults(AdvancedSearchMainModel.FlightSearchData data)
        {
            InitializeComponent();
            this.Title = "Search results";
            BindingContext= model = new FlightSearchViewModel(data);
            GetData();
        }

        private async void GetData()
        {
            var res = await model.LoadData();


            if (model.SearchData.Count == 0 || model.SearchData == null)
            {
                SearchDataListView.ItemsSource = model.SearchData;
                SearchLoadIndicator.IsRunning = false;
                SearchLoadIndicator.IsVisible = false;
                SearchLoadLabel.IsVisible = true;
                SearchLoadLabel.Text = "No flights found that match search desriptions :(";
                SearchDataListView.IsVisible = false;
            }
            else
            {
                SearchDataListView.ItemsSource = model.SearchData;
                SearchLoadIndicator.IsRunning = false;
                SearchLoadIndicator.IsVisible = false;
                SearchLoadLabel.IsVisible = false;
                SearchDataListView.IsVisible = true;
            }
            

        }

        private async void SearchDataListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            JourneyFlighsDTO journey = (JourneyFlighsDTO)SearchDataListView.SelectedItem;
            await Navigation.PushAsync(new JourneyAdditionTabPage(journey));

        }

        private void SearchDataListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            JourneyFlighsDTO journey = (JourneyFlighsDTO)e.Item;
            if (model.IsLastItem(journey))
                model.LoadNextPage();
        }
    }
}