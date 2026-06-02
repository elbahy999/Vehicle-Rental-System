using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace projjjjj
{
    public partial class FilterSortForm : BaseForm
    {
        List<Vehicle>  vehicles  = new List<Vehicle>();
        List<Customer> customers = new List<Customer>();
        private DataTable rentalsTable = new DataTable();

        public FilterSortForm()
        {
            InitializeComponent();

            cmbTable.Items.Add("Vehicles");
            cmbTable.Items.Add("Customers");
            cmbTable.Items.Add("Rentals");

            cmbSort.Items.Add("A-Z");
            cmbSort.Items.Add("Z-A");

            cmbTable.SelectedIndex = 0;
            cmbSort.SelectedIndex  = 0;
        }

        // ══════════════════════════════════════════════════════════════════════
        // TABLE SELECTION CHANGED
        // ══════════════════════════════════════════════════════════════════════
        private void cmbTable_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (cmbTable.SelectedItem == null) return;

                cmbFilter.Items.Clear();
                string selectedTable = cmbTable.SelectedItem.ToString();

                if (selectedTable == "Vehicles")
                {
                    cmbFilter.Items.Add("All");
                    cmbFilter.Items.Add("Available");
                    cmbFilter.Items.Add("Not Available");
                }
                else if (selectedTable == "Customers")
                {
                    cmbFilter.Items.Add("All");
                }
                else if (selectedTable == "Rentals")
                {
                    cmbFilter.Items.Add("All");
                    cmbFilter.Items.Add("Active");
                    cmbFilter.Items.Add("Returned");
                }

                cmbFilter.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex, "FilterSortForm.cmbTable_SelectedIndexChanged");
                MessageBox.Show("Error changing table selection:\n" + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ══════════════════════════════════════════════════════════════════════
        // APPLY
        // ══════════════════════════════════════════════════════════════════════
        private void btnApply_Click_1(object sender, EventArgs e)
        {
            try
            {
                string selectedTable = cmbTable.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(selectedTable)) return;

                if (selectedTable == "Vehicles")
                {
                    LoadVehicles();

                    bool? availableFilter = null;
                    if (cmbFilter.Text == "Available")     availableFilter = true;
                    else if (cmbFilter.Text == "Not Available") availableFilter = false;

                    List<Vehicle> filtered = FilterVehicles(vehicles, txtSearch.Text, availableFilter);
                    BubbleSortVehicles(filtered);
                    if (cmbSort.Text == "Z-A") filtered.Reverse();

                    dgvResults.DataSource = null;
                    dgvResults.DataSource = filtered;
                }
                else if (selectedTable == "Customers")
                {
                    LoadCustomers();

                    List<Customer> filtered = FilterCustomers(customers, txtSearch.Text);
                    BubbleSortCustomers(filtered);
                    if (cmbSort.Text == "Z-A") filtered.Reverse();

                    dgvResults.DataSource = null;
                    dgvResults.DataSource = filtered;
                }
                else if (selectedTable == "Rentals")
                {
                    LoadRentals();

                    DataView dv = new DataView(rentalsTable);
                    if      (cmbFilter.Text == "Active")   dv.RowFilter = "Status = 'Active'";
                    else if (cmbFilter.Text == "Returned") dv.RowFilter = "Status = 'Returned'";
                    else                                   dv.RowFilter = "1=1";

                    dgvResults.DataSource = dv;
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex, "FilterSortForm.btnApply_Click");
                MessageBox.Show("Error applying filter/sort:\n" + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ══════════════════════════════════════════════════════════════════════
        // LOAD VEHICLES
        // ══════════════════════════════════════════════════════════════════════
        private void LoadVehicles()
        {
            try
            {
                vehicles.Clear();

                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT VehicleID, Plate, VehicleType, Brand, DailyRate, IsAvailable FROM Vehicles";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            vehicles.Add(new Vehicle
                            {
                                VehicleID   = reader.GetInt32(0),
                                Plate       = reader.GetString(1),
                                VehicleType = reader.GetString(2),
                                Brand       = reader.GetString(3),
                                DailyRate   = reader.GetDecimal(4),
                                IsAvailable = reader.GetBoolean(5)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex, "FilterSortForm.LoadVehicles");
                MessageBox.Show("Error loading vehicles:\n" + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ══════════════════════════════════════════════════════════════════════
        // LOAD CUSTOMERS
        // ══════════════════════════════════════════════════════════════════════
        private void LoadCustomers()
        {
            try
            {
                customers.Clear();

                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT CustomerID, FirstName, LastName, PhoneNumber, Email FROM Customers";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customers.Add(new Customer
                            {
                                CustomerID  = reader.GetInt32(0),
                                FirstName   = reader.GetString(1),
                                LastName    = reader.GetString(2),
                                PhoneNumber = reader.GetString(3),
                                Email       = reader.GetString(4)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex, "FilterSortForm.LoadCustomers");
                MessageBox.Show("Error loading customers:\n" + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ══════════════════════════════════════════════════════════════════════
        // LOAD RENTALS
        // ══════════════════════════════════════════════════════════════════════
        private void LoadRentals()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM Rentals";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    rentalsTable = new DataTable();
                    adapter.Fill(rentalsTable);
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex, "FilterSortForm.LoadRentals");
                MessageBox.Show("Error loading rentals:\n" + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ══════════════════════════════════════════════════════════════════════
        // FILTER VEHICLES
        // ══════════════════════════════════════════════════════════════════════
        private List<Vehicle> FilterVehicles(List<Vehicle> vehicles, string search, bool? isAvailable)
        {
            List<Vehicle> result = new List<Vehicle>();
            foreach (var v in vehicles)
            {
                bool matchesSearch =
                    string.IsNullOrEmpty(search) ||
                    v.Brand.ToLower().Contains(search.ToLower()) ||
                    v.VehicleType.ToLower().Contains(search.ToLower());

                bool matchesStatus =
                    !isAvailable.HasValue || v.IsAvailable == isAvailable.Value;

                if (matchesSearch && matchesStatus)
                    result.Add(v);
            }
            return result;
        }

        // ══════════════════════════════════════════════════════════════════════
        // FILTER CUSTOMERS
        // ══════════════════════════════════════════════════════════════════════
        private List<Customer> FilterCustomers(List<Customer> customers, string search)
        {
            List<Customer> result = new List<Customer>();
            foreach (var c in customers)
            {
                bool matchesSearch =
                    string.IsNullOrEmpty(search) ||
                    c.FirstName.ToLower().Contains(search.ToLower()) ||
                    c.LastName.ToLower().Contains(search.ToLower());

                if (matchesSearch)
                    result.Add(c);
            }
            return result;
        }

        // ══════════════════════════════════════════════════════════════════════
        // BUBBLE SORT VEHICLES
        // ══════════════════════════════════════════════════════════════════════
        private void BubbleSortVehicles(List<Vehicle> vehicles)
        {
            for (int i = 0; i < vehicles.Count - 1; i++)
                for (int j = 0; j < vehicles.Count - i - 1; j++)
                    if (string.Compare(vehicles[j].Brand, vehicles[j + 1].Brand) > 0)
                    {
                        Vehicle temp  = vehicles[j];
                        vehicles[j]   = vehicles[j + 1];
                        vehicles[j+1] = temp;
                    }
        }

        // ══════════════════════════════════════════════════════════════════════
        // BUBBLE SORT CUSTOMERS
        // ══════════════════════════════════════════════════════════════════════
        private void BubbleSortCustomers(List<Customer> customers)
        {
            for (int i = 0; i < customers.Count - 1; i++)
                for (int j = 0; j < customers.Count - i - 1; j++)
                    if (string.Compare(customers[j].FirstName, customers[j + 1].FirstName) > 0)
                    {
                        Customer temp  = customers[j];
                        customers[j]   = customers[j + 1];
                        customers[j+1] = temp;
                    }
        }

        // ══════════════════════════════════════════════════════════════════════
        // SHOW AVAILABLE ONLY
        // ══════════════════════════════════════════════════════════════════════
        private void btnShowAvailable_Click(object sender, EventArgs e)
        {
            try
            {
                // Switch context to Vehicles table and apply Available filter
                cmbTable.SelectedItem = "Vehicles";
                cmbFilter.SelectedItem = "Available";
                cmbSort.SelectedIndex = 0;
                txtSearch.Clear();

                LoadVehicles();
                List<Vehicle> filtered = FilterVehicles(vehicles, string.Empty, true);
                BubbleSortVehicles(filtered);

                dgvResults.DataSource = null;
                dgvResults.DataSource = filtered;
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex, "FilterSortForm.btnShowAvailable_Click");
                MessageBox.Show("Error showing available vehicles:\n" + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ══════════════════════════════════════════════════════════════════════
        // CLEAR
        // ══════════════════════════════════════════════════════════════════════
        private void btnClear_Click_1(object sender, EventArgs e)
        {
            try
            {
                txtSearch.Clear();
                cmbTable.SelectedIndex = 0;
                cmbSort.SelectedIndex  = 0;
                dgvResults.DataSource  = null;
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex, "FilterSortForm.btnClear_Click");
                MessageBox.Show("Error clearing form:\n" + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ══════════════════════════════════════════════════════════════════════
        // BACK
        // ══════════════════════════════════════════════════════════════════════
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
