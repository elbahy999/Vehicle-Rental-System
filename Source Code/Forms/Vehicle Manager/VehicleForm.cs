using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace projjjjj
{
    public partial class VehicleForm : BaseForm
    {
        public VehicleForm()
        {
            InitializeComponent();
        }

        // ── Form Load ──────────────────────────────────────────────────────────
        private void VehicleForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadAllVehicles();
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex, "VehicleForm.Load");
                MessageBox.Show("Failed to load form:\n" + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ══════════════════════════════════════════════════════════════════════
        // LOAD
        // ══════════════════════════════════════════════════════════════════════
        private void LoadAllVehicles()
        {
            try
            {
                List<Vehicle> vehicles = VehicleManager.GetAllVehicles();
                dgvVehicles.DataSource = vehicles;
                ColorAvailabilityRows();
                lblStatus.Text = $"{vehicles.Count} vehicle(s) loaded.";
                lblStatus.ForeColor = System.Drawing.Color.FromArgb(95, 94, 90);
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex, "VehicleForm.LoadAllVehicles");
                MessageBox.Show("Error loading vehicles:\n" + ex.Message, "Error",
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
                Vehicle newVehicle = new Vehicle
                {
                    Plate       = txtPlate.Text,
                    VehicleType = txtVehicleType.Text,
                    Brand       = txtBrand.Text,
                    DailyRate   = decimal.TryParse(txtDailyRate.Text, out decimal rate) ? rate : 0,
                    IsAvailable = chkIsAvailable.Checked
                };

                bool success = VehicleManager.AddVehicle(newVehicle);

                if (success)
                {
                    lblStatus.ForeColor = System.Drawing.Color.FromArgb(15, 110, 86);
                    lblStatus.Text = "Vehicle added successfully.";
                    ClearFields();
                    LoadAllVehicles();
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex, "VehicleForm.btnAdd_Click");
                MessageBox.Show("Unexpected error adding vehicle:\n" + ex.Message, "Error",
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
                if (string.IsNullOrWhiteSpace(txtVehicleID.Text))
                {
                    MessageBox.Show("Please select a vehicle from the table first.",
                                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Vehicle updated = new Vehicle
                {
                    VehicleID   = int.Parse(txtVehicleID.Text),
                    Plate       = txtPlate.Text,
                    VehicleType = txtVehicleType.Text,
                    Brand       = txtBrand.Text,
                    DailyRate   = decimal.TryParse(txtDailyRate.Text, out decimal rate) ? rate : 0,
                    IsAvailable = chkIsAvailable.Checked
                };

                bool success = VehicleManager.UpdateVehicle(updated);

                if (success)
                {
                    lblStatus.ForeColor = System.Drawing.Color.FromArgb(24, 95, 165);
                    lblStatus.Text = "Vehicle updated successfully.";
                    ClearFields();
                    LoadAllVehicles();
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex, "VehicleForm.btnUpdate_Click");
                MessageBox.Show("Unexpected error updating vehicle:\n" + ex.Message, "Error",
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
                if (string.IsNullOrWhiteSpace(txtVehicleID.Text))
                {
                    MessageBox.Show("Please select a vehicle from the table first.",
                                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtVehicleID.Text);
                string name = $"{txtBrand.Text} {txtVehicleType.Text} ({txtPlate.Text})";

                DialogResult confirm = MessageBox.Show(
                    $"Are you sure you want to delete \"{name}\"?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    bool success = VehicleManager.DeleteVehicle(id);
                    if (success)
                    {
                        lblStatus.ForeColor = System.Drawing.Color.FromArgb(163, 45, 45);
                        lblStatus.Text = $"Vehicle \"{name}\" deleted.";
                        ClearFields();
                        LoadAllVehicles();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex, "VehicleForm.btnDelete_Click");
                MessageBox.Show("Unexpected error deleting vehicle:\n" + ex.Message, "Error",
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
        private void dgvVehicles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;

                DataGridViewRow row = dgvVehicles.Rows[e.RowIndex];
                txtVehicleID.Text   = row.Cells["VehicleID"].Value.ToString();
                txtPlate.Text       = row.Cells["Plate"].Value.ToString();
                txtVehicleType.Text = row.Cells["VehicleType"].Value.ToString();
                txtBrand.Text       = row.Cells["Brand"].Value.ToString();
                txtDailyRate.Text   = row.Cells["DailyRate"].Value.ToString();
                chkIsAvailable.Checked = (bool)row.Cells["IsAvailable"].Value;

                bool avail = chkIsAvailable.Checked;

                lblStatus.ForeColor = System.Drawing.Color.FromArgb(27, 54, 93);
                lblStatus.Text = $"Selected: {txtBrand.Text} {txtVehicleType.Text} — {txtPlate.Text}";
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex, "VehicleForm.dgvVehicles_CellClick");
                MessageBox.Show("Error selecting row:\n" + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ══════════════════════════════════════════════════════════════════════
        // Helpers
        // ══════════════════════════════════════════════════════════════════════
        private void ClearFields()
        {
            txtVehicleID.Clear();
            txtPlate.Clear();
            txtVehicleType.Clear();
            txtBrand.Clear();
            txtDailyRate.Clear();
            chkIsAvailable.Checked = true;
        }

        private void ColorAvailabilityRows()
        {
            foreach (DataGridViewRow row in dgvVehicles.Rows)
            {
                if (row.DataBoundItem is Vehicle v)
                {
                    row.DefaultCellStyle.BackColor = v.IsAvailable
                        ? System.Drawing.Color.FromArgb(220, 255, 220)
                        : System.Drawing.Color.FromArgb(255, 230, 230);
                }
            }
        }
    }
}
