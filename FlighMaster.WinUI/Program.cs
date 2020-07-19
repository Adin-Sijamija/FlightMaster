using FlighMaster.WinUI.Forms.Companies;
using FlighMaster.WinUI.Forms.Flight;
using FlighMaster.WinUI.Forms.Locations.Airfields;
using FlighMaster.WinUI.Forms.Locations.Cities;
using FlighMaster.WinUI.Forms.Locations.Countries;
using FlighMaster.WinUI.Forms.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlighMaster.WinUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainMenuForm());
            Application.Run(new MainPageForm());
            //Application.Run(new FlightInsertForm());


        }
    }
}
