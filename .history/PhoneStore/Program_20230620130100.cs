using System;
using System.Collections.Generic;
using Persistence;
using Ults;
using BL;
using DAL;
using MySql.Data.MySqlClient;

namespace PhoneStoreUI
{

    class Program
    {
        static void Main()
        {
            bool active = true;
            bool loginStatus;
            short mainChoose = 0;
            int loginAccount = ConsoleUlts.Login();
            List<Phone> phones = new List<Phone>();
            phones = GetListItem();
            if (loginAccount == 1)
            {
                Ults.Utilities.DisplayListPhone(phones);
            }
            else if (loginAccount == 2)
            {
                // ConsoleUlts.AccountantMenuUI();
            }
            else if (loginAccount == 3) ConsoleUlts.Notification("Exiting Suscess");
            else ConsoleUlts.Notification("Invalid choice");

        }

        public static List<Phone> GetListItem()
        {
            List<Phone> phones = new List<Phone>();
            string connectionString = "server=localhost;uid=root;pwd=78789898Tia@@;database=phonestore";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            string insertQuery = "SELECT * FROM phones";
            MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Phone phone = new Phone();
                phone.PhoneID = reader.GetInt32("Phone_ID");
                phone.PhoneName = reader.GetString("Phone_Name");
                phone.Price = reader.GetDecimal("Price");
                phone.Brand = reader.GetString("Brand");
                phones.Add(phone);
            }
            return phones;
        }
    }
}


