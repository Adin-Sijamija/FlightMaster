using FlightMaster.MobileApp.ViewModels.JourneyAdditionViewModels;
using FlightMaster.Model.MobileModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlightMaster.MobileApp.Views.JourneyInfoTabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JourneyInfoPage : ContentPage
    {
        JourneyInfoPageViewModel model;
        public JourneyInfoPage(JourneyFlighsDTO  journeyData)
        {
            InitializeComponent();
            BindingContext = model = new JourneyInfoPageViewModel(journeyData);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            JourneyAdditionTabPage parent = (JourneyAdditionTabPage)this.Parent;
            parent.AddJourney();
        }

        public void SetJourneyPrice(List<Models.FlightTicketsTobeAdded> allTickets)
        {

            int totalTickets = 0; double TotalPrice = 0;

            foreach (var item in allTickets)
            {
                totalTickets += item.TicketCount;
                TotalPrice += item.TicketCount * item.Price;
            }
            TotalCostLabel.Text = "Total Price: " + TotalPrice + " $";
            TicketNumberLabel.Text = "Number of tickets: " + totalTickets ;

        }
    }
}