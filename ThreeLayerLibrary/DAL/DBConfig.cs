using MySqlConnector;

namespace DAL
{
    public class DbConfig
    {
        private static MySqlConnection connection = new MySqlConnection();
        private DbConfig() { }
        public static MySqlConnection GetConnection(){
            string conString = @"server=localhost;user id=root;password=anhdat01;port=3306;database=phonestore;";
            connection.ConnectionString = conString;
            if(connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            return connection;
        }
}
}
