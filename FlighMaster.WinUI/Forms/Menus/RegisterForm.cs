using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlighMaster.WinUI.Api;
using FlightMaster.Model.WinUIModels;

namespace FlighMaster.WinUI.Forms.Menus
{
    public partial class RegisterForm : Form
    {

        public EmployeRegisterModel EmployeRegisterModel = new EmployeRegisterModel();
        private ApiCaller api = new ApiCaller();
        bool Registered = false;
        public RegisterForm()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Select picture";
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Bitmap img = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = img;
                

                EmployeRegisterModel.Picture = ImageToByte2(img);
            }
        }

        public static byte[] ImageToByte2(Image img)
        {
            using (var stream = new MemoryStream())
            {

                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }


        private async void button2_Click(object sender, EventArgs e)
        {

            if(ValidLastName() && ValidFirstName()&& ValidatePasswords()&&Registered==false)
            {

                button2.Text = "Registering..";
                button2.Enabled = false;

                if (EmployeRegisterModel.Picture == null)
                {
                    errorProvider1.SetError(button1, "Picture is required");
                    return;
                }
                EmployeRegisterModel.FirstName = FirstNameTextBox.Text;
                EmployeRegisterModel.LastName = LastNameTextBox.Text;
                EmployeRegisterModel.Password = Password1textBox.Text;
                EmployeRegisterModel.UserName = textBox1.Text;
                

                FlightMaster.Model.User user = await api.LogInRegister<FlightMaster.Model.User>(EmployeRegisterModel, "Users", "RegisterEmployee");


                if (user != null)
                {

                    Properties.Settings.Default.UserName = user.Username;
                    Properties.Settings.Default.Role = user.Role;
                    Properties.Settings.Default.Token = user.Token;

                    string encoded = System.Convert.ToBase64String(user.Picture);
                    Properties.Settings.Default.Picture = encoded;

                    Properties.Settings.Default.Save();

                    this.DialogResult = DialogResult.OK;
                    Registered = true;
                    this.Close();

                }

            }



        }





        private void FirstNameTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidFirstName();
        }

        private bool ValidFirstName()
        {
            if (FirstNameTextBox.Text == "")
            {
                errorProvider1.SetError(FirstNameTextBox, "Field required");
                return false;
            }


            if (FirstNameTextBox.Text.Length > 20)
            {
                errorProvider1.SetError(FirstNameTextBox, "First name cant be longer than 20 characters");
                return false;
            }

            if (FirstNameTextBox.Text.Length < 2)
            {
                errorProvider1.SetError(FirstNameTextBox, "First name must be longer than 2 characters");
                return false;
            }
            errorProvider1.Clear();

            return true;
        }

        private void LastNameTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidLastName();
        }

        private bool ValidLastName()
        {
            if (LastNameTextBox.Text == "")
            {
                errorProvider1.SetError(LastNameTextBox, "Field required");
                return false;
            }


            if (LastNameTextBox.Text.Length > 20)
            {
                errorProvider1.SetError(LastNameTextBox, "First name cant be longer than 20 characters");
                return false;
            }

            if (LastNameTextBox.Text.Length < 2)
            {
                errorProvider1.SetError(LastNameTextBox, "First name must be longer than 2 characters");
                return false;
            }
            errorProvider1.Clear();

            return true;
        }


        private void Password1textBox_Validating(object sender, CancelEventArgs e)
        {
            ValidatePasswords();
        }

        private void Password2textBox_Validating(object sender, CancelEventArgs e)
        {
            ValidatePasswords();

        }

        private bool ValidatePasswords()
        {
        
            if (Password1textBox.Text != Password2textBox.Text)
            {
                errorProvider1.SetError(Password2textBox, "Password confirmation doesnt match password!");
                return false;
            }

            if (Password1textBox.Text=="" )
            {
                errorProvider1.SetError(Password1textBox, "Required field!");
                return false;
            }

            if(Password2textBox.Text == "")
            {
                errorProvider1.SetError(Password2textBox, "Required field!");
                return false;
            }

          


            if (Password1textBox.Text.Length > 20)
            {
                errorProvider1.SetError(Password1textBox, "Password cant be longer than 20 characters");
                return false;
            }

            if (Password1textBox.Text.Length < 3)
            {
                errorProvider1.SetError(Password1textBox, "Password must be longer than 6 characters");
                return false;
            }

            errorProvider1.Clear();


            return true;
        }

        private void RegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Registered)
            {
                this.DialogResult = DialogResult.OK;
                return;
            }
            this.DialogResult= DialogResult.Cancel;
            return;
        }

        private void LastNameTextBox_TextChanged(object sender, EventArgs e)
        {
            SetUsername();
        }

        private void SetUsername()
        {
            textBox1.Text = FirstNameTextBox.Text + '.' + LastNameTextBox.Text;
        }

        private void FirstNameTextBox_TextChanged(object sender, EventArgs e)
        {
            SetUsername();
        }
    }
}
