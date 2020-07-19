using FlighMaster.WinUI.Style;
using FlightMaster.Model;
using Flurl.Http;
using Newtonsoft.Json;
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

namespace FlighMaster.WinUI.Forms.Companies
{
    public partial class CompaniesInsertForm : Form
    {
        private Bitmap img;
        private readonly ApiBuilder api = new ApiBuilder("Companies");
        private Company company;

        public CompaniesInsertForm(Company company)
        {
            if (company!=null)
            {
                this.company = company;
            }

            InitializeComponent();
            setForm();
        }

        private void setForm()
        {
            if (company!=null)
            {

                this.Text = "Company Edit";
                InfoTextLableNC.Text = "Edit Company " + company.Name;
                InsertFormDeleteBtn.Visible = true;

                var ms = new MemoryStream(company.Picture);
                CompanyLogoPictureNC.Image = Image.FromStream(ms);
                CompanyLogoPictureNC.Visible = true;
                CompanyLogoLableNC.Visible = true;


                CompanyNameTextBoxNC.Text = company.Name;

            }
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Select picture";
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                img = new Bitmap(openFileDialog1.FileName);
                CompanyLogoPictureNC.Image = new Bitmap(img);
                FileNameLableNC.Text = openFileDialog1.FileName;
                FileNameLableNC.Visible = true;
                CompanyLogoPictureNC.Visible = true;
                CompanyLogoLableNC.Visible = true;
            }
        }

        private void CompanyNameTextBoxNC_Validated(object sender, EventArgs e)
        {
            CompanyNameTextBoxNC.BorderStyle = BorderStyle.Fixed3D;
        }

        private void CompanyNameTextBoxNC_Validating(object sender, CancelEventArgs e)
        {
            check();
        }

        private bool check()
        {
            bool status = true;

            if (CompanyNameTextBoxNC.Text == "" || CompanyNameTextBoxNC.Text.Length < 3)
            {
                errorProvider1.SetError(CompanyNameTextBoxNC, "Filed is required");
                status = false;
            }

            return status;
        }

        private async void SaevBtnNC_Click(object sender, EventArgs e)
        {
            Company data = new Company();
           
            data.Name = CompanyNameTextBoxNC.Text;
            data.Picture = company==null? ImageToByte2(img):company.Picture;


            if (company == null)
            {
                Company comp = await api.Insert<Company>(data);
                PopUp popUp = new PopUp(PopUp.PopUpType.Addtion, "Company succesfully created!");
                popUp.Show();

            }
            else
            {
                if ((company.Name != data.Name && company.Picture == data.Picture) || (company.Name == data.Name && company.Picture != data.Picture))
                {
                    data.Id = company.Id;
                    Company updated = await api.Update<Company>(data.Id, data);

                    if(company.Picture != data.Picture)
                    {
                        using (var ms = new MemoryStream(data.Picture))
                        {
                            CompanyLogoPictureNC.Image = new Bitmap(ms);
                        }

                    }


                    PopUp popUp = new PopUp(PopUp.PopUpType.Addtion, "Company succesfully created!");
                    popUp.Show();
                }
                
            }


        }

        private async void InsertFormDeleteBtn_Click(object sender, EventArgs e)
        {

            DialogResult dialog = MessageBox.Show("Do you want to remove the company " + company.Name + "?", "Deletion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (dialog == DialogResult.OK)
            {
                bool result =await api.Remove<bool>(company.Id);
                if (result)
                {
                    PopUp popUp = new PopUp(PopUp.PopUpType.Removal, "Company sucesfully removed!");
                    popUp.Show();
                }
                this.Close();
            }

        }




        public static byte[] ImageToByte2(Image img)
        {
            using (var stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }

        private void CompaniesInsertForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }
    }
}
