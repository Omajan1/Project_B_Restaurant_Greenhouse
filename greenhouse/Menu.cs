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
                Console.WriteLine("4. Extra");
                Console.WriteLine("5. Vis-gerechten");
                Console.WriteLine("6. Vegan opties");
                Console.WriteLine("7. Vega opties");
                Console.WriteLine("8. Alles (u kan ook 'all' typen)");
                Console.WriteLine("9. Terug naar home");
                Console.WriteLine("Als u naar meerdere opties wilt kijken, kunt u meerdere opties invullen.\nDoe dit als volgt: '1,2'.");
                Console.Write("Wat zou u willen zien: ");
                string result = Console.ReadLine();

                string[] options = result.Split(",");

                Console.Clear();
                foreach (string option in options)
                {
                    if (option == "8" || option == "all")
                    {
                        Alles();
                        Console.Write("Druk op enter om terug te gaan");
                        Console.ReadLine();
                    }
                    else if (option == "9")
                    {
                        running = false;
                        break;
                    }
                    else if (option == "1")
                    {
                        Voorgerechten();
                        Console.Write("Druk op enter om terug te gaan");
                        Console.ReadLine();
                    }
                    else if (option == "2")
                    {
                        Hoofdgerechten();
                        Console.Write("Druk op enter om terug te gaan");
                        Console.ReadLine();
                    }
                    else if (option == "3")
                    {
                        Nagerechten();
                        Console.Write("Druk op enter om terug te gaan");
                        Console.ReadLine();
                    }
                    else if (option == "4")
                    {
                        Extra();
                        Console.Write("Druk op enter om terug te gaan");
                        Console.ReadLine();
                    }
                    else if (option == "5")
                    {
                        Visgerechten();
                        Console.Write("Druk op enter om terug te gaan");
                        Console.ReadLine();
                    }
                    else if (option == "6")
                    {
                        Vegan();
                        Console.Write("Druk op enter om terug te gaan");
                        Console.ReadLine();
                    }
                    else if (option == "7")
                    {
                        Vega();
                        Console.Write("Druk op enter om terug te gaan");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Dit is geen geldige optie");
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

            static void Extra()
            {
                Console.WriteLine("Extra\n--------------------------------------------------------------------------\n");

                string innit = File.ReadAllText(paths.gerechten);
                var Count = JArray.Parse(innit);

                foreach (JObject item in Count)
                {
                    string name = item.GetValue("name").ToString();
                    string info = item.GetValue("info").ToString();
                    string price = item.GetValue("price").ToString();
                    string soortgerecht = item.GetValue("soortgerecht").ToString();


                    if (soortgerecht == "Extra's")
                    {
                        Console.WriteLine($"{name}\n{info}\n-{price}\n");
                    }
                }
            }

            static void Visgerechten()
            {
                Console.WriteLine("Visgerechten\n--------------------------------------------------------------------------\n");

                string innit = File.ReadAllText(paths.gerechten);
                var Count = JArray.Parse(innit);

                Console.WriteLine("Voorgerechten:\n");

                foreach (JObject item in Count)
                {
                    string name = item.GetValue("name").ToString();
                    string info = item.GetValue("info").ToString();
                    string price = item.GetValue("price").ToString();
                    string soortgerecht = item.GetValue("soortgerecht").ToString();
                    string vegan = item.GetValue("vegan").ToString();
                    string vega = item.GetValue("vega").ToString();
                    string vis = item.GetValue("vis").ToString();

                    if (vis == "ja" && soortgerecht == "voorgerecht")
                    {
                        Console.WriteLine($"{name}\n{info}\n-{price}\n");
                    }

                }

                Console.WriteLine("\n\nHoofdgerechten:\n");

                foreach (JObject item in Count)
                {
                    string name = item.GetValue("name").ToString();
                    string info = item.GetValue("info").ToString();
                    string price = item.GetValue("price").ToString();
                    string soortgerecht = item.GetValue("soortgerecht").ToString();
                    string vegan = item.GetValue("vegan").ToString();
                    string vega = item.GetValue("vega").ToString();
                    string vis = item.GetValue("vis").ToString();

                    if (vis == "ja" && soortgerecht == "hoofdgerecht")
                    {
                        Console.WriteLine($"{name}\n{info}\n-{price}\n");
                    }

                }

            }

            static void Vegan()
            {
                Console.WriteLine("Vegan opties\n--------------------------------------------------------------------------\n");

                string innit = File.ReadAllText(paths.gerechten);
                var Count = JArray.Parse(innit);

                Console.WriteLine("\n\nVoorgerechten:\n");

                foreach (JObject item in Count)
                {
                    string name = item.GetValue("name").ToString();
                    string info = item.GetValue("info").ToString();
                    string price = item.GetValue("price").ToString();
                    string soortgerecht = item.GetValue("soortgerecht").ToString();
                    string vegan = item.GetValue("vegan").ToString();
                    string vega = item.GetValue("vega").ToString();
                    string vis = item.GetValue("vis").ToString();

                    if (vegan == "ja" && soortgerecht =="voorgerecht")
                    {
                        Console.WriteLine($"{name}\n{info}\n-{price}\n");
                    }

                }

                Console.WriteLine("\n\nHoofdgerechten:\n");

                foreach (JObject item in Count)
                {
                    string name = item.GetValue("name").ToString();
                    string info = item.GetValue("info").ToString();
                    string price = item.GetValue("price").ToString();
                    string soortgerecht = item.GetValue("soortgerecht").ToString();
                    string vegan = item.GetValue("vegan").ToString();
                    string vega = item.GetValue("vega").ToString();
                    string vis = item.GetValue("vis").ToString();

                    if (vegan == "ja" && soortgerecht == "hoofdgerecht")
                    {
                        Console.WriteLine($"{name}\n{info}\n-{price}\n");
                    }

                }

                Console.WriteLine("\n\nNagerechten:\n");

                foreach (JObject item in Count)
                {
                    string name = item.GetValue("name").ToString();
                    string info = item.GetValue("info").ToString();
                    string price = item.GetValue("price").ToString();
                    string soortgerecht = item.GetValue("soortgerecht").ToString();
                    string vegan = item.GetValue("vegan").ToString();
                    string vega = item.GetValue("vega").ToString();
                    string vis = item.GetValue("vis").ToString();

                    if (vegan == "ja" && soortgerecht == "Nagerecht")
                    {
                        Console.WriteLine($"{name}\n{info}\n-{price}\n");
                    }

                }

                Console.WriteLine("\n\nExtra:\n");

                foreach (JObject item in Count)
                {
                    string name = item.GetValue("name").ToString();
                    string info = item.GetValue("info").ToString();
                    string price = item.GetValue("price").ToString();
                    string soortgerecht = item.GetValue("soortgerecht").ToString();
                    string vegan = item.GetValue("vegan").ToString();
                    string vega = item.GetValue("vega").ToString();
                    string vis = item.GetValue("vis").ToString();

                    if (vegan == "ja" && soortgerecht == "Extra's")
                    {
                        Console.WriteLine($"{name}\n{info}\n-{price}\n");
                    }

                }
            }

            static void Vega()
            {
                Console.WriteLine("Vega opties\n--------------------------------------------------------------------------\n");

                string innit = File.ReadAllText(paths.gerechten);
                var Count = JArray.Parse(innit);

                Console.WriteLine("\n\nVoorgerechten:\n");

                foreach (JObject item in Count)
                {
                    string name = item.GetValue("name").ToString();
                    string info = item.GetValue("info").ToString();
                    string price = item.GetValue("price").ToString();
                    string soortgerecht = item.GetValue("soortgerecht").ToString();
                    string vegan = item.GetValue("vegan").ToString();
                    string vega = item.GetValue("vega").ToString();
                    string vis = item.GetValue("vis").ToString();

                    if (vega == "ja" && soortgerecht == "voorgerecht")
                    {
                        Console.WriteLine($"{name}\n{info}\n-{price}\n");
                    }

                }

                Console.WriteLine("\n\nHoofdgerechten:\n");

                foreach (JObject item in Count)
                {
                    string name = item.GetValue("name").ToString();
                    string info = item.GetValue("info").ToString();
                    string price = item.GetValue("price").ToString();
                    string soortgerecht = item.GetValue("soortgerecht").ToString();
                    string vegan = item.GetValue("vegan").ToString();
                    string vega = item.GetValue("vega").ToString();
                    string vis = item.GetValue("vis").ToString();

                    if (vega == "ja" && soortgerecht == "hoofdgerecht")
                    {
                        Console.WriteLine($"{name}\n{info}\n-{price}\n");
                    }

                }

                Console.WriteLine("\n\nNagerechten:\n");

                foreach (JObject item in Count)
                {
                    string name = item.GetValue("name").ToString();
                    string info = item.GetValue("info").ToString();
                    string price = item.GetValue("price").ToString();
                    string soortgerecht = item.GetValue("soortgerecht").ToString();
                    string vegan = item.GetValue("vegan").ToString();
                    string vega = item.GetValue("vega").ToString();
                    string vis = item.GetValue("vis").ToString();

                    if (vega == "ja" && soortgerecht == "Nagerecht")
                    {
                        Console.WriteLine($"{name}\n{info}\n-{price}\n");
                    }

                }

                Console.WriteLine("\n\nExtra:\n");

                foreach (JObject item in Count)
                {
                    string name = item.GetValue("name").ToString();
                    string info = item.GetValue("info").ToString();
                    string price = item.GetValue("price").ToString();
                    string soortgerecht = item.GetValue("soortgerecht").ToString();
                    string vegan = item.GetValue("vegan").ToString();
                    string vega = item.GetValue("vega").ToString();
                    string vis = item.GetValue("vis").ToString();

                    if (vega == "ja" && soortgerecht == "Extra's")
                    {
                        Console.WriteLine($"{name}\n{info}\n-{price}\n");
                    }

                }

            }
            


            static void Alles()
            {
                Voorgerechten();
                Console.WriteLine("\n\n");
                Hoofdgerechten();
                Console.WriteLine("\n\n");
                Nagerechten();
                Console.WriteLine("\n\n");
                Extra();
                Console.WriteLine("\n\n");
                Visgerechten();
                Console.WriteLine("\n\n");
                Vegan();
                Console.WriteLine("\n\n");
                Vega();
            }

        }
    }
}
