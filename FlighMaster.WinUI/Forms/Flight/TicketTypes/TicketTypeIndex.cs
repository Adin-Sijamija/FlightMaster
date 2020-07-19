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

namespace FlighMaster.WinUI.Forms.Flight.TicketTypes
{
    public partial class TicketTypeIndex : Form
    {
        public TicketTypeIndex()
        {
            InitializeComponent();
            GetData();
        }

        private async void GetData()
        {
            pictureBox1.Visible = true;
            ApiCaller api = new ApiCaller();
            var data =await api.GetAll<List<FlightMaster.Model.TicketType>>("TicketType");

            if (data != null)
            {
                dataGridView1.DataSource = data;
                pictureBox1.Visible = false;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TicketTypeInsert frm = new TicketTypeInsert(null);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                GetData();
            }

        }

        private async void dataGridView1_CellContentClickAsync(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {

                DataGridViewCell cell = senderGrid.CurrentCell;

                TicketType selected = new TicketType();
                selected.Id = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                selected.Name = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(); 
                selected.Icon = (byte[])dataGridView1.Rows[e.RowIndex].Cells[3].Value;

                if (cell.EditedFormattedValue.ToString() == "Edit")
                {
                    TicketTypeInsert frm = new TicketTypeInsert(selected);

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        await Task.Delay(1000);
                        GetData();

                    }
                }

                if (cell.EditedFormattedValue.ToString() == "Delete")
                {
                    DialogResult dialog = MessageBox.Show("Do you want to remove the ticket type " + selected.Name + "?", "Deletion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                    if (dialog == DialogResult.OK)
                    {
                        ApiCaller api = new ApiCaller();
                        bool result = await api.RemoveOneById<bool>("TicketType",selected.Id);
                        if (result)
                        {
                            PopUp up = new PopUp(PopUp.PopUpType.Removal, "Ticket type succesfully removed");
                            up.Show();
                            GetData();

                        }
                    }
                }







            }
        }
    }
}
