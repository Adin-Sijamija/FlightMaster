using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using FlightMaster.MobileApp.Models;

namespace FlightMaster.MobileApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        public Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.StartPage, (NavigationPage)Detail);

            this.Detail = new NavigationPage(new FlightRecomenderPage());
        }

        public async Task NavigateFromMenu(int id)
        {
            bool reopend = false;
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.StartPage:
                        MenuPages.Add(id, new NavigationPage(new FlightRecomenderPage()));
                        reopend = true;
                        break;
                    case (int)MenuItemType.Search:
                        MenuPages.Add(id, new NavigationPage(new AdvancedSearch()));
                        break;
                    case (int)MenuItemType.Journeys:
                        MenuPages.Add(id, new NavigationPage(new UserJourneys.UserJourneysTabPage()));
                        break;
                    case (int)MenuItemType.City:
                        MenuPages.Add(id, new NavigationPage(new RegistrationUserPreferencViews.UserCity(false)));
                        break;
                    case (int)MenuItemType.Tickets:
                        MenuPages.Add(id, new NavigationPage(new RegistrationUserPreferencViews.UserTicketPreferences(false)));
                        break;
                    case (int)MenuItemType.Luxuries:
                        MenuPages.Add(id, new NavigationPage(new RegistrationUserPreferencViews.UserLuxuriesPreferences(false)));
                        break;
                }
            }

            if (MenuPages.ContainsKey(1)&&!reopend)
                MenuPages.Remove(1);
            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}