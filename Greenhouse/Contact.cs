using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Contact
{
	
	public class Comment
    {
		public string Text = "";
		public string Name = "";
		public string Answer = "";
		public Comment(string text, string name)
        {
			this.Text = text;
			this.Name = name;
        }
    }
	public class contact
	{
		public static void showVragen()
        {
			Console.Clear();
			string path = @"../../../../Data/commentsContact.json";
			// Laad het json bestand naar een string
			string initialJson = File.ReadAllText(path);

			// zet de string naar een array
			var array = JArray.Parse(initialJson);
			foreach(JObject q in array)
            {
				string vraag = q.GetValue("Text").ToString();
				string naam = q.GetValue("Name").ToString();
				Console.WriteLine($"{naam} Stelde de vraag : " + vraag);
				Console.WriteLine("Wil je deze vraag beantwoorden: typ y als je dat wilt, anders enter: ");
				string choice = Console.ReadLine();
				if(choice == "y")
                {

                }

				Console.Clear();
			}
			
		}

		public static void show()
		{
			string path = @"../../../../Data/commentsContact.json";
			Console.Clear();
			Console.WriteLine("Wilt u contact opnemen met het restaurant?: dan kan dat op de volgende manieren:\n\n" +
				"Telefoonnummer: 010-794-4000\n" +
				"Email: greenhouse@green.nl\n" +
				"Adres: Wijnhaven 107, 3011 WN Rotterdam\n" +
				"Provincie: Zuid-Holland\n" +
				"Website: https://www.hogeschoolrotterdam.nl/hogeschool/locaties/wijnhaven-107 \n" +
				

				"Verstuur een chat bericht: typ het bericht en druk op enter\n" +
				"Als je terug naar het hoofdmenu wilt, typ dan niks\n");
			// Voeg iets to zodat je een string naar een json bestand kan zetten met de vraag als er tijd over is
			Console.WriteLine("---Druk om een toets om terug te gaan.---\n");

			

			string input = Console.ReadLine();

			if(input != "")
            {

				Console.WriteLine("Wat is je naam?\n");
				string name = Console.ReadLine();



				Comment comment = new Comment(input, name);

				// Laad het json bestand naar een string
				string initialJson = File.ReadAllText(path);

				// zet de string naar een array
				var array = JArray.Parse(initialJson);
				
				// Maakt het object om toetevoegen naar een object voor json
				JObject jsonObject = JObject.FromObject(comment);

				// Voegt het json object toe aan de array
				array.Add(jsonObject);
				
				// Slaat het op in JSON
				File.WriteAllText(path, JsonConvert.SerializeObject(array, Formatting.Indented));
				Console.ReadLine();











			}






		}
	}
}

