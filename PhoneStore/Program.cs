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
                // foreach (var item in ConsoleUlts.SellerMenuUI())
                // {
                //     for (var i = 0; i < item.Value.Count(); i++)
                //     {
                //         Console.WriteLine("Tab: " + item.Key + ", Phone: " + item.Value[i]);
                //     }
                // }
            }
            else if (loginAccount == 2)
            {
                // ConsoleUlts.AccountantMenuUI();
            }
            else if (loginAccount == 3) ConsoleUlts.Notification("Exiting Suscess");
            else ConsoleUlts.Notification("Invalid choice");
            Ults.ConsoleUlts.DisplayListPhone();
        }
    }
}


