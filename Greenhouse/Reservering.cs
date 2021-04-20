using System;
namespace Reservering
{
	public class PageReservering
	{
		public static void show()
		{
			Console.Clear();
			Console.WriteLine("Wat is je Naam?");
			string naam = Console.ReadLine();
			Console.Clear();
			Console.WriteLine("Wat is je Achternaam?");
			string achternaam = Console.ReadLine();
			Console.Clear();
			Console.WriteLine("Met hoeveel mensen wil je reserveren?");
			int aantalMensen = Convert.ToInt32(Console.ReadLine());
			Console.Clear();
			Console.WriteLine("Wat voor tafelnummer wilt u hebben?");
			int tafelNummer = Convert.ToInt32(Console.ReadLine());
			Console.Clear();
			Console.WriteLine("Welk uur wilt u beginnen met eten?");
			int tijd1 = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Welke meniten van dit uur wilt u beginnen met eten?");
			int tijd2 = Convert.ToInt32(Console.ReadLine());
			int[] tijd = new int[2] { tijd1, tijd2 };
			Console.Clear();
			Console.WriteLine("Welke datum wilt u selecteren?");
			string datum = Console.ReadLine();
			Console.Clear();
			Console.WriteLine("Wat is je KlantenID?");
			string klantid = Console.ReadLine();
			Console.Clear();
			Console.WriteLine("Hoe wilt u betalen?");
			string betaalmethode = Console.ReadLine();
			Console.Clear();
			Reservering klant1 = new Reservering(naam, achternaam, aantalMensen, tafelNummer, tijd, datum, klantid, betaalmethode);

			Console.ReadLine();
		}
	}

	public class Reservering
    {
		public string Naam;
		public string Achternaam;
		public int AantalMensen;
		public int TafelNummer;
		public int Res_ID;
		public int[] Tijd;
		public string Datum;
		public string KlantID;
		public string Betaalmethode;

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

