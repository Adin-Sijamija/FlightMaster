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

namespace FlighMaster.WinUI.Style
{
    public partial class PopUp : Form
    {
        public PopUpType Type;
        public int Duration;
        public string message;
        public enum PopUpType
        {
            Info=1,
            Success=2,
            Danger=3,
            Failure=4,
            Removal=5,
            Addtion=6,
            Edit=7
              
        }

        public PopUp(PopUpType type,string Message)
        {
            //this.StartPosition = FormStartPosition.Manual;
            //Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
            //this.Left = workingArea.Left + workingArea.Width - this.Size.Width;
            //this.Top = workingArea.Top + workingArea.Height - this.Size.Height;
            //MessageBox.Show("Screen witdh::" + Screen.PrimaryScreen.WorkingArea.Width);
            //MessageBox.Show("Screen height::" + Screen.PrimaryScreen.WorkingArea.Height);
            //MessageBox.Show("Form witdh::" + this.Width);
            //MessageBox.Show("Form height::" + this.Height);
            this.Opacity = 0;
            FadeIn(this, 50);

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width-105,
                                   Screen.PrimaryScreen.WorkingArea.Height - this.Height+100);
            InitializeComponent();
            SetUpNotifcation(type,Duration,Message);
            FadeOut(this, 50);
        }

       

        private void SetUpNotifcation(PopUpType type, int duration, string message)
        {
            label1.Text = message;
            //pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;

            switch (type)
            {
                case PopUpType.Info:
                    pictureBox1.Image = Properties.Resources.chat;
                    this.BackColor = Color.LightGray;
                    break;
                case PopUpType.Success:
                    pictureBox1.Image = Properties.Resources._checked;
                    this.BackColor = Color.LightGreen;
                    break;
                case PopUpType.Danger:
                    pictureBox1.Image = Properties.Resources.warning;
                    this.BackColor = Color.LightCyan;
                    break;
                case PopUpType.Failure:
                    pictureBox1.Image = Properties.Resources.cancel;
                    this.BackColor = Color.LightCyan;
                    break;
                case PopUpType.Removal:
                    pictureBox1.Image = Properties.Resources.trash;
                    this.BackColor = Color.LightGreen;
                    break;
                case PopUpType.Addtion:
                    pictureBox1.Image = Properties.Resources.folder;
                    this.BackColor = Color.LightGreen;
                    break;
                case PopUpType.Edit:
                    pictureBox1.Image = Properties.Resources.document;
                    this.BackColor = Color.LightGreen;
                    break;

                default:
                    break;
            }
        }

        private void PopUp_Load(object sender, EventArgs e)
        {

        }

        private async void FadeIn(Form o, int interval = 80)
        {
            //Object is not fully invisible. Fade it in
            while (o.Opacity < 1.0)
            {
                await Task.Delay(interval);
                o.Opacity += 0.05;
            }
            o.Opacity = 1; //make fully visible       
        }
        private async void FadeOut(Form o, int interval = 80)
        {
            await Task.Delay(5000);
            //Object is fully visible. Fade it out
            while (o.Opacity > 0.0)
            {
                await Task.Delay(interval);
                o.Opacity -= 0.05;
            }
            o.Opacity = 0; //make fully invisible 
            this.Close();
        }
    }
}
