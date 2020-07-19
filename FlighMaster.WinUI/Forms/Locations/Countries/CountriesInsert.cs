using FlighMaster.WinUI.Api;
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

namespace FlighMaster.WinUI.Forms.Locations.Countries
{
    public partial class CountriesInsert : Form
    {
        public Country EditedCountry=null;
        public CountriesInsert(Country country=null)
        {
            this.DialogResult = DialogResult.OK;

            InitializeComponent();
            if (country != null)
            {
                this.EditedCountry = country;
                SetUpEdit();
            }
        }

        private void SetUpEdit()
        {
            label1.Text = "Edit country " + EditedCountry.Name;
            textBox1.Text = EditedCountry.Name;
            textBox2.Text = EditedCountry.ShortName;
            button1.Text = "Edit";
            this.Text = "Country Edit";

        }

        private async void button1_Click(object sender, EventArgs e)
        {

            if(validatetextbox1() && validatetextbox2())
            {
                if (EditedCountry == null)
                {
                    ApiCaller api = new ApiCaller();
                    Country NewCountry = new Country()
                    {
                        Name = textBox1.Text,
                        ShortName = textBox2.Text
                    };
                    Country country1 = await api.Insert<Country>(NewCountry, "Countries");

                    if (country1 != null)
                    {
                        Style.PopUp popUp = new Style.PopUp(Style.PopUp.PopUpType.Addtion, "Country succesfully added!");
                        popUp.Show();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    ApiCaller api = new ApiCaller();
                    Country edited = new Country()
                    {
                        Id= EditedCountry.Id,
                        Name = textBox1.Text,
                        ShortName = textBox2.Text

                    };
                    Country country = await api.UpdateOne<Country>("Countries", edited);

                    if (country != null)
                    {
                        Style.PopUp popUp = new Style.PopUp(Style.PopUp.PopUpType.Edit, "Country succesfully edited!");
                        popUp.Show();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }

                }

            }



        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            validatetextbox1();
           
        }

        private bool validatetextbox1()
        {
            if (textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "Required field");
                return false;
            }
            if (textBox1.Text.Length < 3)
            {
                errorProvider1.SetError(textBox1, "Must be atleast 3 characters long");

                return false;
            }

            if (textBox1.Text.Length >30)
            {
                errorProvider1.SetError(textBox1, "Must be less than 30 characters long");

                return false;
            }
            return true;

        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            validatetextbox2();
        }

        private bool validatetextbox2()
        {

            if (textBox2.Text == "")
            {
                errorProvider1.SetError(textBox2, "Required field");
                return false;
            }
            if (textBox2.Text.Length < 2)
            {
                errorProvider1.SetError(textBox2, "Must be atleast 2 characters long");

                return false;
            }

            if (textBox2.Text.Length > 4)
            {
                errorProvider1.SetError(textBox2, "Must be less than 4 characters long");

                return false;
            }
            return true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
