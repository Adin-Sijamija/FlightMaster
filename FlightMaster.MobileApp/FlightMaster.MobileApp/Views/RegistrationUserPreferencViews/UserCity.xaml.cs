using FlightMaster.MobileApp.Services;
using FlightMaster.MobileApp.ViewModels.AdvancedSearchModels;
using FlightMaster.Model;
using FlightMaster.Model.MobileModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlightMaster.MobileApp.Views.RegistrationUserPreferencViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserCity : ContentPage
    {

        DeparturesViewModel model;
        bool IsRegistering=false;
        public UserCity(bool IsRegistering)
        {
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
            model = new DeparturesViewModel();
            this.Title = "Select your preferences!";
            this.IsRegistering = IsRegistering;
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
                SavedButton.IsEnabled = false;
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
                SavedButton.IsEnabled = true;
                return;
            }

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (model.CityId != 0)
            {
                button.IsEnabled = false;
                button.Text = "Saving...";
                ApiCaller api = new ApiCaller();
                UserCityUpdateModel data = new UserCityUpdateModel();
                data.CityId = model.CityId;
                data.UserId =(int) Application.Current.Properties["ID"];

                var res = await api.PatchOne<bool>(data, "Users", "SetUserCity");


                if (res)
                {
                    if (IsRegistering)
                    {

                        await Navigation.PushAsync(new UserTicketPreferences(true));
                    }
                    else
                    {

                        button.Text = "Saved";
                        button.IsEnabled = true;
                        return;
                    }

                }
                else
                {
                    await DisplayAlert("Warning", "Something went wrong please try again", "Ok");
                    return;
                }

            }
           




        }
    }
}