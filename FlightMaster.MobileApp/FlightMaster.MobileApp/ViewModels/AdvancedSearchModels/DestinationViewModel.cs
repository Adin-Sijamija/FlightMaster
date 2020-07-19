using FlightMaster.MobileApp.Services;
using FlightMaster.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightMaster.MobileApp.ViewModels.AdvancedSearchModels
{
    public class DestinationViewModel:BaseViewModel
    {
        ApiCaller api;

        private int countryId = 0;
        private bool countrySelected = false;
        private bool citySelected = false;
        private int cityId = 0;

        private List<Country> countries;
        private List<City> cities;

        public int CountryId
        {
            get { return countryId; }
            set { SetProperty(ref countryId, value); }
        }
        public int CityId
        {
            get { return cityId; }
            set { SetProperty(ref cityId, value); }
        }


        public bool FillingCitySearchbar = false;
        public bool FillingCountrySearchbar = false;


        public DestinationViewModel()
        {
            api = new ApiCaller();
            countries = new List<Country>();
            cities = new List<City>();
        }

        public async Task<bool> SetCountries()
        {
            countries = await api.GetAll<List<Country>>("Countries");
            return true;
        }

        public async Task<bool> SetCities()
        {
            cities = await api.GetAllByID<List<City>>("Cities", countryId, "CountriesCities");
            return true;
        }

        public List<City> FilterCities(string text)
        {

            if (text == "")
                return cities;

            List<City> filtered = cities.Where(x => x.Name.Contains(text)).ToList();
            return filtered;


        }


        public void SetCountryId(int id)
        {

            if (id == 0)
            {
                countryId = 0;
                countrySelected = false;
                return;
            }

            countryId = id; countrySelected = true;
        }
        public void SetCityId(int id)
        {

            if (id == 0)
            {
                cityId = 0;
                citySelected = false;
                return;
            }

            cityId = id; citySelected = true;
        }
        public bool IsCountrySelected()
        {
            return countrySelected;
        }
        public bool IsCitySelected() { return citySelected; }





        public List<Country> FilterCountries(string text)
        {

            if (text == "")
                return countries;
            List<Country> filtered = countries.Where(x => x.Name.Contains(text)).ToList();
            return filtered;
        }


        public string TestString = "default";
    }
}
