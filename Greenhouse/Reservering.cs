using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JSON;

namespace reservering
{

	public class ReserveringMain
	{
		public static string getTime()
        {
			// Geeft de 3 timeslots aan en laat de user pas doorgaan als een keuze is gemaakt.
            while (true)
            {
				Console.WriteLine("Welk tijdslot wilt u reserveren voor deze dag?");
				Console.WriteLine("1. Van 13:00 tot 16:00\n" +
								  "2. Van 16:00 tot 19:00\n" +
								  "3. Van 19:00 tot 22:00\n");

				switch (Console.ReadLine())
				{
					case "1":
						return "13:00";
						break;
					case "2":
						return "16:00";
						break;
					case "3":
						return "19:00";
						break;
					default:
						Console.WriteLine("Geef een geldige keuzen : ");
						break;

				}
			}

		}

		public static string getDate()
        {
			// Hier moet nog een check komen die kijkt of de datum geldig is !!!!!!!!!!!!!!
			Console.WriteLine("Wanneer wilt u een reservering plaatsen? : ");
			Console.WriteLine("In het format DD/MM, zoals dit : 29/2 of 2/5");
			string dateOutput = Console.ReadLine();
			return dateOutput;
        }

		public static string getVoornaam()
        {
			// Leest de voornaam
			Console.WriteLine("Wat is uw voornaam?");
			return Console.ReadLine();
        }

