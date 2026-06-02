using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace projjjjj
{
    public static class VehicleManager
    {
        // ══════════════════════════════════════════════════════════════════════
        // CREATE
        // ══════════════════════════════════════════════════════════════════════
        public static bool AddVehicle(Vehicle vehicle)
        {
            try
            {
                VehicleValidator.Validate(vehicle);
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex, "VehicleManager.AddVehicle.Validation");
                MessageBox.Show(ex.Message, "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            const string sql = @"
                INSERT INTO Vehicles (Plate, VehicleType, Brand, DailyRate, IsAvailable)
                VALUES (@Plate, @VehicleType, @Brand, @DailyRate, @IsAvailable)";

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    BindParameters(cmd, vehicle);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex, "VehicleManager.AddVehicle.Database");
                MessageBox.Show("Error adding vehicle:\n" + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ══════════════════════════════════════════════════════════════════════
        // READ ALL
        // ══════════════════════════════════════════════════════════════════════
        public static List<Vehicle> GetAllVehicles()
        {
            var list = new List<Vehicle>();
            const string sql = "SELECT * FROM Vehicles ORDER BY Brand, VehicleType";

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
                ErrorLogger.Log(ex, "VehicleManager.GetAllVehicles");
                MessageBox.Show("Error loading vehicles:\n" + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return list;
        }

        // ══════════════════════════════════════════════════════════════════════
        // READ AVAILABLE
        // ══════════════════════════════════════════════════════════════════════
        public static List<Vehicle> GetAvailableVehicles()
        {
            var list = new List<Vehicle>();
            const string sql = "SELECT * FROM Vehicles WHERE IsAvailable = 1 ORDER BY Brand, VehicleType";

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
                ErrorLogger.Log(ex, "VehicleManager.GetAvailableVehicles");
                MessageBox.Show("Error loading available vehicles:\n" + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return list;
        }

        // ══════════════════════════════════════════════════════════════════════
        // UPDATE
        // ══════════════════════════════════════════════════════════════════════
        public static bool UpdateVehicle(Vehicle vehicle)
        {
            try
            {
                VehicleValidator.Validate(vehicle);
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex, "VehicleManager.UpdateVehicle.Validation");
                MessageBox.Show(ex.Message, "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            const string sql = @"
                UPDATE Vehicles SET
                    Plate       = @Plate,
                    VehicleType = @VehicleType,
                    Brand       = @Brand,
                    DailyRate   = @DailyRate,
                    IsAvailable = @IsAvailable
                WHERE VehicleID = @VehicleID";

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    BindParameters(cmd, vehicle);
                    cmd.Parameters.AddWithValue("@VehicleID", vehicle.VehicleID);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex, "VehicleManager.UpdateVehicle.Database");
                MessageBox.Show("Error updating vehicle:\n" + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ══════════════════════════════════════════════════════════════════════
        // SET AVAILABILITY
        // ══════════════════════════════════════════════════════════════════════
        public static bool SetAvailability(int vehicleId, bool isAvailable)
        {
            const string sql = "UPDATE Vehicles SET IsAvailable = @IsAvailable WHERE VehicleID = @VehicleID";

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@IsAvailable", isAvailable);
                    cmd.Parameters.AddWithValue("@VehicleID", vehicleId);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex, "VehicleManager.SetAvailability");
                MessageBox.Show("Error updating availability:\n" + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ══════════════════════════════════════════════════════════════════════
        // DELETE
        // ══════════════════════════════════════════════════════════════════════
        public static bool DeleteVehicle(int vehicleId)
        {
            const string sql = "DELETE FROM Vehicles WHERE VehicleID = @ID";

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", vehicleId);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex, "VehicleManager.DeleteVehicle");
                MessageBox.Show("Error deleting vehicle:\n" + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ══════════════════════════════════════════════════════════════════════
        // HELPERS
        // ══════════════════════════════════════════════════════════════════════
        private static void BindParameters(SqlCommand cmd, Vehicle v)
        {
            cmd.Parameters.AddWithValue("@Plate",       v.Plate);
            cmd.Parameters.AddWithValue("@VehicleType", v.VehicleType);
            cmd.Parameters.AddWithValue("@Brand",       v.Brand);
            cmd.Parameters.AddWithValue("@DailyRate",   v.DailyRate);
            cmd.Parameters.AddWithValue("@IsAvailable", v.IsAvailable);
        }

        private static Vehicle MapRow(SqlDataReader r) => new Vehicle
        {
            VehicleID   = (int)r["VehicleID"],
            Plate       = r["Plate"].ToString(),
            VehicleType = r["VehicleType"].ToString(),
            Brand       = r["Brand"].ToString(),
            DailyRate   = (decimal)r["DailyRate"],
            IsAvailable = (bool)r["IsAvailable"]
        };
    }
}
