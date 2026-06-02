using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace projjjjj
{
    public partial class Form1 : BaseForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // Verify DB is reachable on startup and show live summary
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    // Optionally load summary stats here in future
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex, "Form1.Load");
                MessageBox.Show("Warning: Could not connect to the database.\n" + ex.Message,
                                "Connection Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label2_Click_1(object sender, EventArgs e) { }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            try
            {
                CustomerForm customerForm = new CustomerForm();
                customerForm.ShowDialog();
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex, "Form1.btnCustomers_Click");
                MessageBox.Show("Failed to open Customer Manager:\n" + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVehicles_Click(object sender, EventArgs e)
        {
            try
            {
                VehicleForm vehicleForm = new VehicleForm();
                vehicleForm.ShowDialog();
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex, "Form1.btnVehicles_Click");
                MessageBox.Show("Failed to open Vehicle Manager:\n" + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRentals_Click(object sender, EventArgs e)
        {
            try
            {
                rentalLogger form = new rentalLogger();
                form.Show();
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex, "Form1.btnRentals_Click");
                MessageBox.Show("Failed to open Rental Logger:\n" + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFilterSort_Click(object sender, EventArgs e)
        {
            try
            {
                FilterSortForm filterSortForm = new FilterSortForm();
                filterSortForm.Show();
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex, "Form1.btnFilterSort_Click");
                MessageBox.Show("Failed to open Filter & Sort:\n" + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorLogSettingsForm settingsForm = new ErrorLogSettingsForm();
                settingsForm.ShowDialog();
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex, "Form1.btnSettings_Click");
                MessageBox.Show("Failed to open Error Log & Settings:\n" + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
