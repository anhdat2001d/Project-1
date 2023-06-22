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
        public static void GreenForegroundColor()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        public static void Line()
        {
            Console.WriteLine(@"                                                                                                                                                                            
█████ █████ █████ █████ █████ █████ █████ █████ █████ █████ █████ █████ █████ █████ █████ █████ █████");
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
        public static void SuccessAlert(string successMsg)
        {
            ConsoleUlts.GreenForegroundColor();
            Console.WriteLine(successMsg.ToUpper() + "✔️");
            ConsoleUlts.ResetColor();
        }
        public static void PrintPhoneInformation(Phone phone)
        {
            Console.WriteLine("| {0, 10} | {1, 20} | {2, 15} | {3, 15} | {4, 15} |", phone.PhoneID, phone.PhoneName, phone.Brand, phone.Price, phone.OS);
        }
        public static void SellerMenu(PhoneBL phoneBL)
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
                        if (Utilities.CreateOrderMenuHandle(phoneBL)) ConsoleUlts.SuccessAlert("Create Order Completed");
                        else ConsoleUlts.ErrorAlert("Don't Have Any Phone To Create Order");
                        break;
                    case 2:
                        Utilities.HandleOrderMenuHandle(phoneBL);
                        break;
                    case 3:
                        active = false;
                        break;
                    default:
                        break;
                }
            }
        }
        public static void AccountantMenu() {}
    }
}