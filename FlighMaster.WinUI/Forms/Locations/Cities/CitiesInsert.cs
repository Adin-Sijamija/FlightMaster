using FlighMaster.WinUI.Api;
using FlighMaster.WinUI.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlighMaster.WinUI.Forms.Locations.Cities
{
    public partial class CitiesInsert : Form
    {
        public CitiesInsert()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Yes;
            LoadCountries();

        }

        private async void LoadCountries()
        {
            ApiCaller api = new ApiCaller();
            List<FlightMaster.Model.Country> countries = await api.GetAll<List<FlightMaster.Model.Country>>("Countries");
            comboBox1.DataSource = countries;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            validatetextbox1();
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            validatetextbox2();

        }

        private bool validatetextbox1()
        {
            if (textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "Required field");
                return false;
            }
            if (textBox1.Text.Length < 3)
            {
                errorProvider1.SetError(textBox1, "Must be atleast 3 characters long");

                return false;
            }

            if (textBox1.Text.Length > 30)
            {
                errorProvider1.SetError(textBox1, "Must be less than 30 characters long");

                return false;
            }
            return true;

        }

       

        private bool validatetextbox2()
        {

            if (textBox2.Text == "")
            {
                errorProvider1.SetError(textBox2, "Required field");
                return false;
            }
            if (textBox2.Text.Length < 2)
            {
                errorProvider1.SetError(textBox2, "Must be atleast 2 characters long");

                return false;
            }

            if (textBox2.Text.Length > 4)
            {
                errorProvider1.SetError(textBox2, "Must be less than 4 characters long");

                return false;
            }
            return true;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (validatetextbox1() && validatetextbox2())
            {

                FlightMaster.Model.City city = new FlightMaster.Model.City();
                city.CountryId = (int)comboBox1.SelectedValue;
                city.Name = textBox1.Text;
                city.ShortName = textBox2.Text;

                FlightMaster.Model.City created =await new ApiCaller().Insert<FlightMaster.Model.City>(city, "Cities");
                if (created != null)
                {
                    PopUp up = new PopUp(PopUp.PopUpType.Addtion, "Citie successfully added!");
                    up.Show();
                    ClearData();
                }
                this.DialogResult = DialogResult.Yes;

            }

        }

        private void ClearData()
        {
            textBox1.Text="";
            textBox2.Text="";
            comboBox1.SelectedIndex = 0;
        }


        private void CitiesInsert_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }

}
