using FlightMaster.MobileApp.Services;
using FlightMaster.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlightMaster.MobileApp.ViewModels
{
    class LogInViewModel : BaseViewModel
    {

        public AuthenticateModel authenticateModel { get; set; }
        public ApiCaller api = new ApiCaller("");
        public Command TryLogIn { get; set; }


        public string _userName = string.Empty;
        public string _UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }


        public string _passWord = string.Empty;
        public string _PassWord
        {
            get { return _passWord; }
            set { SetProperty(ref _passWord, value); }
        }


        private bool IsValidUser = false;
        private string Token = string.Empty;
        private int UserId = 0;
        private byte[] ProfilePicure;
        public LogInViewModel()
        {
            TryLogIn = new Command(async () => await LoginIn());
            authenticateModel = new AuthenticateModel();
        }

        private async Task LoginIn()
        {


            authenticateModel.Username = _userName;
            authenticateModel.Password = _passWord;
            try
            {
                User user = await api.LogInRegister<User>(authenticateModel, "Users", "Authenticate");
                if (user != null)
                {
                    IsValidUser = true;
                    Token = user.Token;
                    UserId = user.Id;
                    ProfilePicure = user.Picture;
                }

            }
            catch (Exception)
            {

            }

        }

        public async Task<bool> LoggedInAsync()
        {
           await LoginIn();

            if (IsValidUser)
            {
                Application.Current.Properties["TOKEN"] = Token;
                Application.Current.Properties["ID"] = UserId;
                Application.Current.Properties["USERNAME"] = _userName;

                string base64 = Convert.ToBase64String(ProfilePicure);
                Application.Current.Properties["PICTURE"] = base64;

                await Application.Current.SavePropertiesAsync();
                return true;
            }


            return false;
        }











    }
}
