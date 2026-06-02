using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace projjjjj
{
    public partial class CustomerForm : BaseForm
    {
        public CustomerForm()
        {
            InitializeComponent();
        }

        // ── Form Load ──────────────────────────────────────────────────────────
        private void CustomerForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadAllCustomers();
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex, "CustomerForm.Load");
                MessageBox.Show("Failed to load form:\n" + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ══════════════════════════════════════════════════════════════════════
        // LOAD
        // ══════════════════════════════════════════════════════════════════════
        private void LoadAllCustomers()
        {
            try
            {
                List<Customer> customers = CustomerManager.GetAllCustomers();
                dgvCustomers.DataSource = customers;
                lblStatus.Text = $"{customers.Count} customer(s) loaded.";
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex, "CustomerForm.LoadAllCustomers");
                MessageBox.Show("Error loading customers:\n" + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ══════════════════════════════════════════════════════════════════════
        // ADD
        // ══════════════════════════════════════════════════════════════════════
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Customer newCustomer = new Customer
                {
                    FirstName   = txtFirstName.Text,
                    LastName    = txtLastName.Text,
                    PhoneNumber = txtPhone.Text,
                    Email       = txtEmail.Text
                };

                bool success = CustomerManager.AddCustomer(newCustomer);

                if (success)
                {
                    lblStatus.ForeColor = System.Drawing.Color.FromArgb(15, 110, 86);
                    lblStatus.Text = "Customer added successfully.";
                    ClearFields();
                    LoadAllCustomers();
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex, "CustomerForm.btnAdd_Click");
                MessageBox.Show("Unexpected error adding customer:\n" + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ══════════════════════════════════════════════════════════════════════
        // UPDATE
        // ══════════════════════════════════════════════════════════════════════
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCustomerID.Text))
                {
                    MessageBox.Show("Please select a customer from the table first.",
                                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Customer updated = new Customer
                {
                    CustomerID  = int.Parse(txtCustomerID.Text),
                    FirstName   = txtFirstName.Text,
                    LastName    = txtLastName.Text,
                    PhoneNumber = txtPhone.Text,
                    Email       = txtEmail.Text
                };

                bool success = CustomerManager.UpdateCustomer(updated);

                if (success)
                {
                    lblStatus.ForeColor = System.Drawing.Color.FromArgb(24, 95, 165);
                    lblStatus.Text = "Customer updated successfully.";
                    ClearFields();
                    LoadAllCustomers();
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex, "CustomerForm.btnUpdate_Click");
                MessageBox.Show("Unexpected error updating customer:\n" + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ══════════════════════════════════════════════════════════════════════
        // DELETE
        // ══════════════════════════════════════════════════════════════════════
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCustomerID.Text))
                {
                    MessageBox.Show("Please select a customer from the table first.",
                                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtCustomerID.Text);
                string name = txtFirstName.Text + " " + txtLastName.Text;

                DialogResult confirm = MessageBox.Show(
                    $"Are you sure you want to delete \"{name}\"?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    bool success = CustomerManager.DeleteCustomer(id);
                    if (success)
                    {
                        lblStatus.ForeColor = System.Drawing.Color.FromArgb(163, 45, 45);
                        lblStatus.Text = $"Customer \"{name}\" deleted.";
                        ClearFields();
                        LoadAllCustomers();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex, "CustomerForm.btnDelete_Click");
                MessageBox.Show("Unexpected error deleting customer:\n" + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ══════════════════════════════════════════════════════════════════════
        // CLEAR FIELDS
        // ══════════════════════════════════════════════════════════════════════
        private void btnClearFields_Click(object sender, EventArgs e)
        {
            ClearFields();
            lblStatus.ForeColor = System.Drawing.Color.FromArgb(95, 94, 90);
            lblStatus.Text = "Fields cleared.";
        }

        // ══════════════════════════════════════════════════════════════════════
        // BACK
        // ══════════════════════════════════════════════════════════════════════
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ══════════════════════════════════════════════════════════════════════
        // GRID ROW CLICK
        // ══════════════════════════════════════════════════════════════════════
        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;

                DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];
                txtCustomerID.Text = row.Cells["CustomerID"].Value.ToString();
                txtFirstName.Text  = row.Cells["FirstName"].Value.ToString();
                txtLastName.Text   = row.Cells["LastName"].Value.ToString();
                txtPhone.Text      = row.Cells["PhoneNumber"].Value.ToString();
                txtEmail.Text      = row.Cells["Email"].Value.ToString();

                lblStatus.ForeColor = System.Drawing.Color.FromArgb(27, 54, 93);
                lblStatus.Text = $"Selected: {txtFirstName.Text} {txtLastName.Text}";
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex, "CustomerForm.dgvCustomers_CellClick");
                MessageBox.Show("Error selecting row:\n" + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ══════════════════════════════════════════════════════════════════════
        // Helper
        // ══════════════════════════════════════════════════════════════════════
        private void ClearFields()
        {
            txtCustomerID.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
        }
    }
}
