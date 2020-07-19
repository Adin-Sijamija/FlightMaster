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
    public partial class Luxuries : ContentPage
    {

        LuxuriesViewModel model;
        public Luxuries(LuxuriesViewModel luxuries)
        {
            InitializeComponent();
            model = luxuries;
            SetTabelData();
        }

        private async void SetTabelData()
        {
            var res = await model.LoadData();

            foreach (var item in model.LuxuriesData)
            {

                var layout = new StackLayout() { Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.Center };
                layout.Children.Add(new Image() { Source = item.Icon, Aspect=Aspect.AspectFit ,HeightRequest=50,WidthRequest=40 });
                layout.Children.Add(new Label() { Text = item.Name });
                layout.Children.Add(new Label() { Text = item.Id.ToString(),IsVisible=false });
                CheckBox check = new CheckBox() { IsChecked = false };
                check.CheckedChanged += Check_CheckedChanged;
                layout.Children.Add(check);

                TabelSelection.Add(new ViewCell() { View = layout });
            }



        }

        private  void Check_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            StackLayout cell = (StackLayout)checkBox.Parent;
            Label label = (Label)cell.Children[2];
            int id = int.Parse(label.Text);

            model.SetIds(id);

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var parent = (AdvancedSearch)this.Parent;
            parent.SetSearchFilter();
        }
    }
}