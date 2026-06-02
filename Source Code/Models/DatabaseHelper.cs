using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projjjjj
{
    public class DatabaseHelper
    {
        //after Server=* -- * is he name of the server locally
        private static string connectionString = @"Server=.\SQLEXPRESS;Database=Vehicle_Rental;Integrated Security=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
