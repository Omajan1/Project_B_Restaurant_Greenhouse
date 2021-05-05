using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JSON;
using Login;
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
        }
    }
	public class Contact
	{
		// Dit laat de vragen zien en geeft je de optie om ze te beantwoorden
		public static void showVragen()
        {
			if (Login.Login.check())
            {

            

				Console.Clear();

				// Laad het json bestand naar een string
				string initialJson = File.ReadAllText(paths.vragen);

				// Zet de string naar een array
				var array = JArray.Parse(initialJson);

					// Gaat door elk element van de JSON array heen
					foreach (JObject q in array)
					{
						// Kijkt of het antwoord al is ingevuld
						JToken isFull = q["Answer"];

						if (isFull == null)
						{
							// Pakt values Text en Name van de JSON file
							string vraag = q.GetValue("Text").ToString();
							string naam = q.GetValue("Name").ToString();

							Console.WriteLine($"\n{naam} stelde de vraag : \t" + vraag + "\n");
							Console.WriteLine("Wil je deze vraag beantwoorden:\n \nY = Beantwoorden \nENTER = Volgende vraag\n");


							string choice = Console.ReadLine();
							choice = choice.ToUpper();

							if (choice == "Y")
							{

								Console.WriteLine("Wat is je antwoord op de vraag: \n");
								string antwoord = Console.ReadLine();
								// Voegt Answer toe aan het element
								q["Answer"] = antwoord;
								// Slaat het op in JSON
								File.WriteAllText(paths.vragen, JsonConvert.SerializeObject(array, Formatting.Indented));

							}

							Console.Clear();
						}
					}
			}

		}

		public static void showInfo()
		{


			Console.Clear();

			Console.WriteLine("Wilt u contact opnemen met het restaurant?: dan kan dat op de volgende manieren:");
			Console.WriteLine();
			Console.WriteLine("Telefoonnummer: 010-794-4000");
			Console.WriteLine("Email: greenhouse@green.nl");
			Console.WriteLine("Adres: Wijnhaven 107, 3011 WN Rotterdam");
			Console.WriteLine("Provincie: Zuid-Holland");
			Console.WriteLine("Website: https://www.hogeschoolrotterdam.nl/hogeschool/locaties/wijnhaven-107");
			Console.WriteLine();
			Console.WriteLine("Verstuur een chat bericht: typ het bericht en druk op enter");
			Console.WriteLine();
			Console.WriteLine("Als je terug naar het hoofdmenu wilt, typ dan niks");
			Console.WriteLine();
			Console.WriteLine("---Druk om een toets om terug te gaan.---");

			// Pakt of de gebruiker terug wilt of welke vraag je wilt achterlaten
			string input = Console.ReadLine();


			// Als input niet leeg is 
			if(input != "")
            {

				Console.WriteLine("Wat is je naam?");
				string name = Console.ReadLine();


				// Maakt een nieuw comment object
				Comment comment = new Comment(input, name);

				// Laad het json bestand naar een string
				string initialJson = File.ReadAllText(paths.vragen);

				// zet de string naar een array
				var array = JArray.Parse(initialJson);
				
				// Maakt het object om toetevoegen naar een object voor json
				JObject jsonObject = JObject.FromObject(comment);

				// Voegt het json object toe aan de array
				array.Add(jsonObject);
				
				// Slaat het op in JSON
				File.WriteAllText(paths.vragen, JsonConvert.SerializeObject(array, Formatting.Indented));
				Console.Clear();
				Console.WriteLine("Je vraag is gestelt, u kunt in het hoofdmenu zien bij FAQ of er antwoord op is gegeven!");
				Console.WriteLine("Druk op enter om terug te gaan");
				Console.ReadLine();
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

