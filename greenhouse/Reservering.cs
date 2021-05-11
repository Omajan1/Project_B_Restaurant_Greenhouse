using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using JSON;

namespace reservering
{

	public class ReserveringMain
	{
		public static string getTime()
        {
			// Geeft de 3 timeslots aan en laat de user pas doorgaan als een keuze is gemaakt.
			bool running = true;
            while (running)
            {

				Console.WriteLine("Welk tijdslot wilt u reserveren voor deze dag?");
				Console.WriteLine("1. Van 13:00 tot 16:00");
				Console.WriteLine("2. Van 16:00 tot 19:00");
				Console.WriteLine("3. Van 19:00 tot 22:00");
				Console.WriteLine("4. Terug naar het menu");
						

				switch (Console.ReadLine())
				{
					case "1":
						return "13:00";
					case "2":
						return "16:00";
					case "3":
						return "19:00";
					case "4":
						running = false;
						return "";
					default:
						Console.WriteLine("Geef een geldige keuze : ");
						break;
				}
			}
			return "";
		}


		public static string getDate()
        {
			Console.WriteLine("Wanneer wilt u een reservering plaatsen? : ");
			Console.WriteLine("In het format DD/MM, zoals dit : 29/02 of 02/05");

			// check:
			string dateOutput = Filter.DateCheck.Check();
			return dateOutput;
        }

		public static string getVoornaam()
        {
			// Leest de voornaam
			Console.WriteLine("Wat is uw voornaam?");
			string Input = Console.ReadLine();
			Filter.FilterMain.FilterString(Input);
			return Input;
		}

