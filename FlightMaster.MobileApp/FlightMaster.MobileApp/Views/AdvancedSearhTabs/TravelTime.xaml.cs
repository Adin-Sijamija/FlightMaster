using FlightMaster.MobileApp.ViewModels.AdvancedSearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlightMaster.MobileApp.Views.AdvancedSearhTabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TravelTime : ContentPage
    {

        TravelTimeViewModel model;
        public TravelTime(TravelTimeViewModel travel)
        {
            InitializeComponent();
            model = travel;
            model.MaxDate = DateTime.Now;
            model.MinDate= DateTime.Now;
            AddTriggers();
        }

        private void AddTriggers()
        {
            MinDatePicker.PropertyChanged += MinDatePicker_PropertyChanged;
            MaxDatePicker.PropertyChanged += MaxDatePicker_PropertyChanged;
        }

        private void MinDatePicker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            model.MinDate = MinDatePicker.Date;
        }


        private void MaxDatePicker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            model.MaxDate= MaxDatePicker.Date;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var parent = (AdvancedSearch)this.Parent;
            parent.SetSearchFilter();
        }
    }
}