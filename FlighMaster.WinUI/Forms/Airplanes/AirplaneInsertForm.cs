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

namespace FlighMaster.WinUI.Forms.Airplanes
{
    public partial class AirplaneInsertForm : Form
    {
        public AirplaneInsertForm()
        {
            InitializeComponent();
            setCompanyData();
            SetPlaneTypeData();
        }

        private async void SetPlaneTypeData()
        {
            ApiCaller api = new ApiCaller();
            List<PlaneType> comp = await api.GetAll<List<PlaneType>>("PlaneType");
            comboBox2.DataSource = comp;
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Id";
            label6.Visible = false;
        }

        private async void setCompanyData()
        {
            ApiCaller api = new ApiCaller();
            List<Company> comp = await api.GetAll<List<Company>>("Companies");
            comboBox1.DataSource = comp;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
            label4.Visible = false;

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            ApiCaller api = new ApiCaller();
            Plane newly = new Plane() { Name = textBox1.Text.ToString() };


            Plane plane =await api.Insert<Plane>(new AirPlaneInsertModel()
            {
                plane = newly,
                CompanyId = (int)comboBox1.SelectedValue,
                PlaneTypeId=(int)comboBox2.SelectedValue
            },
            "Plane");

            if (plane!=null)
            {

                PopUp popUp = new PopUp(PopUp.PopUpType.Addtion, "Airplane succesfully created!");
                popUp.Show();
                textBox1.Text = "";
            }


        }
    }
}
