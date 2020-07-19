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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlighMaster.WinUI.Forms.Airplanes
{
    public partial class AirplaneTypeInsertForm : Form
    {
     

        public AirplaneTypeInsertForm()
        {
            InitializeComponent();
        }

     

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            textbox1Validate();
        }


        private bool textbox1Validate()
        {


            if (textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "Required value");
                return false;

            }
            if (textBox1.Text != "")
                if (textBox1.Text.Length < 2)
                {
                    errorProvider1.SetError(textBox1, "Must be atleast2 characters value");
                    return false;
                }

            return true;
        }

        private void numericUpDown1_Validating(object sender, CancelEventArgs e)
        {
            numberValidation();
        }

        private bool numberValidation()
        {
            if (numericUpDown1.Value < 2)
            {
                errorProvider1.SetError(numericUpDown1, "Must have atleast 2 passangeres");
                return false;
            }
            return true;
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            
            PlaneType planeType = new PlaneType() { Name = textBox1.Text, TotalPassangeres = (int)numericUpDown1.Value };


            ApiCaller api = new ApiCaller();
            PlaneType data = await api.Insert<PlaneType>(planeType, "PlaneType");

            if (data != null)
            {
                PopUp popUp = new PopUp(PopUp.PopUpType.Addtion, "Airplane type succesfully created!");
                popUp.Show();
                textBox1.Text = "";
            }
        }
        
    }
}
