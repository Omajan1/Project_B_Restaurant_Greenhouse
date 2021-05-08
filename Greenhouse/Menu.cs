using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JSON;
namespace Menu
{
    public class menu
    {
        public static void show() 
        {
            bool running = true;
            while (running)
            {

            
            Console.Clear();
            Console.WriteLine("Welkom bij de Menu Pagina\n");

            Console.WriteLine("Kies de catagorie die u wilt bekijken:\n");
            Console.WriteLine("1. Voorgerechten");
            Console.WriteLine("2. Hoofdgerechten");
            Console.WriteLine("3. Nagerechten");
            Console.WriteLine("4. Vis-gerechten");
            Console.WriteLine("5. Vegan opties");
            Console.WriteLine("6. Vega opties");
            Console.WriteLine("7. Alles (u kan ook 'all' typen)");
            Console.WriteLine("8. Terug naar home");
            Console.Write("Wat zou u willen zien: ");
            string result;

            //check wat er is geinput

            switch (result = Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    Voorgerechten();
                        Console.ReadLine();
                        break;
                case "2":
                    Console.Clear();
                    Hoofdgerechten();
                        Console.ReadLine();
                        break;
                case "3":
                    Console.Clear();
                    Nagerechten();
                        Console.ReadLine();
                        break;
                case "4":
                    Console.Clear();
                    Visgerechten();
                        Console.ReadLine();
                        break;
                case "5":
                    Console.Clear();
                    Vegan();
                        Console.ReadLine();
                        break;
                case "6":
                    Console.Clear();
                    Vega();
                        Console.ReadLine();
                        break;
                case "7":
                    Console.Clear();
                    Alles();
                        Console.ReadLine();
                        break;
                case "all":
                    Console.Clear();
                    Alles();
                        Console.ReadLine();
                        break;
                case "8":
                        running = false;
                        break;
            }
           }


            static void Voorgerechten()
            {
                Console.WriteLine("Voorgerechten\n--------------------------------------------------------------------------\n");

                string innit = File.ReadAllText(paths.gerechten);
                var Count = JArray.Parse(innit);

                foreach (JObject item in Count)
                {
                    string name = item.GetValue("name").ToString();
                    string info = item.GetValue("info").ToString();
                    string price = item.GetValue("price").ToString();
                    string soortgerecht = item.GetValue("soortgerecht").ToString();

                    if (soortgerecht == "voorgerecht")
                    {
                        Console.WriteLine($"{name}\n{info}\n-{price}\n");
                    }

                }
            }

            static void Hoofdgerechten()
            {
                Console.WriteLine("Hoofdgerechten\n--------------------------------------------------------------------------\n");

                string innit = File.ReadAllText(paths.gerechten);
                var Count = JArray.Parse(innit);

                foreach (JObject item in Count)
                {
                    string name = item.GetValue("name").ToString();
                    string info = item.GetValue("info").ToString();
                    string price = item.GetValue("price").ToString();
                    string soortgerecht = item.GetValue("soortgerecht").ToString();

                    if (soortgerecht == "hoofdgerecht")
                    {
                        Console.WriteLine($"{name}\n{info}\n-{price}\n");
                    }

                }
            }

            static void Nagerechten()
            {
                Console.WriteLine("Nagerechten\n--------------------------------------------------------------------------\n");

                string innit = File.ReadAllText(paths.gerechten);
                var Count = JArray.Parse(innit);

                foreach (JObject item in Count)
                {
                    string name = item.GetValue("name").ToString();
                    string info = item.GetValue("info").ToString();
                    string price = item.GetValue("price").ToString();
                    string soortgerecht = item.GetValue("soortgerecht").ToString();

                    if (soortgerecht == "Nagerecht")
                    {
                        Console.WriteLine($"{name}\n{info}\n-{price}\n");
                    }
                }
            }

            static void Visgerechten()
            {
                Console.WriteLine("Visgerechten");
            }

            static void Vegan()
            {
                Console.WriteLine("Vegan opties");
            }

            static void Vega()
            {
                Console.WriteLine("Vega opties");
            }


            static void Alles()
            {
                Voorgerechten();
                Hoofdgerechten();
                Nagerechten();
                Visgerechten();
                Vegan();
                Vega();
            }

        }
    }
}
