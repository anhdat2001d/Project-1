using System;
using Persistence;
using BL;
using Enum;

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
        public static bool PressEnterTo(string action)
        {
            Console.WriteLine($"Press Enter To {action}...");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
            {
                return true;
            }
            else PressEnterTo(action);
            return true;
        }
        public static void CreateOrderMenuHandle(PhoneBL phoneBL)
        {
            bool active = true, activeSearchPhone = true;
            List<Phone> phones = phoneBL.GetAllItem();
            List<Phone>? listSearch = new List<Phone>();
            string[] menuItem = { "👉 Search Phone By Information", "👉 Back To Previous Menu" };
            string[] menuOption = { "Re-Enter Phone Information", "Cancel Order" };
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
                        do
                        {
                            string searchPhone = "";
                            int reEnterOrCancel;
                            Console.Write("\nEnter Phone Information To Search: ");
                            searchPhone = Console.ReadLine() ?? "";
                            listSearch = phoneBL.SearchPhoneByInformation(searchPhone);
                            if (listSearch.Count() == 0)
                            {
                                ConsoleUlts.WarningAlert("Phone Not Found");
                                do
                                {
                                    reEnterOrCancel = Utilities.Menu(null, null, menuOption);

                                    switch (reEnterOrCancel)
                                    {
                                        case (int)E.SearchPhone.ReEnterPhoneInfo:
                                            ConsoleUlts.PressEnterTo("Re-enter Phone Infomation");
                                            break;
                                        case (int)E.SearchPhone.CancelOrder:
                                            ConsoleUlts.PressEnterTo("Back Previous Menu");
                                            activeSearchPhone = false;
                                            break;
                                    }
                                } while (reEnterOrCancel == (int)E.SearchPhone.ReEnterPhoneInfo && reEnterOrCancel == (int)E.SearchPhone.CancelOrder);
                            }
                            else if (listSearch.Count() != 0 && Ults.Utilities.PhonePageHandle(listSearch))
                            {
                                int phoneId;
                                // Add phone to order by id
                                do
                                {
                                    Console.WriteLine("Input phone id to add to order:");
                                    int.TryParse(Console.ReadLine(), out phoneId);
                                    if (phoneId <= 0 || phoneId > phones.Count())
                                    {
                                        ConsoleUlts.ErrorAlert("Invalid phone id, Please Try Again");
                                    }
                                } while (phoneId <= 0 || phoneId > phones.Count());
                                ConsoleUlts.Notification("Add Complete");
                                activeSearchPhone = false;
                            }
                            else
                            {
                                Console.WriteLine("Error");
                                activeSearchPhone = false;
                            }
                        } while (activeSearchPhone);
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
            PressEnterTo("Continue");
            if (message == "Invalid Choice!")
                Console.Clear();
        }
        public static void ErrorAlert(string errorMsg)
        {
            ConsoleUlts.RedForegroundColor();
            Console.WriteLine(errorMsg.ToUpper() + "❌");
            ConsoleUlts.ResetColor();
        }
        public static void WarningAlert(string warnMsg)
        {
            ConsoleUlts.YellowForegroundColor();
            Console.WriteLine(warnMsg.ToUpper() + "⚠️");
            ConsoleUlts.ResetColor();
        }
        public static void SellerMenuHandle(PhoneBL phoneBL)
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
                        CreateOrderMenuHandle(phoneBL);
                        break;
                    case 2:
                        HandleOrderMenuHandle(phoneBL);
                        break;
                    case 3:
                        active = false;
                        break;
                    default:
                        break;
                }
            }
        }
        public static void HandleOrderMenuHandle(PhoneBL phoneBL)
        {
            bool active = true;

            string[] menuItem = { "👉 Show order by paid status in day", "👉 Back To Previous Menu" };
            while (active)
            {
                switch (Utilities.Menu(
                    null,
                    @"██   ██  █████  ███    ██ ██████  ██      ███████      ██████  ██████  ██████  ███████ ██████  
██   ██ ██   ██ ████   ██ ██   ██ ██      ██          ██    ██ ██   ██ ██   ██ ██      ██   ██ 
███████ ███████ ██ ██  ██ ██   ██ ██      █████       ██    ██ ██████  ██   ██ █████   ██████  
██   ██ ██   ██ ██  ██ ██ ██   ██ ██      ██          ██    ██ ██   ██ ██   ██ ██      ██   ██ 
██   ██ ██   ██ ██   ████ ██████  ███████ ███████      ██████  ██   ██ ██████  ███████ ██   ██ ", menuItem))
                {
                    case 1:
                        ConsoleUlts.Title(null,
                        @"███████ ██   ██  ██████  ██     ██      ██████  ██████  ██████  ███████ ██████  
██      ██   ██ ██    ██ ██     ██     ██    ██ ██   ██ ██   ██ ██      ██   ██ 
███████ ███████ ██    ██ ██  █  ██     ██    ██ ██████  ██   ██ █████   ██████  
     ██ ██   ██ ██    ██ ██ ███ ██     ██    ██ ██   ██ ██   ██ ██      ██   ██ 
███████ ██   ██  ██████   ███ ███       ██████  ██   ██ ██████  ███████ ██   ██ "
                        );
                        string orderId = "";
                        Console.Write("Input order id:");
                        orderId = Console.ReadLine();

                        break;

                    case 2:
                        active = false;
                        break;
                    default:
                        break;



                }
            }
        }
    }
}