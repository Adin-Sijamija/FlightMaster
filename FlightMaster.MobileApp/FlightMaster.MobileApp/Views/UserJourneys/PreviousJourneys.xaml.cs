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
    public partial class PreviousJourneys : ContentPage
    {
        PastJourneysViewModel model;
        public PreviousJourneys()
        {
            InitializeComponent();
            BindingContext = model = new PastJourneysViewModel();
            LoadData();
        }


        private async void LoadData()
        {
            await model.LoadData();

            if (model.userJourneys.Count == 0)
            {
                LoadingIndicator.IsRunning = false;
                LoadingIndicator.IsVisible = false;
                TapGestureRecognizer tap = new TapGestureRecognizer();
                tap.Tapped += (s, e) => LabelClick();
                LoadingLabel.Text = "User has no previous journeys! Click here to find some!";
                LoadingLabel.GestureRecognizers.Add(tap);
                return;
            }


            //populate tabel
            PopulateTabel();


            LoadingIndicator.IsRunning = false;
            LoadingIndicator.IsVisible = false;
            LoadingLabel.IsVisible = false;
            JourneyTabel.IsVisible = true;
        }
        private void PopulateTabel()
        {

            foreach (var item in model.userJourneys)
            {
                var mainLayout = new StackLayout() { Padding = 10, Margin = 10 };


                var BaseData = new StackLayout() { HorizontalOptions = LayoutOptions.CenterAndExpand, Orientation = StackOrientation.Horizontal };
                var lab = new Label() { Text = item.Journey.Id.ToString(), IsVisible = false };
                var lab1 = new Label() { Text = "Start Location: " + item.Journey.StartCity };
                var lab2 = new Label() { Text = "End Location: " + item.Journey.EndCity };
                BaseData.Children.Add(lab); BaseData.Children.Add(lab1); BaseData.Children.Add(lab2);


                var BaseData2 = new StackLayout() { HorizontalOptions = LayoutOptions.CenterAndExpand, Orientation = StackOrientation.Horizontal };
                var lab3 = new Label() { Text = "Total price: " + item.Journey.TotalPrice };
                var lab4 = new Label() { Text = "Number of Tickets: " + item.ticketsInfos.Count };
                BaseData2.Children.Add(lab3);
                BaseData2.Children.Add(lab4);

                mainLayout.Children.Add(BaseData);
                mainLayout.Children.Add(BaseData2);

                ViewCell viewCell = new ViewCell() { View = mainLayout };
                viewCell.Tapped += ViewCell_Tapped;

                UserJourneys.Add(viewCell);

            }
        }

        private void LabelClick()
        {
            Navigation.PushAsync(new AdvancedSearch());
        }

        private async void ViewCell_Tapped(object sender, EventArgs e)
        {

            ViewCell tapped = (ViewCell)sender;

            View view = (View)tapped.View;
            StackLayout stack = (StackLayout)tapped.View;
            StackLayout Substack = (StackLayout)stack.Children[0];
            Label IdLab = (Label)Substack.Children[0];
            int JourneyId = int.Parse(IdLab.Text);

            UserJourneyInfoModel Selected = model.userJourneys.SingleOrDefault(x => x.Journey.Id == JourneyId);

            if (Selected != null)
            {
                await Navigation.PushAsync(new JourneyFlightTicketShow(Selected));
                return;
            }

            await DisplayAlert("Error", "Something Went Wrong!", "Ok");
        }
    }
}