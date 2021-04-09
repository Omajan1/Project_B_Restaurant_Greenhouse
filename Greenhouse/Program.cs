using System;
using Rules;
using Reservering;
using MenuPage0;
using Contact;
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
                        reservering.show();
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
            //Eerste page standaard open
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.SetWindowSize(160, 35);
            Pages.Home(); 



        }
    }
}
