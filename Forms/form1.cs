using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
        private void btnCustomers_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Navigating to: Customer Manager (Member 2 Side)", "System Router");
        }
        private void btnVehicles_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Navigating to: Vehicle Manager (Member 3 Side)", "System Router");
        }

        private void btnRentals_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Navigating to: Rental Logger (Member 4 Side)", "System Router");
        }

        private void btnFilterSort_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Navigating to: Filter and Sort Engine (Member 5 Side)", "System Router");
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Navigating to: Settings and Logs (Member 6 Side)", "System Router");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
