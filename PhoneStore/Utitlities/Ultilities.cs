using Persistence;
using BL;
using Enum;

namespace Ults
{
    static class Utilities
    {
        public static int Menu(string? title, string? subTitle, string[] menuItem)
        {
            int i = 0, choice;
            if (title != null || subTitle != null) ConsoleUlts.Title(title, subTitle);
            for (; i < menuItem.Count(); i++)
            {
                Console.WriteLine("\n" + menuItem[i] + " (" + (i + 1) + ")");
            }
            ConsoleUlts.Line();
            do
            {
                Console.Write("\n" + "👀 Your choice: ");
                int.TryParse(Console.ReadLine(), out choice);
                if (choice <= 0 || choice > menuItem.Count())
                {
                    ConsoleUlts.ErrorAlert("Invalid Choice, Please Try Again");
                }
            } while (choice <= 0 || choice > menuItem.Count());
            return choice;
        }
        public static bool PhonePageHandle(List<Phone> listPhone)
        {
            if (listPhone.Count() != 0)
            {
                Dictionary<int, List<Phone>> phones = new Dictionary<int, List<Phone>>();
                phones = SellerMenuHandle(listPhone);
                int countPage = phones.Count(), currentPage = 1;
                ConsoleKeyInfo input = new ConsoleKeyInfo();
                while (true)
                {
                    Ults.ConsoleUlts.Title(
                        null,
    @"     █████  ██████  ██████      ████████  ██████       ██████  ██████  ██████  ███████ ██████  
    ██   ██ ██   ██ ██   ██        ██    ██    ██     ██    ██ ██   ██ ██   ██ ██      ██   ██ 
    ███████ ██   ██ ██   ██        ██    ██    ██     ██    ██ ██████  ██   ██ █████   ██████  
    ██   ██ ██   ██ ██   ██        ██    ██    ██     ██    ██ ██   ██ ██   ██ ██      ██   ██ 
    ██   ██ ██████  ██████         ██     ██████       ██████  ██   ██ ██████  ███████ ██   ██ "
                    );
                    Console.WriteLine("=====================================================================================================");
                    Console.WriteLine("| {0, 10} | {1, 20} | {2, 15} | {3, 15} | {4, 15} |", "ID", "Phone Name", "Brand", "Price", "Platform");
                    Console.WriteLine("=====================================================================================================");
                    foreach (Phone phone in phones[currentPage])
                    {
                        ConsoleUlts.PrintPhoneInformation(phone);
                    }
                    Console.WriteLine("=====================================================================================================");
                    Console.WriteLine("{0,55}" + "< " + $"{currentPage}/{countPage}" + " >", " ");
                    Console.WriteLine("=====================================================================================================");
                    Console.WriteLine("Press 'Left Arrow' To Back Previous Page, 'Right Arror' To Next Page");
                    Console.WriteLine("Press 'Space' To Add Phone By ID, 'B' To Back Previous Menu");
                    input = Console.ReadKey();
                    if (currentPage <= countPage)
                    {
                        if (input.Key == ConsoleKey.RightArrow)
                        {
                            if (currentPage <= countPage - 1) currentPage++;
                            Console.Clear();
                        }
                        if (input.Key == ConsoleKey.LeftArrow)
                        {
                            if (currentPage > 1) currentPage--;
                            Console.Clear();
                        }

                        if (input.Key == ConsoleKey.B) break;

                        if (input.Key == ConsoleKey.Spacebar)
                        {
                            Console.Clear();
                            Console.WriteLine("=====================================================================================================");
                            Console.WriteLine("| {0, 10} | {1, 20} | {2, 15} | {3, 15} | {4, 15} |", "ID", "Phone Name", "Brand", "Price", "Platform");
                            Console.WriteLine("=====================================================================================================");

                            foreach (Phone phone in phones[currentPage])
                            {
                                ConsoleUlts.PrintPhoneInformation(phone);
                            }
                            Console.WriteLine("=====================================================================================================");
                            Console.WriteLine("{0,55}" + "< " + $"{currentPage}/{countPage}" + " >", " ");
                            Console.WriteLine("=====================================================================================================");
                            return true;
                        }
                    }
                }
            }
            else
            {
                ConsoleUlts.WarningAlert("Phone Not Found");
                PressEnterTo("Back To Previous Menu");
            }
            return false;
        }
        public static Dictionary<int, List<Phone>> SellerMenuHandle(List<Phone> phoneList)
        {
            List<Phone> sList = new List<Phone>();
            Dictionary<int, List<Phone>> menuTab = new Dictionary<int, List<Phone>>();
            int phoneQuantity = phoneList.Count(), itemInTab = 4, numberOfTab = 0, count = 1, secondCount = 1, idTab = 0;

            if (phoneQuantity % itemInTab != 0) numberOfTab = (phoneQuantity / itemInTab) + 1;
            else numberOfTab = phoneQuantity / itemInTab;

            foreach (Phone phone in phoneList)
            {
                if ((count - 1) == itemInTab)
                {
                    sList = new List<Phone>();
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
        public static int LoginUlt()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            ConsoleUlts.Title(
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
                else if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    // Xóa ký tự cuối cùng trong chuỗi pass khi người dùng nhấn phím Backspace
                    pass = pass.Substring(0, pass.Length - 1);
                    Console.Write("\b \b");
                }
            }
            while (key.Key != ConsoleKey.Enter);
            // sử dụng StaffBL staffBL.Login(); gọi đến phương thức Login để truy cập vào database check tài khoản

            return 1;
        }
        public static bool PressEnterTo(string action)
        {
            Console.Write($"👉 Enter To {action}...");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
            {
                return true;
            }
            else PressEnterTo(action);
            return true;
        }
        public static bool CreateOrderMenuHandle(PhoneBL phoneBL)
        {
            int reEnterOrCancel;
            bool active = true, activeSearchPhone = true;
            List<Phone>? phones = phoneBL.GetAllItem();
            if (phones != null)
            {
                List<Phone>? listSearch = new List<Phone>();
                string? searchPhone = null;
                string[] menuItem = { "👉 Search Phone By Information", "👉 Back To Previous Menu" };
                string[] menuOption = { "👉 Re-Enter Phone Information", "👉 Cancel Order" };
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
                                Console.Write("\nEnter Phone Information To Search: ");
                                searchPhone = Console.ReadLine() ?? null;
                                listSearch = phoneBL.SearchByPhoneInformation(searchPhone);
                                if (listSearch == null)
                                {
                                    ConsoleUlts.ErrorAlert("Phone Not Found");

                                    reEnterOrCancel = Utilities.Menu(null, null, menuOption);
                                    switch (reEnterOrCancel)
                                    {
                                        case (int)ActivityEnum.SearchPhone.ReEnterPhoneInfo:
                                            PressEnterTo("Re-enter Phone Infomation");
                                            break;
                                        case (int)ActivityEnum.SearchPhone.CancelOrder:
                                            PressEnterTo("Back Previous Menu");
                                            activeSearchPhone = false;
                                            break;
                                    }
                                }
                                else
                                {
                                    Utilities.PhonePageHandle(listSearch);
                                    int phoneId;
                                    do
                                    {
                                        Console.Write("👉 Input Phone ID To Add To Order: ");
                                        int.TryParse(Console.ReadLine(), out phoneId);

                                        if (phoneId <= 0 || phoneId > phones.Count())
                                            ConsoleUlts.ErrorAlert("Invalid Phone ID, Please Try Again");

                                    } while (phoneId <= 0 || phoneId > phones.Count());
                                    return true;
                                }
                            } while (activeSearchPhone);
                            break;
                        case 2:
                            active = false;
                            break;
                    }
                }
            }
            else return false;
            return true;
        }
        public static void HandleOrderMenuHandle(PhoneBL phoneBL)
        {
            bool active = true;

            string[] menuItem = { "👉 Show order by paid status in day", "👉 Back To Previous Menu" };
            while (active)
            {
                switch (Utilities.Menu(
                    null,
                    @"    ██   ██  █████  ███    ██ ██████  ██      ███████      ██████  ██████  ██████  ███████ ██████  
    ██   ██ ██   ██ ████   ██ ██   ██ ██      ██          ██    ██ ██   ██ ██   ██ ██      ██   ██ 
    ███████ ███████ ██ ██  ██ ██   ██ ██      █████       ██    ██ ██████  ██   ██ █████   ██████  
    ██   ██ ██   ██ ██  ██ ██ ██   ██ ██      ██          ██    ██ ██   ██ ██   ██ ██      ██   ██ 
    ██   ██ ██   ██ ██   ████ ██████  ███████ ███████      ██████  ██   ██ ██████  ███████ ██   ██ ", menuItem))
                {
                    case 1:
                        ConsoleUlts.Title(null,
                        @"            ███████ ██   ██  ██████  ██     ██      ██████  ██████  ██████  ███████ ██████  
            ██      ██   ██ ██    ██ ██     ██     ██    ██ ██   ██ ██   ██ ██      ██   ██ 
            ███████ ███████ ██    ██ ██  █  ██     ██    ██ ██████  ██   ██ █████   ██████  
                 ██ ██   ██ ██    ██ ██ ███ ██     ██    ██ ██   ██ ██   ██ ██      ██   ██ 
            ███████ ██   ██  ██████   ███ ███       ██████  ██   ██ ██████  ███████ ██   ██ "
                        );
                        string orderId = "";
                        Console.Write("Input order id:");
                        orderId = Console.ReadLine() ?? "";
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