using FlightMaster.MobileApp.ViewModels.UserJourneyViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlightMaster.MobileApp.Views.UserJourneys
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JourneyFlightInfoPage : ContentPage
    {
        FutureJourneyFlightVIewModel model;

        public JourneyFlightInfoPage(Model.Flight flight)
        {
            InitializeComponent();
            BindingContext = model = new FutureJourneyFlightVIewModel(flight);
            loadData();
        }

        private async void loadData()
        {
            await model.LoadData();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView send = (ListView)sender;
            send.SelectedItem = null;

        }
    }
}