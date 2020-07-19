using FlighMaster.WinUI.Api;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FlighMaster.WinUI.Forms.Companies
{
    public partial class CompaniesIndexForm : Form
    {
        private readonly ApiBuilder api = new ApiBuilder("Companies");
            string Token = Properties.Settings.Default.Token;

        public CompaniesIndexForm()
        {
            InitializeComponent();
            ComaniesIndexData.DataSource = null;
            loadData(1, "");
        }

       

        private async void loadData(int v1, string v2)
        {
                 
            //string url = "https://localhost:44369/api/Companies/Search?page=1";
            string url = "http://localhost:19228/api/Companies/Search?page=1";
            url.Replace("page=1", "page=" + v1);


            List<FlightMaster.Model.Company> data = await url.WithOAuthBearerToken(Token).GetJsonAsync<List<FlightMaster.Model.Company>>();
             ComaniesIndexData.DataSource = data;



        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Enabled = true;

            await SearchComapanies();

        }

        private async System.Threading.Tasks.Task SearchComapanies()
        {
            if (CompanySearch.Text.Length > 0)
            {
                string url = "http://localhost:19228/api/Companies/Search?page=1";
                url += "&search=" + CompanySearch.Text;


                List<FlightMaster.Model.Company> data = await url.WithOAuthBearerToken(Token).GetJsonAsync<List<FlightMaster.Model.Company>>();

                ComaniesIndexData.DataSource = data;
            }
        }


        private async void ComaniesIndexData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {

                DataGridViewCell cell = senderGrid.CurrentCell;

                FlightMaster.Model.Company selected = new FlightMaster.Model.Company();
                selected.Id = Int32.Parse(ComaniesIndexData.Rows[e.RowIndex].Cells[1].Value.ToString());
                selected.Name = ComaniesIndexData.Rows[e.RowIndex].Cells[2].Value.ToString();
                selected.Picture = (byte[])ComaniesIndexData.Rows[e.RowIndex].Cells[3].Value;

                if (cell.EditedFormattedValue.ToString()=="Edit") {


                    CompaniesInsertForm edit = new CompaniesInsertForm(selected);
                    if (edit.ShowDialog() == DialogResult.Yes)
                    {
                        if (CompanySearch.Text == "")
                        {
                            loadData(1, "");
                        }
                        else
                        {
                            await SearchComapanies();
                        }
                    }
                }

            




            
                    
            }
        }

        private async void  button2_Click(object sender, EventArgs e)
        {

            if (CompanySearch.Text == "") {
                loadData(1, "");
            }
            else
            {
                await SearchComapanies();
            }

        }
    }


 
}
