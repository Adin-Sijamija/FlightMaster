using FlighMaster.WinUI.Api;
using FlighMaster.WinUI.Style;
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

namespace FlighMaster.WinUI.Forms.Flight
{
    public partial class FlightInsertForm : Form
    {

        ApiCaller api = new ApiCaller();
        int SelectedTicketID = 0;
        bool IsFinalized = false;
        string CompanyName = "";

        bool ValidDate = false;
        CompanyPlaneInfoData SelectedPlane = new CompanyPlaneInfoData();
        FlightInsertModel flightInsertModel = new FlightInsertModel();

        public FlightInsertForm()
        {
            InitializeComponent();
            SetUpDestinations();
            SetUpCompanyPlanes();
            SetUpTicketType();
            TicketTypeSelectionDataGrid.AutoGenerateColumns = false;
            FlightTicketsDataGrid.AutoGenerateColumns = false;
            TicketLuxuriesAvalabelDataGrid.AutoGenerateColumns = false;
            TicketLuxuriesInUseDataGrid.AutoGenerateColumns = false;
            for (int i = 2; i < 4; i++)
            {
                Control control2 = (Control)tabControl1.TabPages[i];
                control2.Enabled = false;
            }

        }

        private void SetUpFinalization()
        {


            FinalizationFlightDestination.Text = string.Format("Destination: {0}:{1}:{2} -- {3}:{4}:{5}",
                DepartureCountryComboBox.Text,
                DepartureCityComboBox.Text,
                DepartureAirfiedlComboBox.Text,
                ArrivalCountryCombobox.Text,
                ArrivalCityCombobox.Text,
                ArrivalAirfieldCombobox.Text
                );

            FInalizationDate.Text = "Date:" + DepartureDatePicker.Value.ToShortDateString();
            FinalizationTime.Text = string.Format("Time:{0}--{1}", DepartureTimePicker.Value.ToShortTimeString(), ArrivalTimePicker.Value.ToShortTimeString());

            FinalizationCOmpany.Text = "Company:" + CompanyName;
            FinalizationAirplane.Text = "Airplane:" + SelectedPlane.PlaneTypeName + '-' + SelectedPlane.PlaneName;


        }


        private void DeFinalize()
        {

            FinalizationFlightDestination.Text = "Destination:";

            FInalizationDate.Text = "Date:";
            FinalizationTime.Text = "Time:";

            FinalizationCOmpany.Text = "Company:";
            FinalizationAirplane.Text = "Airplane:";


        }



        #region Tickets


        #region Tab3TicketAddition
        private async void SetUpTicketType()
        {
            List<TicketType> ticketTypes = await api.GetAll<List<TicketType>>("TicketType");
            ticketTypes = ticketTypes.Where(x => !x.Name.Contains("Discount")).ToList();
            TicketTypeCombobox.ValueMember = "Id";
            TicketTypeCombobox.DisplayMember = "Name";
            TicketTypeCombobox.DataSource = ticketTypes;



        }

        private async void AddTicketButton_Click(object sender, EventArgs e)
        {

            int TotalSeats = 0;
            if (flightInsertModel.tickets.Count > 0)
            {
                foreach (var item in flightInsertModel.tickets)
                {
                    TotalSeats += item.ticketType.MaxTickets;
                }

            }

            TotalSeats += (int)TicketCapacityNumeric.Value;
            if (TotalSeats > flightInsertModel.PassangerCapacity)
            {
                errorProvider2.SetError(TicketCapacityNumeric, "Not enough seats");
                return;
            }
            else
            {
                errorProvider2.Clear();
            }



            FlightTicketType flightTicketType = new FlightTicketType();

            flightTicketType.MaxTickets = (int)TicketCapacityNumeric.Value;
            flightTicketType.Price = (int)TicketPriceNumeric.Value;
            flightTicketType.FlightId = flightInsertModel.Id;
            flightTicketType.TicketTypeID = (int)TicketTypeCombobox.SelectedValue;

            flightTicketType = await api.Insert<FlightTicketType>(flightTicketType, "Flight", "InsertFlightTicket");



            flightInsertModel.tickets.Add(new FlightInsertModel.Tickets()
            {

                ticketType = flightTicketType,
                luxuries = new List<FlightMaster.Model.Luxuries>()
            });

            EnabelDisabelTab(3, true);
            EnabelDisabelTab(4, true);

            UpdateTicketGrid();
            UpdateCapacity();


        }

