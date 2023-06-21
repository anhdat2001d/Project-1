using Persistence;

namespace Ults
{
    static class Utilities
    {
        public static void PrintPhoneInformation(Phone phone)
        {
            Console.WriteLine("| {0, 10} | {1, 30} | {2, 20} | {3, 15} | {4, 20} |", phone.PhoneID, phone.PhoneName, phone.Brand, phone.Price, phone.Platform);
        }

        public static int Menu(string title, string subTitle, string[] menuItem)
        {
            int i = 0, choice;
            ConsoleUlts.Title(title, subTitle);
            for (; i < menuItem.Count(); i++)
            {
                Console.WriteLine("\n" + menuItem[i] + " (" + (i + 1) + ")");
            }
            ConsoleUlts.Line();
            do
            {
                Console.Write("\n" + "👀 Your choice: ");
                int.TryParse(Console.ReadLine(), out choice);
            } while (choice <= 0 || choice > menuItem.Count());
            return choice;
        }
        public static void PhonePageHandle(List<Phone> listPhone)
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
                    Console.WriteLine("===============================================================================================================");
                    Console.WriteLine("| {0, 10} | {1, 30} | {2, 20} | {3, 15} | {4, 20} |", "ID", "Phone Name", "Brand", "Price", "Platform");
                    Console.WriteLine("===============================================================================================================");
                    foreach (Phone phone in phones[currentPage])
                    {
                        PrintPhoneInformation(phone);
                    }
                    Console.WriteLine("===============================================================================================================");
                    Console.WriteLine("{0,55}" + "< " + $"{currentPage}/{countPage}" + " >", " ");
                    Console.WriteLine("===============================================================================================================");
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
                        if (input.Key == ConsoleKey.Spacebar) break;
                    }
                }
            } else {
                ConsoleUlts.WarningAlert("Phone Not Found!");
            }
            // AddPhoneToOrder(phone, order);
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
    }
}