
        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM Customers";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    int count = (int)cmd.ExecuteScalar();

                    MessageBox.Show("Total Customers Registered: " + count);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
