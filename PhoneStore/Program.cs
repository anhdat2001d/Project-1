using System;
using System.Collections.Generic;
using Persistence;
using Ults;
using BL;
using Enum;
using MySql.Data.MySqlClient;

namespace PhoneStoreUI
{
    class Program
    {
        static void Main()
        {
            bool active = true, loginStatus;
            PhoneBL phoneBL = new PhoneBL();
            short mainChoose = 0;
            while (active)
            {
                int loginAccount = Utilities.Login();
                if (loginAccount == (int)ActivityEnum.Login.SellerAccount)
                {
                    Ults.ConsoleUlts.SellerMenu(phoneBL);
                }
                else if (loginAccount == (int)ActivityEnum.Login.AccountantAccount)
                {
                    // ConsoleUlts.AccountantMenuUI();
                }
                else if (loginAccount == (int)ActivityEnum.Login.Exit)
                {
                    active = false;
                    ConsoleUlts.Notification("Exiting Suscess");
                }
                else ConsoleUlts.Notification("Invalid choice");
            }
        }
    }
}


