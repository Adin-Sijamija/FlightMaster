namespace FlighMaster.WinUI.Forms.Flight
{
    partial class CheckInForm
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
            this.CheckInLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DepartureLabel = new System.Windows.Forms.Label();
            this.DestinationLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DurationLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.FlightProviderLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.TicketTypeLabel = new System.Windows.Forms.Label();
            this.TicketStatusLabel = new System.Windows.Forms.Label();
            this.SaveTicketButton = new System.Windows.Forms.Button();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.UserPicture = new System.Windows.Forms.PictureBox();
            this.CompanyLogo = new System.Windows.Forms.PictureBox();
            this.ActivateCodeButton = new System.Windows.Forms.Button();
            this.DepartureTime = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CanceledLabelWarning = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.UserPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // CheckInLabel
            // 
            this.CheckInLabel.AutoSize = true;
            this.CheckInLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.CheckInLabel.Location = new System.Drawing.Point(12, 9);
            this.CheckInLabel.Name = "CheckInLabel";
            this.CheckInLabel.Size = new System.Drawing.Size(122, 31);
            this.CheckInLabel.TabIndex = 0;
            this.CheckInLabel.Text = "Check In";
            this.CheckInLabel.Click += new System.EventHandler(this.CheckInLabel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(13, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Flight Info";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Departure:";
            // 
            // DepartureLabel
            // 
            this.DepartureLabel.AutoSize = true;
            this.DepartureLabel.Location = new System.Drawing.Point(146, 144);
            this.DepartureLabel.Name = "DepartureLabel";
            this.DepartureLabel.Size = new System.Drawing.Size(27, 13);
            this.DepartureLabel.TabIndex = 3;
            this.DepartureLabel.Text = "N/A";
            // 
            // DestinationLabel
            // 
            this.DestinationLabel.AutoSize = true;
            this.DestinationLabel.Location = new System.Drawing.Point(146, 171);
            this.DestinationLabel.Name = "DestinationLabel";
            this.DestinationLabel.Size = new System.Drawing.Size(27, 13);
            this.DestinationLabel.TabIndex = 5;
            this.DestinationLabel.Text = "N/A";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Destination:";
            // 
            // DurationLabel
            // 
            this.DurationLabel.AutoSize = true;
            this.DurationLabel.Location = new System.Drawing.Point(146, 233);
            this.DurationLabel.Name = "DurationLabel";
            this.DurationLabel.Size = new System.Drawing.Size(27, 13);
            this.DurationLabel.TabIndex = 7;
            this.DurationLabel.Text = "N/A";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 233);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Duration:";
            // 
            // FlightProviderLabel
            // 
            this.FlightProviderLabel.AutoSize = true;
            this.FlightProviderLabel.Location = new System.Drawing.Point(149, 322);
            this.FlightProviderLabel.Name = "FlightProviderLabel";
            this.FlightProviderLabel.Size = new System.Drawing.Size(27, 13);
            this.FlightProviderLabel.TabIndex = 9;
            this.FlightProviderLabel.Text = "N/A";
            this.FlightProviderLabel.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 322);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Flight Provide:";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(415, 136);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(196, 20);
            this.textBox1.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label10.Location = new System.Drawing.Point(410, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(162, 25);
            this.label10.TabIndex = 11;
            this.label10.Text = "Enter ticket code:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(410, 185);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(127, 25);
            this.label11.TabIndex = 12;
            this.label11.Text = "Code Status:";
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Location = new System.Drawing.Point(412, 253);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(38, 13);
            this.UserNameLabel.TabIndex = 13;
            this.UserNameLabel.Text = "Name:";
            // 
            // TicketTypeLabel
            // 
            this.TicketTypeLabel.AutoSize = true;
            this.TicketTypeLabel.Location = new System.Drawing.Point(412, 287);
            this.TicketTypeLabel.Name = "TicketTypeLabel";
            this.TicketTypeLabel.Size = new System.Drawing.Size(67, 13);
            this.TicketTypeLabel.TabIndex = 14;
            this.TicketTypeLabel.Text = "Ticket Type:";
            // 
            // TicketStatusLabel
            // 
            this.TicketStatusLabel.AutoSize = true;
            this.TicketStatusLabel.Location = new System.Drawing.Point(412, 322);
            this.TicketStatusLabel.Name = "TicketStatusLabel";
            this.TicketStatusLabel.Size = new System.Drawing.Size(73, 13);
            this.TicketStatusLabel.TabIndex = 15;
            this.TicketStatusLabel.Text = "Ticket Status:";
            // 
            // SaveTicketButton
            // 
            this.SaveTicketButton.Enabled = false;
            this.SaveTicketButton.Location = new System.Drawing.Point(617, 338);
            this.SaveTicketButton.Name = "SaveTicketButton";
            this.SaveTicketButton.Size = new System.Drawing.Size(100, 23);
            this.SaveTicketButton.TabIndex = 17;
            this.SaveTicketButton.Text = "Check In";
            this.SaveTicketButton.UseVisualStyleBackColor = true;
            this.SaveTicketButton.Click += new System.EventHandler(this.SaveTicketButton_Click);
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(146, 264);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(27, 13);
            this.StatusLabel.TabIndex = 20;
            this.StatusLabel.Text = "N/A";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(16, 264);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(40, 13);
            this.label16.TabIndex = 19;
            this.label16.Text = "Status:";
            // 
            // UserPicture
            // 
            this.UserPicture.Location = new System.Drawing.Point(617, 264);
            this.UserPicture.Name = "UserPicture";
            this.UserPicture.Size = new System.Drawing.Size(100, 50);
            this.UserPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.UserPicture.TabIndex = 18;
            this.UserPicture.TabStop = false;
            this.UserPicture.Visible = false;
            // 
            // CompanyLogo
            // 
            this.CompanyLogo.Location = new System.Drawing.Point(114, 338);
            this.CompanyLogo.Name = "CompanyLogo";
            this.CompanyLogo.Size = new System.Drawing.Size(100, 50);
            this.CompanyLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CompanyLogo.TabIndex = 16;
            this.CompanyLogo.TabStop = false;
            this.CompanyLogo.Visible = false;
            // 
            // ActivateCodeButton
            // 
            this.ActivateCodeButton.Location = new System.Drawing.Point(617, 134);
            this.ActivateCodeButton.Name = "ActivateCodeButton";
            this.ActivateCodeButton.Size = new System.Drawing.Size(75, 23);
            this.ActivateCodeButton.TabIndex = 21;
            this.ActivateCodeButton.Text = "Find";
            this.ActivateCodeButton.UseVisualStyleBackColor = true;
            this.ActivateCodeButton.Click += new System.EventHandler(this.ActivateCodeButton_Click);
            // 
            // DepartureTime
            // 
            this.DepartureTime.AutoSize = true;
            this.DepartureTime.Location = new System.Drawing.Point(146, 197);
            this.DepartureTime.Name = "DepartureTime";
            this.DepartureTime.Size = new System.Drawing.Size(27, 13);
            this.DepartureTime.TabIndex = 23;
            this.DepartureTime.Text = "N/A";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Departure Time:";
            // 
            // CanceledLabelWarning
            // 
            this.CanceledLabelWarning.AutoSize = true;
            this.CanceledLabelWarning.Location = new System.Drawing.Point(599, 364);
            this.CanceledLabelWarning.Name = "CanceledLabelWarning";
            this.CanceledLabelWarning.Size = new System.Drawing.Size(169, 13);
            this.CanceledLabelWarning.TabIndex = 24;
            this.CanceledLabelWarning.Text = "Can not check in a canceled flight";
            this.CanceledLabelWarning.Visible = false;
            // 
            // CheckInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 397);
            this.Controls.Add(this.CanceledLabelWarning);
            this.Controls.Add(this.DepartureTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ActivateCodeButton);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.UserPicture);
            this.Controls.Add(this.SaveTicketButton);
            this.Controls.Add(this.CompanyLogo);
            this.Controls.Add(this.TicketStatusLabel);
            this.Controls.Add(this.TicketTypeLabel);
            this.Controls.Add(this.UserNameLabel);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.FlightProviderLabel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.DurationLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.DestinationLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DepartureLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CheckInLabel);
            this.Name = "CheckInForm";
            this.Text = "CheckInForm";
            ((System.ComponentModel.ISupportInitialize)(this.UserPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CheckInLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label DepartureLabel;
        private System.Windows.Forms.Label DestinationLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label DurationLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label FlightProviderLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.Label TicketTypeLabel;
        private System.Windows.Forms.Label TicketStatusLabel;
        private System.Windows.Forms.PictureBox CompanyLogo;
        private System.Windows.Forms.Button SaveTicketButton;
        private System.Windows.Forms.PictureBox UserPicture;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button ActivateCodeButton;
        private System.Windows.Forms.Label DepartureTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label CanceledLabelWarning;
    }
}