namespace Ults
{
    static class Utilities
    {
        public static void DisplayListPhone()
        {
            Dictionary<int, List<string>> phones = ConsoleUlts.SellerMenuUI();
            int countPage = phones.Count();
            int currentPage = 1;
            Console.WriteLine(countPage);
            ConsoleKeyInfo input = new ConsoleKeyInfo();
            while (true)
            {
                foreach (var phone in phones[currentPage]) Console.WriteLine(phone);
                input = Console.ReadKey();
                if (currentPage <= countPage)
                {
                    if (input.Key == ConsoleKey.RightArrow)
                    {
                        if (currentPage <= countPage - 1) currentPage++;
                    }
                    if (input.Key == ConsoleKey.LeftArrow)
                    {
                        if (currentPage > 1)
                        {
                            currentPage--;
                        }
                    }
                    if (input.Key == ConsoleKey.Spacebar)
                    {
                        break;
                    }

                    Console.Clear();
                }
            }
            Console.WriteLine("Thoat hien thi danh sach dien thoai");
        }
    }
}