using FlightMaster.MobileApp.Models;
using FlightMaster.MobileApp.ViewModels.JourneyAdditionViewModels;
using FlightMaster.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlightMaster.MobileApp.Views.JourneyInfoTabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlightInfoPage : ContentPage
    {

        public JourneyFlightInfoViewModel model;
        public FlightInfoPage(Model.Flight flight)
        {
            InitializeComponent();
            BindingContext = model = new JourneyFlightInfoViewModel(flight);
            LoadExtraData();
        }

        private async void LoadExtraData()
        {
            await model.LoadData();
            CompanyLogoImage.Source = model.CompanyLogoImage;
            CompanyLogoImage.IsVisible = true;

            //TicketData


            foreach (var item in model.ticketLuxuriesInfos)
            {


                //set TableData
                var mainLayout = new StackLayout() { Padding = 10, Margin = 10 };

                //TicketData
                var TicketTitel = new StackLayout() { HorizontalOptions = LayoutOptions.CenterAndExpand };
                var TicketTitelLabel = new Label() { Text = "Ticket Type: " + item.Name };
                var TicketId = new Label() { Text = item.Id.ToString(),IsVisible=false };
                TicketTitel.Children.Add(TicketTitelLabel);
                TicketTitel.Children.Add(TicketId);

                //TicketNumbers

                var TicketNumbersStack = new StackLayout() { HorizontalOptions = LayoutOptions.CenterAndExpand,Orientation=StackOrientation.Horizontal };
                var TickPrice = new Label() { Text = "Price:: " + item.Price+ " $" };
                var TickAvail= new Label() { Text = "Current Tickets: "};
                var TickAvail2= new Label() { Text =  item.CurrentTickets.ToString() };
                var TickTotal= new Label() { Text = "of "};
                var TickTotal2 = new Label() { Text = item.MaxTickets.ToString()};
                var TickPrice2 = new Label() { Text = item.Price.ToString(),IsVisible=false};

                TicketNumbersStack.Children.Add(TickPrice);
                TicketNumbersStack.Children.Add(TickAvail);
                TicketNumbersStack.Children.Add(TickAvail2);
                TicketNumbersStack.Children.Add(TickTotal);
                TicketNumbersStack.Children.Add(TickTotal2);
                TicketNumbersStack.Children.Add(TickPrice2);

                //YourTickets Option
                var YourTickTitelStack = new StackLayout() { HorizontalOptions = LayoutOptions.CenterAndExpand };
                var YourTickTitelLabel = new Label() { Text = "Your Tickets:"  };
                YourTickTitelStack.Children.Add(YourTickTitelLabel);

                //OptionButtons
                var OptionsStack = new StackLayout() { HorizontalOptions = LayoutOptions.CenterAndExpand,Orientation = StackOrientation.Horizontal };
                var MinusButton = new Button() { Text = "-" };
                MinusButton.Clicked += MinusButton_Clicked;
                var TicketEntry = new Label() { Text = "0", HorizontalTextAlignment = TextAlignment.Center };
                var PlusButton = new Button() { Text = "+" };
                PlusButton.Clicked += PlusButton_Clicked;
                OptionsStack.Children.Add(MinusButton);
                OptionsStack.Children.Add(TicketEntry);
                OptionsStack.Children.Add(PlusButton);




                ScrollView scrool = new ScrollView()
                {
                    HorizontalOptions = LayoutOptions.Fill,
                    Orientation = ScrollOrientation.Horizontal,

                };
                var ScrollStack = new StackLayout();
                var ScrollMainStack= new StackLayout() { Margin = 3, Padding = 3, Orientation = StackOrientation.Horizontal };

                foreach (var luxs in item.TicketLuxuries)
                {

                    var ScrollStacktemp = new StackLayout() { Margin = 4, Padding = 4, Orientation = StackOrientation.Horizontal };
                    Image img = new Image()
                    {
                        HeightRequest = 40,
                        WidthRequest = 30,
                        Source= ImageSource.FromStream(() => new MemoryStream(luxs.Icon))

                    };

                    var LuxName = new Label() { Text = luxs.Name};
                    ScrollStacktemp.Children.Add(img);
                    ScrollStacktemp.Children.Add(LuxName);
                    ScrollMainStack.Children.Add(ScrollStacktemp);

                }



                scrool.Content = ScrollMainStack;
                if (item.TicketLuxuries.Count>0)
                {
                    var lbl = new Label() { Text = "Ticket Has Luxuries:" };
                    ScrollStack.Children.Add(lbl);
                }
                    ScrollStack.Children.Add(scrool);


                mainLayout.Children.Add(TicketTitel);
                mainLayout.Children.Add(TicketNumbersStack);
                mainLayout.Children.Add(YourTickTitelStack);
                mainLayout.Children.Add(OptionsStack);
                mainLayout.Children.Add(ScrollStack);

                TicketData.Add(new ViewCell() { View = mainLayout });

            }

        }

        private void PlusButton_Clicked(object sender, EventArgs e)
        {

            Button button = (Button)sender;
            //
            StackLayout MainLayout = (StackLayout)button.Parent.Parent;
            StackLayout titelLayout = (StackLayout)MainLayout.Children[0];
            Label LabId = (Label)titelLayout.Children[1]; int id = int.Parse(LabId.Text);
            StackLayout CountLayout = (StackLayout)MainLayout.Children[1];
            Label curTcikLab = (Label)CountLayout.Children[2]; int curTcikid = int.Parse(curTcikLab.Text);
            Label MaxtickLab = (Label)CountLayout.Children[4]; int Maxtickid = int.Parse(MaxtickLab.Text);
            Label TickPriceLabel = (Label)CountLayout.Children[5]; double TickPrice = double.Parse(TickPriceLabel.Text);
            StackLayout EntryLayout = (StackLayout)button.Parent;
            Label NewCounTLab = (Label)EntryLayout.Children[1]; int NewCounTInt = int.Parse(NewCounTLab.Text)+1;




            if (NewCounTInt + curTcikid > Maxtickid)
            {
                NewCounTLab.Text = (NewCounTInt - 1).ToString();
                NewCounTInt--;
                return;
            }



            FlightTicketsTobeAdded flightTickets = model.UserTickets.Find(x => x.FlightTicketTypeID == id);

            if (flightTickets == null)
            {
                flightTickets = new FlightTicketsTobeAdded()
                {
                    FlightId = model.flight.Id,
                    FlightTicketTypeID = id,
                    TicketCount = NewCounTInt,
                    Price=TickPrice

                };
                model.UserTickets.Add(flightTickets);
                NewCounTLab.Text = (NewCounTInt).ToString();
                UpdateJourneyTab();
                return;
            }
            else
            {

                foreach (var item in model.UserTickets)
                {
                    if (item.FlightTicketTypeID == id)
                    {
                        item.TicketCount = item.TicketCount + 1;
                        break;
                    }
                }

                NewCounTLab.Text = (NewCounTInt).ToString();
                UpdateJourneyTab();

            }


        }

        private void MinusButton_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            //
            StackLayout MainLayout = (StackLayout)button.Parent.Parent;
            StackLayout titelLayout = (StackLayout)MainLayout.Children[0];
            Label LabId = (Label)titelLayout.Children[1]; int id = int.Parse(LabId.Text);
            StackLayout CountLayout = (StackLayout)MainLayout.Children[1];
            Label curTcikLab = (Label)CountLayout.Children[2]; int curTcikid = int.Parse(curTcikLab.Text);
            Label MaxtickLab = (Label)CountLayout.Children[4]; int Maxtickid = int.Parse(MaxtickLab.Text);
            Label TickPriceLabel = (Label)CountLayout.Children[5]; double TickPrice = double.Parse(TickPriceLabel.Text);
            StackLayout EntryLayout = (StackLayout)button.Parent;
            Label NewCounTLab = (Label)EntryLayout.Children[1]; int NewCounTInt = int.Parse(NewCounTLab.Text)-1;


            if (NewCounTInt < 0)
            {
                NewCounTLab.Text = "0";
                return;
            }

            FlightTicketsTobeAdded flightTickets = model.UserTickets.Find(x => x.FlightTicketTypeID == id);
            //if not add

            if (flightTickets == null)
            {
              
                UpdateJourneyTab();
                return;
            }
            else
            {
                bool toDelete = false;
                foreach (var item in model.UserTickets)
                {
                    if (item.FlightTicketTypeID == id)
                    {
                        item.TicketCount = item.TicketCount -1;

                        if (item.TicketCount == 0)
                            toDelete = true;

                        NewCounTLab.Text = item.TicketCount.ToString();

                        break;
                    }
                }


                if (toDelete)
                {
                    FlightTicketsTobeAdded toBeRemoved = model.UserTickets.Find(x => x.FlightTicketTypeID == id);
                    model.UserTickets.Remove(toBeRemoved);
                    NewCounTLab.Text = "0";

                }
                UpdateJourneyTab();

            }



        }

        private void UpdateJourneyTab()
        {

            JourneyAdditionTabPage main = (JourneyAdditionTabPage)this.Parent;
            main.UpdateJourneyPrice();

        }
    }
}