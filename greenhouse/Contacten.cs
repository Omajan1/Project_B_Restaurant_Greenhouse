using JSON;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Diagnostics.CodeAnalysis;
namespace contact
{


    
    public class Comment
    {
        public string Text = "";
        public string Name = "";
        public Comment(string text, string name)
        {
            this.Text = text;
            this.Name = name;

            // Laad het json bestand naar een string
            string initialJson = File.ReadAllText(paths.vragen);

            // zet de string naar een array
            var array = JArray.Parse(initialJson);

            // Maakt het object om toetevoegen naar een object voor json
            JObject jsonObject = JObject.FromObject(this);

            // Voegt het json object toe aan de array
            array.Add(jsonObject);

            // Slaat het op in JSON
            File.WriteAllText(paths.vragen, JsonConvert.SerializeObject(array, Formatting.Indented));
        }
        public void deleteComment(string text)
        {
            string initialJson = File.ReadAllText(paths.vragen);

            var array = JArray.Parse(initialJson);
            foreach(JToken i in array)
            {
                string question = i["Text"].ToString();
                if (question == text)
                {
                    i["Text"] = null;
                    i["Name"] = null;
                    
                }
            }
            File.WriteAllText(paths.vragen, JsonConvert.SerializeObject(array, Formatting.Indented));
        }
    }
    [ExcludeFromCodeCoverage]
    public class Contact
    {
        // Dit laat de vragen zien en geeft je de optie om ze te beantwoorden
        public static void showVragen()
        {
            // Als de inlog gegevens niet goed zijn kun je hier niet bij



            Console.Clear();

            // Laad het json bestand naar een string
            string initialJson = File.ReadAllText(paths.vragen);

            // Zet de string naar een array
            var array = JArray.Parse(initialJson);

            // Gaat door elk element van de JSON array heen
            bool running = true;
            while (running)
            {
                if (array == null)
                    foreach (JObject q in array)
                    {
                        // Kijkt of het antwoord al is ingevuld
                        JToken isFull = q["Answer"];

                        if (isFull == null)
                        {
                            // Pakt values Text en Name van de JSON file
                            string vraag = q.GetValue("Text").ToString();
                            string naam = q.GetValue("Name").ToString();

                            Console.WriteLine($"\n{naam} stelde de vraag: \t" + vraag + "\n");
                            Console.WriteLine("Wilt u deze vraag beantwoorden:\n \nY = Beantwoorden\nD = Delete \nENTER = Volgende vraag\n");


                            string choice = Console.ReadLine();
                            choice = choice.ToUpper();

                            if (choice.ToUpper() == "Y")
                            {

                                Console.WriteLine("Wat is uw antwoord op de vraag: \n");
                                string antwoord = Console.ReadLine();
                                // Voegt Answer toe aan het element
                                q["Answer"] = antwoord;
                                // Slaat het op in JSON
                                File.WriteAllText(paths.vragen, JsonConvert.SerializeObject(array, Formatting.Indented));

                            }
                            if (choice.ToUpper() == "D")
                            {


                                q["Answer"] = null;
                                q["Answer"] = null;
                                q["Answer"] = null;
                                // Slaat het op in JSON
                                File.WriteAllText(paths.vragen, JsonConvert.SerializeObject(array, Formatting.Indented));

                            }
                            if (choice.ToUpper() == "Q")
                            {
                                running = false;
                                Console.WriteLine("Tot ziens!");

                            }
                            Console.Clear();
                        }
                        running = false;
                    }

            }
        }

