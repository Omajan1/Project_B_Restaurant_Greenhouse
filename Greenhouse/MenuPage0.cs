using System;
namespace MenuPage0
{
    public class menuPage0
    {
        public static void show() //voor nu void 
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
}

