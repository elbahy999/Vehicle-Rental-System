using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace projjjjj
{
    public partial class ErrorLogSettingsForm : BaseForm
    {
        private bool _isLoadingLogs = false;
        
        public ErrorLogSettingsForm()
        {
            InitializeComponent();
        }

        // ─── Form Load ────────────────────────────────────────────────────────────
        private void ErrorLogSettingsForm_Load(object sender, EventArgs e)
        {
            LoadErrorLogs();
            LoadConnectionString();
        }

        // ─── Error Log Tab ────────────────────────────────────────────────────────

        private void LoadErrorLogs()
        {
            if (_isLoadingLogs) return;
                _isLoadingLogs = true;
                
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string sql = @"
                        SELECT ErrorID,
                               Source,
                               Message,
                               StackTrace,
                               OccurredAt
                        FROM ErrorLogs
                        ORDER BY OccurredAt DESC";

                    DataTable dt = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                    {
                        da.Fill(dt);
                    }

                    dgvErrors.DataSource = dt;
                    dgvErrors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvErrors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvErrors.ReadOnly = true;

                    // Hide the heavy StackTrace column by default
                    if (dgvErrors.Columns["StackTrace"] != null)
                        dgvErrors.Columns["StackTrace"].Visible = false;

                    lblStatus.Text = $"Loaded {dt.Rows.Count} log entries.";

                    ErrorLogger.ClearMemoryLogs();
                }
            }
            catch (Exception ex)
            {
                // Can't log to DB if DB is the problem — show in-memory fallback
                lblStatus.Text = "DB unavailable. Showing in-memory logs.";
                ErrorLogger.Log(ex, "ErrorLogSettingsForm.LoadErrorLogs");
                ShowMemoryLogs();
            }
            finally
            {
                _isLoadingLogs = false;
            }
        }

        private void ShowMemoryLogs()
        {
            var logs = ErrorLogger.GetMemoryLogs();
            DataTable dt = new DataTable();
            dt.Columns.Add("Source");
            dt.Columns.Add("Message");
            dt.Columns.Add("OccurredAt");

            foreach (string entry in logs)
                dt.Rows.Add("Memory", entry, DateTime.Now.ToString());

            dgvErrors.DataSource = dt;
            lblStatus.Text = $"DB unavailable. Showing {logs.Count} in-memory log(s).";
        }

        private void btnRefreshLogs_Click(object sender, EventArgs e)
        {
            LoadErrorLogs();
        }

        private void btnClearLogs_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to delete ALL error logs? This cannot be undone.",
                "Confirm Clear",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;
            
            ErrorLogger.ClearMemoryLogs();

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM ErrorLogs", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("All logs cleared.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadErrorLogs();
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex, "ErrorLogSettingsForm.ClearLogs");
                MessageBox.Show("Error clearing logs: " + ex.Message);
            }
        }

        // Show the full stack trace of the selected row in a popup
        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvErrors.CurrentRow == null)
            {
                MessageBox.Show("Select a log entry first.");
                return;
            }

            string source  = dgvErrors.CurrentRow.Cells["Source"].Value?.ToString() ?? "";
            string message = dgvErrors.CurrentRow.Cells["Message"].Value?.ToString() ?? "";
            string stack   = dgvErrors.CurrentRow.Cells["StackTrace"].Value?.ToString() ?? "(no stack trace)";
            string date    = dgvErrors.CurrentRow.Cells["OccurredAt"].Value?.ToString() ?? "";

            string details = $"Date    : {date}\nSource  : {source}\nMessage : {message}\n\nStack Trace:\n{stack}";

            MessageBox.Show(details, "Error Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ─── Settings Tab ─────────────────────────────────────────────────────────

        private void LoadConnectionString()
        {
            // Display the current connection string for review (read from DatabaseHelper via reflection-free copy)
            txtConnectionString.Text = @"Server=.\SQLEXPRESS;Database=Vehicle_Rental;Integrated Security=True;";
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(txtConnectionString.Text.Trim()))
                {
                    conn.Open();
                    lblConnectionStatus.ForeColor = System.Drawing.Color.Green;
                    lblConnectionStatus.Text = "✔  Connection successful!";
                }
            }
            catch (Exception ex)
            {
                lblConnectionStatus.ForeColor = System.Drawing.Color.Red;
                lblConnectionStatus.Text = "✘  Connection failed: " + ex.Message;
                ErrorLogger.Log(ex, "ErrorLogSettingsForm.TestConnection");
            }
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
