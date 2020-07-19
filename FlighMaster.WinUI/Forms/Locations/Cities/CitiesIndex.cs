using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlighMaster.WinUI.Api;
using FlightMaster.Model;

namespace FlighMaster.WinUI.Forms.Locations.Cities
{
    public partial class CitiesIndex : Form
    {
        int page = 1;
        public Country country;
        public CitiesIndex(Country SelectedCountry = null)
        {
            InitializeComponent();
            SetPageText();
            if (SelectedCountry != null)
            {
                this.country = SelectedCountry;
                SetUpByCountry(page);

            }
            else
            {
                SetUpAll(page);
            }

        }

        private void SetPageText()
        {
            toolStripLabel1.Text = "Page:" + page;
        }

        private async void SetUpAll(int currentpage)
        {
            label1.Text = "Cities";
            pictureBox1.Visible = true;
            ApiCaller api = new ApiCaller();
            List<City> cities = await api.GetPageDefault<List<City>>("Cities", currentpage, "GetPagination");
            page = (page == 1) ? 1 : ++page;
            toolStripButton2.Enabled = (page == 1) ? false : true;



            SetPageText();

            dataGridView1.DataSource = cities;
            pictureBox1.Visible = false;
        }

        private async void SetUpByCountry(int currentpage)
        {
            label1.Text = "Cities of " + country.Name;
            pictureBox1.Visible = true;
            ApiCaller api = new ApiCaller();

            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("page", currentpage);
            param.Add("search", "");
            param.Add("id", country.Id);
            List<City> cities = await api.GetQuery<List<City>>(param, "Cities", "GetPaginationSearch");
            dataGridView1.DataSource = cities;
            page = (page == 1) ? 1 : ++page;
            toolStripButton2.Enabled = (page == 1) ? false : true;
            SetPageText();

            if (cities.Count < 10)
                toolStripButton3.Enabled = false;

            pictureBox1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CitiesInsert citiesInsert = new CitiesInsert();
            var result = citiesInsert.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (country != null)
                {
                    SetUpByCountry(page);

                }
                else
                {
                    SetUpAll(page);
                }
            }
        }

        private async void toolStripButton2_Click(object sender, EventArgs e)
        {

            if (country == null)
            {
                toolStripButton3.Enabled = true;

                if (page > 1)
                {
                    pictureBox1.Visible = true;

                    --page;
                    ApiCaller api = new ApiCaller();
                    List<City> cities = await api.GetPageDefault<List<City>>("Cities", page, "GetPagination");
                    dataGridView1.DataSource = cities;
                    SetPageText();
                    pictureBox1.Visible = false;
                    toolStripButton2.Enabled = (page == 1) ? false : true;
                }
                else
                {
                    toolStripButton2.Enabled = false;
                }
            }
            else
            {
                toolStripButton3.Enabled = true;

                if (page > 1)
                {
                    pictureBox1.Visible = true;

                    --page;
                    ApiCaller api = new ApiCaller();
                    Dictionary<string, object> param = new Dictionary<string, object>();
                    param.Add("page", page);
                    param.Add("search", "");
                    param.Add("id", country.Id);

                    List<City> cities = await api.GetQuery<List<City>>(param, "Cities", "GetPaginationSearch");

                    dataGridView1.DataSource = cities;
                    SetPageText();
                    pictureBox1.Visible = false;
                    toolStripButton2.Enabled = (page == 1) ? false : true;
                }
                else
                {
                    toolStripButton2.Enabled = false;
                }

            }






        }

        private async void toolStripButton3_Click(object sender, EventArgs e)
        {


            if (country == null)
            {

                toolStripButton2.Enabled = true;

                ++page;
                pictureBox1.Visible = true;
                ApiCaller api = new ApiCaller();
                List<City> cities = await api.GetPageDefault<List<City>>("Cities", page, "GetPagination");

                if (cities.Count < 10)
                {
                    toolStripButton3.Enabled = false;
                    dataGridView1.DataSource = cities;
                    SetPageText();

                }
                else
                {
                    dataGridView1.DataSource = cities;
                    pictureBox1.Visible = false;
                    SetPageText();
                }
                pictureBox1.Visible = false;
            }
            else
            {


                pictureBox1.Visible = true;

                ++page;
                ApiCaller api = new ApiCaller();
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("page", page);
                param.Add("search", "");
                param.Add("id", country.Id);
                List<City> cities = await api.GetQuery<List<City>>(param, "Cities", "GetPaginationSearch");

                if (cities.Count < 10)
                {
                    toolStripButton3.Enabled = false;
                    dataGridView1.DataSource = cities;

                    SetPageText();

                }
                else
                {
                    dataGridView1.DataSource = cities;
                    pictureBox1.Visible = false;
                    SetPageText();
                }
                pictureBox1.Visible = false;

                SetPageText();
                pictureBox1.Visible = false;
                toolStripButton2.Enabled = (page == 1) ? false : true;


            }




        }

       
    }
}
