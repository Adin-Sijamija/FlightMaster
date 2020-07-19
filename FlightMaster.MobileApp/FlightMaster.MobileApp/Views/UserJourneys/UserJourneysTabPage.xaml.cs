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
    public partial class UserJourneysTabPage : TabbedPage
    {


        public UserJourneysTabPage()
        {
            InitializeComponent();
            this.Title = "My Journeys";
            FutureJourneys future = new FutureJourneys() {Title="Future Journeys" };
            PreviousJourneys previous = new PreviousJourneys() {Title= "Previous Journeys" };

            this.Children.Add(future);
            this.Children.Add(previous);

        }
    }
}