using System;
using Persistence;

namespace Ults
{
    static class ConsoleUlts
    {
        public static void ResetColor()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void RedForegroundColor()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        public static void BlueForegroundColor()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
        }
        public static void YellowForegroundColor()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        public static void Line()
        {
            Console.WriteLine(@"                                                                                                                                                                            
█████ █████ █████ █████ █████ █████ █████ █████ █████ █████ █████ █████ █████ █████ █████ █████ █████");
        }
        public static int Login()
        {
            LoginMenuUI();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Write(@"👉 User Name: ");
            string userName = Console.ReadLine() ?? "";
            Console.Write(@"👉 Password: ");
            string pass = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    Console.Write("\b");
                }
            }
            while (key.Key != ConsoleKey.Enter);
            return 1;
        }
        public static bool PressEnterToContinue()
        {
            Console.Write("Press Enter To Countinue...");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
            {
                return true;
            }
            else PressEnterToContinue();
            return true;
        }
        public static void CreateOrderMenuHandle(DAL.PhoneDAL phoneDAL)
        {
            bool active = true;
            List<Phone> phones = phoneDAL.GetAllItem();
            string[] menuItem = { "👉 Search Phone By Information", "👉 Back To Previous Menu" };
            while (active)
            {
                switch (Utilities.Menu(
                   null,
    @"     ██████ ██████  ███████  █████  ████████ ███████      ██████  ██████  ██████  ███████ ██████  
    ██      ██   ██ ██      ██   ██    ██    ██          ██    ██ ██   ██ ██   ██ ██      ██   ██ 
    ██      ██████  █████   ███████    ██    █████       ██    ██ ██████  ██   ██ █████   ██████  
    ██      ██   ██ ██      ██   ██    ██    ██          ██    ██ ██   ██ ██   ██ ██      ██   ██ 
     ██████ ██   ██ ███████ ██   ██    ██    ███████      ██████  ██   ██ ██████  ███████ ██   ██ ", menuItem))
                {
                    case 1:
                        ConsoleUlts.Title(null, 
                        @"    ███████ ███████  █████  ██████   ██████ ██   ██     ██████  ██   ██  ██████  ███    ██ ███████ 
    ██      ██      ██   ██ ██   ██ ██      ██   ██     ██   ██ ██   ██ ██    ██ ████   ██ ██      
    ███████ █████   ███████ ██████  ██      ███████     ██████  ███████ ██    ██ ██ ██  ██ █████   
         ██ ██      ██   ██ ██   ██ ██      ██   ██     ██      ██   ██ ██    ██ ██  ██ ██ ██      
    ███████ ███████ ██   ██ ██   ██  ██████ ██   ██     ██      ██   ██  ██████  ██   ████ ███████ "
                        );
                        Console.Write("\nEnter Phone Information To Add To Order: ");
                        string searchPhone = Console.ReadLine() ?? "";
                        Ults.Utilities.PhonePageHandle(phoneDAL.Search(searchPhone));
                        break;
                    case 2:
                        active = false;
                        break;
                    default:
                        break;
                }
            }
        }
        public static void Title(string? title, string? subTitle)
        {
            if (title != null)
            {
                Ults.ConsoleUlts.ResetColor();
                Ults.ConsoleUlts.Line();
                RedForegroundColor();
                Console.WriteLine("\n" + title);
                Ults.ConsoleUlts.ResetColor();
                Ults.ConsoleUlts.Line();
            }
            if (subTitle != null)
            {
                Ults.ConsoleUlts.Line();
                BlueForegroundColor();
                Console.WriteLine("\n" + subTitle);
                Ults.ConsoleUlts.ResetColor();
                Ults.ConsoleUlts.Line();
            }

        }
        public static void LoginMenuUI()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Title(
                @"        ██████  ██   ██  ██████  ███    ██ ███████ ███████ ████████  ██████  ██████  ███████ 
        ██   ██ ██   ██ ██    ██ ████   ██ ██      ██         ██    ██    ██ ██   ██ ██      
        ██████  ███████ ██    ██ ██ ██  ██ █████   ███████    ██    ██    ██ ██████  █████   
        ██      ██   ██ ██    ██ ██  ██ ██ ██           ██    ██    ██    ██ ██   ██ ██      
        ██      ██   ██  ██████  ██   ████ ███████ ███████    ██     ██████  ██   ██ ███████ "
            , @"                            ██       ██████   ██████  ██ ███    ██ 
                            ██      ██    ██ ██       ██ ████   ██ 
                            ██      ██    ██ ██   ███ ██ ██ ██  ██ 
                            ██      ██    ██ ██    ██ ██ ██  ██ ██ 
                            ███████  ██████   ██████  ██ ██   ████ ");
        }
        public static void Notification(string message) // thông báo
        {
            Console.WriteLine(message + "!");
            PressEnterToContinue();
            if (message == "Invalid Choice!")
                Console.Clear();
        }
        public static void ErrorAlert(string errorMsg)
        {
            ConsoleUlts.RedForegroundColor();
            Console.WriteLine("⛔ " + errorMsg);
            ConsoleUlts.ResetColor();
        }
        public static void WarningAlert(string warnMsg)
        {
            ConsoleUlts.YellowForegroundColor();
            Console.WriteLine("⚠️ " + warnMsg);
            ConsoleUlts.ResetColor();
        }
        public static void SellerMenuHandle(DAL.PhoneDAL phoneDAL)
        {
            bool active = true;
            string[] menuItem = { "👉 Create Order", "👉 Handle Order", "👉 Log Out" };
            while (active)
            {
                switch (Utilities.Menu(
                    null
    , @"    ███████ ███████ ██      ██      ███████ ██████      ███    ███ ███████ ███    ██ ██    ██ 
    ██      ██      ██      ██      ██      ██   ██     ████  ████ ██      ████   ██ ██    ██ 
    ███████ █████   ██      ██      █████   ██████      ██ ████ ██ █████   ██ ██  ██ ██    ██ 
         ██ ██      ██      ██      ██      ██   ██     ██  ██  ██ ██      ██  ██ ██ ██    ██ 
    ███████ ███████ ███████ ███████ ███████ ██   ██     ██      ██ ███████ ██   ████  ██████  ", menuItem))
                {
                    case 1:
                        CreateOrderMenuHandle(phoneDAL);
                        break;
                    case 2:
                        break;
                    case 3:
                        active = false;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}