using FlighMaster.WinUI.Api;
using FlightMaster.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlighMaster.WinUI.Forms.Menus
{
    public partial class LogInForm : Form
    {

        ApiCaller api = new ApiCaller();
        public AuthenticateModel model = new AuthenticateModel();
        bool LogIn = false;

        public FlightMaster.Model.User user = new User();


        public LogInForm()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {

                errorProvider1.SetError(textBox1, "Required field!");
                return;
            }

            if (textBox2.Text == "")
            {

                errorProvider1.SetError(textBox2, "Required field!");
                return;
            }

            button1.Enabled = false;
            button1.Text = "Logging in...";
            errorProvider1.Clear();

            model.Username = textBox1.Text;
            model.Password = textBox2.Text;


            


            FlightMaster.Model.User user = await api.LogInRegister<User>(model, "Users", "Authenticate");

            if (user != null)
            {

                if (user.Role == "User")
                {
                    MessageBox.Show("Only Company Employees May Use The Aplication!", "UnAuthorized", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    button1.Enabled = true;
                    button1.Text = "Log in";
                    return;
                }


                Properties.Settings.Default.UserName = user.Username;
                Properties.Settings.Default.Role = user.Role;
                Properties.Settings.Default.Token = user.Token;

                string encoded = System.Convert.ToBase64String(user.Picture);
                Properties.Settings.Default.Picture = encoded;

                Properties.Settings.Default.Save();

                this.DialogResult = DialogResult.OK;
                LogIn = true;

                this.Close();

            }
            else
            {

                button1.Enabled = true;
                button1.Text = "Log in";
                MessageBox.Show("User not found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



        }

        private void LogInForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (LogIn)
            {
                this.DialogResult = DialogResult.OK;
                return;
            }

            this.DialogResult = DialogResult.Cancel;
        }
    }
}
