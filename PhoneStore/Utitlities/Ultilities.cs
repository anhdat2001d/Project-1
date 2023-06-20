using Persistence;

namespace Ults
{
    static class Utilities
    {
        public static void PrintPhoneInformation(Phone phone)
        {
            Console.WriteLine("| {0, 30} | {1, 20} | {2, 15} | {3, 20} |", phone.PhoneName, phone.Brand, phone.Price, phone.Platform);
        }
        public static void DisplayListPhone(List<Phone> listPhone)
        {
            Dictionary<int, List<Phone>> phones = ConsoleUlts.SellerMenuHandle(listPhone);
            int countPage = phones.Count();
            int currentPage = 1;
            Console.WriteLine(countPage);
            ConsoleKeyInfo input = new ConsoleKeyInfo();
            while (true)
            {
                Console.WriteLine("==================================================================================================");
                Console.WriteLine("| {0, 30} | {1, 20} | {2, 15} | {3, 20} |", "Phone Name", "Brand", "Price", "Platform");
                Console.WriteLine("==================================================================================================");
                foreach (Phone phone in phones[currentPage])
                {
                    PrintPhoneInformation(phone);
                }
                Console.WriteLine("{0,45}" + "◀️ " + $"{currentPage}/{countPage}" + " ▶️", " ");
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
            Console.WriteLine("Thoat hien thi danh sach dien thoai");
        }
    }
}