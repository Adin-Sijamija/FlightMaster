using FlighMaster.WinUI.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlightMaster.Model;
using FlighMaster.WinUI.Style;

namespace FlighMaster.WinUI.Forms.Locations.Airfields
{
    public partial class AirfieldInsert : Form
    {
        
        public AirfieldInsert()
        {
            InitializeComponent();
            SetUpCOmboBoxes();
        }

        private async void SetUpCOmboBoxes()
        {
            button1.Enabled = false;
            label5.Visible = true;

            ApiCaller api = new ApiCaller();
            List<Country> countries = await api.GetAll<List<Country>>("Countries");
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember= "Id";
            comboBox1.DataSource = countries;
            label5.Visible = false;


            label6.Visible = true;

            List<City> cities = await api.GetAllByID<List<City>>("Cities",countries.First().Id,"CountriesCities");
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Id";
            comboBox2.DataSource = cities;
            label6.Visible = false;

            comboBox1.SelectedIndexChanged += new EventHandler(TestHandler);
            button1.Enabled = true;

        }

        private async void TestHandler(object sender, EventArgs e)
        {
            label6.Visible = true;

            ApiCaller api = new ApiCaller();
            int id = (int)comboBox1.SelectedValue;

            List<City> cities = await api.GetAllByID<List<City>>("Cities", id, "CountriesCities");
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Id";
            comboBox2.DataSource = cities;
            label6.Visible = false;

        }



        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            IsValid();
        }

        private bool IsValid()
        {
            if (textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "Required field!");
                return false;

            }

            if (textBox1.Text.Length < 3)
            {
                errorProvider1.SetError(textBox1, "Name too short!");
                return false;

            }

            if (textBox1.Text.Length > 40)
            {
                errorProvider1.SetError(textBox1, "Name too long!");
                return false;
            }
            return true;

        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            if (IsValid())
            {

                Airfield airfield = new Airfield();

                airfield.Name = textBox1.Text;
                airfield.CityId = (int)comboBox2.SelectedValue;
                ApiCaller api = new ApiCaller();
                Airfield airfield1 = await api.Insert<Airfield>(airfield,"Airfield");

                if (airfield1!=null)
                {
                    PopUp up = new PopUp(PopUp.PopUpType.Addtion, "Airfield " + airfield1.Name + " successfully added!");
                    up.Show();
                    textBox1.Text = null;

                }
            }
        }

      
    }
}
