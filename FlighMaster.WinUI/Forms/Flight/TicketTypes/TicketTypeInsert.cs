using FlighMaster.WinUI.Api;
using FlighMaster.WinUI.Style;
using FlightMaster.Model;
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

namespace FlighMaster.WinUI.Forms.Flight.TicketTypes
{
    public partial class TicketTypeInsert : Form
    {

        private TicketType ticket;
        private Bitmap img;
        public TicketTypeInsert(TicketType type = null)
        {
            InitializeComponent();

            pictureBox1.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            this.DialogResult = DialogResult.OK;
            if (type == null)
            {
            }
            else
            {
                ticket = type;
                this.Text = "Ticket Type Edit";
                textBox1.Text = ticket.Name;
                label1.Text = "Ticket Type Edit";
                button2.Text = "Edit";
                pictureBox1.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                var ms = new MemoryStream(type.Icon);
                pictureBox1.Image = Image.FromStream(ms);
               
            }

          
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
                label4.Visible = true;
                label5.Visible = true;
                label5.Text = openFileDialog1.FileName;
                
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {


                if (ticket == null)
                {
                    ticket = new TicketType();
                    ticket.Name = textBox1.Text;

                    ImageConverter converter = new ImageConverter();
                    ticket.Icon = (byte[])converter.ConvertTo(img, typeof(byte[]));

                    if (ticket.Icon == null)
                    {
                        MessageBox.Show("Error", "Icon required!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    ApiCaller api = new ApiCaller();
                    TicketType createdTicket = await api.Insert<TicketType>(ticket, "TicketType");

                    if (createdTicket != null)
                    {
                        PopUp up = new PopUp(PopUp.PopUpType.Addtion, "TicketType succesfully added!");
                        up.Show();
                        textBox1.Text = "";
                    }
                }
                else
                {

                    TicketType edited = new TicketType();

                    if (img != null)
                    {
                        ImageConverter converter = new ImageConverter();
                        edited.Icon = (byte[])converter.ConvertTo(img, typeof(byte[]));
                    }
                    else
                    {
                        edited.Icon = ticket.Icon;
                    }
                    
                    edited.Name = textBox1.Text;
                    edited.Id = ticket.Id;

                    ApiCaller api = new ApiCaller();
                    TicketType createdTicket = await api.UpdateOne<TicketType>("TicketType", edited);

                    if (createdTicket != null)
                    {
                        PopUp up = new PopUp(PopUp.PopUpType.Edit, "TicketType succesfully eddited!");
                        up.Show();
                    }

                }
               


            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            IsValid();
        }

        private bool IsValid()
        {

            if (textBox1.Text.Length < 3)
            {
                errorProvider1.SetError(textBox1, "Must be atleast 4 letters long");
                return false;
            }

            if (textBox1.Text.Length > 30)
            {
                errorProvider1.SetError(textBox1, "Must be less than 30 letters long");
                return false;
            }
            if(Text.Length==0)
            {
                errorProvider1.SetError(textBox1, "Required field");
                return false;
            }

            if (ticket == null)
            {
                if (img == null)
                {
                    errorProvider1.SetError(button1, "Icon is required");
                    return false;
                }
            }
           


            return true;
        }

        private void TicketTypeInsert_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            
        }
    }
}
