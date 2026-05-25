using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace projjjjj
{
    /// <summary>
    /// Static system-wide exception logger.
    /// Call ErrorLogger.Log(ex) from any catch block in any form.
    /// </summary>
    public static class ErrorLogger
    {
        // In-memory fallback list used when DB is unreachable
        private static readonly List<string> _memoryLog = new List<string>();

        /// <summary>
        /// Logs an exception. Tries the DB first; falls back to in-memory list.
        /// </summary>
        public static void Log(Exception ex, string source = "Unknown")
        {
            string message = ex?.Message ?? "No message";
            string stackTrace = ex?.StackTrace ?? "";
            DateTime occurredAt = DateTime.Now;

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"
                        INSERT INTO ErrorLogs (Source, Message, StackTrace, OccurredAt)
                        VALUES (@source, @message, @stack, @date)";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@source", source);
                        cmd.Parameters.AddWithValue("@message", message);
                        cmd.Parameters.AddWithValue("@stack", stackTrace);
                        cmd.Parameters.AddWithValue("@date", occurredAt);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                // DB unavailable — store in memory so the app keeps running
                _memoryLog.Add($"[{occurredAt:yyyy-MM-dd HH:mm:ss}] [{source}] {message}");
            }
        }

        /// <summary>
        /// Returns all in-memory logs (used when DB is unavailable).
        /// </summary>
        public static IReadOnlyList<string> GetMemoryLogs() => _memoryLog.AsReadOnly();
        public static void ClearMemoryLogs() => _memoryLog.Clear();
    }
}
