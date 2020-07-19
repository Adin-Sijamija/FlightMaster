using FlighMaster.WinUI.Api;
using FlighMaster.WinUI.Style;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FlighMaster.WinUI.Forms.Flight.Luxuries
{
    public partial class LuxuriesInsert : Form
    {
        public FlightMaster.Model.Luxuries luxury;
        public Bitmap img;
        public LuxuriesInsert(FlightMaster.Model.Luxuries luxuries)
        {
            InitializeComponent();

            if (luxuries != null)
            {
                luxury = luxuries;
                SetUpEdit();
            }
            else
            {

            }
        }

        private void SetUpEdit()
        {

            label1.Text = "Edit " + luxury.Name;
            textBox1.Text = luxury.Name;
            var ms = new MemoryStream(luxury.Icon);
            pictureBox1.Image = Image.FromStream(ms);
            PictureLabel.Visible = true;
            pictureBox1.Visible = true;
            button1.Text = "Change";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Select picture";
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png";


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                img = new Bitmap(openFileDialog1.FileName);

                pictureBox1.Image = img;
                pictureBox1.Visible = true;
                FlileRoutLabel.Visible = true;
                FlileRoutLabel.Text = openFileDialog1.FileName;

            }
        }

        private async void Save_Click(object sender, EventArgs e)
        {




            if (ISValid())
            {
                if (luxury != null)
                {
                    bool Differnt = false;

                    FlightMaster.Model.Luxuries EditedLux = new FlightMaster.Model.Luxuries();
                    EditedLux.Id = luxury.Id;
                    EditedLux.Name = textBox1.Text;
                 
                    if (img == null)
                    {
                        EditedLux.Icon = luxury.Icon;
                    }
                    else
                    {
                        ImageConverter converter = new ImageConverter();
                        EditedLux.Icon = (byte[])converter.ConvertTo(img, typeof(byte[]));

                    }


                    if (EditedLux.Name != luxury.Name || EditedLux.Icon != luxury.Icon)
                        Differnt = true;

                    if (Differnt)
                    {
                        ApiCaller api = new ApiCaller();
                        FlightMaster.Model.Luxuries Edited = await api.UpdateOne<FlightMaster.Model.Luxuries>("Luxuries", EditedLux);
                        if (Edited != null)
                        {
                            this.DialogResult = DialogResult.OK;
                            PopUp up = new PopUp(PopUp.PopUpType.Edit, "Luxuries succesfully eddited");
                            up.Show();
                        }
                    }


                }
                else
                {


                    if (pictureBox1.Image == null)
                    {
                        errorProvider1.SetError(button1, "Please select image!");
                        return;
                    }
                    else
                    {
                        errorProvider1.Clear();
                    }

                    FlightMaster.Model.Luxuries NewLux = new FlightMaster.Model.Luxuries();
                    NewLux.Name = textBox1.Text;
                    ImageConverter converter = new ImageConverter();
                    NewLux.Icon = (byte[])converter.ConvertTo(img, typeof(byte[]));

                    if (NewLux.Icon == null)
                    {
                        MessageBox.Show("Error", "Icon required!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    ApiCaller api = new ApiCaller();

                    FlightMaster.Model.Luxuries CreatedLux = await api.Insert<FlightMaster.Model.Luxuries>(NewLux, "Luxuries");
                    if (CreatedLux != null)
                    {
                        this.DialogResult = DialogResult.OK;
                        PopUp up = new PopUp(PopUp.PopUpType.Addtion, "Luxuries succesfully created");
                        up.Show();
                    }

                }


            }
        }

        private void textBox1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ISValid();
        }

        private bool ISValid()
        {
            if (textBox1.Text.Length < 2)
            {
                errorProvider1.SetError(textBox1, "Must be atleast 2 characters long");
                return false;
            }

            if (textBox1.Text.Length > 30)
            {
                errorProvider1.SetError(textBox1, "Must be less than 30 characters long");
                return false;
            }

            return true;
        }
    }
}
