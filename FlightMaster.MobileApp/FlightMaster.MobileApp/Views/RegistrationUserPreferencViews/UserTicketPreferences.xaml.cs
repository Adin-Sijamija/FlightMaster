using FlightMaster.MobileApp.ViewModels.UserPreferencesViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlightMaster.MobileApp.Views.RegistrationUserPreferencViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserTicketPreferences : ContentPage
    {
        UserTicketPreferencesViewModel model;
        public UserTicketPreferences(bool isNewAccount=false)
        {
            NavigationPage.SetHasBackButton(this, false);
            this.Title = "Your Ticket Taste!";
            InitializeComponent();
            BindingContext = model = new UserTicketPreferencesViewModel(isNewAccount);


            GetData();
        }

        private async void GetData()
         {
            var res=await model.LoadTickets();
            SetTabel();
        }

        private void SetTabel()
        {


            int count = 0;
            foreach (var item in model.ticketTypes)
            {


                var mainLayout = new StackLayout() { Padding = 10, Margin = 10 };


                //TicketData
                var TicketTitel = new StackLayout();
                var TickId = new Label() { Text = item.Id.ToString(), IsVisible = false };
                var TicketTitelLabel = new Label() { Text = "Ticket Type: " + item.Name };
                TicketTitel.Children.Add(TickId);
                TicketTitel.Children.Add(TicketTitelLabel);



                //Rating
                var RatingLayout = new StackLayout() {  Orientation=StackOrientation.Horizontal, HorizontalOptions= LayoutOptions.CenterAndExpand, Margin=5,Padding=5 };
                var Label = new Label() { Text = "Your rating:" };
                var slider = new Stepper() {  Minimum=1,Maximum=5,Increment=1, Value=1,Margin=5};

               var ratingval = model.userTicketPreferences.SingleOrDefault(x => x.TicketTypeId == item.Id);
               var SliderVal = new Label() { Text = "0" };

                if (ratingval != null)
                {
                    SliderVal.Text = ratingval.Rating.ToString();
                    slider.Value = ratingval.Rating;
                }
                slider.ValueChanged += Slider_ValueChangedTrigger;


                RatingLayout.Children.Add(Label);
                RatingLayout.Children.Add(slider);
                RatingLayout.Children.Add(SliderVal);

                mainLayout.Children.Add(TicketTitel);
                mainLayout.Children.Add(RatingLayout);

                ViewCell cell = new ViewCell() { View = mainLayout };


                TabelSection.Add(cell);

                ++count;
            }

            TicketLoadIndicator.IsVisible = false;
            TicketLoadIndicator.IsRunning= false;
            Maintabel.IsVisible = true;
            SaveButton.IsVisible = true;
        }

        private void Slider_ValueChangedTrigger(object sender, ValueChangedEventArgs e)
        {
            Stepper slider = (Stepper)sender;

            StackLayout sliderLayout =(StackLayout) slider.Parent;
            StackLayout main =(StackLayout) sliderLayout.Parent;
            StackLayout IdLayout = (StackLayout)main.Children[0];

            var IdLabel = (Label)IdLayout.Children[0];       int TicketTypeId =int.Parse(IdLabel.Text);

            Label NewValueLabel =(Label) sliderLayout.Children[2];

            NewValueLabel.Text=slider.Value.ToString();


            int SliderValue = (int)slider.Value;

            model.UpdateTicketPref(SliderValue, TicketTypeId);

            SaveButton.IsEnabled = true;



        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {

           var res=  await model.SaveData();

            if (model.isNewAccount)
            {
                await Navigation.PushAsync(new UserLuxuriesPreferences(true));
                return;
            }

            SaveButton.Text = "Saved";
        }
    }
}