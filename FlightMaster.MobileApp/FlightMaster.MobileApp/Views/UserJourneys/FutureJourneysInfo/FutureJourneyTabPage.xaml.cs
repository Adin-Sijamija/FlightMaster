using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlightMaster.MobileApp.Views.UserJourneys.FutureJourneysInfo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FutureJourneyTabPage : TabbedPage
    {
        public FutureJourneyTabPage(Model.MobileModel.UserFutureJourneysData selected)
        {
            InitializeComponent();
            this.Title = "Journey Flights";

            int count = 1;
            foreach (var flight in selected.Flights)
            {
                this.Children.Add(new JourneyFlightInfoPage(flight) {Title="Flight "+count });
                ++count;
            }
        }
    }
}