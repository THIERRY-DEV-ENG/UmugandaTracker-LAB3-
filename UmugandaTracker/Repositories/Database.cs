using MySqlConnector;

namespace UmugandaTracker.Models
{
    public static class Database
    {
        public static string ConnectionString =
            "Server=127.0.0.1;Port=3306;Database=UmugandaDB;User ID=root;Password=";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}