using MySqlConnector;
using Persistence;

namespace DAL
{
    public class PhoneDAL
    {
        private string query = "";
        private MySqlConnection connection = DbConfig.GetConnection();
        public Phone GetItemById(int itemId)
        {
            Phone item = new Phone();
            try
            {
                query = @"select Phone_ID, Phone_Name, Brand, Price, Platform
                        from phones where Phone_ID=@itemId;";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@itemId", itemId);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    item = GetItem(reader);
                }
                reader.Close();
            }
            catch { }

            return item;
        }
        internal Phone GetItem(MySqlDataReader reader)
        {
            Phone item = new Phone();
            item.PhoneID = reader.GetInt32("Phone_ID");
            item.PhoneName = reader.GetString("Phone_Name");
            item.Brand = reader.GetString("Brand");
            item.Price = reader.GetDecimal("Price");
            item.OS = reader.GetString("Platform");
            return item;
        }
        public List<Phone> GetAllItem()
        {
            List<Phone> lst = new List<Phone>();
            try
            {
                MySqlCommand command = new MySqlCommand("", connection);
                query = @"select Phone_ID, Phone_Name, Brand, Price, Platform from Phones;";
                command.CommandText = query;
                MySqlDataReader reader = command.ExecuteReader();
                lst = new List<Phone>();
                while (reader.Read())
                {
                    lst.Add(GetItem(reader));
                }
                reader.Close();
            }
            catch { }
            return lst;
        }
        public List<Phone> Search(string input){
            List<Phone> output = new List<Phone>();
            try{
                MySqlCommand command = new MySqlCommand("", connection);
                query = @"select Phone_ID, Phone_Name, Brand, Price, Platform from Phones where Phone_Name like @input
                or Brand like @input or CPUnit like @input or RAM like @input or Battery_Capacity like @input or Platform like @input
                or Sim_Slot like @input or Screen_Hz like @input or Screen_Resolution like @input or ROM like @input or Mobile_Network like @input 
                or Phone_Size like @input or Price like @input or DiscountPrice like @input;";
                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@input", "%"+input+"%");
                MySqlDataReader reader = command.ExecuteReader();
                while(reader.Read()){
                    output.Add(GetItem(reader));
                }
                reader.Close();
            }
            catch{}
            return output;
        }
    }
}