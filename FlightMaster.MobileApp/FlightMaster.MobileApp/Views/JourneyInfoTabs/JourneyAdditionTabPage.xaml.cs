
using FlightMaster.MobileApp.Models;
using FlightMaster.MobileApp.Services;
using FlightMaster.MobileApp.Views.JourneyInfoTabs;
using FlightMaster.MobileApp.Views.UserJourneys;
using FlightMaster.Model.MobileModel;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlightMaster.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JourneyAdditionTabPage : TabbedPage
    {

        JourneyFlighsDTO testdata;
        public JourneyAdditionTabPage(JourneyFlighsDTO journeydata)
        {
            InitializeComponent();
            testdata = journeydata;

            JourneyInfoPage info = new JourneyInfoPage(journeydata);
            info.Title = "Journey Info";
            this.Children.Add(info);

            int id = 1;
            foreach (var flight in journeydata.Journeyflights)
            {

                FlightInfoPage tab = new FlightInfoPage(flight);
                tab.Title = "Flight " + id;
                this.Children.Add(tab);
                ++id;
            }


        }

        private async void test()
        {
            await DisplayAlert("TEST", "test cost:" + testdata.AvarageCost, "OK");
        }

        public async void AddJourney()
        {

            bool TicketsMissing = false;
            foreach (var item in this.Children)
            {

                if (item.GetType() == typeof(FlightInfoPage))
                {
                    FlightInfoPage page = (FlightInfoPage)item;

                    if (page.model.UserTickets.Count == 0)
                        TicketsMissing = true;


                }

            }

            if (TicketsMissing)
            {
                await DisplayAlert("Warning", "Not all flights have tickets! Add tickets to all flights to save your journey!", "Ok");
                return;
            }



            List<FlightTicketsTobeAdded> allTickets = new List<FlightTicketsTobeAdded>();
            foreach (var item in this.Children)
            {


                if (item.GetType() == typeof(FlightInfoPage))
                {
                    FlightInfoPage page = (FlightInfoPage)item;

                    allTickets.AddRange(page.model.UserTickets);
                }

            }

            JourneyInsertModel model = new JourneyInsertModel()
            {
                UserId = int.Parse(Application.Current.Properties["ID"].ToString()),
                //UserId=4,
                ticketsTobeAddeds = allTickets
            };

            ApiCaller api = new ApiCaller();

            var res = await api.Insert<bool>(model, "Journey", "InsertNewJourney");


            if (res)
            {
                await Navigation.PushAsync(new UserJourneysTabPage());
                var existingPages = Navigation.NavigationStack.ToList();
                foreach (var page in existingPages)
                {
                    if (page.GetType() == typeof(UserJourneysTabPage))
                        continue;

                    Navigation.RemovePage(page);
                }
                var MainPage = (MainPage)Application.Current.MainPage;
                MainPage.MenuPages.Remove(2);
            }

        }

        public void UpdateJourneyPrice()
        {

            List<FlightTicketsTobeAdded> allTickets = new List<FlightTicketsTobeAdded>();
            foreach (var item in this.Children)
            {


                if (item.GetType() == typeof(FlightInfoPage))
                {
                    FlightInfoPage page = (FlightInfoPage)item;
             
                    allTickets.AddRange(page.model.UserTickets);
                }

            }

            JourneyInfoPage journey = (JourneyInfoPage)this.Children[0];
            journey.SetJourneyPrice(allTickets);

        }

    }
}