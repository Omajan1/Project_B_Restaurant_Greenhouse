using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JSON;
namespace Contact
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
	public class contact
	{
		// Dit laat de vragen zien en geeft je de optie om ze te beantwoorden
		public static void showVragen()
        {
			Console.Clear();



			// Laad het json bestand naar een string
			string initialJson = File.ReadAllText(paths.vragen);

			// Zet de string naar een array
			var array = JArray.Parse(initialJson);

			// Gaat door elk element van de JSON array heen
			foreach(JObject q in array)
            {
				// Kijkt of het antwoord al is ingevuld
				JToken isFull = q["Answer"];

				if (isFull == null)
				{
					// Pakt values Text en Name van de JSON file
					string vraag = q.GetValue("Text").ToString();
					string naam = q.GetValue("Name").ToString();

					Console.WriteLine($"{naam} stelde de vraag : \t" + vraag);
					Console.WriteLine("Wil je deze vraag beantwoorden: typ Y als je dat wilt, anders enter: ");


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

		public static void show()
		{


			Console.Clear();

			Console.WriteLine("Wilt u contact opnemen met het restaurant?: dan kan dat op de volgende manieren:");
			Console.WriteLine("Telefoonnummer: 010-794-4000");
			Console.WriteLine("Email: greenhouse@green.nl");
			Console.WriteLine("Adres: Wijnhaven 107, 3011 WN Rotterdam");
			Console.WriteLine("Provincie: Zuid-Holland");
			Console.WriteLine("Website: https://www.hogeschoolrotterdam.nl/hogeschool/locaties/wijnhaven-107");
			Console.WriteLine("Verstuur een chat bericht: typ het bericht en druk op enter");
			Console.WriteLine("Als je terug naar het hoofdmenu wilt, typ dan niks");
			Console.WriteLine("---Druk om een toets om terug te gaan.---");

			// Pakt of de gebruiker terug wilt of welke vraag je wilt achterlaten
			string input = Console.ReadLine();


			// Als input niet leeg is 
			if(input != "")
            {

				Console.WriteLine("Wat is je naam?\n");
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

				Console.ReadLine();
			}
		}
	}
}