        public static void showInfo()
        {


            Console.Clear();
            // verandering van de kleur van de tekst
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("Contact Opnemen?\n");
            Console.WriteLine("U kunt op de volgende manieren contact opnemen:\n");
            Console.WriteLine("- Wij zijn telefonisch bereikbaar via ons telefoonummer: 010-794-4000.\n");
            Console.WriteLine("- U kunt ook een email sturen naar: greenhouse@green.nl.\n");
            Console.WriteLine("- Stuur een brief of bezoek onze locatie op:");
            Console.WriteLine("   Adres: Wijnhaven 107, 3011 WN Rotterdam");
            Console.WriteLine("   Provincie: Zuid-Holland\n");
            Console.WriteLine("- U kunt ons ook online vinden via:");
            Console.WriteLine("   https://www.hogeschoolrotterdam.nl/hogeschool/locaties/wijnhaven-107");
            Console.WriteLine();
            Console.WriteLine("1. Tenslotte kunt een chat bericht sturen naar een medewerker, dit doet u als volgt:");
            Console.WriteLine("   -  Typ hieronder een 1.");
            Console.WriteLine("   -  Druk daarna op enter.");
            Console.WriteLine("   -  Vul vervolgens uw vraag in zodat u een antwoord kunt ontvangen.\n\n");
            Console.WriteLine("Als u terug naar het hoofdmenu wilt, typ dan niks en druk op enter.");


            // Pakt of de gebruiker terug wilt of welke vraag je wilt achterlaten
            string input = Console.ReadLine();


            // Als input niet leeg is 
            Console.WriteLine("Type STOP om te stoppen met typen van een bericht.");
            if (input == "1")
            {
                string vraag = "\n";
                string inputVraag;
                bool runningVraag = true;
                while (runningVraag)
                {
                    inputVraag = Console.ReadLine();
                    if (inputVraag == "STOP")
                    {
                        runningVraag = false;
                        Console.WriteLine("Wat is je naam?");
                        string name = Console.ReadLine();
                        Comment comment = new Comment(vraag, name);

                    }
                    else
                    {
                        vraag += inputVraag;
                        vraag += "\n";
                    }


                }

                Console.Clear();
                Console.WriteLine("Je vraag is gestelt, u kunt in het hoofdmenu zien bij FAQ of er antwoord op is gegeven!");
                Console.WriteLine("Druk op enter om terug te gaan");
                Console.ReadLine();
            }
        }
        public static void FAQ()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("Is er een drive thru?");
            Console.WriteLine("Nee helaas, we hebben geen drive thru.");
            Console.WriteLine("--------------------------------------------------------------------\n");

            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("Welke dagen zijn jullie open?");
            Console.WriteLine("Maandag tot en met Zaterdag, Zondag zijn we helaas gesloten.");
            Console.WriteLine("--------------------------------------------------------------------\n");

            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("Welk merk cola wordt er geserveerd?");
            Console.WriteLine("We serveren alleen Coca Cola, geen Pepsi.");
            Console.WriteLine("--------------------------------------------------------------------\n");

            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("Hebben jullie nog meer faciliteiten op andere plekken?");
            Console.WriteLine("Nee, we hebben ons restaurant nog maar op 1 plek staan.");
            Console.WriteLine("--------------------------------------------------------------------\n");

            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("Hebben jullie wifi?");
            Console.WriteLine("Ja, we hebben gratis wifi voor onze gasten.");
            Console.WriteLine("--------------------------------------------------------------------\n");

            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("Hebben jullie een kinderhoek?");
            Console.WriteLine("We hebben geen kinderhoek, maar we kunnen de kinderen wel een tekening aanbieden.");
            Console.WriteLine("--------------------------------------------------------------------\n");

        }
        public static void showAnswers()
        {

            Console.Clear();
            Console.WriteLine("Dit zijn alle vragen met antwoorden die gesteld zijn door gebruikers: \n");

            // Laad het json bestand naar een string
            string initialJson = File.ReadAllText(paths.vragen);

            // Zet de string naar een array
            var array = JArray.Parse(initialJson);

            // Gaat door elk element van de JSON array heen
            foreach (JObject q in array)
            {
                // Kijkt of het antwoord al is ingevuld
                JToken isFull = q["Answer"];

                if (isFull != null)
                {
                    Console.WriteLine("--------------------------");
                    Console.WriteLine($"Vraag van {q["Name"]} : " + q["Text"]);
                    Console.WriteLine("Antwoord : " + q["Answer"]);
                    Console.WriteLine("--------------------------\n");

                }
            }
            Console.WriteLine("Druk op enter om terug te gaan naar het hoofdmenu : ");
            Console.ReadLine();
        }
    }
}