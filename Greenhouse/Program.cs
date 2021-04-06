using System;
using Rules;
namespace Greenhouse
{
    class Pages
    {
        public static void FirstPage0()
        {

            
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to the GreenHouse Reservation Application\n");

                Console.WriteLine("These are the avalable options:\n");
                Console.WriteLine("1. Reservation");
                Console.WriteLine("2. Menu");
                Console.WriteLine("3. Rules");
                Console.WriteLine("4. Exit");

                Console.Write("Put down your option here: ");
                string result = Console.ReadLine();


                /*
                switch (result)
                {
                    case "3":
                        {

                        }
                }
                */


                if (result == "3") //rules
                {
                    var page = new ShowPage();
                    page.show();
                }
                else if(result == "4")
                {
                    break;
                }
                /*
                if (result == "1") //reservation
                {
                    return "1";
                }
                else if (result == "2") //menu
                {
                    return "2";
                }
                else if (result == "3") //rules
                {
                    var page = new ShowPage();
                    page.show();
                    return null;
                }
                else if (result == "4") //exit
                {
                    Environment.Exit(1);
                    return null;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n ----This is not a valid option, try again.----\n");
                    FirstPage0();
                    return null;
                }
                */
            } while (true);
        }

        public static void MenuPage0() //voor nu void 
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Menu Page\n");

            Console.WriteLine("Choose the catagory you want to view\n");
            Console.WriteLine("1. Appitizer");
            Console.WriteLine("2. Main");
            Console.WriteLine("3. Dessert");
            Console.WriteLine("4. Fish");
            Console.WriteLine("5. Vegan");
            Console.WriteLine("6. Vega");
            Console.WriteLine("7. All options listed above (you can also type 'all')");

            Console.Write("What would you want to see: ");
            string result = Console.ReadLine();

            //check wat er is geinput
            if (result == "7" || result == "all")
            {
                //test cuz i dont got notin
                Console.Clear();
                Console.WriteLine("All options and stuff");
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            //Eerste page standaard open
            
            Console.SetWindowSize(160, 35);

            Pages.FirstPage0();


        }
    }
}
