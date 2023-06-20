using MySqlConnector;

namespace DAL
{
    public class DbConfig
    {
        private static MySqlConnection connection = new MySqlConnection();
        private DbConfig() { }
        public static MySqlConnection GetDefaultConnection()
        {
            return GetConnection("server=localhost;user id=root;password=78789898Tia@@;port=3306;database=phonestore;IgnoreCommandTransaction=true;");
        }

        public static MySqlConnection GetConnection()
        {
            try
            {
                string conString;
                using (System.IO.FileStream fileStream = System.IO.File.OpenRead("DbConfig.txt"))
                using (System.IO.StreamReader reader = new System.IO.StreamReader(fileStream))
                {
                    conString = reader.ReadLine() ?? "server=localhost;user id=root;password=78789898Tia;port=3306;database=phonestore;IgnoreCommandTransaction=true;";
                }

                if (!conString.Contains("IgnoreCommandTransaction=true"))
                {
                    conString += "IgnoreCommandTransaction=true;";
                }
                return GetConnection(conString);
            }
            catch
            {
                return GetDefaultConnection();
            }
        }

        public static MySqlConnection GetConnection(string connectionString)
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.ConnectionString = connectionString;
                Console.WriteLine(connectionString);
                connection.Open();
            }
            return connection;
        }
    }
}