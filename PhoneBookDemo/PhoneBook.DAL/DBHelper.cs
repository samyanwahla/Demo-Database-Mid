using MySql.Data.MySqlClient;

namespace PhoneBook.DAL
{
    // DAL LAYER: Manages the database connection
    // Teaching Point 1: Connection strings live here in the DAL — never in the UI
    // Teaching Point 5: Separation of Concerns — DBHelper has ONE job: provide a connection
    public static class DBHelper
    {
        // TODO: Update the password below to match your MySQL installation
        private const string ConnectionString =
            "Server=localhost;Database=PhoneBookDB;Uid=root;Pwd=yourpassword;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
