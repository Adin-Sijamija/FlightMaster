using FlightMaster.MobileApp.ViewModels;
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
    public partial class LogInPage : ContentPage
    {
        LogInViewModel model;
        public LogInPage()
        {
            InitializeComponent();
            BindingContext = model = new LogInViewModel();
            setLabelClick();
        }

        private void setLabelClick()
        {
            var tap = new TapGestureRecognizer();
            tap.Tapped += (s, e) => RegLabelClick();
            RegisterLabel.GestureRecognizers.Add(tap);
        }

        private async void RegLabelClick()
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            LoggingLabel.TextColor = Color.Black;
            LoggingIndicator.IsRunning = true;
            LoggingLabel.Text ="Logging in...";
            LoggingLabel.IsVisible = true;

            var succes = await model.LoggedInAsync();

            if (succes)
            {
                LoggingIndicator.IsRunning = false;
                LoggingLabel.Text = "Welcome " + model._UserName;

                await Task.Delay(1000);
                App.Current.MainPage = new MainPage();
                return;
            }
           
            LoggingIndicator.IsRunning = false;
            LoggingLabel.IsVisible = true;
            LoggingLabel.Text = "User not found!"; LoggingLabel.TextColor = Color.Red;



        }
    }
}