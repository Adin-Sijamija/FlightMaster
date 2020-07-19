using FlightMaster.MobileApp.ViewModels.UserPreferencesViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlightMaster.MobileApp.Views.RegistrationUserPreferencViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserLuxuriesPreferences : ContentPage
    {
        UserLuxuriesViewModel model;
        public UserLuxuriesPreferences(bool IsNewAccount=true)
        {
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
            this.Title = "Your Luxuries Taste!";
            BindingContext = model = new UserLuxuriesViewModel(IsNewAccount);

          

            GetData();
        }

        private async void GetData()
        {
            var res = await model.LoadTickets();
            SetTabel();
        }

        private void SetTabel()
        {


            int count = 0;
            foreach (var item in model.luxuriesTypes)
            {


                var mainLayout = new StackLayout() { Padding = 10, Margin = 10 };


                //TicketData
                var TicketTitel = new StackLayout();
                var TickId = new Label() { Text = item.Id.ToString(), IsVisible = false };
                var TicketTitelLabel = new Label() { Text = "Luxury Type: " + item.Name };


                var Image = new Image() { HeightRequest = 40, WidthRequest = 30,Aspect=Aspect.AspectFit };
                Stream stream = new MemoryStream(item.Icon);
                Image.Source = ImageSource.FromStream(() => stream);


                TicketTitel.Children.Add(TickId);
                TicketTitel.Children.Add(TicketTitelLabel);
                TicketTitel.Children.Add(Image);



                //Rating
                var RatingLayout = new StackLayout() { Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.CenterAndExpand, Margin = 5, Padding = 5 };
                var Label = new Label() { Text = "Your rating:" };
                var slider = new Stepper() { Minimum = 1, Maximum = 5, Increment = 1, Value = 1, Margin = 5 };

                var ratingval = model.userLuxuryPreferences.SingleOrDefault(x => x.LuxuriesId == item.Id);
                var SliderVal = new Label() { Text = "1" };

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

            LuxuriesLoadIndicator.IsVisible = false;
            LuxuriesLoadIndicator.IsRunning = false;
            Maintabel.IsVisible = true;
            SaveButton.IsVisible = true;
        }

        private void Slider_ValueChangedTrigger(object sender, ValueChangedEventArgs e)
        {
            Stepper slider = (Stepper)sender;

            StackLayout sliderLayout = (StackLayout)slider.Parent;
            StackLayout main = (StackLayout)sliderLayout.Parent;
            StackLayout IdLayout = (StackLayout)main.Children[0];

            var IdLabel = (Label)IdLayout.Children[0]; int LuxTypeId = int.Parse(IdLabel.Text);

            Label NewValueLabel = (Label)sliderLayout.Children[2];

            NewValueLabel.Text = slider.Value.ToString();


            int SliderValue = (int)slider.Value;

            model.UpdateTicketPref(SliderValue, LuxTypeId);


            SaveButton.IsEnabled = true;


        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {

            var res = await model.SaveData();

            if (model.isNewAccount)
            {
               Application.Current.MainPage = new MainPage();
                return;
            }
            SaveButton.Text = "Saved";
        }
    }
}