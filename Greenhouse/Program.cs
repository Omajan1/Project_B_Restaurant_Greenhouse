using System;
using Rules;
using reservering;
using Menu;
using contact;


namespace Greenhouse
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console settings

            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.SetWindowSize(180, 42);

            // Running loop
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("--Welkom bij de Reserverings Applicatie van GreenHouse--\n");
                Console.WriteLine("--Duurzaamheid en Sustainability met Lokale Leveranciers!--");
                Console.WriteLine("\t--Voor elke portomonee en altijd lekker!--\n");
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("\t-----------------------------------------");
                Console.WriteLine("\t| Elke dag open, vannaf 13:00 tot 22:00 |");
                Console.WriteLine("\t| De bar is open van 13:00 tot 01:00    |");
                Console.WriteLine("\t-----------------------------------------\n");
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

                // Pakt keuze van user
                string result = Console.ReadLine();

                // SLuit af als het 8 is
                if (result == "8") break;

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
                        Contact.showInfo();
                        break;
                    case "5":
                        Contact.showAnswers();
                        break;
                    case "6":
                        ReserveringMain.showReserveringen();
                        break;
                    case "7":
                        Console.Clear();
                        Console.WriteLine("Gebruikersnaam:");
                        string username = Console.ReadLine();
                        Console.WriteLine("Wachtwoord:");
                        string password = Console.ReadLine();
                        if (Login.Login.check(username, password)) Contact.showVragen();
                        else Console.WriteLine("Verkeerde gegevens ");
                        break;
                    default:
                        Console.Clear();
                        break;


                }
            }
        }
    }
}
