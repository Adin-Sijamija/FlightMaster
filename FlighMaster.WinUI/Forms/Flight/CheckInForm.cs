using FlighMaster.WinUI.Api;
using FlighMaster.WinUI.Style;
using FlightMaster.Model.WinUIModels;
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

namespace FlighMaster.WinUI.Forms.Flight
{
    public partial class CheckInForm : Form
    {

        ApiCaller api;
        int id = 0;
        string TicketCode = "";
        public CheckInForm()
        {
            api = new ApiCaller();
            InitializeComponent();

        }


        private async void ActivateCodeButton_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "")
            {
                ActivateCodeButton.Text = "Finding...";
                ActivateCodeButton.Enabled = false;

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("TicketCode", textBox1.Text);

                TicketInfoModel data = await api.GetQuery<TicketInfoModel>(param, "Flight", "GetTicketInfo");

                if (data == null)
                {
                    label11.ForeColor = Color.Red;
                    label11.Text = "Code Status: NOT FOUND";
                    SaveTicketButton.Enabled = false;
                    SetNAData();
                    id = 0;
                    TicketCode = "";
                    ActivateCodeButton.Text = "Find";
                    ActivateCodeButton.Enabled = true;
                    return;
                }

                id = data.TicketId;
                TicketCode = textBox1.Text;

                label11.ForeColor = Color.Green;
                label11.Text = "Code Status: FOUND";

                DepartureLabel.Text = data.Departure;
                DestinationLabel.Text = data.Destination;
                DepartureTime.Text = data.DepartureTime;
                DurationLabel.Text = data.Duration;
                StatusLabel.Text = data.FlightStatus;
                FlightProviderLabel.Text = data.FlightProvider;
                CompanyLogo.Image = ByteToImage(data.FlightproviderIcon);
                CompanyLogo.Visible = true;
                UserPicture.Image = ByteToImage(data.UserIcon);
                UserPicture.Visible = true;
                UserNameLabel.Text = "Name: " + data.UserName;
                TicketTypeLabel.Text = "Ticket Type: " + data.FlightTicketType;
                TicketStatusLabel.Text = "Ticket Status: " + data.TicketStatus;

                if (data.TicketStatus == "Checked In") { SaveTicketButton.Enabled = false; } else { SaveTicketButton.Enabled = true; }
                if(data.FlightStatus== "Canceled")
                {
                    SaveTicketButton.Enabled = false;
                    CanceledLabelWarning.Visible = true;
                }
                else
                {
                    SaveTicketButton.Enabled = true;
                    CanceledLabelWarning.Visible = false;
                }


                ActivateCodeButton.Text = "Find";
                ActivateCodeButton.Enabled = true;
            }

        }

        private async void SaveTicketButton_Click(object sender, EventArgs e)
        {
            FlightMaster.Model.Ticket ticket = new FlightMaster.Model.Ticket() { Id = id, Name = TicketCode };

            SaveTicketButton.Enabled = false;
            SaveTicketButton.Text = "Checking in....";

            bool checkedIn =await api.UpdateOne<bool>("Flight", ticket, "CheckInTicket");
         
            if (checkedIn)
            {
                PopUp up = new PopUp(PopUp.PopUpType.Success, "Ticket Succesfully checked In!");
                up.Show();
                SetNAData();
                label11.ForeColor = Color.Black;
                label11.Text = "Code Status: ";
                textBox1.Text = "";
              
                return;
            }
            else
            {
                MessageBox.Show("Something went wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            SaveTicketButton.Enabled = true;
            SaveTicketButton.Text = "Check in";
        }

        private void SetNAData()
        {
            DepartureLabel.Text = "N/A";
            DestinationLabel.Text = "N/A";
            DepartureTime.Text = "N/A";
            DurationLabel.Text = "N/A";
            StatusLabel.Text = "N/A";
            FlightProviderLabel.Text = "N/A";
            CompanyLogo.Visible = false;
            UserPicture.Visible = false;
            UserNameLabel.Text = "Name: ";
            TicketTypeLabel.Text = "Ticket Type: ";
            TicketStatusLabel.Text = "Ticket Status: ";
            SaveTicketButton.Enabled = false;
            SaveTicketButton.Text = "Check in";

        }






        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }



        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void CheckInLabel_Click(object sender, EventArgs e)
        {

        }


    }
}
