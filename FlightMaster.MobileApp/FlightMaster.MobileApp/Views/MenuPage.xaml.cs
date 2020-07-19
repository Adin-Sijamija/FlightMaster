using FlightMaster.MobileApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlightMaster.MobileApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.StartPage, Title="Recommended Flights" },
                new HomeMenuItem {Id = MenuItemType.Search, Title="Advanced search" },
                new HomeMenuItem {Id = MenuItemType.Journeys, Title="My Journeys" },
                new HomeMenuItem {Id = MenuItemType.City, Title="My City" },
                new HomeMenuItem {Id = MenuItemType.Tickets, Title="Ticket Preferences" },
                new HomeMenuItem {Id = MenuItemType.Luxuries, Title="Luxuries Preferences" }
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };

            string username =(string) Application.Current.Properties["USERNAME"];
            string picture =(string) Application.Current.Properties["PICTURE"];
            byte[] bytes = Convert.FromBase64String(picture);

            UserName.Text = username;
            Stream stream = new MemoryStream(bytes);

            UserIcon.Source = ImageSource.FromStream(() => stream);

        }
    }
}