namespace FlighMaster.WinUI.Forms.Companies
{
    partial class CompaniesIndexForm
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
            this.ComaniesIndexData = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.CompanySearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Company = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Logo = new System.Windows.Forms.DataGridViewImageColumn();
            this.Options = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ComaniesIndexData)).BeginInit();
            this.SuspendLayout();
            // 
            // ComaniesIndexData
            // 
            this.ComaniesIndexData.AllowUserToAddRows = false;
            this.ComaniesIndexData.AllowUserToDeleteRows = false;
            this.ComaniesIndexData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ComaniesIndexData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Company,
            this.Logo,
            this.Options});
            this.ComaniesIndexData.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ComaniesIndexData.Location = new System.Drawing.Point(0, 146);
            this.ComaniesIndexData.Name = "ComaniesIndexData";
            this.ComaniesIndexData.ReadOnly = true;
            this.ComaniesIndexData.RowTemplate.Height = 50;
            this.ComaniesIndexData.Size = new System.Drawing.Size(800, 304);
            this.ComaniesIndexData.TabIndex = 0;
            this.ComaniesIndexData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ComaniesIndexData_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Companies index";
            // 
            // CompanySearch
            // 
            this.CompanySearch.Location = new System.Drawing.Point(16, 95);
            this.CompanySearch.Name = "CompanySearch";
            this.CompanySearch.Size = new System.Drawing.Size(196, 20);
            this.CompanySearch.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Search";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(229, 91);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Find";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(310, 91);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Refresh";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // Company
            // 
            this.Company.DataPropertyName = "Name";
            this.Company.HeaderText = "Company";
            this.Company.Name = "Company";
            this.Company.ReadOnly = true;
            // 
            // Logo
            // 
            this.Logo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Logo.DataPropertyName = "Picture";
            this.Logo.HeaderText = "Logo";
            this.Logo.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Logo.Name = "Logo";
            this.Logo.ReadOnly = true;
            // 
            // Options
            // 
            this.Options.HeaderText = "Options";
            this.Options.Name = "Options";
            this.Options.ReadOnly = true;
            this.Options.Text = "Edit";
            this.Options.UseColumnTextForButtonValue = true;
            // 
            // CompaniesIndexForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CompanySearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ComaniesIndexData);
            this.Name = "CompaniesIndexForm";
            this.Text = "CompaniesIndexForm";
            ((System.ComponentModel.ISupportInitialize)(this.ComaniesIndexData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ComaniesIndexData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CompanySearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Company;
        private System.Windows.Forms.DataGridViewImageColumn Logo;
        private System.Windows.Forms.DataGridViewButtonColumn Options;
    }
}