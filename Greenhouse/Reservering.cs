using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Reservering
{



	public class PageReservering
	{

		public static string path = @"../../../../Data/reservering.json";


		public static void showReser()
        {
			// Laad het json bestand naar een string
			string innit = File.ReadAllText(path);

			// zet de string naar een array
			var Count = JArray.Parse(innit);





			foreach (JObject item in Count)
			{
				string date = item.GetValue("Datum").ToString();
				string name = item.GetValue("Naam").ToString();

				string Tafel = item.GetValue("TafelNummer").ToString();
				Console.WriteLine($"{name} heeft een reservering op {date} bij tafel {Tafel} \n\n");
				Console.WriteLine("Druk op enter om door de reserveringen te gaan, typ back om terug te gaan.");
				if(Console.ReadLine() == "back")
                {
					break;
                }

			}

			
        }
		public static void show()
		{
			Console.Clear();

			string datum;

			while (true)
			{
				Console.Clear();
				string Time = DateTime.Now.ToShortDateString(); 
				Console.WriteLine("Op welke datum wilt u deze reservering plaatsen? Typ het in het format DD-M, zoals dit: 21/4");
				Console.WriteLine($"De datum van vandaag is: " + Time);
				datum = Console.ReadLine();

				
				string[] datumTotaal = datum.Split('/');

				if(datumTotaal.Length != 2)
                {
					Console.WriteLine("Not the correct format, try again:");
					Console.ReadLine();
                }
                else
                {
					try
					{
						foreach (var word in datumTotaal)
						{
							int a = Int32.Parse(word);
						}

						int month = (int)System.DateTime.Now.Month;
						int day = (int)System.DateTime.Now.Day;

						if(Int32.Parse(datumTotaal[1]) > month && Int32.Parse(datumTotaal[1]) < 12)
                        {
							if(Int32.Parse(datumTotaal[0]) > 31 && Int32.Parse(datumTotaal[0]) < 1)
                            {
								Console.WriteLine("That isnt a valid day, please try again:");
                            }
                            else
                            {
								break;
                            }
						}
                        else
                        {
							Console.WriteLine("That isnt a valid day, please try again:");
                        }
						
						Console.ReadLine();
					}
					catch (Exception e)
					{
						Console.WriteLine("Not a valid date, try again:");

					}


					Console.ReadLine();
				}




				





			}

			//check komen

			Console.Clear();

			string tijd;

			Console.Clear();
			while (true)
			{
				Console.Clear();
				Console.WriteLine("Welk tijdslot wilt u reserveren voor deze dag?");
				Console.WriteLine("1. Van 13:00 tot 16:00\n" +
					"2. Van 16:00 tot 19:00\n" +
					"3. Van 19:00 tot 22:00\n");
				string input = Console.ReadLine();
                switch (input)
                {
					case "1":
						tijd = "13:00";
						break;
					case "2":
						tijd = "16:00";
						break;

					case "3":
						tijd = "19:00";
						break;
					default:
						Console.WriteLine("Please give a valid choice:");
						Console.ReadLine();
						tijd = "";
						break;

                }
				
				if (tijd != "") break;

			}

			int tafelNummer;
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
				Console.WriteLine("Tafel: " + "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15" + " zijn nog beschikbaar.\n");
				Console.WriteLine("<> zijn de stoelen en richting ervan.");

				Console.WriteLine("Aan welke tafel wilt u eten? Typ het nummer van deze tafel in:");
				tafelNummer = Convert.ToInt32(Console.ReadLine());
				if (tafelNummer > 15) // We kunnen hier toevoegen dat als een tafel bezet is hij niet meer gereserveerd kan worden
				{
					Console.WriteLine("Dit tafelnummer is niet beschikbaar, probeer een ander tafelnummer");
					Console.ReadLine();

				}
				else
				{
					break;
				}
			}

			Console.Clear();


			/*
			int aantalMensen;
			while (true)
			{
                while (true)
                {
					Console.WriteLine("Voor hoeveel mensen is deze reservering?");
					try
					{
						aantalMensen = Convert.ToInt32(Console.ReadLine());
						break;
					}

					catch (Exception e)
					{
						Console.WriteLine("Invalid number, try again:");
					}
				}


				if (aantalMensen > 8)
				{
					Console.WriteLine("Voor het reserveren van groepen boven de 8 kunt u bellen naar : 0800-0432 \n Hierbij komen extra servicekosten van pas van 1,30 euro per persoon boven de 8\n");

				}
				else
				{
					if(aantalMensen < 1)
                    {
						Console.WriteLine("'Het aantal mensen moet minimaal 1 zijn.");
                    }
                    else
                    {
						break;
					}
					
				}
			}
			*/




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
			Console.WriteLine("Wat is je Naam?");
			string naam = Console.ReadLine();
			Console.Clear();
			Console.WriteLine("Wat is je Achternaam?");
			string achternaam = Console.ReadLine();

			Reservering klant = new Reservering(naam, achternaam, tafelNummer, tijd, datum, klantid);

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
		public int TafelNummer { get; set; }
		public int Res_ID { get; set; }
		public string Tijd { get; set; }
		public string Datum { get; set; }
		public string KlantID { get; set; }

		public void Info()
        {
			Console.WriteLine($"Er staat een reservering op de naam {this.Naam} {this.Achternaam} op {this.Datum} om {this.Tijd} uur");
        }
		public Reservering(string naam, string achternaam, int tafelnummer, string tijd, string datum, string klantid)
        {
			Random r = new Random();
			this.Naam = naam;
			this.Achternaam = achternaam;
			this.TafelNummer = tafelnummer;
			this.Tijd = tijd;
			this.Datum = datum;
			this.KlantID = klantid;
			

			string path = @"../../../../Data/reservering.json";
			// Laad het json bestand naar een string
			string innit = File.ReadAllText(path);

			// zet de string naar een array
			var Count = JArray.Parse(innit);



			int len = Count.Count;

			this.Res_ID = len + 1;

			Console.WriteLine($"Er is succesvol een reservering geplaatst op de naam {this.Naam} {this.Achternaam} op {this.Datum} om {this.Tijd} uur met ID {this.Res_ID}");
		}
	}
}

