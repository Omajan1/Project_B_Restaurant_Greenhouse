using System;
using Rules;
using Reservering;
using MenuPage0;
using Contact;
using Test;

namespace Greenhouse
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.SetWindowSize(180, 35);

            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("--Welkom bij de Reserverings Applicatie van GreenHouse--\n");
                Console.WriteLine("--Duurzaamheid en Sustainability met Lokale Leveranciers!--");
                Console.WriteLine("\t--Voor elke portomonee en altijd lekker!--\n");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("| Elke dag open, vannaf 13:00 tot 22:00 |");
                Console.WriteLine("| De bar is open van 13:00 tot 01:00    |");
                Console.WriteLine("-----------------------------------------\n");
                Console.WriteLine("Dit zijn de opties:");
                Console.WriteLine("1. Reserveren");
                Console.WriteLine("2. Menu");
                Console.WriteLine("3. Regels");
                Console.WriteLine("4. Contact Opnemen?");
                Console.WriteLine("5. FAQ");
                Console.WriteLine("6. Reservering laten zien");
                Console.WriteLine("7. Laat vragen zien om te beantwoorden");
                Console.WriteLine("8. Exit");

                Console.Write("Zet hier uw keuze neer: ");
                string result = Console.ReadLine();
                if (result == "8") break;
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
                        contact.showAnswers();
                        break;
                    case "666":
                        test.run();
                        break;
                    case "6":
                        PageReservering.showReser();
                        break;
                    case "7":
                        contact.showVragen();
                        break;
                    default:
                        Console.Clear();
                        break;


                }
            }
        }
    }
}
