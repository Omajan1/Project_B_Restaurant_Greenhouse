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
            bool running = true;
            // Running loop
            while (running)
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("----Welkom bij de Reserverings Applicatie van GreenHouse---");
                Console.WriteLine("--Duurzaamheid en Sustainability met Lokale Leveranciers!--");
                Console.WriteLine("-----------Voor elke portomonee en altijd lekker!----------");
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("--------|  Elke dag open, vannaf 13:00 tot 22:00  |--------");
                Console.WriteLine("---------|  De bar is open van 13:00 tot 01:00  |----------");
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("Dit zijn de opties                          ");
                Console.WriteLine("1. Een reservering plaatsen                 ");
                Console.WriteLine("2. Het menu bekijken                        ");
                Console.WriteLine("3. De regels bekijken                       ");
                Console.WriteLine("4. Contact opnemen met Greenhouse           ");
                Console.WriteLine("5. FAQ                                      ");
                Console.WriteLine("6. Alle geplaatste reserveringen laten zien ");
                Console.WriteLine("7. Admin panel                              ");
                Console.WriteLine("8. Exit                                     ");
                Console.WriteLine("Zet hieronder uw keuze neer                 ");


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
                    case "8":
                        running = false;
                        break;
                    default:
                        Console.Clear();
                        break;


                }
            }
        }
    }
}
