namespace projjjjj
{
    partial class ErrorLogSettingsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabErrorLog = new System.Windows.Forms.TabPage();
            this.dgvErrors = new System.Windows.Forms.DataGridView();
            this.pnlLogButtons = new System.Windows.Forms.Panel();
            this.btnRefreshLogs = new System.Windows.Forms.Button();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.btnClearLogs = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.grpConnection = new System.Windows.Forms.GroupBox();
            this.lblConnStr = new System.Windows.Forms.Label();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabErrorLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrors)).BeginInit();
            this.pnlLogButtons.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.grpConnection.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabErrorLog);
            this.tabControl1.Controls.Add(this.tabSettings);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControl1.Location = new System.Drawing.Point(22, 143);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1063, 597);
            this.tabControl1.TabIndex = 1;
            // 
            // tabErrorLog
            // 
            this.tabErrorLog.Controls.Add(this.dgvErrors);
            this.tabErrorLog.Controls.Add(this.pnlLogButtons);
            this.tabErrorLog.Controls.Add(this.lblStatus);
            this.tabErrorLog.Location = new System.Drawing.Point(4, 32);
            this.tabErrorLog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabErrorLog.Name = "tabErrorLog";
            this.tabErrorLog.Size = new System.Drawing.Size(1055, 561);
            this.tabErrorLog.TabIndex = 0;
            this.tabErrorLog.Text = "  Error Log  ";
            // 
            // dgvErrors
            // 
            this.dgvErrors.BackgroundColor = System.Drawing.Color.White;
            this.dgvErrors.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvErrors.ColumnHeadersHeight = 29;
            this.dgvErrors.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvErrors.Location = new System.Drawing.Point(6, 6);
            this.dgvErrors.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvErrors.Name = "dgvErrors";
            this.dgvErrors.RowHeadersVisible = false;
            this.dgvErrors.RowHeadersWidth = 51;
            this.dgvErrors.Size = new System.Drawing.Size(1043, 472);
            this.dgvErrors.TabIndex = 0;
            // 
            // pnlLogButtons
            // 
            this.pnlLogButtons.Controls.Add(this.btnRefreshLogs);
            this.pnlLogButtons.Controls.Add(this.btnViewDetails);
            this.pnlLogButtons.Controls.Add(this.btnClearLogs);
            this.pnlLogButtons.Location = new System.Drawing.Point(6, 487);
            this.pnlLogButtons.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlLogButtons.Name = "pnlLogButtons";
            this.pnlLogButtons.Size = new System.Drawing.Size(1043, 67);
            this.pnlLogButtons.TabIndex = 1;
            // 
            // btnRefreshLogs
            // 
            this.btnRefreshLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(54)))), ((int)(((byte)(93)))));
            this.btnRefreshLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshLogs.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnRefreshLogs.ForeColor = System.Drawing.Color.White;
            this.btnRefreshLogs.Location = new System.Drawing.Point(0, 12);
            this.btnRefreshLogs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefreshLogs.Name = "btnRefreshLogs";
            this.btnRefreshLogs.Size = new System.Drawing.Size(169, 46);
            this.btnRefreshLogs.TabIndex = 0;
            this.btnRefreshLogs.Text = "Refresh";
            this.btnRefreshLogs.UseVisualStyleBackColor = false;
            this.btnRefreshLogs.Click += new System.EventHandler(this.btnRefreshLogs_Click);
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewDetails.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnViewDetails.ForeColor = System.Drawing.Color.White;
            this.btnViewDetails.Location = new System.Drawing.Point(180, 12);
            this.btnViewDetails.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(202, 46);
            this.btnViewDetails.TabIndex = 1;
            this.btnViewDetails.Text = "View Details";
            this.btnViewDetails.UseVisualStyleBackColor = false;
            this.btnViewDetails.Click += new System.EventHandler(this.btnViewDetails_Click);
            // 
            // btnClearLogs
            // 
            this.btnClearLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClearLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearLogs.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClearLogs.ForeColor = System.Drawing.Color.White;
            this.btnClearLogs.Location = new System.Drawing.Point(394, 12);
            this.btnClearLogs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClearLogs.Name = "btnClearLogs";
            this.btnClearLogs.Size = new System.Drawing.Size(169, 46);
            this.btnClearLogs.TabIndex = 2;
            this.btnClearLogs.Text = "Clear All Logs";
            this.btnClearLogs.UseVisualStyleBackColor = false;
            this.btnClearLogs.Click += new System.EventHandler(this.btnClearLogs_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblStatus.Location = new System.Drawing.Point(6, 557);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(675, 24);
            this.lblStatus.TabIndex = 2;
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.grpConnection);
            this.tabSettings.Location = new System.Drawing.Point(4, 32);
            this.tabSettings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Size = new System.Drawing.Size(1055, 606);
            this.tabSettings.TabIndex = 1;
            this.tabSettings.Text = "  Connection Settings  ";
            // 
            // grpConnection
            // 
            this.grpConnection.Controls.Add(this.lblConnStr);
            this.grpConnection.Controls.Add(this.txtConnectionString);
            this.grpConnection.Controls.Add(this.btnTestConnection);
            this.grpConnection.Controls.Add(this.lblConnectionStatus);
            this.grpConnection.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpConnection.Location = new System.Drawing.Point(34, 36);
            this.grpConnection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpConnection.Name = "grpConnection";
            this.grpConnection.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpConnection.Size = new System.Drawing.Size(979, 242);
            this.grpConnection.TabIndex = 0;
            this.grpConnection.TabStop = false;
            this.grpConnection.Text = "Database Connection";
            // 
            // lblConnStr
            // 
            this.lblConnStr.AutoSize = true;
            this.lblConnStr.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblConnStr.Location = new System.Drawing.Point(17, 48);
            this.lblConnStr.Name = "lblConnStr";
            this.lblConnStr.Size = new System.Drawing.Size(275, 21);
            this.lblConnStr.TabIndex = 0;
            this.lblConnStr.Text = "Current Connection String (read-only):";
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.txtConnectionString.Font = new System.Drawing.Font("Courier New", 9F);
            this.txtConnectionString.Location = new System.Drawing.Point(17, 79);
            this.txtConnectionString.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtConnectionString.Multiline = true;
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.ReadOnly = true;
            this.txtConnectionString.Size = new System.Drawing.Size(933, 66);
            this.txtConnectionString.TabIndex = 1;
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(54)))), ((int)(((byte)(93)))));
            this.btnTestConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestConnection.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnTestConnection.ForeColor = System.Drawing.Color.White;
            this.btnTestConnection.Location = new System.Drawing.Point(17, 163);
            this.btnTestConnection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(202, 48);
            this.btnTestConnection.TabIndex = 2;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.UseVisualStyleBackColor = false;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblConnectionStatus.Location = new System.Drawing.Point(236, 173);
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(675, 29);
            this.lblConnectionStatus.TabIndex = 3;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(54)))), ((int)(((byte)(93)))));
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.Color.White;
            this.lblFormTitle.Location = new System.Drawing.Point(-4, -7);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(1125, 61);
            this.lblFormTitle.TabIndex = 1;
            this.lblFormTitle.Text = "Settings";
            this.lblFormTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(1044, 58);
            this.btnBack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(59, 56);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "←";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click_1);
            // 
            // ErrorLogSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 790);
            this.Controls.Add(this.lblFormTitle);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnBack);
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.MaximumSize = new System.Drawing.Size(1123, 837);
            this.MinimumSize = new System.Drawing.Size(1123, 837);
            this.Name = "ErrorLogSettingsForm";
            this.Text = "Error Log & Settings";
            this.Load += new System.EventHandler(this.ErrorLogSettingsForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabErrorLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrors)).EndInit();
            this.pnlLogButtons.ResumeLayout(false);
            this.tabSettings.ResumeLayout(false);
            this.grpConnection.ResumeLayout(false);
            this.grpConnection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl         tabControl1;
        private System.Windows.Forms.TabPage            tabErrorLog;
        private System.Windows.Forms.TabPage            tabSettings;
        private System.Windows.Forms.DataGridView       dgvErrors;
        private System.Windows.Forms.Panel              pnlLogButtons;
        private System.Windows.Forms.Button             btnRefreshLogs;
        private System.Windows.Forms.Button             btnClearLogs;
        private System.Windows.Forms.Button             btnViewDetails;
        private System.Windows.Forms.Label              lblStatus;
        private System.Windows.Forms.GroupBox           grpConnection;
        private System.Windows.Forms.Label              lblConnStr;
        private System.Windows.Forms.TextBox            txtConnectionString;
        private System.Windows.Forms.Button             btnTestConnection;
        private System.Windows.Forms.Label              lblConnectionStatus;
        private System.Windows.Forms.Label              lblFormTitle;
        private System.Windows.Forms.Button             btnBack;
    }
}
