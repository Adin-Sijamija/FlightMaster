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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlighMaster.WinUI.Forms.Flight
{
    public partial class FlightIndex : Form
    {

        ApiCaller api = new ApiCaller();
        FlightSearchModel flightSearchModel = new FlightSearchModel() { page = 1 };

        int CurrentPage = 1;

        bool FilterChange = false;

        bool IsLoaded = false;
        public enum FlightStatus
        {
            All = -1,
            OnTime = 0,
            LateDeparture,
            LateArrival,
            DepartureDelayed,
            PostPoned,
            Rescheduled,
            Canceled,

        }

        public enum OrderByEnum
        {
            DateAscending = 1,
            DateDescending,
            TotalTicketsDescending,
            TotalTicketsAscending,
            TicketsSoldDescending,
            TicketsSoldAscending

        }

        public FlightIndex()
        {
            InitializeComponent();
            button1.Enabled = false;
            dataGridView1.AutoGenerateColumns = false;
            SetUpSearchData();
            LoadDefaultDataAsync();
            IsLoaded = true;
            button1.Enabled = true;

        }


        private bool UpdatePage(bool lastpage = false)
        {

            PageLabel.Text = CurrentPage.ToString();

            if (CurrentPage == 1)
            {
                PreviousButton.Enabled = false;
            }
            else
            {
                PreviousButton.Enabled = true;

            }

            if (lastpage)
            {
                NextButton.Enabled = false;
            }
            else
            {
                NextButton.Enabled = Enabled;

            }
            return true;
        }

        private FlightSearchModel SetSearchModel(FlightSearchModel flightSearchModel)
        {
            flightSearchModel.DepCountryId = (int)DepCountry.SelectedValue;
            flightSearchModel.DepCityId = (int)DepCity.SelectedValue;
            flightSearchModel.DepAirfieldId = (int)DepAirfield.SelectedValue;

            flightSearchModel.ArrCountryID = (int)ArrCountry.SelectedValue;
            flightSearchModel.ArrCityId = (int)ArrCity.SelectedValue;
            flightSearchModel.ArrAirfieldID = (int)ArrAirfield.SelectedValue;

            flightSearchModel.StartDate = MinDate.Value;
            flightSearchModel.EndDate = MaxDate.Value;

            flightSearchModel.StatusId = (int)StatusComboBox.SelectedValue;
            flightSearchModel.CompanyId = (int)CompanyComboBox.SelectedValue;
            flightSearchModel.PlaneTypeId = (int)PlaneTypeComboBox.SelectedValue;

            flightSearchModel.OrderBy = (int)OrderbyComboBox.SelectedValue;
            return flightSearchModel;

        }


        private async void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            flightSearchModel.page = 1;
            CurrentPage = 1;
            flightSearchModel = SetSearchModel(flightSearchModel);
        
            List<FlightInfoClass> info = await api.GetByObject<List<FlightInfoClass>>("Flight", flightSearchModel, "GetFlightInfo");

            if (info != null)
            {
                if (info.Count > 0)
                {
                    dataGridView1.DataSource = info;
                    pictureBox1.Visible = false;
                    bool d = info.Count < 20 ? UpdatePage(true) : UpdatePage(false);
                }
                else
                {
                    dataGridView1.DataSource = null;
                    pictureBox1.Visible = false;

                }
            }

        }

        private async void PreviousButton_Click(object sender, EventArgs e)
        {


            pictureBox1.Visible = true;
            flightSearchModel.page = CurrentPage - 1;
            CurrentPage--;
            flightSearchModel = SetSearchModel(flightSearchModel);

            List<FlightInfoClass> info = await api.GetByObject<List<FlightInfoClass>>("Flight", flightSearchModel, "GetFlightInfo");

            if (info != null)
            {
                if (info.Count > 0)
                {
                    dataGridView1.DataSource = info;
                    pictureBox1.Visible = false;
                    bool d = info.Count < 20 ? UpdatePage(true) : UpdatePage(false);
                }
                else
                {
                    dataGridView1.DataSource = null;
                    pictureBox1.Visible = false;

                }
            }

        }

        private async void NextButton_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            flightSearchModel.page = CurrentPage+1;
            CurrentPage++;
            flightSearchModel = SetSearchModel(flightSearchModel);

            List<FlightInfoClass> info = await api.GetByObject<List<FlightInfoClass>>("Flight", flightSearchModel, "GetFlightInfo");

            if (info != null)
            {
                if (info.Count > 0)
                {
                    dataGridView1.DataSource = info;
                    pictureBox1.Visible = false;
                    bool d = info.Count < 20 ? UpdatePage(true) : UpdatePage(false);
                }
                else
                {
                    flightSearchModel.page = CurrentPage - 1;
                    CurrentPage--;
                    UpdatePage(true);
                    pictureBox1.Visible = false;

                }
            }



        }




        private async void LoadDefaultDataAsync()
        {
            pictureBox1.Visible = true;
            PreviousButton.Enabled = false;
            flightSearchModel.SetDefaultData();
            List<FlightInfoClass> info = await api.GetByObject<List<FlightInfoClass>>("Flight", flightSearchModel, "GetFlightInfo");
            if (info != null)
            {
                dataGridView1.DataSource = info;
                pictureBox1.Visible = false;

            }

        }


        private void SetUpSearchData()
        {
            SetUpDestinations();
            SetUpMisc();
        }

        #region Misc
        private void SetUpMisc()
        {

            SetPlaneType();
            SetUpCompany();
            SetUpStatus();

        }

        private void SetUpStatus()
        {
            StatusComboBox.DataSource = Enum.GetValues(typeof(FlightStatus));
            StatusComboBox.SelectedItem = FlightStatus.All;
            OrderbyComboBox.DataSource = Enum.GetValues(typeof(OrderByEnum));
        }

        private async void SetUpCompany()
        {
            List<Company> company = await api.GetAll<List<Company>>("Companies");
            company.Insert(0, new Company() { Id = -1, Name = "All" });
            CompanyComboBox.ValueMember = "Id";
            CompanyComboBox.DisplayMember = "Name";
            CompanyComboBox.DataSource = company;


        }

        private async void SetPlaneType()
        {
            List<PlaneType> types = await api.GetAll<List<PlaneType>>("PlaneType");
            types.Insert(0, new PlaneType() { Id = -1, Name = "All" });
            PlaneTypeComboBox.ValueMember = "Id";
            PlaneTypeComboBox.DisplayMember = "Name";
            PlaneTypeComboBox.DataSource = types;

        }
        #endregion

        #region Locations
        private void SetUpDestinations()
        {
            SetUpDepaure();
            SetUpArrival();
        }

        private async void SetUpArrival()
        {
            EnableArrivalBoxes(false);

            List<Country> countries = await api.GetAll<List<Country>>("Countries");
            countries.Insert(0, new Country() { Id = -1, Name = "All" });
            ArrCountry.DisplayMember = "Name";
            ArrCountry.ValueMember = "Id";
            ArrCountry.DataSource = countries;




            List<City> cities = new List<City>();
            cities.Insert(0, new City() { Id = -1, Name = "All" });
            ArrCity.DisplayMember = "Name";
            ArrCity.ValueMember = "Id";
            ArrCity.DataSource = cities;


            List<Airfield> airfields = new List<Airfield>();
            airfields.Insert(0, new Airfield() { Id = -1, Name = "All" });
            ArrAirfield.DisplayMember = "Name";
            ArrAirfield.ValueMember = "Id";
            ArrAirfield.DataSource = airfields;


            ArrCountry.SelectedIndexChanged += new EventHandler(UpdateArrivalCity);
            ArrCity.SelectedIndexChanged += new EventHandler(UpdateArrivalAirfields);
            EnableArrivalBoxes(true);

        }

        private void EnableArrivalBoxes(bool v)
        {
            ArrCountry.Enabled = v;
            ArrAirfield.Enabled = v;
            ArrCity.Enabled = v;
        }

        private async void UpdateArrivalAirfields(object sender, EventArgs e)
        {
            int id = ArrCity.SelectedValue != null ? (int)ArrCity.SelectedValue : 0;
            if (id > 0)
            {


                List<Airfield> airfields = await api.GetAllByID<List<Airfield>>("Airfield", id, "CityAirfields");

                if (airfields.Count > 1)
                    airfields.Insert(0, new Airfield() { Id = -1, Name = "All" });

                ArrAirfield.DisplayMember = "Name";
                ArrAirfield.ValueMember = "Id";
                ArrAirfield.DataSource = airfields;
            }
            else
            {
                // ArrAirfield.DataSource = null;
                List<Airfield> airfields = new List<Airfield>();
                airfields.Add(new Airfield() { Id = -1, Name = "All" });

                ArrAirfield.DataSource = airfields;

            }



        }

        private async void UpdateArrivalCity(object sender, EventArgs e)
        {

            int id = ArrCountry.SelectedValue != null ? (int)ArrCountry.SelectedValue : 0;
            if (id > 0)
            {
                List<City> cities = await api.GetAllByID<List<City>>("Cities", id, "CountriesCities");
                if (cities.Count > 1)
                    cities.Insert(0, new City() { Id = -1, Name = "All" });

                ArrCity.DisplayMember = "Name";
                ArrCity.ValueMember = "Id";
                ArrCity.DataSource = cities;
            }
            else
            {
                List<City> cities = new List<City>();
                cities.Add(new City() { Id = -1, Name = "All" });
                ArrCity.DataSource = cities;

            }
        }

        private async void SetUpDepaure()
        {
            SetDepartureComboBoxEnabelStatus(false);

            List<Country> countries = await api.GetAll<List<Country>>("Countries");
            countries.Insert(0, new Country() { Id = -1, Name = "All" });
            DepCountry.DisplayMember = "Name";
            DepCountry.ValueMember = "Id";
            DepCountry.DataSource = countries;


            List<City> cities = new List<City>();
            cities.Insert(0, new City() { Id = -1, Name = "All" });
            DepCity.DisplayMember = "Name";
            DepCity.ValueMember = "Id";
            DepCity.DataSource = cities;



            List<Airfield> airfields = new List<Airfield>();
            airfields.Insert(0, new Airfield() { Id = -1, Name = "All" });
            DepAirfield.DisplayMember = "Name";
            DepAirfield.ValueMember = "Id";
            DepAirfield.DataSource = airfields;


            DepCountry.SelectedIndexChanged += new EventHandler(UpdateDepCities);
            DepCity.SelectedIndexChanged += new EventHandler(UpdateDepAirfields);

            SetDepartureComboBoxEnabelStatus(true);



        }

        private void SetDepartureComboBoxEnabelStatus(bool v)
        {
            DepCountry.Enabled = v;
            DepCity.Enabled = v;
            DepAirfield.Enabled = v;
        }

        private async void UpdateDepCities(object sender, EventArgs e)
        {



            int id = DepCountry.SelectedValue != null ? (int)DepCountry.SelectedValue : 0;
            if (id > 0)
            {
                List<City> cities = await api.GetAllByID<List<City>>("Cities", id, "CountriesCities");
                if (cities.Count > 1)
                    cities.Insert(0, new City() { Id = -1, Name = "All" });

                DepCity.DisplayMember = "Name";
                DepCity.ValueMember = "Id";
                DepCity.DataSource = cities;
            }
            else
            {
                List<City> cities = new List<City>();
                cities.Insert(0, new City() { Id = -1, Name = "All" });
                DepCity.DataSource = cities;

            }



        }


        private async void UpdateDepAirfields(object sender, EventArgs e)
        {

            int id = DepCity.SelectedValue != null ? (int)DepCity.SelectedValue : 0;
            if (id > 0)
            {


                List<Airfield> airfields = await api.GetAllByID<List<Airfield>>("Airfield", id, "CityAirfields");

                if (airfields.Count > 1)
                    airfields.Insert(0, new Airfield() { Id = -1, Name = "All" });

                DepAirfield.DisplayMember = "Name";
                DepAirfield.ValueMember = "Id";
                DepAirfield.DataSource = airfields;
            }
            else
            {
                List<Airfield> airfields = new List<Airfield>();
                airfields.Add(new Airfield() { Id = -1, Name = "All" });

                DepAirfield.DataSource = airfields;

            }






        }


        #endregion




        private void MinDate_ValueChanged(object sender, EventArgs e)
        {
            if (MinDate.Value == MaxDate.Value)
            {
                flightSearchModel.DateSearch = false;
                return;

            }

            flightSearchModel.DateSearch = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            flightSearchModel.SetDefaultData();
            CurrentPage = 1;
            SetUpSearchData();
            LoadDefaultDataAsync();

        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            var senderGrid = (DataGridView)sender;


            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {

                DataGridViewCell cell = senderGrid.CurrentCell;

                if (cell.EditedFormattedValue.ToString() == "Status")
                {
                    int id = (int)senderGrid.Rows[e.RowIndex].Cells[0].Value;
                    FlightStatusForm  frm = new FlightStatusForm(id);
                    var res = frm.ShowDialog();

                    if (res == DialogResult.OK)
                    {

                        ReFreshData();
                    }


                }
                if (cell.EditedFormattedValue.ToString() == "Tickets")
                {
                    int id = (int)senderGrid.Rows[e.RowIndex].Cells[0].Value;
                    FlightTicketsDiscount frm = new FlightTicketsDiscount(id);
                    frm.Show();
                    return;

                }
            }

        }

        private async void ReFreshData()
        {
            pictureBox1.Visible = true;
            flightSearchModel.page = CurrentPage;
            flightSearchModel = SetSearchModel(flightSearchModel);

            List<FlightInfoClass> info = await api.GetByObject<List<FlightInfoClass>>("Flight", flightSearchModel, "GetFlightInfo");

            if (info != null)
            {
                if (info.Count > 0)
                {
                    dataGridView1.DataSource = info;
                    pictureBox1.Visible = false;
                    bool d = info.Count < 20 ? UpdatePage(true) : UpdatePage(false);
                }
                else
                {
                    dataGridView1.DataSource = null;
                    pictureBox1.Visible = false;

                }
            }
        }

      

        private void CompanyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterChange = true;
        }





       
    }
}