		public static string getAchternaam()
        {
			// Leest de achternaam
			Console.WriteLine("Wat is uw achternaam?");
			string Input = Console.ReadLine();
			Filter.FilterMain.FilterString(Input);
			return Input;
		}
		public static string getTable(string tijd, string datum)
        {

			while (true)
			{
				// Laad het json bestand naar een string
				string innit = File.ReadAllText(paths.reservaring);

				// zet de string naar een array
				var Count = JArray.Parse(innit);

				List<JObject> UsedTableObjects = new List<JObject>(); 

				// gaat langs elk object in reservering, pakt de objects met dezelfde datum en stopt deze in een list voor verdere fitlering
				foreach (JObject item in Count)
                {
					string date = item.GetValue("Datum").ToString();
					if (date == datum)
                    {
						UsedTableObjects.Add(item);
                    }
				}

				List<JObject> FinalUsableObjects = new List<JObject>();

				// gaat langs elk object in objecten van die ene datum en kijkt welke dezelfde tijd hebben, voegt deze toe aan een list
				foreach (JObject item in UsedTableObjects)
                {
					string time = item.GetValue("Tijd").ToString();
					if (time == tijd)
                    {
						FinalUsableObjects.Add(item);
                    }
                }

				List<string> TableNumbersInUse = new List<string>();

				//voegt alle tafelnummers toe die gebruikt worden op die dag op dat tijdstip
				foreach (JObject item in FinalUsableObjects)
                {
					string TableInUse = item.GetValue("TafelNummer").ToString();
					TableNumbersInUse.Add(TableInUse);
				}

				List<string> TafelsVrij = new List<string>();

				//vul tafelsvrij met alle mogelijke tafels
				TafelsVrij.Add("1");
				TafelsVrij.Add("2");
				TafelsVrij.Add("3");
				TafelsVrij.Add("4");
				TafelsVrij.Add("5");
				TafelsVrij.Add("6");
				TafelsVrij.Add("7");
				TafelsVrij.Add("8");
				TafelsVrij.Add("9");
				TafelsVrij.Add("10");
				TafelsVrij.Add("11");
				TafelsVrij.Add("12");
				TafelsVrij.Add("13");
				TafelsVrij.Add("14");
				TafelsVrij.Add("15");


				List<string> result = TafelsVrij.Except(TableNumbersInUse).ToList();

				string TafelsVrij_string = "";

				foreach (string tafel in result)
                {
					TafelsVrij_string += tafel + ",";
                }

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

				Console.WriteLine("Tafel: " + TafelsVrij_string + " zijn nog beschikbaar.\n");
				Console.WriteLine("'<'/'>' zijn de stoelen en richting ervan.");

				Console.WriteLine("Aan welke tafel wilt u eten? Typ het nummer van deze tafel in:");

				// Voeg check toe voor int, het crasht als je een string invoeft
				// int tafelNummer = Convert.ToInt32(Console.ReadLine());
				// Hier moet laten een int van gemaakt worden, maar het cracht nu als je dat invult
				var tafelNummer = Console.ReadLine();
				Filter.FilterMain.FilterInt(tafelNummer);
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
			var running = true;
			while (running)
			{


				foreach (JObject item in Count)
				{
					// Loopt door alle objecten in het JSON bestand, en laat zien welke reserveringen er zijn.
					Console.Clear();
					Console.WriteLine("Druk op enter om door te gaan naar de volgende reservering, typ Q om terug te gaan\n");
					string date = item.GetValue("Datum").ToString();
					string name = item.GetValue("Naam").ToString();
					string table = item.GetValue("TafelNummer").ToString();

					Console.WriteLine($"{name} heeft een reservering op {date} bij tafel {table}\n");
					string choice = Console.ReadLine();
					if (choice.ToUpper() == "Q")
                    {
						running = false;
						break;

                    }




				}


			}
		}
		public static void makeReservation()
		{
			bool running = true;

			string tijd = "";
			string naam = "";
			string achternaam = "";
			string tafelNummer = "";
			string datum = "";
			

            while (running)
            {
				// 3 kan niet als 1 en 2 niet gedaan zijn
				Console.Clear();
				Console.WriteLine("1. Kies een datum                      : " + datum);
				Console.WriteLine("2. Op welk tijdstip wilt u komen eten? : " + tijd);
				Console.WriteLine("3. Kies een tafel                      : " + tafelNummer);
				Console.WriteLine("4. Wat is uw voornaam                  : " + naam);
				Console.WriteLine("5. Wat is uw achternaam                : " + achternaam);
				Console.WriteLine("6. Plaats reservering                  :");
				Console.WriteLine("7. Terug naar het hoofdmenu            :");

				switch (Console.ReadLine()){
					case "7":
						running = false;
						break;
					case "1":
						datum = getDate();
						break;
					case "2":
						tijd = getTime();
						break;
					case "3":
						if(tijd != "" && datum != "")
                        {
							tafelNummer = getTable(tijd, datum);
                        }
                        else
                        {
							Console.Clear();
							Console.WriteLine("Vul eerst optie 1 en 2 in : ");
							Console.ReadLine();
                        }
						
						break;
					case "4":
						naam = getVoornaam();
						break;
					case "5":
						achternaam = getAchternaam();
						break;
					case "6":
						
						if(naam != "" && achternaam != "" && tafelNummer != "" && tijd != "" && datum != "")
                        {
							Reservering klant = new Reservering(naam, achternaam, tafelNummer, tijd, datum);

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
							running = false;
							Console.WriteLine("Druk op enter om terug te gaan");
							Console.ReadLine();
							break;
						}
                        else
                        {
							Console.Clear();
							Console.WriteLine("De reservering is nog niet compleet, vul hem aub aan : ");
							Console.ReadLine();
							break;
                        }
				}
			}
		}
	}
	
	public class Reservering
    {
		public string Naam { get; set; }
		public string Achternaam { get; set; }
		public string TafelNummer { get; set; }		public int Res_ID { get; set; }
		public string Tijd { get; set; }
		public string Datum { get; set; }
		

		public void Info()
        {
			Console.WriteLine($"Er staat een reservering op de naam {this.Naam} {this.Achternaam} op {this.Datum} om {this.Tijd} uur");
        }
		public Reservering(string naam, string achternaam, string tafelnummer, string tijd, string datum )
        {
			Random r = new Random();
			this.Naam = naam;
			this.Achternaam = achternaam;
			this.TafelNummer = tafelnummer;
			this.Tijd = tijd;
			this.Datum = datum;
	
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

