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
                string result = Console.ReadLine();

                string[] options = result.Split(",");

                Console.Clear();
                foreach (string option in options)
                {
                    if (option == "7" || option == "all")
                    {
                        Alles();
                        Console.WriteLine();
                    }
                    else if (option == "8")
                    {
                        running = false;
                        break;
                    }
                    else if (option == "1")
                    {
                        Voorgerechten();
                        Console.ReadLine();
                    }
                    else if (option == "2")
                    {
                        Hoofdgerechten();
                        Console.ReadLine();
                    }
                    else if (option == "3")
                    {
                        Nagerechten();
                        Console.ReadLine();
                    }
                    else if (option == "4")
                    {
                        Visgerechten();
                        Console.ReadLine();
                    }
                    else if (option == "5")
                    {
                        Vegan();
                        Console.ReadLine();
                    }
                    else if (option == "6")
                    {
                        Vega();
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("This is not a valid option");
                        Console.ReadLine();
                    }
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
