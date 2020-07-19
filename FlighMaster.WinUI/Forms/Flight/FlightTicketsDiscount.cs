using FlighMaster.WinUI.Api;
using FlighMaster.WinUI.Style;
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

namespace FlighMaster.WinUI.Forms.Flight
{
    public partial class FlightTicketsDiscount : Form
    {
        int FlightId = 0;
        ApiCaller api = new ApiCaller();
        List<FlightTicketType> flightTicketTypes;
        FlightTicketType SelectedTicket;
        public FlightTicketsDiscount(int id)
        {
            FlightId = id;
            flightTicketTypes = new List<FlightTicketType>();
            InitializeComponent();
            loadData();
        }

        private async void loadData()
        {
            dataGridView1.AutoGenerateColumns = false;
            flightTicketTypes = await api.GetAllByID<List<FlightTicketType>>("Flight", FlightId, "GetFlightTicketTypes");
            dataGridView1.DataSource = flightTicketTypes;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;


            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                DataGridViewCell cell = senderGrid.CurrentCell;
                if (cell.EditedFormattedValue.ToString() == "Select")
                {

                    int id = (int)senderGrid.Rows[e.RowIndex].Cells[0].Value;
                    button1.Enabled = true;
                    SelectTicketForDiscount(id);
                }
            }
        }

        private void SelectTicketForDiscount(int id)
        {
            SelectedTicket = flightTicketTypes.SingleOrDefault(x => x.Id == id);



            if (SelectedTicket.TicketTypeName.Contains("Discount"))
            {
                button1.Text = "Edit Discount";
                DiscountPriceNumeric.Enabled = false;
                DiscountPriceNumeric.Value = decimal.Parse(SelectedTicket.Price.ToString());

                DiscountTicketsCountNumeric.Maximum = SelectedTicket.MaxTickets;
                DiscountTicketsCountNumeric.Value = SelectedTicket.MaxTickets;
            }
            else
            {
                button1.Text = "Create Discount";
            }
            SelectedTicketTypeLabel.Text = SelectedTicket.TicketTypeName;
            SelectedCurrentTickets.Text = SelectedTicket.CurrentTickets.ToString();
            SelectedMaxTickets.Text = SelectedTicket.MaxTickets.ToString();



        }

        private void DiscountTicketsCountNumeric_ValueChanged(object sender, EventArgs e)
        {
            int disscountTickets = (int)DiscountTicketsCountNumeric.Value;

            if (disscountTickets + SelectedTicket.CurrentTickets > SelectedTicket.MaxTickets)
            {
                DiscountTicketsCountNumeric.Value = SelectedTicket.MaxTickets - SelectedTicket.CurrentTickets;
                return;
            }
        }

        private void DiscountPriceNumeric_ValueChanged(object sender, EventArgs e)
        {
            int disscountTickets = (int)DiscountPriceNumeric.Value;

            if (disscountTickets > SelectedTicket.Price)
            {
                DiscountPriceNumeric.Value = decimal.Parse((SelectedTicket.Price - 1).ToString());
                return;
            }

        }

        private async void button1_Click(object sender, EventArgs e)
        {



            if (SelectedTicket.TicketTypeName.Contains("Discount"))
            {
                FlightTicketType TobeUpdated = SelectedTicket;
                TobeUpdated.MaxTickets = (int)DiscountTicketsCountNumeric.Value;
                TobeUpdated.Price = float.Parse(DiscountPriceNumeric.Value.ToString());
                TobeUpdated.TicketTypeName = SelectedTicket.TicketTypeName;
                TobeUpdated.Id = SelectedTicket.Id;
              
                TobeUpdated.CurrentTickets = int.Parse(DiscountTicketsCountNumeric.Value.ToString());
                TobeUpdated.FlightId = SelectedTicket.FlightId;
                var res = await api.UpdateOne<bool>( "TicketType", TobeUpdated, "ChangeTicketDiscount");

                if (res)
                {
                    PopUp up = new PopUp(PopUp.PopUpType.Edit, "Ticket Discount Succesfully Eddited!");
                    up.Show();
                    loadData();
                    ClearOldLabelData();
                    SelectedTicket = null;
                }
            }
            else
            {
                FlightTicketType TobeUpdated = new FlightTicketType();
                TobeUpdated.Id = SelectedTicket.Id;
                TobeUpdated.MaxTickets = (int)DiscountTicketsCountNumeric.Value;
                TobeUpdated.Price = float.Parse(DiscountPriceNumeric.Value.ToString());
                TobeUpdated.CurrentTickets = 0;
                TobeUpdated.TicketTypeName = SelectedTicket.TicketTypeName;

                var res = await api.Insert<bool>(TobeUpdated, "TicketType", "SetFlightTicketDiscount");

                if (res)
                {
                    PopUp up = new PopUp(PopUp.PopUpType.Success, "Ticket Discount Succesfully Created!");
                    up.Show();
                    loadData();
                    ClearOldLabelData();
                    SelectedTicket = null;
                }

            }

        }

        private void ClearOldLabelData()
        {
            SelectedTicketTypeLabel.Text = "N/A";
            SelectedMaxTickets.Text = "0";
            SelectedCurrentTickets.Text = "0";
            DiscountPriceNumeric.Value = 1;
            DiscountTicketsCountNumeric.Value = 0;
            button1.Enabled = false;
        }
    }
}
