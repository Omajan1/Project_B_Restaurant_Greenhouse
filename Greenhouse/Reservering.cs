using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
namespace Reservering
{
	public class PageReservering
	{
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
			
			int aantalMensen;
			while (true)
			{
				
				Console.WriteLine("Voor hoeveel mensen is deze reservering?");
				aantalMensen = Convert.ToInt32(Console.ReadLine());
				if (aantalMensen > 6)
				{
					Console.WriteLine("Voor het reserveren van groepen boven de 6 kunt u bellen naar : 0800-0432\n Bij het reserveren van grote groepen kunnen extra kosten worden gerekend, dit ligt aan het aantal mensen en de dag waarop de reservering staat.");

				}
				else
				{
					break;
				}
			}

			string tijd;

			Console.Clear();
			while (true)
			{
				
				Console.WriteLine("Hoelaat wilt u komen eten? Typ eerst het uur, druk op enter, en typ vervolgens het aantal minuten:");
				int tijd1 = Convert.ToInt32(Console.ReadLine());
				int tijd2 = Convert.ToInt32(Console.ReadLine());
				if (tijd1 > 22)
				{
					Console.WriteLine("Dit is geen geldige tijd: Het restaurant stopt met serveren om 22:00, kies een tijd voor dit");

				}
				else
				{
					tijd = (tijd1.ToString() + ":" +  tijd2.ToString());
					break;

				}
			}


			string klantid;
			Console.Clear();
			while (true)
			{
				
				Console.WriteLine("Wat is je KlantenID?");
				klantid = Console.ReadLine();
				if (klantid.Length == 4)
				{
					break;

				}
				else
				{
					Console.WriteLine("Dit is geen geldig ID, probeer het opnieuw, druk enter om opnieuw te proberen");

				}
			}
			
			
			Console.Clear();
			Console.WriteLine("Hoe wilt u betalen? Contant , Pinnen of ApplePay");
			string betaalmethode = Console.ReadLine();
			Console.Clear();
			Reservering klant1 = new Reservering(naam, achternaam, aantalMensen, tafelNummer, tijd, datum, klantid, betaalmethode);
			Console.WriteLine("Typ INFO om informatie te zien over deze reservering, anders druk op enter om terug te gaan:");
			string t = Console.ReadLine();
			if(t == "INFO")
            {
				klant1.Info();
				Console.WriteLine("Druk op enter om terug te gaan");
				Console.ReadLine();
            }
			JsonSerializerOptions options = new JsonSerializerOptions
			{
				WriteIndented = true

			};
			//string jsonStringRead = File.ReadAllText("../../../../Data/reservering.json");

			//var res1 = JsonSerializer.Deserialize<Reservering>(jsonStringRead);
			//Console.WriteLine(res1);
			//string jsonString = JsonSerializer.Serialize(klant1, options);
			//File.WriteAllText("../../../../Data/reservering.json", jsonString);



			
			
		}
	}
	
	public class Reservering
    {
		public string Naam { get; set; }
		public string Achternaam { get; set; }
		public int AantalMensen { get; set; }
		public int TafelNummer { get; set; }
		public int Res_ID { get; set; }
		public string Tijd { get; set; }
		public string Datum { get; set; }
		public string KlantID { get; set; }
		public string Betaalmethode { get; set; }

		public void Info()
        {
			Console.WriteLine($"Er staat een reservering op de naam {this.Naam} {this.Achternaam} op {this.Datum} om {this.Tijd} uur");
        }
		public Reservering(string naam, string achternaam, int aantalmensen, int tafelnummer, string tijd, string datum, string klantid, string betaalmethode)
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
			Console.WriteLine($"Er is succesvol een reservering geplaatst op de naam {this.Naam} {this.Achternaam} op {this.Datum} om {this.Tijd} uur met ID {this.Res_ID}");
		}
	}
}

