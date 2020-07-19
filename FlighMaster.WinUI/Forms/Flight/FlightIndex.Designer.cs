namespace FlighMaster.WinUI.Forms.Flight
{
    partial class FlightIndex
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.LocationsTab = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DepAirfield = new System.Windows.Forms.ComboBox();
            this.DepCity = new System.Windows.Forms.ComboBox();
            this.DepCountry = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ArrAirfield = new System.Windows.Forms.ComboBox();
            this.ArrCity = new System.Windows.Forms.ComboBox();
            this.ArrCountry = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.MaxDate = new System.Windows.Forms.DateTimePicker();
            this.MinDate = new System.Windows.Forms.DateTimePicker();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.OrderbyComboBox = new System.Windows.Forms.ComboBox();
            this.OderByLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.StatusComboBox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.PlaneTypeComboBox = new System.Windows.Forms.ComboBox();
            this.CompanyComboBox = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.PreviousButton = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.PageLabel = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.NextButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TravelDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlaneType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Company = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Capacity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TicketsSold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepartureLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArrivalLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TicketsRows = new System.Windows.Forms.DataGridViewButtonColumn();
            this.FlightStatusRow = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.LocationsTab.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.TravelDate,
            this.Status,
            this.PlaneType,
            this.Company,
            this.Capacity,
            this.TicketsSold,
            this.DepartureLocation,
            this.ArrivalLocation,
            this.TicketsRows,
            this.FlightStatusRow});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(341, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1035, 476);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // LocationsTab
            // 
            this.LocationsTab.Controls.Add(this.tabControl1);
            this.LocationsTab.Location = new System.Drawing.Point(12, 62);
            this.LocationsTab.Name = "LocationsTab";
            this.LocationsTab.Size = new System.Drawing.Size(317, 204);
            this.LocationsTab.TabIndex = 1;
            this.LocationsTab.TabStop = false;
            this.LocationsTab.Text = "Locations/Date";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(6, 19);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(305, 181);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.DepAirfield);
            this.tabPage1.Controls.Add(this.DepCity);
            this.tabPage1.Controls.Add(this.DepCountry);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(297, 155);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Departure";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Airfield:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "City:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Country:";
            // 
            // DepAirfield
            // 
            this.DepAirfield.FormattingEnabled = true;
            this.DepAirfield.Location = new System.Drawing.Point(59, 107);
            this.DepAirfield.Name = "DepAirfield";
            this.DepAirfield.Size = new System.Drawing.Size(232, 21);
            this.DepAirfield.TabIndex = 2;
            // 
            // DepCity
            // 
            this.DepCity.FormattingEnabled = true;
            this.DepCity.Location = new System.Drawing.Point(59, 65);
            this.DepCity.Name = "DepCity";
            this.DepCity.Size = new System.Drawing.Size(232, 21);
            this.DepCity.TabIndex = 1;
            // 
            // DepCountry
            // 
            this.DepCountry.FormattingEnabled = true;
            this.DepCountry.Location = new System.Drawing.Point(59, 20);
            this.DepCountry.Name = "DepCountry";
            this.DepCountry.Size = new System.Drawing.Size(232, 21);
            this.DepCountry.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.ArrAirfield);
            this.tabPage2.Controls.Add(this.ArrCity);
            this.tabPage2.Controls.Add(this.ArrCountry);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(297, 155);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Arrival";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Airfield:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "City:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Country:";
            // 
            // ArrAirfield
            // 
            this.ArrAirfield.FormattingEnabled = true;
            this.ArrAirfield.Location = new System.Drawing.Point(59, 110);
            this.ArrAirfield.Name = "ArrAirfield";
            this.ArrAirfield.Size = new System.Drawing.Size(232, 21);
            this.ArrAirfield.TabIndex = 8;
            // 
            // ArrCity
            // 
            this.ArrCity.FormattingEnabled = true;
            this.ArrCity.Location = new System.Drawing.Point(59, 68);
            this.ArrCity.Name = "ArrCity";
            this.ArrCity.Size = new System.Drawing.Size(232, 21);
            this.ArrCity.TabIndex = 7;
            // 
            // ArrCountry
            // 
            this.ArrCountry.FormattingEnabled = true;
            this.ArrCountry.Location = new System.Drawing.Point(59, 23);
            this.ArrCountry.Name = "ArrCountry";
            this.ArrCountry.Size = new System.Drawing.Size(232, 21);
            this.ArrCountry.TabIndex = 6;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.MaxDate);
            this.tabPage3.Controls.Add(this.MinDate);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(297, 155);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Date";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "End Date:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Start Date:";
            // 
            // MaxDate
            // 
            this.MaxDate.Location = new System.Drawing.Point(94, 92);
            this.MaxDate.MinDate = new System.DateTime(2000, 1, 20, 0, 0, 0, 0);
            this.MaxDate.Name = "MaxDate";
            this.MaxDate.Size = new System.Drawing.Size(200, 20);
            this.MaxDate.TabIndex = 2;
            this.MaxDate.Value = new System.DateTime(2000, 1, 20, 0, 0, 0, 0);
            this.MaxDate.ValueChanged += new System.EventHandler(this.MinDate_ValueChanged);
            // 
            // MinDate
            // 
            this.MinDate.Location = new System.Drawing.Point(94, 44);
            this.MinDate.MinDate = new System.DateTime(2000, 1, 20, 0, 0, 0, 0);
            this.MinDate.Name = "MinDate";
            this.MinDate.Size = new System.Drawing.Size(200, 20);
            this.MinDate.TabIndex = 0;
            this.MinDate.Value = new System.DateTime(2000, 1, 20, 0, 0, 0, 0);
            this.MinDate.ValueChanged += new System.EventHandler(this.MinDate_ValueChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage4.Controls.Add(this.OrderbyComboBox);
            this.tabPage4.Controls.Add(this.OderByLabel);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(297, 155);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "OderBy";
            // 
            // OrderbyComboBox
            // 
            this.OrderbyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OrderbyComboBox.FormattingEnabled = true;
            this.OrderbyComboBox.Location = new System.Drawing.Point(72, 65);
            this.OrderbyComboBox.Name = "OrderbyComboBox";
            this.OrderbyComboBox.Size = new System.Drawing.Size(201, 21);
            this.OrderbyComboBox.TabIndex = 8;
            // 
            // OderByLabel
            // 
            this.OderByLabel.AutoSize = true;
            this.OderByLabel.Location = new System.Drawing.Point(19, 65);
            this.OderByLabel.Name = "OderByLabel";
            this.OderByLabel.Size = new System.Drawing.Size(47, 13);
            this.OderByLabel.TabIndex = 5;
            this.OderByLabel.Text = "Oder by:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Flight Search";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.StatusComboBox);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.PlaneTypeComboBox);
            this.groupBox1.Controls.Add(this.CompanyComboBox);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(18, 294);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 204);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Miscellaneous";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 175);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(226, 175);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // StatusComboBox
            // 
            this.StatusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StatusComboBox.FormattingEnabled = true;
            this.StatusComboBox.Location = new System.Drawing.Point(91, 79);
            this.StatusComboBox.Name = "StatusComboBox";
            this.StatusComboBox.Size = new System.Drawing.Size(204, 21);
            this.StatusComboBox.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 82);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "Flight Status:";
            // 
            // PlaneTypeComboBox
            // 
            this.PlaneTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PlaneTypeComboBox.FormattingEnabled = true;
            this.PlaneTypeComboBox.Location = new System.Drawing.Point(91, 121);
            this.PlaneTypeComboBox.Name = "PlaneTypeComboBox";
            this.PlaneTypeComboBox.Size = new System.Drawing.Size(204, 21);
            this.PlaneTypeComboBox.TabIndex = 3;
            // 
            // CompanyComboBox
            // 
            this.CompanyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CompanyComboBox.FormattingEnabled = true;
            this.CompanyComboBox.Location = new System.Drawing.Point(91, 35);
            this.CompanyComboBox.Name = "CompanyComboBox";
            this.CompanyComboBox.Size = new System.Drawing.Size(204, 21);
            this.CompanyComboBox.TabIndex = 2;
            this.CompanyComboBox.SelectedIndexChanged += new System.EventHandler(this.CompanyComboBox_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 129);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Plane type:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Company:";
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.None;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorSeparator,
            this.PreviousButton,
            this.bindingNavigatorSeparator1,
            this.toolStripLabel1,
            this.PageLabel,
            this.bindingNavigatorSeparator2,
            this.NextButton,
            this.toolStripSeparator1});
            this.bindingNavigator1.Location = new System.Drawing.Point(1137, 491);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.Size = new System.Drawing.Size(208, 25);
            this.bindingNavigator1.TabIndex = 5;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // PreviousButton
            // 
            this.PreviousButton.Image = global::FlighMaster.WinUI.Properties.Resources.previous;
            this.PreviousButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.Size = new System.Drawing.Size(72, 22);
            this.PreviousButton.Text = "Previous";
            this.PreviousButton.Click += new System.EventHandler(this.PreviousButton_Click);
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(36, 22);
            this.toolStripLabel1.Text = "Page:";
            // 
            // PageLabel
            // 
            this.PageLabel.Name = "PageLabel";
            this.PageLabel.Size = new System.Drawing.Size(13, 22);
            this.PageLabel.Text = "1";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // NextButton
            // 
            this.NextButton.Image = global::FlighMaster.WinUI.Properties.Resources.next;
            this.NextButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(51, 22);
            this.NextButton.Text = "Next";
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FlighMaster.WinUI.Properties.Resources.ajax_loader;
            this.pictureBox1.Location = new System.Drawing.Point(822, 183);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(121, 103);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // TravelDate
            // 
            this.TravelDate.DataPropertyName = "FlightDate";
            this.TravelDate.HeaderText = "Travel Date";
            this.TravelDate.Name = "TravelDate";
            this.TravelDate.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 5;
            // 
            // PlaneType
            // 
            this.PlaneType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.PlaneType.DataPropertyName = "PlaneType";
            this.PlaneType.HeaderText = "PlaneType";
            this.PlaneType.Name = "PlaneType";
            this.PlaneType.ReadOnly = true;
            this.PlaneType.Width = 5;
            // 
            // Company
            // 
            this.Company.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Company.DataPropertyName = "Company";
            this.Company.HeaderText = "Company";
            this.Company.Name = "Company";
            this.Company.ReadOnly = true;
            this.Company.Width = 76;
            // 
            // Capacity
            // 
            this.Capacity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Capacity.DataPropertyName = "Capacity";
            this.Capacity.HeaderText = "Total Seats";
            this.Capacity.Name = "Capacity";
            this.Capacity.ReadOnly = true;
            this.Capacity.Width = 86;
            // 
            // TicketsSold
            // 
            this.TicketsSold.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TicketsSold.DataPropertyName = "TicketsSold";
            this.TicketsSold.HeaderText = "Sold Tickets";
            this.TicketsSold.Name = "TicketsSold";
            this.TicketsSold.ReadOnly = true;
            this.TicketsSold.Width = 91;
            // 
            // DepartureLocation
            // 
            this.DepartureLocation.DataPropertyName = "DepLocation";
            this.DepartureLocation.HeaderText = "Departure Location";
            this.DepartureLocation.Name = "DepartureLocation";
            this.DepartureLocation.ReadOnly = true;
            // 
            // ArrivalLocation
            // 
            this.ArrivalLocation.DataPropertyName = "ArrLocation";
            this.ArrivalLocation.HeaderText = "Arrival Location";
            this.ArrivalLocation.Name = "ArrivalLocation";
            this.ArrivalLocation.ReadOnly = true;
            // 
            // TicketsRows
            // 
            this.TicketsRows.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.TicketsRows.HeaderText = "Tickets";
            this.TicketsRows.Name = "TicketsRows";
            this.TicketsRows.ReadOnly = true;
            this.TicketsRows.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TicketsRows.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.TicketsRows.Text = "Tickets";
            this.TicketsRows.UseColumnTextForButtonValue = true;
            this.TicketsRows.Width = 5;
            // 
            // FlightStatusRow
            // 
            this.FlightStatusRow.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.FlightStatusRow.HeaderText = "Status";
            this.FlightStatusRow.Name = "FlightStatusRow";
            this.FlightStatusRow.ReadOnly = true;
            this.FlightStatusRow.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.FlightStatusRow.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.FlightStatusRow.Text = "Status";
            this.FlightStatusRow.UseColumnTextForButtonValue = true;
            this.FlightStatusRow.Width = 5;
            // 
            // FlightIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1388, 520);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LocationsTab);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FlightIndex";
            this.Text = "FlightIndex";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.LocationsTab.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox LocationsTab;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox DepAirfield;
        private System.Windows.Forms.ComboBox DepCity;
        private System.Windows.Forms.ComboBox DepCountry;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox ArrAirfield;
        private System.Windows.Forms.ComboBox ArrCity;
        private System.Windows.Forms.ComboBox ArrCountry;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker MaxDate;
        private System.Windows.Forms.DateTimePicker MinDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox PlaneTypeComboBox;
        private System.Windows.Forms.ComboBox CompanyComboBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox StatusComboBox;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripButton PreviousButton;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel PageLabel;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton NextButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ComboBox OrderbyComboBox;
        private System.Windows.Forms.Label OderByLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn TravelDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlaneType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Company;
        private System.Windows.Forms.DataGridViewTextBoxColumn Capacity;
        private System.Windows.Forms.DataGridViewTextBoxColumn TicketsSold;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepartureLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArrivalLocation;
        private System.Windows.Forms.DataGridViewButtonColumn TicketsRows;
        private System.Windows.Forms.DataGridViewButtonColumn FlightStatusRow;
    }
}