using System;
using Rules;
using Reservering;
using MenuPage0;
using Contact;
using Test;
namespace Greenhouse
{
    class Pages
    {
        public static void Home()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("--Welkom bij de Reserverings Applicatie van GreenHouse--\n");
                Console.WriteLine("--Duurzaamheid en Sustainability met Lokale Leveranciers!--");
                Console.WriteLine("\t--Voor elke portomonee en altijd lekker!--\n");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("| Elke dag open, vannaf 13:00 tot 22:00 |");
                Console.WriteLine("| De bar is open van 13:00 tot 01:00    |");
                Console.WriteLine("-----------------------------------------\n");
                Console.WriteLine("Dit zijn de opties:\n");
                Console.WriteLine("1. Reserveren");
                Console.WriteLine("2. Menu");
                Console.WriteLine("3. Regels");
                Console.WriteLine("4. Contact Opnemen?");
                Console.WriteLine("5. Exit");

                Console.Write("Zet hier uw keuze neer: ");
                string result = Console.ReadLine();
                switch (result)
                {
                    case "1":
                        PageReservering.show();
                        break;
                    case "2":
                        menuPage0.show();
                        break;
                    case "3":
                        rules.show();
                        break;
                    case "4":
                        contact.show();
                        break;
                    case "5":
                        running = false;
                        break;
                    case "6":
                        test.run();
                        break;
                    default:
                        Console.Clear();
                        break;



                }
            }
        }


    }
    
    class Program
    {
        static void Main(string[] args)
        {
            // Omdat het greenhouse is deze kleuren
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.SetWindowSize(160, 35);
            Pages.Home(); 



        }
    }
}
