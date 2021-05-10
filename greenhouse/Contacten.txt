            }
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