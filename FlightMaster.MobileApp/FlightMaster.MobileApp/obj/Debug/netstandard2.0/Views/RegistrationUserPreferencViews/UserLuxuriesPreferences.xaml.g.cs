//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Xamarin.Forms.Xaml.XamlResourceIdAttribute("FlightMaster.MobileApp.Views.RegistrationUserPreferencViews.UserLuxuriesPreferenc" +
    "es.xaml", "Views/RegistrationUserPreferencViews/UserLuxuriesPreferences.xaml", typeof(global::FlightMaster.MobileApp.Views.RegistrationUserPreferencViews.UserLuxuriesPreferences))]

namespace FlightMaster.MobileApp.Views.RegistrationUserPreferencViews {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("Views\\RegistrationUserPreferencViews\\UserLuxuriesPreferences.xaml")]
    public partial class UserLuxuriesPreferences : global::Xamarin.Forms.ContentPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.ActivityIndicator LuxuriesLoadIndicator;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.TableView Maintabel;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.TableSection TabelSection;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.Button SaveButton;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(UserLuxuriesPreferences));
            LuxuriesLoadIndicator = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.ActivityIndicator>(this, "LuxuriesLoadIndicator");
            Maintabel = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.TableView>(this, "Maintabel");
            TabelSection = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.TableSection>(this, "TabelSection");
            SaveButton = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Button>(this, "SaveButton");
        }
    }
}
