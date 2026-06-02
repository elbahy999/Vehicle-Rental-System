namespace projjjjj
{
    partial class VehicleForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.txtVehicleID = new System.Windows.Forms.TextBox();
            this.lblPlate = new System.Windows.Forms.Label();
            this.txtPlate = new System.Windows.Forms.TextBox();
            this.lblVehicleType = new System.Windows.Forms.Label();
            this.txtVehicleType = new System.Windows.Forms.TextBox();
            this.lblBrand = new System.Windows.Forms.Label();
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.lblDailyRate = new System.Windows.Forms.Label();
            this.txtDailyRate = new System.Windows.Forms.TextBox();
            this.chkIsAvailable = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClearFields = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.dgvVehicles = new System.Windows.Forms.DataGridView();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicles)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(54)))), ((int)(((byte)(93)))));
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(-5, -8);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1286, 68);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Vehicle Manager";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblID
            // 
            this.lblID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblID.Location = new System.Drawing.Point(261, 115);
            this.lblID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(96, 27);
            this.lblID.TabIndex = 2;
            this.lblID.Text = "Vehicle ID";
            // 
            // txtVehicleID
            // 
            this.txtVehicleID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.txtVehicleID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtVehicleID.Location = new System.Drawing.Point(261, 145);
            this.txtVehicleID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtVehicleID.Name = "txtVehicleID";
            this.txtVehicleID.ReadOnly = true;
            this.txtVehicleID.Size = new System.Drawing.Size(95, 30);
            this.txtVehicleID.TabIndex = 3;
            // 
            // lblPlate
            // 
            this.lblPlate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPlate.Location = new System.Drawing.Point(377, 115);
            this.lblPlate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPlate.Name = "lblPlate";
            this.lblPlate.Size = new System.Drawing.Size(135, 27);
            this.lblPlate.TabIndex = 4;
            this.lblPlate.Text = "License Plate";
            // 
            // txtPlate
            // 
            this.txtPlate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPlate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPlate.Location = new System.Drawing.Point(377, 145);
            this.txtPlate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPlate.Name = "txtPlate";
            this.txtPlate.Size = new System.Drawing.Size(153, 30);
            this.txtPlate.TabIndex = 5;
            // 
            // lblVehicleType
            // 
            this.lblVehicleType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblVehicleType.Location = new System.Drawing.Point(550, 115);
            this.lblVehicleType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVehicleType.Name = "lblVehicleType";
            this.lblVehicleType.Size = new System.Drawing.Size(135, 27);
            this.lblVehicleType.TabIndex = 6;
            this.lblVehicleType.Text = "Vehicle Type";
            // 
            // txtVehicleType
            // 
            this.txtVehicleType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtVehicleType.Location = new System.Drawing.Point(550, 145);
            this.txtVehicleType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtVehicleType.Name = "txtVehicleType";
            this.txtVehicleType.Size = new System.Drawing.Size(192, 30);
            this.txtVehicleType.TabIndex = 7;
            // 
            // lblBrand
            // 
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBrand.Location = new System.Drawing.Point(763, 115);
            this.lblBrand.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(77, 27);
            this.lblBrand.TabIndex = 8;
            this.lblBrand.Text = "Brand";
            // 
            // txtBrand
            // 
            this.txtBrand.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBrand.Location = new System.Drawing.Point(763, 145);
            this.txtBrand.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.Size = new System.Drawing.Size(192, 30);
            this.txtBrand.TabIndex = 9;
            // 
            // lblDailyRate
            // 
            this.lblDailyRate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDailyRate.Location = new System.Drawing.Point(975, 115);
            this.lblDailyRate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDailyRate.Name = "lblDailyRate";
            this.lblDailyRate.Size = new System.Drawing.Size(135, 27);
            this.lblDailyRate.TabIndex = 10;
            this.lblDailyRate.Text = "Daily Rate ($)";
            // 
            // txtDailyRate
            // 
            this.txtDailyRate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDailyRate.Location = new System.Drawing.Point(975, 145);
            this.txtDailyRate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDailyRate.Name = "txtDailyRate";
            this.txtDailyRate.Size = new System.Drawing.Size(127, 30);
            this.txtDailyRate.TabIndex = 11;
            // 
            // chkIsAvailable
            // 
            this.chkIsAvailable.Checked = true;
            this.chkIsAvailable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsAvailable.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkIsAvailable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.chkIsAvailable.Location = new System.Drawing.Point(1123, 149);
            this.chkIsAvailable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkIsAvailable.Name = "chkIsAvailable";
            this.chkIsAvailable.Size = new System.Drawing.Size(129, 32);
            this.chkIsAvailable.TabIndex = 12;
            this.chkIsAvailable.Text = "Available";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(26, 210);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(129, 47);
            this.btnAdd.TabIndex = 18;
            this.btnAdd.Text = "+ Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(95)))), ((int)(((byte)(165)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(167, 210);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(129, 47);
            this.btnUpdate.TabIndex = 19;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(309, 210);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(129, 47);
            this.btnDelete.TabIndex = 21;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClearFields
            // 
            this.btnClearFields.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.btnClearFields.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFields.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClearFields.ForeColor = System.Drawing.Color.White;
            this.btnClearFields.Location = new System.Drawing.Point(450, 210);
            this.btnClearFields.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClearFields.Name = "btnClearFields";
            this.btnClearFields.Size = new System.Drawing.Size(141, 47);
            this.btnClearFields.TabIndex = 22;
            this.btnClearFields.Text = "Clear Fields";
            this.btnClearFields.UseVisualStyleBackColor = false;
            this.btnClearFields.Click += new System.EventHandler(this.btnClearFields_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(1201, 64);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(59, 56);
            this.btnBack.TabIndex = 23;
            this.btnBack.Text = "←";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dgvVehicles
            // 
            this.dgvVehicles.AllowUserToAddRows = false;
            this.dgvVehicles.AllowUserToDeleteRows = false;
            this.dgvVehicles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVehicles.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(54)))), ((int)(((byte)(93)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVehicles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvVehicles.ColumnHeadersHeight = 29;
            this.dgvVehicles.EnableHeadersVisualStyles = false;
            this.dgvVehicles.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvVehicles.Location = new System.Drawing.Point(26, 277);
            this.dgvVehicles.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvVehicles.MultiSelect = false;
            this.dgvVehicles.Name = "dgvVehicles";
            this.dgvVehicles.ReadOnly = true;
            this.dgvVehicles.RowHeadersWidth = 51;
            this.dgvVehicles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVehicles.Size = new System.Drawing.Size(1234, 548);
            this.dgvVehicles.TabIndex = 24;
            this.dgvVehicles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVehicles_CellClick);
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.lblStatus.Location = new System.Drawing.Point(26, 842);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(1234, 30);
            this.lblStatus.TabIndex = 25;
            this.lblStatus.Text = "Ready.";
            // 
            // VehicleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.ClientSize = new System.Drawing.Size(1263, 883);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.txtVehicleID);
            this.Controls.Add(this.lblPlate);
            this.Controls.Add(this.txtPlate);
            this.Controls.Add(this.lblVehicleType);
            this.Controls.Add(this.txtVehicleType);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.txtBrand);
            this.Controls.Add(this.lblDailyRate);
            this.Controls.Add(this.txtDailyRate);
            this.Controls.Add(this.chkIsAvailable);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClearFields);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dgvVehicles);
            this.Controls.Add(this.lblStatus);
            this.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.MaximumSize = new System.Drawing.Size(1281, 930);
            this.MinimumSize = new System.Drawing.Size(1281, 930);
            this.Name = "VehicleForm";
            this.Text = "Vehicle Manager";
            this.Load += new System.EventHandler(this.VehicleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // ── Private field declarations ─────────────────────────────────────────
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtVehicleID;
        private System.Windows.Forms.Label lblPlate;
        private System.Windows.Forms.TextBox txtPlate;
        private System.Windows.Forms.Label lblVehicleType;
        private System.Windows.Forms.TextBox txtVehicleType;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.TextBox txtBrand;
        private System.Windows.Forms.Label lblDailyRate;
        private System.Windows.Forms.TextBox txtDailyRate;
        private System.Windows.Forms.CheckBox chkIsAvailable;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClearFields;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridView dgvVehicles;
        private System.Windows.Forms.Label lblStatus;
    }
}
