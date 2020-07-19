using FlighMaster.WinUI.Api;
using FlightMaster.Model;
using FlightMaster.Model.WinUIModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlighMaster.WinUI.Forms.Locations.Airfields
{
    public partial class AirfieldIndex : Form
    {
        ApiCaller api = new ApiCaller();
        public AirfieldIndex()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            UpdateGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AirfieldInsert frm = new AirfieldInsert();
            var res = frm.ShowDialog();

            if (res == DialogResult.OK)
            {
                UpdateGrid();
            }
        }

        private async void UpdateGrid()
        {
            pictureBox1.Visible = true;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("CountryId", -1);
            param.Add("CityId", -1);
            var airfleids = await api.GetQuery<List<AirfieldInfoDTO>>(param, "Airfield", "GetAirfieldSearchs");
            dataGridView1.DataSource = airfleids;


            List<Country> countries = await api.GetAll<List<Country>>("Countries");
            countries.Insert(0, new Country() { Id = -1, Name = "All" });
            CountryComboBox.DisplayMember = "Name";
            CountryComboBox.ValueMember = "Id";
            CountryComboBox.DataSource = countries;


            List<City> cities = new List<City>();
            cities.Add(new City() { Id = -1, Name = "All" });
            CityComboBox.DisplayMember = "Name";
            CityComboBox.ValueMember = "Id";
            CityComboBox.DataSource = cities;

       

            CountryComboBox.SelectedIndexChanged += new EventHandler(SelectedCountryChange);


            pictureBox1.Visible = false;

        }


        private async void SelectedCountryChange(object sender, EventArgs e)
        {

            int id = CountryComboBox.SelectedValue != null ? (int)CountryComboBox.SelectedValue : 0;
            if (id > 0)
            {
                List<City> cities = await api.GetAllByID<List<City>>("Cities", id, "CountriesCities");
                if (cities.Count > 1)
                    cities.Insert(0, new City() { Id = -1, Name = "All" });

                CityComboBox.DisplayMember = "Name";
                CityComboBox.ValueMember = "Id";
                CityComboBox.DataSource = cities;
            }
            else
            {
                List<City> cities = new List<City>();
                cities.Add(new City() { Id = -1, Name = "All" });
                CityComboBox.DataSource = cities;

            }
        }

        private async void SearchButton_Click(object sender, EventArgs e)
        {

            pictureBox1.Visible = true;
            Dictionary<string, object> param = new Dictionary<string, object>();

            int CountryId =(int) CountryComboBox.SelectedValue;
            int CityId=(int)CityComboBox.SelectedValue;

            param.Add("CountryId", CountryId);
            param.Add("CityId", CityId);
            var airfleids = await api.GetQuery<List<AirfieldInfoDTO>>(param, "Airfield", "GetAirfieldSearchs");
            dataGridView1.DataSource = airfleids;
            pictureBox1.Visible = false;

        }
    }
}
