using FlightMaster.MobileApp.ViewModels.UserJourneyViewModels;
using FlightMaster.Model.MobileModel;
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
    public partial class JourneyFlightTicketShow : ContentPage
    {
        UserJourneysFlightTicketsViewModel model;
        public JourneyFlightTicketShow(UserJourneyInfoModel data)
        {
            this.Title = "Tickets";
            InitializeComponent();
            BindingContext = model = new UserJourneysFlightTicketsViewModel(data);
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView listView = (ListView)sender;
            listView.SelectedItem = null;
        }
    }
}