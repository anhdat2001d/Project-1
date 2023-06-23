using MySqlConnector;
using Persistence;

namespace DAL
{
    public class PhoneDAL
    {
        private static string query = "";
        public static MySqlConnection connection = DbConfig.GetConnection();
        public static Phone GetItemById(int itemId)
        {
            Phone item = new Phone();
            try
            {
                query = @"select phone_id, Phone_Name, Brand, Price, Platform, status
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
        public static Phone GetItem(MySqlDataReader reader)
        {
            Phone item = new Phone();
            item.PhoneID = reader.GetInt32("Phone_ID");
            item.PhoneName = reader.GetString("Phone_Name");
            item.Brand = reader.GetString("Brand");
            item.Price = reader.GetDecimal("Price");
            item.Platform = reader.GetString("Platform");
            item.Status = reader.GetInt32("status");
            return item;
        }
        public static List<Phone> GetAllItems()
        {
            List<Phone> lst = new List<Phone>();
            try
            {
                MySqlCommand command = new MySqlCommand("", connection);
                query = @"select Phone_Name, Brand, Price, Platform, status from Phones;";
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
        public static List<Phone> Search(string input){
            List<Phone> output = new List<Phone>();
            try{
                MySqlCommand command = new MySqlCommand("", connection);
                query = @"select Phone_Name, Brand, Price, Platform from Phones where Phone_Name like @input
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
        public static List<Phone> GetPhoneHaveDiscount(){
            List<Phone> output = new List<Phone>();
            try{
                query = @"select * from Phones where DiscountPrice != '0';";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while(reader.Read()){
                    output.Add(GetItem(reader));
                }
                reader.Close();
            }
            catch{}
            return output;
        }
        public static int GetQuantityOfItem(Phone phone){
            int output = 0;
            try{
                query = @"select * from phones where Phone_Name = @phonename and Brand = @brand and Price = @price and Platform = @platform;";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@phonename", phone.PhoneName);
                command.Parameters.AddWithValue("@brand", phone.Brand);
                command.Parameters.AddWithValue("@price", phone.Price);
                command.Parameters.AddWithValue("@platform", phone.Platform);

                MySqlDataReader reader = command.ExecuteReader();
                if(reader.Read()){
                    output++;
                }
                reader.Close();
            }catch{}
            return output;
        }
        public static bool InsertItemWithQuantity(Phone phone, int quantity){
            try{
                query = @"insert into phones(phone_name, brand, price, platform) value(@name, @brand, @price, @platform);";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@name", phone.PhoneName);
                command.Parameters.AddWithValue("@brand", phone.Brand);
                command.Parameters.AddWithValue("@price", phone.Price);
                command.Parameters.AddWithValue("@platform", phone.Platform);
                for(int i = 0;i<quantity;i++)command.ExecuteNonQuery();
            }catch{}
            return true;
        }
        
    }
}