namespace projjjjj
{
    partial class rentalLogger
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvRentals;
        private System.Windows.Forms.Button btnAddRental;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnMarkReturned;
        private System.Windows.Forms.Button Back;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvRentals = new System.Windows.Forms.DataGridView();
            this.btnAddRental = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnMarkReturned = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.txtVehicleID = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentals)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRentals
            // 
            this.dgvRentals.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.dgvRentals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRentals.Location = new System.Drawing.Point(15, 337);
            this.dgvRentals.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvRentals.Name = "dgvRentals";
            this.dgvRentals.RowHeadersWidth = 51;
            this.dgvRentals.Size = new System.Drawing.Size(1234, 541);
            this.dgvRentals.TabIndex = 0;
            // 
            // btnAddRental
            // 
            this.btnAddRental.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnAddRental.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRental.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAddRental.ForeColor = System.Drawing.Color.White;
            this.btnAddRental.Location = new System.Drawing.Point(15, 261);
            this.btnAddRental.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddRental.Name = "btnAddRental";
            this.btnAddRental.Size = new System.Drawing.Size(381, 53);
            this.btnAddRental.TabIndex = 1;
            this.btnAddRental.Text = "Add Rental";
            this.btnAddRental.UseVisualStyleBackColor = false;
            this.btnAddRental.Click += new System.EventHandler(this.btnAddRental_Click_1);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Brown;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(404, 261);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(176, 53);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click_1);
            // 
            // btnMarkReturned
            // 
            this.btnMarkReturned.BackColor = System.Drawing.Color.DarkGreen;
            this.btnMarkReturned.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarkReturned.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMarkReturned.ForeColor = System.Drawing.Color.White;
            this.btnMarkReturned.Location = new System.Drawing.Point(588, 261);
            this.btnMarkReturned.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMarkReturned.Name = "btnMarkReturned";
            this.btnMarkReturned.Size = new System.Drawing.Size(176, 53);
            this.btnMarkReturned.TabIndex = 3;
            this.btnMarkReturned.Text = "Mark Returned";
            this.btnMarkReturned.UseVisualStyleBackColor = false;
            this.btnMarkReturned.Click += new System.EventHandler(this.btnMarkReturned_Click_1);
            // 
            // Back
            // 
            this.Back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Back.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Back.ForeColor = System.Drawing.Color.White;
            this.Back.Location = new System.Drawing.Point(1201, 72);
            this.Back.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(59, 56);
            this.Back.TabIndex = 4;
            this.Back.Text = "←";
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(54)))), ((int)(((byte)(93)))));
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(-10, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1286, 68);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Rental Logger";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(395, 162);
            this.dtpStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(256, 30);
            this.dtpStart.TabIndex = 13;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(395, 204);
            this.dtpEnd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(256, 30);
            this.dtpEnd.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(15, 169);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 31);
            this.label1.TabIndex = 15;
            this.label1.Text = "Customer ID";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(15, 204);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 31);
            this.label2.TabIndex = 16;
            this.label2.Text = "Vehicle ID";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(291, 165);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 31);
            this.label3.TabIndex = 17;
            this.label3.Text = "Start Date";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(291, 207);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 31);
            this.label4.TabIndex = 18;
            this.label4.Text = "End Date";
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Location = new System.Drawing.Point(144, 162);
            this.txtCustomerID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(127, 30);
            this.txtCustomerID.TabIndex = 19;
            // 
            // txtVehicleID
            // 
            this.txtVehicleID.Location = new System.Drawing.Point(144, 204);
            this.txtVehicleID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtVehicleID.Name = "txtVehicleID";
            this.txtVehicleID.Size = new System.Drawing.Size(127, 30);
            this.txtVehicleID.TabIndex = 20;
            // 
            // rentalLogger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.ClientSize = new System.Drawing.Size(1263, 883);
            this.Controls.Add(this.txtVehicleID);
            this.Controls.Add(this.txtCustomerID);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvRentals);
            this.Controls.Add(this.btnAddRental);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnMarkReturned);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.MaximumSize = new System.Drawing.Size(1281, 930);
            this.MinimumSize = new System.Drawing.Size(1281, 930);
            this.Name = "rentalLogger";
            this.Text = "Rental Logger";
            this.Load += new System.EventHandler(this.rentalLogger_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentals)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.TextBox txtVehicleID;
    }
}