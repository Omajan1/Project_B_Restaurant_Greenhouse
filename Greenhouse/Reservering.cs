using System;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Reservering
{
	public class PageReservering
	{
		public static string path = @"../../../../Data/reservering.json";

		public static void show()
		{
			Console.Clear();

			string datum;

			while (true)
			{
				Console.WriteLine("Op welke datum wilt u deze reservering plaatsen? Typ het in het format DD-MM-YYYY, zoals dit: 21-04-2021");
				datum = Console.ReadLine();
				if (datum.Length == 10)
				{
					break;

				}
				else
				{
					Console.WriteLine("Deze datum is volgeboekt of het is niet in het geldige format DD-MM-YYYY");
				}
			}

			//check komen

			Console.Clear();



			int tafelNummer;
			while (true)
			{
				Console.WriteLine("Aan welke tafel wilt u eten? Typ het nummer van deze tafel in:");
				tafelNummer = Convert.ToInt32(Console.ReadLine());
				if (tafelNummer > 100) // We kunnen hier toevoegen dat als een tafel bezet is hij niet meer gereserveerd kan worden
				{
					Console.WriteLine("Dit tafelnummer is niet beschikbaar, probeer een ander tafelnummer");
					Console.Clear();
				}
				else
				{
					break;
				}
			}

			Console.Clear();
			Console.WriteLine("Wat is je Naam?");
			string naam = Console.ReadLine();
			Console.Clear();
			Console.WriteLine("Wat is je Achternaam?");
			string achternaam = Console.ReadLine();
			Console.Clear();
			int aantalMensen;
			while (true)
			{
				Console.WriteLine("Voor hoeveel mensen is deze reservering?");
				aantalMensen = Convert.ToInt32(Console.ReadLine());
				if (aantalMensen > 8)
				{
					Console.WriteLine("Voor het reserveren van groepen boven de 8 kunt u bellen naar : 0800-0432 \n Hierbij komen extra servicekosten van pas van 1,30 euro per persoon boven de 8\n");

				}
				else
				{
					break;
				}
			}


			Console.Clear();

			Console.WriteLine("Hoelaat wilt u komen eten? Typ eerst het uur, druk op enter, en typ vervolgens het aantal minuten:");
			int tijd1 = Convert.ToInt32(Console.ReadLine());
			int tijd2 = Convert.ToInt32(Console.ReadLine());
			int[] tijd = new int[2] { tijd1, tijd2 };
			Console.Clear();

			Console.WriteLine("Wat is je KlantenID?");
			string klantid = Console.ReadLine();
			Console.Clear();
			Console.WriteLine("Hoe wilt u betalen? Contant , Pinnen of ApplePay");
			string betaalmethode = Console.ReadLine();
			Console.Clear();


			Reservering klant = new Reservering(naam, achternaam, aantalMensen, tafelNummer, tijd, datum, klantid, betaalmethode);

			// Laad het json bestand naar een string
			string initialJson = File.ReadAllText(path);

			// zet de string naar een array
			var array = JArray.Parse(initialJson);

			// Maakt het object om toetevoegen naar een object voor json
			JObject jsonObject = JObject.FromObject(klant);

			// Voegt het json object toe aan de array
			array.Add(jsonObject);

			// Slaat het op in JSON
			File.WriteAllText(path, JsonConvert.SerializeObject(array, Formatting.Indented));

			Console.WriteLine("Typ INFO om informatie te zien over deze reservering, anders druk op enter om terug te gaan:");
			string t = Console.ReadLine();
			if(t == "INFO")
            {

				// Laad het json bestand naar een string
				string innit = File.ReadAllText(path);

				// zet de string naar een array
				var Count = JArray.Parse(innit);





				foreach (JObject item in Count)
				{
					Console.WriteLine(item);
					string name = item.GetValue("Naam").ToString();
					Console.WriteLine(name);
					
				}

				Console.WriteLine("Druk op enter om terug te gaan");
				Console.ReadLine();
            }








		}
	}
	
	public class Reservering
    {
		public string Naam { get; set; }
		public string Achternaam { get; set; }
		public int AantalMensen { get; set; }
		public int TafelNummer { get; set; }
		public int Res_ID { get; set; }
		public int[] Tijd { get; set; }
		public string Datum { get; set; }
		public string KlantID { get; set; }
		public string Betaalmethode { get; set; }

		public void Info()
        {
			Console.WriteLine($"Er staat een reservering op de naam {this.Naam} {this.Achternaam} op {this.Datum} om {this.Tijd[0]}:{this.Tijd[1]} uur");
        }
		public Reservering(string naam, string achternaam, int aantalmensen, int tafelnummer, int[] tijd, string datum, string klantid, string betaalmethode)
        {
			Random r = new Random();
			this.Naam = naam;
			this.Achternaam = achternaam;
			this.AantalMensen = aantalmensen;
			this.TafelNummer = tafelnummer;
			this.Tijd = tijd;
			this.Datum = datum;
			this.KlantID = klantid;
			this.Betaalmethode = betaalmethode;
			this.Res_ID = r.Next(1000, 9999);
			Console.WriteLine($"Er is succesvol een reservering geplaatst op de naam {this.Naam} {this.Achternaam} op {this.Datum} om {this.Tijd[0]}:{this.Tijd[1]} uur met ID {this.Res_ID}");
		}
	}
}

