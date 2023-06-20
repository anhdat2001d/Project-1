using System;
using System.Collections.Generic;
using Persistence;
using Ults;
using BL;
using DAL;
using Enum;
using MySql.Data.MySqlClient;

namespace PhoneStoreUI
{
    class Program
    {
        static void Main()
        {
            bool active = true, loginStatus;
            PhoneDAL phoneDAL = new DAL.PhoneDAL();
            short mainChoose = 0;
            while (active)
            {
                int loginAccount = ConsoleUlts.Login();
                if (loginAccount == (int)E.LoginActivity.SellerAccount)
                {
                    Ults.ConsoleUlts.SellerMenuHandle(phoneDAL);
                }
                else if (loginAccount == (int)E.LoginActivity.AccountantAccount)
                {
                    // ConsoleUlts.AccountantMenuUI();
                }
                else if (loginAccount == (int)E.LoginActivity.Exit)
                {
                    active = false;
                    ConsoleUlts.Notification("Exiting Suscess");
                }
                else ConsoleUlts.Notification("Invalid choice");
            }
        }
    }
}


