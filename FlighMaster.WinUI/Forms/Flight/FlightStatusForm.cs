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

namespace FlighMaster.WinUI.Forms.Flight
{
    public partial class FlightStatusForm : Form
    {
        ApiCaller api = new ApiCaller();
        bool DataChanged = false;
        FlightMaster.Model.Flight Flight = new FlightMaster.Model.Flight();
        public enum FlightStatus
        {
            OnTime = 0,
            LateDeparture,
            LateArrival,
            DepartureDelayed,
            PostPoned,
            Rescheduled,
            Canceled,

        }


        public FlightStatusForm(int id)
        {
            InitializeComponent();
            comboBox1.DataSource = Enum.GetValues(typeof(FlightStatus));
            LoadData(id);
        }

        private async void LoadData(int id)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("FlightId", id);
            Flight = await api.GetQuery<FlightMaster.Model.Flight>(param, "Flight", "GetFlightInfo");

            FlightNameLabel.Text = Flight.Name;
            DurationLabel.Text = Flight.Duration;
            var EnumInt= (FlightStatus)Flight.Status;
            StatusLabel.Text = EnumInt.ToString();

            CurrentDepartureDateTime.Value = Flight.StartDate;
            NewDepartureDateTime.Value = Flight.StartDate;



            CurrentArrivalDateTime.Value = Flight.EndDate;
            NewArrivalDateTime.Value = Flight.EndDate;

        }

        private async void button1_Click(object sender, EventArgs e)
        {

            errorProvider1.Clear();

            DateTime NewDepartureDate = NewDepartureDateTime.Value;
            DateTime NewArrivalDate = NewArrivalDateTime.Value;


            FlightStatus newStatus = (FlightStatus)comboBox1.SelectedItem;
            FlightStatus oldStatus = (FlightStatus)Flight.Status;
            if (newStatus == oldStatus)
            {
                errorProvider1.SetError(comboBox1, "Must Select a new flight status to update");
                return;
            }

            

            if (NewArrivalDate < NewDepartureDate)
            {
                errorProvider1.SetError(button1, "Arrival date cant be smaller than departure date!");
                return;
            }

            TimeSpan NewTimeSpan = (NewArrivalDate - NewDepartureDate);

            if (NewTimeSpan.TotalMinutes < 15)
            {
                errorProvider1.SetError(button1, "Flight Must Be atleast 15 minutes long");
                return;
            }


            if (newStatus != FlightStatus.Canceled)
            {
                if (NewDepartureDate==CurrentDepartureDateTime.Value && NewArrivalDate==CurrentArrivalDateTime.Value)
                {
                    errorProvider1.SetError(button1, "You must select a new date(s) to update!");
                    return;
                }
            }

       

            errorProvider1.Clear();
            TimeSpan flightduration = (NewArrivalDate - NewDepartureDate);
            string Duration = string.Format("{0:00}:{1:00}", (int)flightduration.TotalHours, flightduration.Minutes);
            NewDuration.Text = Duration;


            FlightMaster.Model.Flight EditedData = new FlightMaster.Model.Flight();
            EditedData.Id = Flight.Id;
            EditedData.Name = Flight.Name;
            EditedData.PlaneId= Flight.PlaneId;
            EditedData.StartDate= NewDepartureDate;
            EditedData.EndDate= NewArrivalDate;
            EditedData.Duration = Duration;
            EditedData.Status = (int)newStatus;


            FlightMaster.Model.Flight NewFlightData =await api.UpdateOne<FlightMaster.Model.Flight>("Flight", EditedData, "UpdateFlightStatus");

            if (NewFlightData != null)
            {

                Flight = NewFlightData;
                CurrentDepartureDateTime.Value = NewFlightData.StartDate;
                NewDepartureDateTime.Value = NewFlightData.StartDate;

                CurrentArrivalDateTime.Value= NewFlightData.EndDate;
                NewArrivalDateTime.Value= NewFlightData.EndDate;

               
                DurationLabel.Text = Duration;
                FlightStatus flightStatus = (FlightStatus)NewFlightData.Status;
                StatusLabel.Text = flightStatus.ToString();
                DataChanged = true;
                PopUp up = new PopUp(PopUp.PopUpType.Success, "Flight Status Succesfully changed!");
                up.Show();
            }
            else
            {

                MessageBox.Show("Something went wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }




        }

        private void NewDateTimeChange(object sender, EventArgs e)
        {

            DateTime NewDepartureDate = NewDepartureDateTime.Value;

            DateTime NewArrivalDate = NewArrivalDateTime.Value;

            TimeSpan flightduration = (NewArrivalDate - NewDepartureDate);
            string Duration = string.Format("{0:00}:{1:00}", (int)flightduration.TotalHours, flightduration.Minutes);
            NewDuration.Text = Duration;
        }

        private void FlightStatusForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (DataChanged)
            {
                this.DialogResult = DialogResult.OK;
                return;
            }

            this.DialogResult = DialogResult.Cancel;


        }
    }
}


