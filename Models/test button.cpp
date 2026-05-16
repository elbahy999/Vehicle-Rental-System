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
                    // Member 6 will eventually handle this logging to a .txt file
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
