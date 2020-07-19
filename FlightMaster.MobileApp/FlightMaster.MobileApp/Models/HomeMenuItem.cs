using System;
using System.Collections.Generic;
using System.Text;

namespace FlightMaster.MobileApp.Models
{
    public enum MenuItemType
    {
        StartPage=1,
        Search,
        Journeys,
        City,
        Tickets,
        Luxuries
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
