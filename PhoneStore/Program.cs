using System;
using System.Collections.Generic;
//using Persistence;
using Ults;

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
            if (loginAccount == 1)
            {
                Ults.Utilities.DisplayListPhone();
            }
            else if (loginAccount == 2)
            {
                // ConsoleUlts.AccountantMenuUI();
            }
            else if (loginAccount == 3) ConsoleUlts.Notification("Exiting Suscess");
            else ConsoleUlts.Notification("Invalid choice");
        }
    }
}


