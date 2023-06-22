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
            PhoneBL phoneBL = new PhoneBL();
            int loginAccount;
            do
            {
                loginAccount = Utilities.LoginUlt();

                if (loginAccount == (int)ActivityEnum.Login.SellerAccount) ConsoleUlts.SellerMenu(phoneBL);

                else if (loginAccount == (int)ActivityEnum.Login.AccountantAccount) ConsoleUlts.AccountantMenu();

                else if (loginAccount == (int)ActivityEnum.Login.Exit) return;

                else ConsoleUlts.ErrorAlert("Invalid choice");

            } while (true);
        }
    }
}


