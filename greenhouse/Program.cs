using Menu;
using reservering;
using Rules;
using System;
using login;
namespace Greenhouse
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console settings




            Console.SetWindowSize(180, 42);
            bool darkMode = false;
            bool running = true;
            // Running loop
            while (running)
            {
                if (!darkMode)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                Console.Clear();
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("----Welkom bij de Reserverings Applicatie van GreenHouse---");
                Console.WriteLine("--Duurzaamheid en Sustainability met Lokale Leveranciers!--");
                Console.WriteLine("-----------Voor elke portomonee en altijd lekker!----------");
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("--------|  Elke dag open, vanaf 13:00 tot 22:00  |--------");
                Console.WriteLine("---------|  De bar is open van 13:00 tot 01:00  |----------");
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("Dit zijn de opties:                         ");
                Console.WriteLine("1. Een reservering plaatsen                 ");
                Console.WriteLine("2. Het menu bekijken                        ");
                Console.WriteLine("3. De huisregels inkijken                   ");
                Console.WriteLine("4. Contact opnemen met Greenhouse           ");
                Console.WriteLine("5. Alle gestelde vragen van gebruikers      ");
                Console.WriteLine("6. FAQ (Veelgestelde vragen)               ");
                Console.WriteLine("7. Alle geplaatste reserveringen van u laten zien ");
                if (!darkMode) Console.WriteLine("8. Zet darkmode aan                         ");
                else Console.WriteLine("8. Zet darkmode uit                         ");
                Console.WriteLine("9. Exit                                     ");
                Console.WriteLine("Zet hieronder uw keuze neer:                ");


                // Pakt keuze van user
                string result = Console.ReadLine();

                // Keuzes
                switch (result)
                {
                    case "1":
                        ReserveringMain.makeReservation();
                        break;

                    case "2":
                        menu.show();
                        break;
                    case "3":
                        rules.show();
                        break;
                    case "4":
                        contact.Contact.showInfo();
                        break;
                    case "5":
                        contact.Contact.showAnswers();
                        break;
                    case "6":
                        contact.Contact.FAQ();
                        Console.WriteLine("Druk op enter om terug te gaan");
                        Console.ReadLine();
                        break;
                    case "7":
                        Console.WriteLine("Wat is uw achternaam?");
                    
                        ReserveringMain.showReserveringen(Console.ReadLine());
                        break;

                    case "8":
                        darkMode = !darkMode;
                        break;

                    case "9":
                        running = false;
                        break;

                    case "666":
                        Console.Clear();
                        Console.WriteLine("Gebruikersnaam:");
                        string username = Console.ReadLine();
                        Console.WriteLine("Wachtwoord:");
                        string password = Console.ReadLine();
                        if (Login.check(username, password)) contact.Contact.showVragen();
                        else Console.WriteLine("Verkeerde gegevens");
                        break;

                    default:
                        Console.Clear();
                        break;


                }
            }
        }
    }
}