		public static string getAchternaam()
        {
			// Leest de achternaam
			Console.WriteLine("Wat is uw achternaam?");
			return Console.ReadLine();
		}
		public static string getTable()
        {

			while (true)
			{
				Console.Clear();
				//■
				Console.WriteLine("                     -TAFEL INDELING GREENHOUSE-                                      |                   |              ");
				Console.WriteLine("                                                                                      |                   |              ");
				Console.WriteLine("---------------------------------------------------------------------                 |                   |              ");
				Console.WriteLine("|   ■ ■ ■                     ■ ■ ■         ■ ■ ■          ■ ■ ■    |                 |                   |              ");
				Console.WriteLine("| > ■ 1 ■ <      ■ ■ ■      > ■ 8 ■ <     > ■ 10■ <      > ■ ■ ■ <  |                 |                   |              ");
				Console.WriteLine("|   ■ ■ ■      > ■ 5 ■ <      ■ ■ ■         ■ ■ ■          ■ ■ ■    |                 |                   |              ");
				Console.WriteLine("|                ■ ■ ■                                   > ■ 15■ <  |                 |                   |              ");
				Console.WriteLine("|   ■ ■ ■                     ■ ■ ■         ■ ■ ■          ■ ■ ■    |                 |                   |              ");
				Console.WriteLine("| > ■ 2 ■ <      ■ ■ ■      > ■ 9 ■ <     > ■ 11■ <      > ■ ■ ■ <  |         -----------------------------------------  ");
				Console.WriteLine("|   ■ ■ ■      > ■ 6 ■ <      ■ ■ ■         ■ ■ ■          ■ ■ ■    |         | Elke dag open, vannaf 13:00 tot 22:00 |  ");
				Console.WriteLine("|                ■ ■ ■                                              |         | De bar is open van 13:00 tot 01:00    |  ");
				Console.WriteLine("|   ■ ■ ■                                   ■ ■ ■          ■        |         -----------------------------------------  ");
				Console.WriteLine("| > ■ 3 ■ <      ■ ■ ■                    > ■ 12■ <       ----------|                                                    ");
				Console.WriteLine("|   ■ ■ ■      > ■ 7 ■ <                    ■ ■ ■       ■ |         |                        ^                           ");
				Console.WriteLine("|                ■ ■ ■                                    |         |                        |                           ");
				Console.WriteLine("|   ■ ■ ■                                   ■ ■ ■       ■ |   B     |                        |                           ");
				Console.WriteLine("| > ■ ■ ■ <                               > ■ 13■ <       |   A     |");
				Console.WriteLine("|   ■ ■ ■                                   ■ ■ ■       ■ |   R     |");
				Console.WriteLine("| > ■ 4 ■ <                                               |         |");
				Console.WriteLine("|   ■ ■ ■                                   ■ ■ ■       ■ |         |");
				Console.WriteLine("| > ■ ■ ■ <                               > ■ 14■ <       |         |");
				Console.WriteLine("|   ■ ■ ■                                   ■ ■ ■       ■ |         |");
				Console.WriteLine("|                             ^                           |         |");
				Console.WriteLine("|                             |                         ■ |         |");
				Console.WriteLine("---------------------------   |    ----------------------------------\n");

				//voor 1,2,3,... komt iets waarbij hij alleen de tafels laat zien die vrij zijn
				// Hier wordt op de datum en tijd van de reservering gekeken welke tafels er nog niet gereserveerd zijn.
				Console.WriteLine("Tafel: " + "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15" + " zijn nog beschikbaar.\n");
				Console.WriteLine("'<'/'>' zijn de stoelen en richting ervan.");

				Console.WriteLine("Aan welke tafel wilt u eten? Typ het nummer van deze tafel in:");

				// Voeg check toe voor int, het crasht als je een string invoeft
				// int tafelNummer = Convert.ToInt32(Console.ReadLine());
				// Hier moet laten een int van gemaakt worden, maar het cracht nu als je dat invult
				string tafelNummer = Console.ReadLine();
				if (tafelNummer == "") // We kunnen hier toevoegen dat als een tafel bezet is hij niet meer gereserveerd kan worden
				{
					Console.WriteLine("Dit tafelnummer is niet beschikbaar, probeer een ander tafelnummer");

					


				}
				else
				{
					return tafelNummer.ToString();
				}
			}
		}
		public static void showReserveringen()
        {
			// Laad het json bestand naar een string
			string innit = File.ReadAllText(paths.reservaring);

			// zet de string naar een array
			var Count = JArray.Parse(innit);

			// Loopt door alle reserveringen
			foreach (JObject item in Count)
			{
				// Loopt door alle objecten in het JSON bestand, en laat zien welke reserveringen er zijn.
				Console.Clear();
				string date = item.GetValue("Datum").ToString();
				string name = item.GetValue("Naam").ToString();
				string table = item.GetValue("TafelNummer").ToString();
				Console.WriteLine();
				Console.WriteLine($"{name} heeft een reservering op {date} bij tafel {table}\n");
				Console.WriteLine("Druk op enter om door de reserveringen te gaan, typ back om terug te gaan.");

				if(Console.ReadLine() == "back")
                {
					break;
                }
			}
        }
		public static void makeReservation()
		{

			bool running = true;

			string tijd = "";
			string naam = "";
			string achternaam = "";
			// Tijdelijk nog een string
			string tafelNummer = "";
			string datum = "";
			string klantid = "";

            while (running)
            {

				Console.Clear();
				Console.WriteLine("1. Kies een datum                      : " + datum);
				Console.WriteLine("2. Op welk tijdstip wilt u komen eten? : " + tijd);
				Console.WriteLine("3. Kies een tafel                      : " + tafelNummer);
				Console.WriteLine("4. Wat is uw voornaam                  : " + naam);
				Console.WriteLine("5. Wat is uw achternaam                : " + achternaam);
				Console.WriteLine("6. Plaats reservaring                  :");
				
				switch(Console.ReadLine()){ 
					case "1":
						datum = getDate();
						break;
					case "2":
						tijd = getTime();
						break;
					case "3":
						tafelNummer = getTable();
						break;
					case "4":
						naam = getVoornaam();
						break;
					case "5":
						achternaam = getAchternaam();
						break;
					case "6":
						running = false;
						// Hier moet nog een check komen of alles is ingevuld !!!!!!!!!!!

						Reservering klant = new Reservering(naam, achternaam, tafelNummer, tijd, datum, klantid);

						// Laad het json bestand naar een string
						string initialJson = File.ReadAllText(paths.reservaring);

						// zet de string naar een array
						var array = JArray.Parse(initialJson);

						// Maakt het object om toetevoegen naar een object voor json
						JObject jsonObject = JObject.FromObject(klant);

						// Voegt het json object toe aan de array
						array.Add(jsonObject);

						// Slaat het op in JSON
						File.WriteAllText(paths.reservaring, JsonConvert.SerializeObject(array, Formatting.Indented));

						break;
				}
			}


				Console.WriteLine("Druk op enter om terug te gaan");
				Console.ReadLine();
            
		}
	}
	
	public class Reservering
    {
		public string Naam { get; set; }
		public string Achternaam { get; set; }
		public string TafelNummer { get; set; }		public int Res_ID { get; set; }
		public string Tijd { get; set; }
		public string Datum { get; set; }
		public string KlantID { get; set; }

		public void Info()
        {
			Console.WriteLine($"Er staat een reservering op de naam {this.Naam} {this.Achternaam} op {this.Datum} om {this.Tijd} uur");
        }
		public Reservering(string naam, string achternaam, string tafelnummer, string tijd, string datum, string klantid)
        {
			Random r = new Random();
			this.Naam = naam;
			this.Achternaam = achternaam;
			this.TafelNummer = tafelnummer;
			this.Tijd = tijd;
			this.Datum = datum;
			this.KlantID = klantid;
			

			
			// Laad het json bestand naar een string
			string innit = File.ReadAllText(JSON.paths.reservaring);

			// zet de string naar een array
			var Count = JArray.Parse(innit);



			int len = Count.Count;

			this.Res_ID = len + 1;

			Console.WriteLine($"Er is succesvol een reservering geplaatst op de naam {this.Naam} {this.Achternaam} op {this.Datum} om {this.Tijd} uur met ID {this.Res_ID}");
		}
	}
}

