using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JSON;
namespace MenuPage0
{
    public class menu
    {
        public static void show() 
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
            Console.Write("Wat zou u willen zien: ");
            string result;

            //check wat er is geinput
            while (true)
            {
                result = Console.ReadLine();
                if (result == "7" || result == "all")
                {
                    Console.Clear();
                    Alles();
                }
                else if (result == "1")
                {
                    Console.Clear();
                    Voorgerechten();
                }
                else if (result == "2")
                {
                    Console.Clear();
                    Hoofdgerechten();
                }
                else if (result == "3")
                {
                    Console.Clear();
                    Nagerechten();
                }
                else if (result == "4")
                {
                    Console.Clear();
                    Visgerechten();
                }
                else if (result == "5")
                {
                    Console.Clear();
                    Vegan();
                }
                else if (result == "6")
                {
                    Console.Clear();
                    Vega();
                }
            }


            static void Voorgerechten()
            {
                Console.WriteLine("Voorgerechten\n");

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
                        Console.WriteLine($"{name}\n{info}\n{price}\n");
                    }

                }
            }

            static void Hoofdgerechten()
            {
                Console.WriteLine("Hoofdgerechten\n");

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
                        Console.WriteLine($"{name}\n{info}\n{price}\n");
                    }

                }
            }

            static void Nagerechten()
            {
                Console.WriteLine("Nagerechten\n");

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
                        Console.WriteLine($"{name}\n{info}\n{price}\n");
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
