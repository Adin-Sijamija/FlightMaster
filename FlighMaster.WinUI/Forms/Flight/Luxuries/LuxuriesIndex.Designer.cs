namespace FlighMaster.WinUI.Forms.Flight.Luxuries
{
    partial class LuxuriesIndex
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LuxName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LuxIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.LuxEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.LuxDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Luxuries";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.LuxName,
            this.LuxIcon,
            this.LuxEdit,
            this.LuxDelete});
            this.dataGridView1.Location = new System.Drawing.Point(12, 88);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(512, 255);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(449, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "New";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FlighMaster.WinUI.Properties.Resources.ajax_loader;
            this.pictureBox1.Location = new System.Drawing.Point(201, 186);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(121, 76);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // LuxName
            // 
            this.LuxName.DataPropertyName = "Name";
            this.LuxName.HeaderText = "Name";
            this.LuxName.Name = "LuxName";
            this.LuxName.ReadOnly = true;
            // 
            // LuxIcon
            // 
            this.LuxIcon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LuxIcon.DataPropertyName = "Icon";
            this.LuxIcon.HeaderText = "Icon";
            this.LuxIcon.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.LuxIcon.Name = "LuxIcon";
            this.LuxIcon.ReadOnly = true;
            this.LuxIcon.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LuxIcon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // LuxEdit
            // 
            this.LuxEdit.HeaderText = "Edit";
            this.LuxEdit.Name = "LuxEdit";
            this.LuxEdit.ReadOnly = true;
            this.LuxEdit.Text = "Edit";
            this.LuxEdit.UseColumnTextForButtonValue = true;
            // 
            // LuxDelete
            // 
            this.LuxDelete.HeaderText = "Delete";
            this.LuxDelete.Name = "LuxDelete";
            this.LuxDelete.ReadOnly = true;
            this.LuxDelete.Text = "Delete";
            this.LuxDelete.UseColumnTextForButtonValue = true;
            // 
            // LuxuriesIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 351);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "LuxuriesIndex";
            this.Text = "LuxuriesIndex";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn LuxName;
        private System.Windows.Forms.DataGridViewImageColumn LuxIcon;
        private System.Windows.Forms.DataGridViewButtonColumn LuxEdit;
        private System.Windows.Forms.DataGridViewButtonColumn LuxDelete;
    }
}