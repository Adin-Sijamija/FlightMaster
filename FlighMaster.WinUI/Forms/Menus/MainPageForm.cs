using FlighMaster.WinUI.Api;
using FlighMaster.WinUI.Forms.Airplanes;
using FlighMaster.WinUI.Forms.Companies;
using FlighMaster.WinUI.Forms.Flight;
using FlighMaster.WinUI.Forms.Flight.Luxuries;
using FlighMaster.WinUI.Forms.Flight.TicketTypes;
using FlighMaster.WinUI.Forms.Locations.Airfields;
using FlighMaster.WinUI.Forms.Locations.Cities;
using FlighMaster.WinUI.Forms.Locations.Countries;
using FlighMaster.WinUI.Style;
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

namespace FlighMaster.WinUI.Forms.Menus
{
    public partial class MainPageForm : MdiParent
    {


        LogInForm LoginFrm;
        bool Authenticated = false;

        public MainPageForm()
        {
            InitializeComponent();
            LogInformShow();
        }

        private void EnableForm()
        {
            if (Authenticated)
            {
                this.ForceReleaseOfControls();

               
                return;
            }
            this.DisableControls();
            toolStripButton4.Enabled = true;
            toolStripButton5.Enabled = true;
        }



        private void LogInformShow()
        {
            LoginFrm = new LogInForm();
            ShowChildDialog(LoginFrm, ChildForm_LogIn);

        }

        private void ChildForm_LogIn(object sender, DialogResultArgs e)
        {

            if (e.Result == DialogResult.OK)
            {


                string Username = Properties.Settings.Default.UserName;
                string Role = Properties.Settings.Default.Role;
                string Token = Properties.Settings.Default.Token;
                string Picture = Properties.Settings.Default.Picture;

                byte[] bytes = System.Convert.FromBase64String(Picture);


                UserNameLable.Text += Username;
                UserRoleLable.Text += Role;


                Bitmap bmp;
                using (var ms = new MemoryStream(bytes))
                {
                    bmp = new Bitmap(ms);
                }
                pictureBox1.Image = bmp;

                toolStripButton4.Visible = false;
                toolStripButton5.Visible = false;

                Authenticated = true;

                EnableForm();

                return;
            }


            EnableForm();


            ((Form)sender).Dispose();
        }


        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            LoginFrm = new LogInForm();
            ShowChildDialog(LoginFrm, ChildForm_LogIn);


        }

        private async void toolStripButton3_Click(object sender, EventArgs e)
        {

            ApiCaller api = new ApiCaller();

            
                var list = await api.TestCall<List<FlightMaster.Model.User>>("Users", "GetAll");
                if (list != null)
                {
                    MessageBox.Show("TEST" + list.Count);
                }
         



           
        }





        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            RegisterForm frm = new RegisterForm();
            ShowChildDialog(frm, ChildForm_Register);

        }


        private void ChildForm_Register(object sender, DialogResultArgs e)
        {

            if (e.Result == DialogResult.OK)
            {


                string Username = Properties.Settings.Default.UserName;
                string Role = Properties.Settings.Default.Role;
                string Token = Properties.Settings.Default.Token;
                string Picture = Properties.Settings.Default.Picture;
                byte[] bytes = System.Convert.FromBase64String(Picture);


                UserNameLable.Text += Username;
                UserRoleLable.Text += Role;


                Bitmap bmp;
                using (var ms = new MemoryStream(bytes))
                {
                    bmp = new Bitmap(ms);
                }
                pictureBox1.Image = bmp;

                toolStripButton4.Visible = false;
                toolStripButton5.Visible = false;

                Authenticated = true;
                return;
            }


            EnableForm();


            ((Form)sender).Dispose();
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompaniesInsertForm frm = new CompaniesInsertForm(null);
            frm.MdiParent = this;
            frm.Show();
        }


        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AirplaneInsertForm form = new AirplaneInsertForm();
            form.MdiParent = this;
            form.Show();

        }

        private void aviationCompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompaniesIndexForm frm = new CompaniesIndexForm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void airplaneTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AirplaneTypeInsertForm frm = new AirplaneTypeInsertForm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void companyAirplaneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AirplaneInsertForm frm = new AirplaneInsertForm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void newToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            TicketTypeInsert frm = new TicketTypeInsert(null);
            frm.MdiParent = this;
            frm.Show();
        }

        private void indexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TicketTypeIndex frm = new TicketTypeIndex();
            frm.MdiParent = this;
            frm.Show();

        }

        private void countriesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void indexToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            LuxuriesIndex frm = new LuxuriesIndex();
            frm.MdiParent = this;
            frm.Show();
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LuxuriesInsert frm = new LuxuriesInsert(null);
            frm.MdiParent = this;
            frm.Show();
        }

        private void newFlightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FlightInsertForm frm = new FlightInsertForm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void indexToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            DrzaveIndex frm = new DrzaveIndex();
            frm.MdiParent = this;
            frm.Show();
        }

        private void insertToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CountriesInsert frm = new CountriesInsert(null);
            frm.MdiParent = this;
            frm.Show();
        }

        private void indexToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            CitiesIndex frm = new CitiesIndex();
            frm.MdiParent = this;
            frm.Show();
        }

        private void insertToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CitiesInsert frm = new CitiesInsert();
            frm.MdiParent = this;
            frm.Show();
        }

        private void indexToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            AirfieldIndex frm = new AirfieldIndex();
            frm.MdiParent = this;
            frm.Show();
        }

        private void insertToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            AirfieldInsert frm = new AirfieldInsert();
            frm.MdiParent = this;
            frm.Show();
        }

        private void indexToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FlightIndex frm = new FlightIndex();
            frm.MdiParent = this;
            frm.Show();
        }

        private void checkInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckInForm frm = new CheckInForm();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
