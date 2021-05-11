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


		public Comment(string text, string name, bool x)
		{
			this.Text = text;
			this.Name = name;
		}


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
	}
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

		public static void showInfo()
		{


			Console.Clear();
			Console.WriteLine("Contact Opnemen?\n");
			Console.WriteLine("U kunt op de volgende manieren contact opnemen:\n");
			// verandering van de kleur van de tekst
			Console.ForegroundColor = ConsoleColor.DarkBlue;
			Console.WriteLine("1. Wij zijn telefonisch bereikbaar via ons telefoonummer: 010-794-4000.\n");
			Console.WriteLine("2. U kunt ook een email sturen naar: greenhouse@green.nl.\n");
			Console.WriteLine("3. Stuur een brief of bezoek onze locatie op:");
			Console.WriteLine("   Adres: Wijnhaven 107, 3011 WN Rotterdam");
			Console.WriteLine("   Provincie: Zuid-Holland\n");
			Console.WriteLine("4. U kunt ons ook online vinden via:");
			Console.WriteLine("   https://www.hogeschoolrotterdam.nl/hogeschool/locaties/wijnhaven-107");
			Console.WriteLine();
			Console.WriteLine("5. Tenslotte kunt een chat bericht sturen naar een medewerker, dit doet u als volgt:");
			Console.WriteLine("   -  Typ hieronder eerst het bericht.");
			Console.WriteLine("   -  Druk daarna op enter.");
			Console.WriteLine("   -  Vul vervolgens uw gegevens in zodat u een antwoord kunt ontvangen.\n\n");
			Console.ForegroundColor = ConsoleColor.Black;
			Console.WriteLine("Als u terug naar het hoofdmenu wilt, typ dan niks en druk op enter.");
			Console.WriteLine();
			Console.WriteLine("---Druk op een toets om terug te gaan.---\n");

			// Pakt of de gebruiker terug wilt of welke vraag je wilt achterlaten
			string input = Console.ReadLine();


			// Als input niet leeg is 
			if (input != "")
			{
				Console.WriteLine();
				Console.WriteLine("Wat is je naam?");
				string name = Console.ReadLine();


				// Maakt een nieuw comment object
				// Het maken van een nieuw object slaat het automatisch op in JSON
				Comment comment = new Comment(input, name);


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