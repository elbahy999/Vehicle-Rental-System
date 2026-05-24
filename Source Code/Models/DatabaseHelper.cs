namespace Project_Name
{
    public class DatabaseHelper
    {
        //Change the Server_name
        private static string connectionString = "Server=Server_name; Database=Vehicle_Rental; Integrated Security=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
