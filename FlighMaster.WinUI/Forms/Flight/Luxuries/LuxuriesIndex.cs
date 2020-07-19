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

namespace FlighMaster.WinUI.Forms.Flight.Luxuries
{
    public partial class LuxuriesIndex : Form
    {
        public LuxuriesIndex()
        {
            InitializeComponent();
            SetUpData();
        }

        private async void SetUpData()
        {
            pictureBox1.Visible = true;
            ApiCaller api = new ApiCaller();
            List<FlightMaster.Model.Luxuries> luxuries = await api.GetAll<List<FlightMaster.Model.Luxuries>>("Luxuries", "GetAll");
            dataGridView1.DataSource = luxuries;

            pictureBox1.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LuxuriesInsert frm = new LuxuriesInsert(null);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                SetUpData();
            }
        }

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {

                DataGridViewCell cell = senderGrid.CurrentCell;

                if (cell.EditedFormattedValue.ToString() == "Edit")
                {

                    FlightMaster.Model.Luxuries selected = new FlightMaster.Model.Luxuries();

                    selected.Id = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                    selected.Name = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    selected.Icon = (byte[])dataGridView1.Rows[e.RowIndex].Cells[4].Value;

                    LuxuriesInsert frm = new LuxuriesInsert(selected);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        SetUpData();
                    }
                }
                if (cell.EditedFormattedValue.ToString() == "Delete")
                {
                    FlightMaster.Model.Luxuries selected = new FlightMaster.Model.Luxuries();

                    selected.Id = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()); //2
                    selected.Name = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();//3
                    selected.Icon = (byte[])dataGridView1.Rows[e.RowIndex].Cells[4].Value; //4

                   var res= MessageBox.Show("Do you want to delete luxury " + selected.Name, "Deletion?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        ApiCaller api = new ApiCaller();
                        bool deleted = await api.RemoveOneById<bool>("Luxuries", selected.Id);
                        if (deleted)
                        {
                            PopUp up = new PopUp(PopUp.PopUpType.Removal,"Luxury "+selected.Name+" succesfully deleted!");
                            up.Show();
                            SetUpData();
                        }
                    }

                }


            }
        }
    }
}
