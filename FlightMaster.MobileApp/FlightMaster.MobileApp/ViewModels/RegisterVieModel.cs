using FlightMaster.MobileApp.Services;
using FlightMaster.Model.MobileModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FlightMaster.MobileApp.ViewModels
{
    public class RegisterVieModel:BaseViewModel
    {

        private ApiCaller api = new ApiCaller("");
        private UserRegistrationModel model;

        public RegisterVieModel()
        {
            this.model = new UserRegistrationModel();
        }


        private string _userName = string.Empty;
        public string _UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        private string _firstname = string.Empty;
        public string _Firstname
        {
            get { return _firstname; }
            set { SetProperty(ref _firstname, value); }
        }


        private string _lastname= string.Empty;
        public string _Lastname
        {
            get { return _lastname; }
            set { SetProperty(ref _lastname, value); }
        }


        private string _passWord1 = string.Empty;
        public string _PassWord1
        {
            get { return _passWord1; }
            set { SetProperty(ref _passWord1, value); }
        }

        private string _password2 = string.Empty;
        public string _PassWord2
        {
            get { return _password2; }
            set { SetProperty(ref _password2, value); }
        }

        internal void SetData(byte[] data)
        {

            model.Username = _userName;
            model.Password = _passWord1;
            model.FirstName = _firstname;
            model.LastName = _lastname;
            model.Picture = data;

        
            
        }

        public async Task<bool> UserNameTaken()
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("UserName", _userName);
            bool Exsists=  await api.GetQuery<bool>(data, "Users", "UserNameExsists");

            return Exsists;
        }

        public bool HasSamePasswords()
        {
            if (_PassWord1 == _password2)
                return true;
            return false;
        }

        public async Task<bool> RegisterUser()
        {

            FlightMaster.Model.User user = await api.LogInRegister<FlightMaster.Model.User>(model, "Users", "RegisterUser");

            if (user != null)
            {
                Application.Current.Properties["TOKEN"] = user.Token;
                Application.Current.Properties["ID"] = user.Id;
                Application.Current.Properties["USERNAME"]=user.Username;

                string PicString = Convert.ToBase64String(user.Picture);
                Application.Current.Properties["PICTURE"] = PicString;
                await Application.Current.SavePropertiesAsync();



                return true;
            }




            return false;
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
