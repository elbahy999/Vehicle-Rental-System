using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace projjjjj
{
    public class CustomerManager
    {
        // ══════════════════════════════════════════════════════════════════════
        // CREATE
        // ══════════════════════════════════════════════════════════════════════
        public static bool AddCustomer(Customer customer)
        {
            var validation = CustomerValidator.Validate(customer);
            if (!validation.IsValid)
            {
                MessageBox.Show(validation.ErrorSummary, "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            const string sql = @"
                INSERT INTO Customers (FirstName, LastName, PhoneNumber, Email)
                VALUES (@FirstName, @LastName, @PhoneNumber, @Email)";

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    BindParameters(cmd, customer);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex, "CustomerManager.AddCustomer");
                MessageBox.Show("Error adding customer:\n" + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ══════════════════════════════════════════════════════════════════════
        // READ – Get All
        // ══════════════════════════════════════════════════════════════════════
        public static List<Customer> GetAllCustomers()
        {
            var list = new List<Customer>();
            const string sql = "SELECT * FROM Customers ORDER BY LastName, FirstName";

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                        while (reader.Read())
                            list.Add(MapRow(reader));
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex, "CustomerManager.GetAllCustomers");
                MessageBox.Show("Error loading customers:\n" + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return list;
        }

        // ══════════════════════════════════════════════════════════════════════
        // READ – Get by ID
        // ══════════════════════════════════════════════════════════════════════
        public static Customer GetCustomerByID(int customerID)
        {
            const string sql = "SELECT * FROM Customers WHERE CustomerID = @ID";

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", customerID);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                        if (reader.Read())
                            return MapRow(reader);
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex, "CustomerManager.GetCustomerByID");
                MessageBox.Show("Error finding customer:\n" + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        // ══════════════════════════════════════════════════════════════════════
        // UPDATE
        // ══════════════════════════════════════════════════════════════════════
        public static bool UpdateCustomer(Customer customer)
        {
            var validation = CustomerValidator.Validate(customer);
            if (!validation.IsValid)
            {
                MessageBox.Show(validation.ErrorSummary, "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            const string sql = @"
                UPDATE Customers SET
                    FirstName   = @FirstName,
                    LastName    = @LastName,
                    PhoneNumber = @PhoneNumber,
                    Email       = @Email
                WHERE CustomerID = @CustomerID";

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    BindParameters(cmd, customer);
                    cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex, "CustomerManager.UpdateCustomer");
                MessageBox.Show("Error updating customer:\n" + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ══════════════════════════════════════════════════════════════════════
        // DELETE
        // ══════════════════════════════════════════════════════════════════════
        public static bool DeleteCustomer(int customerID)
        {
            const string sql = "DELETE FROM Customers WHERE CustomerID = @ID";

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", customerID);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex, "CustomerManager.DeleteCustomer");
                MessageBox.Show("Error deleting customer:\n" + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ══════════════════════════════════════════════════════════════════════
        // Helpers
        // ══════════════════════════════════════════════════════════════════════
        private static Customer MapRow(SqlDataReader reader)
        {
            return new Customer
            {
                CustomerID  = (int)reader["CustomerID"],
                FirstName   = reader["FirstName"].ToString(),
                LastName    = reader["LastName"].ToString(),
                PhoneNumber = reader["PhoneNumber"].ToString(),
                Email       = reader["Email"].ToString()
            };
        }

        private static void BindParameters(SqlCommand cmd, Customer c)
        {
            cmd.Parameters.AddWithValue("@FirstName",   c.FirstName.Trim());
            cmd.Parameters.AddWithValue("@LastName",    c.LastName.Trim());
            cmd.Parameters.AddWithValue("@PhoneNumber", c.PhoneNumber.Trim());
            cmd.Parameters.AddWithValue("@Email",       c.Email.Trim());
        }
    }
}
