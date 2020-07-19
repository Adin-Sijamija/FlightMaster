using FlighMaster.WinUI.Api;
using FlighMaster.WinUI.Forms.Locations.Cities;
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
using Transitions;

namespace FlighMaster.WinUI.Forms.Locations.Countries
{
    public partial class DrzaveIndex : Form
    {
        public DrzaveIndex()
        {
            
            InitializeComponent();
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Visible = false;

            LoadData();
        }

        private async void LoadData()
        {

            pictureBox1.Visible = true;
            ApiCaller api=new ApiCaller();
            List<FlightMaster.Model.Country> data=await api.GetAll<List<FlightMaster.Model.Country>>("Countries");
            dataGridView1.DataSource = data;
            pictureBox1.Visible = false;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;

            ApiCaller api = new ApiCaller();
            List<FlightMaster.Model.Country> data = await api.SearchAll<List<FlightMaster.Model.Country>>("Countries", textBox1.Text, "Search");
            dataGridView1.DataSource = data;
            pictureBox1.Visible = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadData();
            textBox1.Text = String.Empty;
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
                 

                    Country country = new Country();
                    country.Id = (int) senderGrid.Rows[e.RowIndex].Cells[2].Value;
                    country.Name = (string) senderGrid.Rows[e.RowIndex].Cells[3].Value;
                    country.ShortName = (string)senderGrid.Rows[e.RowIndex].Cells[4].Value;

                    CountriesInsert insfrm = new CountriesInsert(country);
                    if (insfrm.ShowDialog()==DialogResult.OK)
                    {
                        if (textBox1.Text!=null)
                        {
                            LoadData();
                        }
                        else
                        {
                            button1.PerformClick();
                        }
                    }

                }

                if (cell.EditedFormattedValue.ToString() == "Delete")
                {

                    Country country = new Country();
                    country.Id = (int)senderGrid.Rows[e.RowIndex].Cells[2].Value;
                    country.Name = (string)senderGrid.Rows[e.RowIndex].Cells[3].Value;
                    country.ShortName = (string)senderGrid.Rows[e.RowIndex].Cells[4].Value;

                   DialogResult dialog= MessageBox.Show("Do you want to delete country " + country.Name + " ?", "Deletion?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog==DialogResult.Yes)
                    {
                        ApiCaller api = new ApiCaller();
                        bool result = await api.RemoveOneById<bool>("Countries", country.Id);

                        if (result)
                        {
                            PopUp up = new PopUp(PopUp.PopUpType.Removal, "Country successfully removed!");
                            up.Show();

                            if (textBox1.Text != null)
                            {
                                LoadData();
                            }
                            else
                            {
                                button1.PerformClick();
                            }
                        }

                    }
                  


                }

                if (cell.EditedFormattedValue.ToString() == "View Cities")
                {
                    Country country = new Country();
                    country.Id = (int)senderGrid.Rows[e.RowIndex].Cells[2].Value;
                    country.Name = (string)senderGrid.Rows[e.RowIndex].Cells[3].Value;
                    country.ShortName = (string)senderGrid.Rows[e.RowIndex].Cells[4].Value;

                    CitiesIndex frm = new CitiesIndex(country);
                    frm.Show();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            CountriesInsert insfrm = new CountriesInsert(null);
            if (insfrm.ShowDialog() == DialogResult.OK)
            {
                if (textBox1.Text != null)
                {
                    LoadData();
                }
                else
                {
                    button1.PerformClick();
                }
            }
        }
    }

}
