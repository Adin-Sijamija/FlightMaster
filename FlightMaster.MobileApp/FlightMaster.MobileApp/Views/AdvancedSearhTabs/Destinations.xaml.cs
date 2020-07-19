using FlightMaster.MobileApp.ViewModels.AdvancedSearchModels;
using FlightMaster.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlightMaster.MobileApp.Views.AdvancedSearhTabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Destinations : ContentPage
    {
        DestinationViewModel model;
        public Destinations(DestinationViewModel mod)
        {
            InitializeComponent();
            model = mod;
            GetCountryData();

        }

        private async void GetCountryData()
        {
            var res = await model.SetCountries();
            ListViewResults.ItemsSource = model.FilterCountries("");

            CountrySearch.IsEnabled = true;




        }

    
        private void CountrySearch_TextChanged_1(object sender, TextChangedEventArgs e)
        {

            if (model.FillingCountrySearchbar)
            {
                model.FillingCountrySearchbar = false;
                return;
            }


            if (!model.IsCountrySelected())
            {
                ListViewResults.ItemsSource = model.FilterCountries(CountrySearch.Text);
                return;
            }
            else
            {

                if (model.IsCitySelected())
                {
                    CitySearch.Text = "";
                    CitySearch.IsEnabled = false;
                    model.SetCityId(0);
                }

                model.SetCountryId(0);
                ListViewResults.ItemsSource = model.FilterCountries(CountrySearch.Text);
            }


        }

        private void CitySearch_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (model.FillingCitySearchbar)
            {
                model.FillingCitySearchbar = false;
                return;
            }

            if (model.IsCitySelected())
            {
                ListViewResults.SelectedItem = null;
                model.SetCityId(0);
            }


            ListViewResults.ItemsSource = model.FilterCities(CitySearch.Text);
        }

        private async void ListViewResults_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            if (!model.IsCountrySelected())
            {
                Country country = (Country)ListViewResults.SelectedItem;
                model.SetCountryId(country.Id);
                var res = await model.SetCities();
                ListViewResults.ItemsSource = model.FilterCities("");
                model.FillingCountrySearchbar = true;
                CountrySearch.Text = country.Name;
                CitySearch.IsEnabled = true;

                return;
            }

            if (!model.IsCitySelected())
            {
                City city = (City)ListViewResults.SelectedItem;
                model.SetCityId(city.Id);
                model.FillingCitySearchbar = true;
                CitySearch.Text = city.Name;
                return;
            }

        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            var parent = (AdvancedSearch)this.Parent;
            model.TestString = "TEST CLICK";
            parent.SetSearchFilter();
        }
    }
}