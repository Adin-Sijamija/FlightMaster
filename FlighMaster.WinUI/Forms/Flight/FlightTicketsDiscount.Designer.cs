namespace FlighMaster.WinUI.Forms.Flight
{
    partial class FlightTicketsDiscount
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SelectedTicketTypeLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SelectedCurrentTickets = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SelectedMaxTickets = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.DiscountTicketsCountNumeric = new System.Windows.Forms.NumericUpDown();
            this.DiscountPriceNumeric = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.FlightTicketTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TicketTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TicketTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentTickets = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxTickets = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TicketPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectFlightTicket = new System.Windows.Forms.DataGridViewButtonColumn();
            this.FlightIndetifier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DiscountTicketsCountNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DiscountPriceNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Flight Tickets";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FlightTicketTypeId,
            this.TicketTypeId,
            this.TicketTypeName,
            this.CurrentTickets,
            this.MaxTickets,
            this.TicketPrice,
            this.SelectFlightTicket,
            this.FlightIndetifier});
            this.dataGridView1.Location = new System.Drawing.Point(12, 61);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(547, 294);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DiscountPriceNumeric);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.DiscountTicketsCountNumeric);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.SelectedMaxTickets);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.SelectedCurrentTickets);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.SelectedTicketTypeLabel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(605, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 294);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "New Discount";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ticket type:";
            // 
            // SelectedTicketTypeLabel
            // 
            this.SelectedTicketTypeLabel.AutoSize = true;
            this.SelectedTicketTypeLabel.Location = new System.Drawing.Point(100, 56);
            this.SelectedTicketTypeLabel.Name = "SelectedTicketTypeLabel";
            this.SelectedTicketTypeLabel.Size = new System.Drawing.Size(27, 13);
            this.SelectedTicketTypeLabel.TabIndex = 1;
            this.SelectedTicketTypeLabel.Text = "N/A";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(57, 232);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(216, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "Create Discount";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Current Tickets:";
            // 
            // SelectedCurrentTickets
            // 
            this.SelectedCurrentTickets.AutoSize = true;
            this.SelectedCurrentTickets.Location = new System.Drawing.Point(123, 98);
            this.SelectedCurrentTickets.Name = "SelectedCurrentTickets";
            this.SelectedCurrentTickets.Size = new System.Drawing.Size(13, 13);
            this.SelectedCurrentTickets.TabIndex = 5;
            this.SelectedCurrentTickets.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(184, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "of";
            // 
            // SelectedMaxTickets
            // 
            this.SelectedMaxTickets.AutoSize = true;
            this.SelectedMaxTickets.Location = new System.Drawing.Point(244, 98);
            this.SelectedMaxTickets.Name = "SelectedMaxTickets";
            this.SelectedMaxTickets.Size = new System.Drawing.Size(13, 13);
            this.SelectedMaxTickets.TabIndex = 7;
            this.SelectedMaxTickets.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 140);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Discount Tickets:";
            // 
            // DiscountTicketsCountNumeric
            // 
            this.DiscountTicketsCountNumeric.Location = new System.Drawing.Point(145, 140);
            this.DiscountTicketsCountNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.DiscountTicketsCountNumeric.Name = "DiscountTicketsCountNumeric";
            this.DiscountTicketsCountNumeric.Size = new System.Drawing.Size(163, 20);
            this.DiscountTicketsCountNumeric.TabIndex = 8;
            this.DiscountTicketsCountNumeric.ValueChanged += new System.EventHandler(this.DiscountTicketsCountNumeric_ValueChanged);
            // 
            // DiscountPriceNumeric
            // 
            this.DiscountPriceNumeric.Location = new System.Drawing.Point(145, 183);
            this.DiscountPriceNumeric.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.DiscountPriceNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DiscountPriceNumeric.Name = "DiscountPriceNumeric";
            this.DiscountPriceNumeric.Size = new System.Drawing.Size(163, 20);
            this.DiscountPriceNumeric.TabIndex = 10;
            this.DiscountPriceNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DiscountPriceNumeric.ValueChanged += new System.EventHandler(this.DiscountPriceNumeric_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 185);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Discount Ticket Price:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FlightTicketTypeId
            // 
            this.FlightTicketTypeId.DataPropertyName = "Id";
            this.FlightTicketTypeId.HeaderText = "FlightTicketTypeId";
            this.FlightTicketTypeId.Name = "FlightTicketTypeId";
            this.FlightTicketTypeId.ReadOnly = true;
            this.FlightTicketTypeId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FlightTicketTypeId.Visible = false;
            // 
            // TicketTypeId
            // 
            this.TicketTypeId.DataPropertyName = "TicketTypeID";
            this.TicketTypeId.HeaderText = "TicketTypeId";
            this.TicketTypeId.Name = "TicketTypeId";
            this.TicketTypeId.ReadOnly = true;
            this.TicketTypeId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TicketTypeId.Visible = false;
            // 
            // TicketTypeName
            // 
            this.TicketTypeName.DataPropertyName = "TicketTypeName";
            this.TicketTypeName.HeaderText = "TicketType";
            this.TicketTypeName.Name = "TicketTypeName";
            this.TicketTypeName.ReadOnly = true;
            this.TicketTypeName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CurrentTickets
            // 
            this.CurrentTickets.DataPropertyName = "CurrentTickets";
            this.CurrentTickets.HeaderText = "Current Tickets";
            this.CurrentTickets.Name = "CurrentTickets";
            this.CurrentTickets.ReadOnly = true;
            this.CurrentTickets.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MaxTickets
            // 
            this.MaxTickets.DataPropertyName = "MaxTickets";
            this.MaxTickets.HeaderText = "Max Tickets";
            this.MaxTickets.Name = "MaxTickets";
            this.MaxTickets.ReadOnly = true;
            this.MaxTickets.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TicketPrice
            // 
            this.TicketPrice.DataPropertyName = "Price";
            this.TicketPrice.HeaderText = "Price";
            this.TicketPrice.Name = "TicketPrice";
            this.TicketPrice.ReadOnly = true;
            this.TicketPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SelectFlightTicket
            // 
            this.SelectFlightTicket.HeaderText = "Options";
            this.SelectFlightTicket.Name = "SelectFlightTicket";
            this.SelectFlightTicket.ReadOnly = true;
            this.SelectFlightTicket.Text = "Select";
            this.SelectFlightTicket.UseColumnTextForButtonValue = true;
            // 
            // FlightIndetifier
            // 
            this.FlightIndetifier.DataPropertyName = "FlightId";
            this.FlightIndetifier.HeaderText = "FlightIndetifier";
            this.FlightIndetifier.Name = "FlightIndetifier";
            this.FlightIndetifier.Visible = false;
            // 
            // FlightTicketsDiscount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 369);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "FlightTicketsDiscount";
            this.Text = "FlightTicketsDiscount";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DiscountTicketsCountNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DiscountPriceNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown DiscountPriceNumeric;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown DiscountTicketsCountNumeric;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label SelectedMaxTickets;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label SelectedCurrentTickets;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label SelectedTicketTypeLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FlightTicketTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TicketTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TicketTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentTickets;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxTickets;
        private System.Windows.Forms.DataGridViewTextBoxColumn TicketPrice;
        private System.Windows.Forms.DataGridViewButtonColumn SelectFlightTicket;
        private System.Windows.Forms.DataGridViewTextBoxColumn FlightIndetifier;
    }
}