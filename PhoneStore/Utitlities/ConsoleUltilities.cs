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
        static Dictionary<int, List<Phone>> menuTab = new Dictionary<int, List<Phone>>();
        static List<Phone> sList = new List<Phone>();
        public static Dictionary<int, List<Phone>> SellerMenuHandle(List<Phone> phoneList)
        {
            int phoneQuantity = phoneList.Count(), itemInTab = 4, numberOfTab = 0, count = 1, secondCount = 1, idTab = 0;

            if (phoneQuantity % itemInTab != 0) numberOfTab = (phoneQuantity / itemInTab) + 1; // nếu phoneQuantity chia dư cho itemInTab thì + thêm 1, ex: có 13 phone và mỗi tab hiển thị 3 phone thì chia ra được 4.3 vì là kiểu int nên sẽ là 4 + 1 = 5 
            else numberOfTab = phoneQuantity / itemInTab;

            foreach (Phone phone in phoneList) // 1. tạo vòng for để add phone vào sList và sử lí logic
            {
                if ((count - 1) == itemInTab)
                {
                    sList = new List<Phone>(); // khởi tạo lại list mới khi add đứng số lượng phone = itemInTab vào sList
                    count = 1; // gán lại count = 1 sau khi add đứng số lượng phone = itemInTab số lượng phone vào sList
                }
                sList.Add(phone);
                if (sList.Count() == itemInTab)
                {
                    idTab++;
                    menuTab.Add(idTab, sList);  // add idTab và sList vào menutab (sList ở đây có số lượng phần tử = itemInTab)
                }
                else if (sList.Count() < itemInTab && secondCount == phoneQuantity) // second count là biến đếm số lần chạy của vòng lặp nếu nó = số lượng điện thoại => lần cuối cùng vòng lặp chạy
                {
                    idTab++;
                    menuTab.Add(idTab, sList); // thêm nốt idTab và sList còn lại vào menuTab
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