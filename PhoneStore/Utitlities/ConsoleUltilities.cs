using System;
namespace Ults
{
    static class ConsoleUlts
    {

        public static void ResetColor()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void Line()
        {
            Console.WriteLine(@"                                                                                                                                                                            
█████ █████ █████ █████ █████ █████ █████ █████ █████ █████ █████ █████ █████ █████ █████ █████");
        }
        public static int Login()
        {
            LoginMenuUI();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Write(@"👉 User Name: ");
            string userName = Console.ReadLine()??"";
            Console.Write(@"👉 Password: ");
            string pwd = Console.ReadLine()??"";
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
        public static void LoginMenuUI()
        {
            string titlePhonestore = @"    ██████  ██   ██  ██████  ███    ██ ███████ ███████ ████████  ██████  ██████  ███████        
    ██   ██ ██   ██ ██    ██ ████   ██ ██      ██         ██    ██    ██ ██   ██ ██             
    ██████  ███████ ██    ██ ██ ██  ██ █████   ███████    ██    ██    ██ ██████  █████          
    ██      ██   ██ ██    ██ ██  ██ ██ ██           ██    ██    ██    ██ ██   ██ ██             
    ██      ██   ██  ██████  ██   ████ ███████ ███████    ██     ██████  ██   ██ ███████       ";
            Ults.ConsoleUlts.ResetColor();
            Ults.ConsoleUlts.Line();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n" + titlePhonestore);
            Ults.ConsoleUlts.ResetColor();
            Ults.ConsoleUlts.Line();
            Console.ForegroundColor = ConsoleColor.Blue;
            string titleLogin = @"                        ██       ██████   ██████  ██ ███    ██                                  
                        ██      ██    ██ ██       ██ ████   ██                                  
                        ██      ██    ██ ██   ███ ██ ██ ██  ██                                  
                        ██      ██    ██ ██    ██ ██ ██  ██ ██                                  
                        ███████  ██████   ██████  ██ ██   ████";

            Console.WriteLine("\n" + titleLogin);
            Ults.ConsoleUlts.ResetColor();
            Ults.ConsoleUlts.Line();
        }
        // START 
        static Dictionary<int, List<string>> menuTab = new Dictionary<int, List<string>>();
        static List<string> sList = new List<string>();
        static List<string> listPhone = new List<string>() { "iphone x", "xs", "xs max", "ip 11", "ip 12", "ip 13", "ip 14", "ip 15", "ip 16", "ip 17", "ip 18", "ip 19", "ip 20" };
        public static Dictionary<int, List<string>> SellerMenuUI()
        {
            int phoneQuantity = listPhone.Count(), itemInTab = 4, numberOfTab = 0, count = 1, secondCount = 1, idTab = 0;

            if (phoneQuantity % itemInTab != 0) numberOfTab = (phoneQuantity / itemInTab) + 1;
            else numberOfTab = phoneQuantity / itemInTab;

            foreach (string phone in listPhone)
            {
                if ((count - 1) == itemInTab)
                {
                    sList = new List<string>();
                    count = 1;
                }
                sList.Add(phone);
                if (sList.Count() == itemInTab)
                {
                    idTab++;
                    menuTab.Add(idTab, sList);
                }
                else if (sList.Count() < itemInTab && secondCount == phoneQuantity)
                {
                    idTab++;
                    menuTab.Add(idTab, sList);
                }
                secondCount++;
                count++;
            }
            return menuTab;
        }
        // END
        public static void Notification(string message) // thông báo
        {
            Console.WriteLine(message + "!");
            PressEnterToContinue();
            if (message == "Invalid Choice!")
                Console.Clear();
        }
    }
}