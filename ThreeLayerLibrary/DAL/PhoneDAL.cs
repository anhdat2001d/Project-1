using MySqlConnector;
using Persistence;

namespace DAL
{
    public static class ItemFilter
    {
        public const int GET_ALL = 0;
        public const int FILTER_BY_ITEM_NAME = 1;
    }
    public class PhoneDAL
    {
        private string query = "";
        private MySqlConnection connection = DbConfig.GetConnection();
        public Phone GetItemById(int itemId)
        {
            Phone item = new Phone();
            try
            {
                query = @"select Phone_Name, Brand, Price, Platform
                        from phones where Phone_ID=@itemId;";
                MySqlCommand command = new MySqlCommand(query, connection);
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
            item.Brand = reader.GetString("Brand");
            item.Price = reader.GetDecimal("Price");
            item.Platform = reader.GetString("Platform");
            return item;
        }
        public List<Phone> GetItems(int itemFilter, Phone item)
        {
            List<Phone> lst = new List<Phone>();
            try
            {
                MySqlCommand command = new MySqlCommand("", connection);
                switch (itemFilter)
                {
                    case ItemFilter.GET_ALL:
                        query = @"select Phone_Name, Brand, Price, Platform from Phones";
                        break;
                    case ItemFilter.FILTER_BY_ITEM_NAME:
                        query = @"select Phone_Name, Brand, Price, Platform from Phones
                                where item_name like concat('%',@phoneName,'%');";
                        command.Parameters.AddWithValue("@phoneName", item.PhoneName);
                        break;
                }
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
    }
}