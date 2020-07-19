using FlightMaster.MobileApp.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FlightMaster.MobileApp.ViewModels;

namespace FlightMaster.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {

        private RegisterVieModel model;


        private byte[] PictureData;
        public RegisterPage()
        {
            InitializeComponent();

            BindingContext = model = new RegisterVieModel();
            var embeddedImage = new Image
            {
                Source = ImageSource.FromResource(
        "FlightMaster.MobileApp.register_icon_default.png",
        typeof(RegisterPage).GetTypeInfo().Assembly
      )
            };


            image.Source = embeddedImage.Source;
            

        }

        private async void PictureSelectClick(object sender, EventArgs e)
        {
            (sender as Button).IsEnabled = false;

            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();


    

            PictureData = ReadFully(stream);
            SetPicture();

            (sender as Button).IsEnabled = true;
        }

        private void SetPicture()
        {

            Stream stream = new MemoryStream(PictureData);
            image.Source = ImageSource.FromStream(() => stream);
        }

        private async void RegisterClick(object sender, EventArgs e)
        {


            //Check has password

            if (model._Firstname == "")
            {
                ValidationLabel.Text = "Firstname required";
                ValidationLabel.Opacity = 0;
                await ValidationLabel.FadeTo(1, 500, Easing.SpringIn);

                return;
            }
            if (model._Lastname == "")
            {
                ValidationLabel.Text = "Lastname required";
                ValidationLabel.Opacity = 0;
                await ValidationLabel.FadeTo(1, 500, Easing.SpringIn);

                return;
            }

            if (model._Firstname.Length<3)
            {
                ValidationLabel.Text = "Firstname requires atleast 3 characters";
                ValidationLabel.Opacity = 0;
                await ValidationLabel.FadeTo(1, 500, Easing.SpringIn);

                return;
            }
            if (model._Lastname.Length < 3)
            {
                ValidationLabel.Text = "Lastname requires atleast 3 characters";
                ValidationLabel.Opacity = 0;
                await ValidationLabel.FadeTo(1, 500, Easing.SpringIn);

                return;
            }

            if (model._PassWord1.Length <3)
            {
                ValidationLabel.Text = "Password requires atleast 6 characters";
                ValidationLabel.Opacity = 0;
                await ValidationLabel.FadeTo(1, 500, Easing.SpringIn);

                return;
            }

            if (model._PassWord2.Length < 3)
            {
                ValidationLabel.Text = "Password confirmation requires atleast 6 characters";
                ValidationLabel.Opacity = 0;
                await ValidationLabel.FadeTo(1, 500, Easing.SpringIn);

                return;
            }

            if (!model.HasSamePasswords())
            {
                ValidationLabel.Text= "Passwords need to match!";
                ValidationLabel.Opacity = 0;
                await ValidationLabel.FadeTo(1, 500, Easing.SpringIn);

                return;
            }

        

            if (PictureData == null)
            {
                ValidationLabel.Text = "Profile picture required";
                ValidationLabel.Opacity = 0;
                await ValidationLabel.FadeTo(1, 500, Easing.SpringIn);

                return;
            }
            model.SetData(PictureData);




            if (model._UserName == "")
            {
                ValidationLabel.Text = "Username required";
                ValidationLabel.Opacity = 0;
                await ValidationLabel.FadeTo(1, 500, Easing.SpringIn);

                return;
            }
            if (model._UserName.Length<6)
            {
                ValidationLabel.Text = "Username requires atleast 6 characters";
                ValidationLabel.Opacity = 0;
                await ValidationLabel.FadeTo(1, 500, Easing.SpringIn);

                return;
            }

            bool exsists = await model.UserNameTaken();

            if (exsists == true)
            {
                ValidationLabel.Text = "Username allready taken";
                ValidationLabel.Opacity = 0;
                await ValidationLabel.FadeTo(1, 500, Easing.SpringIn);
                return;
            }


            var res= await model.RegisterUser();

            if (res)
            {

                //await DisplayAlert("SUCCES", "da", "da");
                await Navigation.PushAsync(new RegistrationUserPreferencViews.UserCity(true));
            }


        }


        public static byte[] ReadFully(Stream input)
        {

            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }

        }

    }
}