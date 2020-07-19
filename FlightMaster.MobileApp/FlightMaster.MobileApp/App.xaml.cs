using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FlightMaster.MobileApp.Services;
using FlightMaster.MobileApp.Views;
using FlightMaster.MobileApp.Views.RegistrationUserPreferencViews;
using FlightMaster.MobileApp.Views.UserJourneys;

namespace FlightMaster.MobileApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

               MainPage =new NavigationPage( new LogInPage() { Title="Welcome"});

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
