using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace projjjjj
{
    public partial class rentalLogger : BaseForm
    {
        public rentalLogger()
        {
            InitializeComponent();
        }

        private void rentalLogger_Load(object sender, EventArgs e)
        {
            try
            {
                LoadRentals();
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex, "rentalLogger.Load");
                MessageBox.Show("Failed to load form:\n" + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ══════════════════════════════════════════════════════════════════════
        // LOAD
        // ══════════════════════════════════════════════════════════════════════
        private void LoadRentals()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string sql = @"
                        SELECT r.RentalID,
                               r.VehicleID,
                               c.FirstName + ' ' + c.LastName AS Customer,
                               v.Brand + ' ' + v.Plate AS Vehicle,
                               r.RentalStartDate,
                               r.RentalEndDate,
                               r.Status
                        FROM Rentals r
                        JOIN Customers c ON r.CustomerID = c.CustomerID
                        JOIN Vehicles  v ON r.VehicleID  = v.VehicleID
                        ORDER BY r.RentalStartDate DESC";

                    DataTable dt = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                        da.Fill(dt);

                    dgvRentals.DataSource = dt;
                    dgvRentals.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvRentals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvRentals.ReadOnly = true;

                    if (dgvRentals.Columns["VehicleID"] != null)
                        dgvRentals.Columns["VehicleID"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex, "rentalLogger.LoadRentals");
                MessageBox.Show("Error loading rentals:\n" + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ══════════════════════════════════════════════════════════════════════
        // EXISTS CHECK
        // ══════════════════════════════════════════════════════════════════════
        private bool Exists(string table, string column, int id)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = $"SELECT COUNT(1) FROM {table} WHERE {column} = @id";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        return (int)cmd.ExecuteScalar() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex, $"rentalLogger.Exists({table})");
                MessageBox.Show("Error checking record existence:\n" + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ══════════════════════════════════════════════════════════════════════
        // ADD RENTAL
        // ══════════════════════════════════════════════════════════════════════
        private void btnAddRental_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtCustomerID.Text, out int customerId))
                {
                    MessageBox.Show("Invalid Customer ID");
                    return;
                }

                if (!int.TryParse(txtVehicleID.Text, out int vehicleId))
                {
                    MessageBox.Show("Invalid Vehicle ID");
                    return;
                }

                if (!Exists("Customers", "CustomerID", customerId))
                {
                    MessageBox.Show("Customer does not exist");
                    return;
                }

                if (!Exists("Vehicles", "VehicleID", vehicleId))
                {
                    MessageBox.Show("Vehicle does not exist");
                    return;
                }

                if (dtpEnd.Value.Date < dtpStart.Value.Date)
                {
                    MessageBox.Show("Return date cannot be before the rental start date.",
                                    "Invalid Dates", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dtpEnd.Value.Date == dtpStart.Value.Date)
                {
                    MessageBox.Show("Return date cannot be the same as the rental start date.",
                                    "Invalid Dates", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string sql = @"
                        INSERT INTO Rentals (CustomerID, VehicleID, RentalStartDate, RentalEndDate, Status)
                        VALUES (@cid, @vid, @start, @end, 'Active')";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@cid",   customerId);
                        cmd.Parameters.AddWithValue("@vid",   vehicleId);
                        cmd.Parameters.AddWithValue("@start", dtpStart.Value.Date);
                        cmd.Parameters.AddWithValue("@end",   dtpEnd.Value.Date);
                        cmd.ExecuteNonQuery();
                    }

                    string sql2 = "UPDATE Vehicles SET IsAvailable = 0 WHERE VehicleID = @vid";
                    using (SqlCommand cmd2 = new SqlCommand(sql2, conn))
                    {
                        cmd2.Parameters.AddWithValue("@vid", vehicleId);
                        cmd2.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Rental added");
                LoadRentals();
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex, "rentalLogger.btnAddRental_Click");
                MessageBox.Show("Error adding rental:\n" + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ══════════════════════════════════════════════════════════════════════
        // REFRESH
        // ══════════════════════════════════════════════════════════════════════
        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            try
            {
                LoadRentals();
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex, "rentalLogger.btnRefresh_Click");
                MessageBox.Show("Error refreshing rentals:\n" + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ══════════════════════════════════════════════════════════════════════
        // MARK RETURNED
        // ══════════════════════════════════════════════════════════════════════
        private void btnMarkReturned_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dgvRentals.CurrentRow == null)
                {
                    MessageBox.Show("Select rental first");
                    return;
                }

                int rentalId  = Convert.ToInt32(dgvRentals.CurrentRow.Cells["RentalID"].Value);
                int vehicleId = Convert.ToInt32(dgvRentals.CurrentRow.Cells["VehicleID"].Value);

                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(
                        "UPDATE Rentals SET Status = 'Returned' WHERE RentalID = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", rentalId);
                        cmd.ExecuteNonQuery();
                    }

                    using (SqlCommand cmd2 = new SqlCommand(
                        "UPDATE Vehicles SET IsAvailable = 1 WHERE VehicleID = @vid", conn))
                    {
                        cmd2.Parameters.AddWithValue("@vid", vehicleId);
                        cmd2.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Rental returned");
                LoadRentals();
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex, "rentalLogger.btnMarkReturned_Click");
                MessageBox.Show("Error marking rental as returned:\n" + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ══════════════════════════════════════════════════════════════════════
        // BACK
        // ══════════════════════════════════════════════════════════════════════
        private void Back_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
