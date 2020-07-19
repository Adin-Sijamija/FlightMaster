namespace FlighMaster.WinUI.Forms.Companies
{
    partial class CompaniesInsertForm
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
            this.InfoTextLableNC = new System.Windows.Forms.Label();
            this.CompanyNameLableNC = new System.Windows.Forms.Label();
            this.CompanyNameTextBoxNC = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.CompanyLogoButtonNC = new System.Windows.Forms.Button();
            this.CompanyLogoLableNC = new System.Windows.Forms.Label();
            this.CompanyLogoPictureNC = new System.Windows.Forms.PictureBox();
            this.SaevBtnNC = new System.Windows.Forms.Button();
            this.FileNameLableNC = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.InsertFormDeleteBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyLogoPictureNC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // InfoTextLableNC
            // 
            this.InfoTextLableNC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InfoTextLableNC.AutoSize = true;
            this.InfoTextLableNC.Location = new System.Drawing.Point(20, 37);
            this.InfoTextLableNC.Name = "InfoTextLableNC";
            this.InfoTextLableNC.Size = new System.Drawing.Size(135, 13);
            this.InfoTextLableNC.TabIndex = 0;
            this.InfoTextLableNC.Text = "Add new aviation company";
            // 
            // CompanyNameLableNC
            // 
            this.CompanyNameLableNC.AutoSize = true;
            this.CompanyNameLableNC.Location = new System.Drawing.Point(20, 92);
            this.CompanyNameLableNC.Name = "CompanyNameLableNC";
            this.CompanyNameLableNC.Size = new System.Drawing.Size(35, 13);
            this.CompanyNameLableNC.TabIndex = 1;
            this.CompanyNameLableNC.Text = "Name";
            // 
            // CompanyNameTextBoxNC
            // 
            this.CompanyNameTextBoxNC.Location = new System.Drawing.Point(23, 109);
            this.CompanyNameTextBoxNC.Name = "CompanyNameTextBoxNC";
            this.CompanyNameTextBoxNC.Size = new System.Drawing.Size(100, 20);
            this.CompanyNameTextBoxNC.TabIndex = 2;
            this.CompanyNameTextBoxNC.Validating += new System.ComponentModel.CancelEventHandler(this.CompanyNameTextBoxNC_Validating);
            this.CompanyNameTextBoxNC.Validated += new System.EventHandler(this.CompanyNameTextBoxNC_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Company Logo";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // CompanyLogoButtonNC
            // 
            this.CompanyLogoButtonNC.Location = new System.Drawing.Point(23, 193);
            this.CompanyLogoButtonNC.Name = "CompanyLogoButtonNC";
            this.CompanyLogoButtonNC.Size = new System.Drawing.Size(75, 23);
            this.CompanyLogoButtonNC.TabIndex = 4;
            this.CompanyLogoButtonNC.Text = "Select";
            this.CompanyLogoButtonNC.UseVisualStyleBackColor = true;
            this.CompanyLogoButtonNC.Click += new System.EventHandler(this.button1_Click);
            // 
            // CompanyLogoLableNC
            // 
            this.CompanyLogoLableNC.AutoSize = true;
            this.CompanyLogoLableNC.Location = new System.Drawing.Point(346, 92);
            this.CompanyLogoLableNC.Name = "CompanyLogoLableNC";
            this.CompanyLogoLableNC.Size = new System.Drawing.Size(31, 13);
            this.CompanyLogoLableNC.TabIndex = 5;
            this.CompanyLogoLableNC.Text = "Logo";
            // 
            // CompanyLogoPictureNC
            // 
            this.CompanyLogoPictureNC.Location = new System.Drawing.Point(349, 109);
            this.CompanyLogoPictureNC.Name = "CompanyLogoPictureNC";
            this.CompanyLogoPictureNC.Size = new System.Drawing.Size(276, 241);
            this.CompanyLogoPictureNC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CompanyLogoPictureNC.TabIndex = 6;
            this.CompanyLogoPictureNC.TabStop = false;
            this.CompanyLogoPictureNC.Visible = false;
            // 
            // SaevBtnNC
            // 
            this.SaevBtnNC.Location = new System.Drawing.Point(23, 327);
            this.SaevBtnNC.Name = "SaevBtnNC";
            this.SaevBtnNC.Size = new System.Drawing.Size(75, 23);
            this.SaevBtnNC.TabIndex = 7;
            this.SaevBtnNC.Text = "Save";
            this.SaevBtnNC.UseVisualStyleBackColor = true;
            this.SaevBtnNC.Click += new System.EventHandler(this.SaevBtnNC_Click);
            // 
            // FileNameLableNC
            // 
            this.FileNameLableNC.AutoSize = true;
            this.FileNameLableNC.Location = new System.Drawing.Point(20, 219);
            this.FileNameLableNC.Name = "FileNameLableNC";
            this.FileNameLableNC.Size = new System.Drawing.Size(51, 13);
            this.FileNameLableNC.TabIndex = 8;
            this.FileNameLableNC.Text = "FileName";
            this.FileNameLableNC.Visible = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // InsertFormDeleteBtn
            // 
            this.InsertFormDeleteBtn.Location = new System.Drawing.Point(23, 357);
            this.InsertFormDeleteBtn.Name = "InsertFormDeleteBtn";
            this.InsertFormDeleteBtn.Size = new System.Drawing.Size(75, 23);
            this.InsertFormDeleteBtn.TabIndex = 9;
            this.InsertFormDeleteBtn.Text = "Delete";
            this.InsertFormDeleteBtn.UseVisualStyleBackColor = true;
            this.InsertFormDeleteBtn.Visible = false;
            this.InsertFormDeleteBtn.Click += new System.EventHandler(this.InsertFormDeleteBtn_Click);
            // 
            // CompaniesInsertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.InsertFormDeleteBtn);
            this.Controls.Add(this.FileNameLableNC);
            this.Controls.Add(this.SaevBtnNC);
            this.Controls.Add(this.CompanyLogoPictureNC);
            this.Controls.Add(this.CompanyLogoLableNC);
            this.Controls.Add(this.CompanyLogoButtonNC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CompanyNameTextBoxNC);
            this.Controls.Add(this.CompanyNameLableNC);
            this.Controls.Add(this.InfoTextLableNC);
            this.Name = "CompaniesInsertForm";
            this.Text = "New Company";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CompaniesInsertForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.CompanyLogoPictureNC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InfoTextLableNC;
        private System.Windows.Forms.Label CompanyNameLableNC;
        private System.Windows.Forms.TextBox CompanyNameTextBoxNC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button CompanyLogoButtonNC;
        private System.Windows.Forms.Label CompanyLogoLableNC;
        private System.Windows.Forms.PictureBox CompanyLogoPictureNC;
        private System.Windows.Forms.Button SaevBtnNC;
        private System.Windows.Forms.Label FileNameLableNC;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button InsertFormDeleteBtn;
    }
}