        private async void UpdateTicketGrid()
        {
            List<FlightTicketType> ticketTypes = await api.GetAllByID<List<FlightTicketType>>("Flight", flightInsertModel.Id, "GetFlightTicketTypes");

            if (ticketTypes.Count == 0)
            {

                EnabelDisabelTab(3, false);
                EnabelDisabelTab(4, false);
                FlightTicketsDataGrid.DataSource = null;
                TicketTypeSelectionDataGrid.DataSource = null;
                TicketLuxuriesInUseDataGrid.DataSource = null;
                TicketLuxuriesAvalabelDataGrid.DataSource = null;
                DeFinalize();
                IsFinalized = false;
                return;
            }
            FlightTicketsDataGrid.DataSource = ticketTypes;
            TicketTypeSelectionDataGrid.DataSource = ticketTypes;
            IsFinalized = true;
            SetUpFinalization();

        }





        private async void FlightTicketsDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
              e.RowIndex >= 0)
            {

                DataGridViewCell cell = senderGrid.CurrentCell;


                if (cell.EditedFormattedValue.ToString() == "Delete")
                {

                    int id = (int)senderGrid.Rows[e.RowIndex].Cells[0].Value;

                    bool Deleted = await api.RemoveOneById<bool>("Flight", id, "RemoveFlightTicket");

                    if (Deleted)
                    {
                        flightInsertModel.RemoveTicket(id);
                        UpdateCapacity();
                        UpdateTicketGrid();
                    }

                }

            }



        }

        private void UpdateCapacity()
        {


            int TotalSeats = 0;
            if (flightInsertModel.tickets.Count > 0)
            {
                foreach (var item in flightInsertModel.tickets)
                {
                    TotalSeats += item.ticketType.MaxTickets;
                }

            }
            CurrentCapacityLabel.Text = TotalSeats.ToString();
        }
        #endregion

        #region Tab4TicketLuxAddition

        private async void TicketLuxuriesInUseDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
              e.RowIndex >= 0)
            {

                DataGridViewCell cell = senderGrid.CurrentCell;


                if (cell.EditedFormattedValue.ToString() == "Remove")
                {


                    int id = (int)senderGrid.Rows[e.RowIndex].Cells[0].Value;
                    FlightTicketLuxuries flightTicketLuxuries = new FlightTicketLuxuries()
                    {
                        FlightTicketTypeID = SelectedTicketID,
                        LuxuriesID = id
                    };
                    bool deleted = await api.RemoveByObject<bool>("Luxuries", flightTicketLuxuries, "RemoveTicketLuxuries");

                    if (deleted)
                        LoadLuxuries(SelectedTicketID);




                }

            }


        }

        private async void TicketLuxuriesAvalabelDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
              e.RowIndex >= 0)
            {

                DataGridViewCell cell = senderGrid.CurrentCell;


                if (cell.EditedFormattedValue.ToString() == "Add")
                {

                    int id = (int)senderGrid.Rows[e.RowIndex].Cells[0].Value;
                    FlightTicketLuxuries flightTicketLuxuries = new FlightTicketLuxuries();
                    flightTicketLuxuries.FlightTicketTypeID = SelectedTicketID;
                    flightTicketLuxuries.LuxuriesID = id;
                    flightTicketLuxuries = await api.Insert<FlightTicketLuxuries>(flightTicketLuxuries, "Luxuries", "AddTicketLuxuries");

                    LoadLuxuries(SelectedTicketID);



                }

            }
        }

        private void TicketTypeSelectionDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
              e.RowIndex >= 0)
            {

                DataGridViewCell cell = senderGrid.CurrentCell;
                //MessageBox.Show("Owning collum" + cell.OwningColumn + "Owning row" + cell.OwningRow +"/n Row data row index::" + cell.RowIndex + ":: collumn idenx::" + cell.ColumnIndex, "TEST", MessageBoxButtons.OK);


                if (cell.EditedFormattedValue.ToString() == "Select")
                {


                    SelectedTicketID = (int)senderGrid.Rows[e.RowIndex].Cells[0].Value;


                    LoadLuxuries(SelectedTicketID);



                }

            }
        }

        private async void LoadLuxuries(int selectedTicketID)
        {
            SetLuxuriesPictureBoxes(true);
            TicketLuxuriesDTF dTF = await api.GetAllByID<TicketLuxuriesDTF>("Luxuries", selectedTicketID, "GetAllTicketLuxuries");

            TicketLuxuriesAvalabelDataGrid.DataSource = dTF.AvailabelLuxuries;
            TicketLuxuriesInUseDataGrid.DataSource = dTF.TakenLuxuries;
            SetLuxuriesPictureBoxes(false);

        }

        private void SetLuxuriesPictureBoxes(bool v)
        {
            AvalLuxPictureBox.Visible = v;
            InUseLuxPictureBox.Visible = v;
        }





        #endregion

        #endregion




        #region CompanyPlane
        private void SetUpCompanyPlanes()
        {
            LoadCompanies();
        }


        private async void BackToCompanyBtn_Click(object sender, EventArgs e)
        {
            LoadCompanies();
            BackToCompanyBtn.Visible = false;
            SelectPlaneButton.Text = "Select";
            SelectedPlane = null;


            PlaneTypeLabel.Text = "Plane type:";
            PlaneNameLabel.Text = "Plane designation:";
            PlaneCapacityLabel.Text = "Plane capacity:";


            SelectPlaneButton.Visible = false;
            SelectedLabel.Visible = false;


            if (SelectedPlane != null)
                SelectedPlane.Id = 0;

            if (flightInsertModel != null && flightInsertModel.Id != 0)
            {
                bool deleted = await api.RemoveOneById<bool>("Flight", flightInsertModel.Id, "RemoveFlight");
                if (deleted)
                {
                    flightInsertModel.Clear();
                    EnabelDisabelTab(2, false);
                    EnabelDisabelTab(3, false);
                    EnabelDisabelTab(4, false);
                }
            }






            flightInsertModel.Clear();
            MaxCapacityLabel.Text = "0";



            CompanyDataLabel.Text = "Companies";

            EnabelDisabelTab(2, false);
            EnabelDisabelTab(3, false);
            EnabelDisabelTab(4, false);


        }

        private async void LoadCompanies()
        {
            pictureBox1.Visible = true;
            List<Company> companies = await api.GetAll<List<Company>>("Companies");

            SetCompanyCollums();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = companies;
            pictureBox1.Visible = false;



        }

        private void SetCompanyCollums()
        {

            dataGridView1.Columns.Clear();
            DataGridViewTextBoxColumn IdCollumn = new DataGridViewTextBoxColumn();
            IdCollumn.DataPropertyName = "Id";
            IdCollumn.Name = "CompanyID";
            IdCollumn.Resizable = DataGridViewTriState.False;
            IdCollumn.HeaderText = "Company Id";
            IdCollumn.Visible = false;

            DataGridViewTextBoxColumn NameCollum = new DataGridViewTextBoxColumn();
            NameCollum.DataPropertyName = "Name";
            NameCollum.Name = "CompanyName";
            NameCollum.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            NameCollum.Resizable = DataGridViewTriState.False;
            NameCollum.HeaderText = "Company name";

            DataGridViewImageColumn CompanyIcon = new DataGridViewImageColumn();
            CompanyIcon.DataPropertyName = "Picture";
            CompanyIcon.Name = "CompanyIcon";
            CompanyIcon.ImageLayout = DataGridViewImageCellLayout.Zoom;
            CompanyIcon.Resizable = DataGridViewTriState.False;
            CompanyIcon.HeaderText = "Company logo";

            DataGridViewButtonColumn SelectButtonn = new DataGridViewButtonColumn();
            SelectButtonn.Name = "CompanySelect";
            SelectButtonn.UseColumnTextForButtonValue = true;
            SelectButtonn.Text = "Select";
            SelectButtonn.Resizable = DataGridViewTriState.False;
            SelectButtonn.HeaderText = "Option";


            dataGridView1.Columns.Add(IdCollumn);
            dataGridView1.Columns.Add(NameCollum);
            dataGridView1.Columns.Add(CompanyIcon);
            dataGridView1.Columns.Add(SelectButtonn);
        }


        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;



            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {

                DataGridViewCell cell = senderGrid.CurrentCell;


                if (cell.EditedFormattedValue.ToString() == "Info")
                {
                    SelectedPlane = new CompanyPlaneInfoData();
                    SelectedPlane.Id = (int)senderGrid.Rows[e.RowIndex].Cells[0].Value;

                    SelectedPlane.PlaneName = (string)senderGrid.Rows[e.RowIndex].Cells[1].Value;
                    SelectedPlane.PlaneTypeName = (string)senderGrid.Rows[e.RowIndex].Cells[2].Value;
                    SelectedPlane.TotalPassangeres = (int)senderGrid.Rows[e.RowIndex].Cells[3].Value;


                    PlaneNameLabel.Text = "Plane designation: " + (string)senderGrid.Rows[e.RowIndex].Cells[1].Value;
                    PlaneTypeLabel.Text = "Plane type: " + (string)senderGrid.Rows[e.RowIndex].Cells[2].Value;
                    PlaneCapacityLabel.Text = "Plane capacity: " + SelectedPlane.TotalPassangeres.ToString();

                    SelectPlaneButton.Visible = true;

                }




                if (cell.EditedFormattedValue.ToString() == "Select")
                {
                    Company company = new Company();
                    company.Id = (int)senderGrid.Rows[e.RowIndex].Cells[0].Value;
                    company.Name = (string)senderGrid.Rows[e.RowIndex].Cells[1].Value;
                    company.Picture = (byte[])senderGrid.Rows[e.RowIndex].Cells[2].Value;

                    CompanyName = company.Name;


                    pictureBox1.Visible = true;
                    CompanyDataLabel.Text = "Company " + company.Name + " ->Airplanes";

                    List<CompanyPlaneInfoData> data = await api.GetAllByID<List<CompanyPlaneInfoData>>("Companies", company.Id, "PlanesData");


                    dataGridView1.Columns.Clear();


                    DataGridViewTextBoxColumn PlaneId = new DataGridViewTextBoxColumn();
                    PlaneId.DataPropertyName = "Id";
                    PlaneId.Name = "PlaneId";
                    PlaneId.Resizable = DataGridViewTriState.False;
                    PlaneId.HeaderText = "Plane Id";
                    PlaneId.Visible = false;


                    DataGridViewTextBoxColumn PlaneName = new DataGridViewTextBoxColumn();
                    PlaneName.DataPropertyName = "PlaneName";
                    PlaneName.Name = "PlaneDesignation";
                    PlaneName.Resizable = DataGridViewTriState.False;
                    PlaneName.HeaderText = "Plane Designation";
                    PlaneName.Visible = true;


                    DataGridViewTextBoxColumn PlaneType = new DataGridViewTextBoxColumn();
                    PlaneType.DataPropertyName = "PlaneTypeName";
                    PlaneType.Name = "PlaneType";
                    PlaneType.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    PlaneType.Resizable = DataGridViewTriState.False;
                    PlaneType.HeaderText = "Plane Type";
                    PlaneType.Visible = true;

                    DataGridViewTextBoxColumn PlaneCapacity = new DataGridViewTextBoxColumn();
                    PlaneCapacity.DataPropertyName = "TotalPassangeres";
                    PlaneCapacity.Name = "PlaneCapacity";
                    PlaneCapacity.Resizable = DataGridViewTriState.False;
                    PlaneCapacity.HeaderText = "Plane Capacity";
                    PlaneCapacity.Visible = true;
                    PlaneCapacity.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    DataGridViewButtonColumn SelectPlane = new DataGridViewButtonColumn();
                    SelectPlane.Name = "SelectPlane";
                    SelectPlane.Text = "Info";
                    SelectPlane.UseColumnTextForButtonValue = true;
                    SelectPlane.Resizable = DataGridViewTriState.False;
                    SelectPlane.HeaderText = "Option";
                    SelectPlane.Visible = true;

                    dataGridView1.Columns.Add(PlaneId);
                    dataGridView1.Columns.Add(PlaneName);
                    dataGridView1.Columns.Add(PlaneType);
                    dataGridView1.Columns.Add(PlaneCapacity);
                    dataGridView1.Columns.Add(SelectPlane);

                    dataGridView1.DataSource = data;

                    BackToCompanyBtn.Visible = true;


                    pictureBox1.Visible = false;
                    PlaneId.Visible = false;


                }




            }
        }

        private async void SelectPlaneButton_Click(object sender, EventArgs e)
        {

            if (SelectPlaneButton.Text == "Select")
            {

                if (CheckDestinationIds())
                {
                    if (CheckDates())
                    {

                        if (SelectedPlane != null)
                        {

                            SelectedLabel.Text = " Plane " + SelectedPlane.PlaneName + " selected for journey";
                            SelectedLabel.Visible = true;

                            SelectPlaneButton.Text = "Unselect";
                            flightInsertModel.PassangerCapacity = SelectedPlane.TotalPassangeres;
                            flightInsertModel.PlaneId = SelectedPlane.Id;
                            SetFlightModel();

                            MaxCapacityLabel.Text = SelectedPlane.TotalPassangeres.ToString();





                            FlightInsertModel createdModel = await api.Insert<FlightInsertModel>(flightInsertModel, "Flight", "CreateFlight");
                            if (createdModel != null)
                            {
                                flightInsertModel = createdModel;
                                flightInsertModel.tickets = new List<FlightInsertModel.Tickets>();
                                EnabelDisabelTab(2, true);

                            }


                            SetUpFinalization();
                            return;


                        }
                    }
                }


                tabControl1.SelectedTab = tabControl1.TabPages[0];
                return;


            }
            if (SelectPlaneButton.Text == "Unselect")
            {
                SelectedLabel.Text = "";
                SelectedLabel.Visible = true;


                SelectPlaneButton.Text = "Select";

                SelectedPlane = null;

                PlaneTypeLabel.Text = "Plane type:";
                PlaneNameLabel.Text = "Plane designation:";
                PlaneCapacityLabel.Text = "Plane capacity:";


                bool deleted = await api.RemoveOneById<bool>("Flight", flightInsertModel.Id, "RemoveFlight");
                FlightTicketsDataGrid.DataSource = null;
                TicketTypeSelectionDataGrid.DataSource = null;
                TicketLuxuriesAvalabelDataGrid.DataSource = null;
                TicketLuxuriesInUseDataGrid.DataSource = null;
                if (deleted)
                {
                    flightInsertModel.Clear();
                    EnabelDisabelTab(2, false);
                    EnabelDisabelTab(3, false);
                    EnabelDisabelTab(4, false);
                }

                DeFinalize();
                IsFinalized = false;
                UpdateTicketGrid();
            }


        }


        #endregion


        #region Destinations
        private void SetUpDestinations()
        {
            SetUpDepaure();
            SetUpArrival();
        }

        private async void SetUpArrival()
        {
            EnableArrivalBoxes(false);

            List<Country> countries = await api.GetAll<List<Country>>("Countries");
            ArrivalCountryCombobox.DisplayMember = "Name";
            ArrivalCountryCombobox.ValueMember = "Id";
            ArrivalCountryCombobox.DataSource = countries;

            List<City> cities = await api.GetAllByID<List<City>>("Cities", countries.First().Id, "CountriesCities");
            ArrivalCityCombobox.DisplayMember = "Name";
            ArrivalCityCombobox.ValueMember = "Id";
            ArrivalCityCombobox.DataSource = cities;


            List<Airfield> airfields = await api.GetAllByID<List<Airfield>>("Airfield", cities.First().Id, "CityAirfields");
            ArrivalAirfieldCombobox.DisplayMember = "Name";
            ArrivalAirfieldCombobox.ValueMember = "Id";
            ArrivalAirfieldCombobox.DataSource = airfields;
            ArrivalAirfieldCombobox.SelectedIndex = -1;


            ArrivalCountryCombobox.SelectedIndexChanged += new EventHandler(UpdateArrivalCity);
            ArrivalCityCombobox.SelectedIndexChanged += new EventHandler(UpdateArrivalAirfields);
            EnableArrivalBoxes(true);

        }

        private void EnableArrivalBoxes(bool v)
        {
            ArrivalCountryCombobox.Enabled = v;
            ArrivalAirfieldCombobox.Enabled = v;
            ArrivalCityCombobox.Enabled = v;
        }

        private async void UpdateArrivalAirfields(object sender, EventArgs e)
        {
            int id = (int)ArrivalCityCombobox.SelectedValue;

            List<Airfield> airfields = await api.GetAllByID<List<Airfield>>("Airfield", id, "CityAirfields");
            ArrivalAirfieldCombobox.DisplayMember = "Name";
            ArrivalAirfieldCombobox.SelectedValue = "Id";
            ArrivalAirfieldCombobox.DataSource = airfields;


        }

        private async void UpdateArrivalCity(object sender, EventArgs e)
        {

            int id = (int)ArrivalCountryCombobox.SelectedValue;

            List<City> cities = await api.GetAllByID<List<City>>("Cities", id, "CountriesCities");
            ArrivalCityCombobox.DisplayMember = "Name";
            ArrivalCityCombobox.ValueMember = "Id";
            ArrivalCityCombobox.DataSource = cities;


        }

        private async void SetUpDepaure()
        {
            SetDepartureComboBoxEnabelStatus(false);

            List<Country> countries = await api.GetAll<List<Country>>("Countries");
            DepartureCountryComboBox.DisplayMember = "Name";
            DepartureCountryComboBox.ValueMember = "Id";
            DepartureCountryComboBox.DataSource = countries;


            List<City> cities = await api.GetAllByID<List<City>>("Cities", countries.First().Id, "CountriesCities");
            DepartureCityComboBox.DisplayMember = "Name";
            DepartureCityComboBox.ValueMember = "Id";
            DepartureCityComboBox.DataSource = cities;



            List<Airfield> airfields = await api.GetAllByID<List<Airfield>>("Airfield", cities.First().Id, "CityAirfields");
            DepartureAirfiedlComboBox.DisplayMember = "Name";
            DepartureAirfiedlComboBox.ValueMember = "Id";
            DepartureAirfiedlComboBox.DataSource = airfields;
            DepartureAirfiedlComboBox.SelectedIndex = -1;


            DepartureCountryComboBox.SelectedIndexChanged += new EventHandler(DepartureCountryHandler);
            DepartureCityComboBox.SelectedIndexChanged += new EventHandler(DepartureCityHandler);

            SetDepartureComboBoxEnabelStatus(true);



        }

        private void SetDepartureComboBoxEnabelStatus(bool v)
        {
            DepartureCountryComboBox.Enabled = v;
            DepartureCityComboBox.Enabled = v;
            DepartureAirfiedlComboBox.Enabled = v;
        }

        private async void DepartureCountryHandler(object sender, EventArgs e)
        {

            SetDepartureComboBoxEnabelStatus(false);

            int id = (int)DepartureCountryComboBox.SelectedValue;

            List<City> cities = await api.GetAllByID<List<City>>("Cities", id, "CountriesCities");
            DepartureCityComboBox.DisplayMember = "Name";
            DepartureCityComboBox.ValueMember = "Id";
            DepartureCityComboBox.DataSource = cities;
            SetDepartureComboBoxEnabelStatus(true);

        }


        private async void DepartureCityHandler(object sender, EventArgs e)
        {

            SetDepartureComboBoxEnabelStatus(false);

            int id = (int)DepartureCityComboBox.SelectedValue;

            List<Airfield> airfields = await api.GetAllByID<List<Airfield>>("Airfield", id, "CityAirfields");
            DepartureAirfiedlComboBox.DataSource = null;
            DepartureAirfiedlComboBox.DisplayMember = "Name";
            DepartureAirfiedlComboBox.ValueMember = "Id";
            DepartureAirfiedlComboBox.DataSource = airfields;
            SetDepartureComboBoxEnabelStatus(true);

        }


        #endregion


        private void EnabelDisabelTab(int id, bool enabel)
        {
            Control control2 = (Control)tabControl1.TabPages[id];
            control2.Enabled = enabel;
        }

        private void DateTimeChangeListener(object sender, EventArgs e)
        {
            if (CheckDates())
                ValidDate = true;
        }

        private void ValidateDates(object sender, CancelEventArgs e)
        {
            if (CheckDates())
            {

                DateTime departure = new DateTime(DepartureDatePicker.Value.Year, DepartureDatePicker.Value.Month, DepartureDatePicker.Value.Day,
             DepartureTimePicker.Value.Hour, DepartureTimePicker.Value.Minute, DepartureTimePicker.Value.Second, DepartureTimePicker.Value.Millisecond, DateTimeKind.Utc
             );

                DateTime arrival = new DateTime(ArrivalDatePicker.Value.Year, ArrivalDatePicker.Value.Month, ArrivalDatePicker.Value.Day,
                      ArrivalTimePicker.Value.Hour, ArrivalTimePicker.Value.Minute, ArrivalTimePicker.Value.Second, ArrivalTimePicker.Value.Millisecond, DateTimeKind.Utc
                      );

                ValidDate = true;
                flightInsertModel.DepartureDateTime = departure;
                flightInsertModel.ArrivalDateTime = arrival;

            }
            else
            {
                ValidDate = false;
            }

        }

        private bool CheckDates()
        {
            DateTime departure = new DateTime(DepartureDatePicker.Value.Year, DepartureDatePicker.Value.Month, DepartureDatePicker.Value.Day,
              DepartureTimePicker.Value.Hour, DepartureTimePicker.Value.Minute, DepartureTimePicker.Value.Second, DepartureTimePicker.Value.Millisecond, DateTimeKind.Utc
              );

            DateTime arrival = new DateTime(ArrivalDatePicker.Value.Year, ArrivalDatePicker.Value.Month, ArrivalDatePicker.Value.Day,
                  ArrivalTimePicker.Value.Hour, ArrivalTimePicker.Value.Minute, ArrivalTimePicker.Value.Second, ArrivalTimePicker.Value.Millisecond, DateTimeKind.Utc
                  );


            DateTime now = DateTime.Now;


            if (arrival < DateTime.UtcNow)
            {
                errorProvider1.SetError(ArrivalDatePicker, " Arrival time cant be less then current time");
                return false;
            }
             
            if (departure < DateTime.UtcNow )
            {
                errorProvider1.SetError(DepartureDatePicker, " Departure time cant be less then current time");
                return false;

            }

            TimeSpan timeSpan = arrival.Subtract(departure);

            if (departure > arrival)
            {
                errorProvider1.SetError(DepartureDatePicker, " Departure time cant be greater than arrival");
                TotalTimeLabel.Text = "[Time]";

                return false;
            }

            if (timeSpan.TotalMinutes < 15)
            {
                errorProvider1.SetError(DepartureDatePicker, "Flight must be atleast 15 minutes long");
                TotalTimeLabel.Text = "[Time]";
                return false;

            }

            errorProvider1.Clear();
            TimeSpan flightduration = (arrival - departure);

            flightInsertModel.DepartureDateTime = departure;
            flightInsertModel.ArrivalDateTime = arrival;


            TotalTimeLabel.Text = string.Format("{0:00}:{1:00}", (int)flightduration.TotalHours, flightduration.Minutes);




            return true;
        }


        private void SetFlightModel()
        {

            DateTime departure = new DateTime(DepartureDatePicker.Value.Year, DepartureDatePicker.Value.Month, DepartureDatePicker.Value.Day,
            DepartureTimePicker.Value.Hour, DepartureTimePicker.Value.Minute, DepartureTimePicker.Value.Second, DepartureTimePicker.Value.Millisecond, DateTimeKind.Utc
            );

            DateTime arrival = new DateTime(ArrivalDatePicker.Value.Year, ArrivalDatePicker.Value.Month, ArrivalDatePicker.Value.Day,
                  ArrivalTimePicker.Value.Hour, ArrivalTimePicker.Value.Minute, ArrivalTimePicker.Value.Second, ArrivalTimePicker.Value.Millisecond, DateTimeKind.Utc
                  );

            TimeSpan flightduration = (arrival - departure);

            flightInsertModel.DepartureDateTime = departure;
            flightInsertModel.ArrivalDateTime = arrival;

            if (CheckDestinationIds())
            {
                errorProvider2.Clear();
                flightInsertModel.DepartureAirfieldId = (int)DepartureAirfiedlComboBox.SelectedValue;
                flightInsertModel.ArrivalAirfieldId = (int)ArrivalAirfieldCombobox.SelectedValue;
            }
            else
            {
                flightInsertModel.DepartureAirfieldId = 0;
                flightInsertModel.ArrivalAirfieldId = 0;
            }

        }

        private bool CheckDestinationIds()
        {

            if (ArrivalAirfieldCombobox.SelectedValue == null)
            {
                errorProvider2.SetError(ArrivalAirfieldCombobox, "Please select arrival airfield");
                return false;
            }
            else
            {
                errorProvider2.Clear();
            }

            if (DepartureAirfiedlComboBox.SelectedValue == null)
            {
                errorProvider2.SetError(DepartureAirfiedlComboBox, "Please select departure airfield");
                return false;
            }

            int DepartureId = (int)DepartureAirfiedlComboBox.SelectedValue;
            int ArrivalId = (int)ArrivalAirfieldCombobox.SelectedValue;

            if (ArrivalId == DepartureId)
            {
                errorProvider2.SetError(ArrivalAirfieldCombobox, "Departure and Arrival airfields cant be the same");
                return false;
            }
            return true;

        }

        private void CheckDesinations(object sender, EventArgs e)
        {
            if (CheckDestinationIds())
            {
                errorProvider2.Clear();
                flightInsertModel.DepartureAirfieldId = (int)DepartureAirfiedlComboBox.SelectedValue;
                flightInsertModel.ArrivalAirfieldId = (int)ArrivalAirfieldCombobox.SelectedValue;
            }
            else
            {
                flightInsertModel.DepartureAirfieldId = 0;
                flightInsertModel.ArrivalAirfieldId = 0;
            }
        }

        private async void FlightInsertForm_FormClosing(object sender, FormClosingEventArgs e)
        {


            if (IsFinalized)
            {
                var result = MessageBox.Show("Do you want to close this form? doing so all data will be lost!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    bool deleted = false;


                    if (flightInsertModel != null && flightInsertModel.Id != 0)
                        deleted = await api.RemoveOneById<bool>("Flight", flightInsertModel.Id, "RemoveFlight");



                }
                else
                {
                    e.Cancel = true;
                }
            }




        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsFinalized)
            {
                PopUp up = new PopUp(PopUp.PopUpType.Addtion, "Flight succesfully created!");
                up.Show();
                Task.Delay(1000);

                this.Close();
            }
        }
    }
}
