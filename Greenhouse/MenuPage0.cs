using System;
namespace MenuPage0
{
    public class menuPage0
    {
        public static void show() //voor nu void 
        {
            Console.Clear();
            Console.WriteLine("Welkom bij de Menu Pagina\n");

            Console.WriteLine("Kies de catagorie die u wilt bekijken:\n");
            Console.WriteLine("1. Voorgerechten");
            Console.WriteLine("2. Hoofdgerechten");
            Console.WriteLine("3. Toetjes");
            Console.WriteLine("4. Vis-gerechten");
            Console.WriteLine("5. Vegan opties");
            Console.WriteLine("6. Vega opties");
            Console.WriteLine("7. Alles (u kan ook 'all' typen)");

            Console.Write("Wat zou u willen zien: ");
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

