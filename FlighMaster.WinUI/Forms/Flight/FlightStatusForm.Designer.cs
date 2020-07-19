namespace FlighMaster.WinUI.Forms.Flight
{
    partial class FlightStatusForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FlightNameLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DurationLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.CurrentDepartureDateTime = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.NewDepartureDateTime = new System.Windows.Forms.DateTimePicker();
            this.CurrentArrivalDateTime = new System.Windows.Forms.DateTimePicker();
            this.NewArrivalDateTime = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label14 = new System.Windows.Forms.Label();
            this.NewDuration = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(11, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Flight Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Flight:";
            // 
            // FlightNameLabel
            // 
            this.FlightNameLabel.AutoSize = true;
            this.FlightNameLabel.Location = new System.Drawing.Point(106, 96);
            this.FlightNameLabel.Name = "FlightNameLabel";
            this.FlightNameLabel.Size = new System.Drawing.Size(66, 13);
            this.FlightNameLabel.TabIndex = 3;
            this.FlightNameLabel.Text = "FlightName..";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Duration:";
            // 
            // DurationLabel
            // 
            this.DurationLabel.AutoSize = true;
            this.DurationLabel.Location = new System.Drawing.Point(106, 159);
            this.DurationLabel.Name = "DurationLabel";
            this.DurationLabel.Size = new System.Drawing.Size(45, 13);
            this.DurationLabel.TabIndex = 5;
            this.DurationLabel.Text = "Loading";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Current Status:";
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(106, 121);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(51, 13);
            this.StatusLabel.TabIndex = 7;
            this.StatusLabel.Text = "Loading..";
            // 
            // CurrentDepartureDateTime
            // 
            this.CurrentDepartureDateTime.CustomFormat = "dd/MM/yyyy HH:mm";
            this.CurrentDepartureDateTime.Enabled = false;
            this.CurrentDepartureDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.CurrentDepartureDateTime.Location = new System.Drawing.Point(247, 71);
            this.CurrentDepartureDateTime.Name = "CurrentDepartureDateTime";
            this.CurrentDepartureDateTime.Size = new System.Drawing.Size(200, 20);
            this.CurrentDepartureDateTime.TabIndex = 9;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(247, 189);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(200, 21);
            this.comboBox1.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(244, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Current Departure Date:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(552, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "New Departure Date:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(552, 122);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "New Arrival Date:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(244, 122);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(102, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "Current Arrival Date:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(555, 189);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // NewDepartureDateTime
            // 
            this.NewDepartureDateTime.CustomFormat = "dd/MM/yyyy HH:mm";
            this.NewDepartureDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.NewDepartureDateTime.Location = new System.Drawing.Point(555, 71);
            this.NewDepartureDateTime.Name = "NewDepartureDateTime";
            this.NewDepartureDateTime.Size = new System.Drawing.Size(200, 20);
            this.NewDepartureDateTime.TabIndex = 19;
            this.NewDepartureDateTime.ValueChanged += new System.EventHandler(this.NewDateTimeChange);
            // 
            // CurrentArrivalDateTime
            // 
            this.CurrentArrivalDateTime.CustomFormat = "dd/MM/yyyy HH:mm";
            this.CurrentArrivalDateTime.Enabled = false;
            this.CurrentArrivalDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.CurrentArrivalDateTime.Location = new System.Drawing.Point(247, 138);
            this.CurrentArrivalDateTime.Name = "CurrentArrivalDateTime";
            this.CurrentArrivalDateTime.Size = new System.Drawing.Size(200, 20);
            this.CurrentArrivalDateTime.TabIndex = 20;
            // 
            // NewArrivalDateTime
            // 
            this.NewArrivalDateTime.CustomFormat = "dd/MM/yyyy HH:mm";
            this.NewArrivalDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.NewArrivalDateTime.Location = new System.Drawing.Point(555, 138);
            this.NewArrivalDateTime.Name = "NewArrivalDateTime";
            this.NewArrivalDateTime.Size = new System.Drawing.Size(200, 20);
            this.NewArrivalDateTime.TabIndex = 21;
            this.NewArrivalDateTime.ValueChanged += new System.EventHandler(this.NewDateTimeChange);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FlighMaster.WinUI.Properties.Resources.next;
            this.pictureBox1.Location = new System.Drawing.Point(462, 65);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(73, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::FlighMaster.WinUI.Properties.Resources.next;
            this.pictureBox2.Location = new System.Drawing.Point(462, 132);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(73, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 23;
            this.pictureBox2.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(14, 197);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 13);
            this.label14.TabIndex = 25;
            this.label14.Text = "New Duration:";
            // 
            // NewDuration
            // 
            this.NewDuration.AutoSize = true;
            this.NewDuration.Location = new System.Drawing.Point(107, 197);
            this.NewDuration.Name = "NewDuration";
            this.NewDuration.Size = new System.Drawing.Size(27, 13);
            this.NewDuration.TabIndex = 28;
            this.NewDuration.Text = "N/A";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FlightStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 253);
            this.Controls.Add(this.NewDuration);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.NewArrivalDateTime);
            this.Controls.Add(this.CurrentArrivalDateTime);
            this.Controls.Add(this.NewDepartureDateTime);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.CurrentDepartureDateTime);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DurationLabel);
            this.Controls.Add(this.FlightNameLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FlightStatusForm";
            this.Text = "Change Flight Status";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FlightStatusForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label FlightNameLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label DurationLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.DateTimePicker CurrentDepartureDateTime;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker NewDepartureDateTime;
        private System.Windows.Forms.DateTimePicker CurrentArrivalDateTime;
        private System.Windows.Forms.DateTimePicker NewArrivalDateTime;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label NewDuration;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}