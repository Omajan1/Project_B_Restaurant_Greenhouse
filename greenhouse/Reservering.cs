using JSON;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Diagnostics.CodeAnalysis;
namespace reservering
{
    [ExcludeFromCodeCoverage]
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


                string reader = Console.ReadLine();

                switch (reader)
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
            Console.WriteLine("In het format DD/MM, zoals dit: 29/02 of 02/05");

            // check:
            string DateInput = Console.ReadLine();
            string dateOutput = Filter.DateCheck.Check(DateInput);
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
                Console.WriteLine("--------------    --------------    ---------------    --------------                 |                   |              ");
                Console.WriteLine("|   ■ ■ ■                     ■ ■ ■         ■ ■ ■          ■ ■ ■    |                 |                   |              ");
                Console.WriteLine("  Θ ■ 1 ■ Θ      ■ ■ ■      Θ ■ 8 ■ Θ     Θ ■ 10■ Θ      Θ ■ ■ ■ Θ  |                 |                   |              ");
                Console.WriteLine("    ■ ■ ■      Θ ■ 5 ■ Θ      ■ ■ ■         ■ ■ ■          ■ ■ ■    |                 |                   |              ");
                Console.WriteLine("|                ■ ■ ■                                   Θ ■ 15■ Θ                    |                   |              ");
                Console.WriteLine("|   ■ ■ ■                     ■ ■ ■         ■ ■ ■          ■ ■ ■                      |                   |              ");
                Console.WriteLine("| Θ ■ 2 ■ Θ      ■ ■ ■      Θ ■ 9 ■ Θ     Θ ■ 11■ Θ      Θ ■ ■ ■ Θ  |         -----------------------------------------  ");
                Console.WriteLine("|   ■ ■ ■      Θ ■ 6 ■ Θ      ■ ■ ■         ■ ■ ■          ■ ■ ■    |         | Elke dag open, vanaf 13:00 tot 22:00  |  ");
                Console.WriteLine("                 ■ ■ ■                                       0                | De bar is open vanaf 13:00 tot 01:00  |  ");
                Console.WriteLine("    ■ ■ ■                                   ■ ■ ■          WC ----->          -----------------------------------------  ");
                Console.WriteLine("| Θ ■ 3 ■ Θ      ■ ■ ■                    Θ ■ 12■ Θ       ----------|                                                    ");
                Console.WriteLine("|   ■ ■ ■      Θ ■ 7 ■ Θ                    ■ ■ ■       Θ |         |                        ^                           ");
                Console.WriteLine("|                ■ ■ ■                                    |         |                        |                           ");
                Console.WriteLine("|   ■ ■ ■                                   ■ ■ ■       Θ |   B     |                        |                           ");
                Console.WriteLine("| Θ ■ ■ ■ Θ                               Θ ■ 13■ Θ       |   A     |");
                Console.WriteLine("    ■ ■ ■                                   ■ ■ ■       Θ |   R     |");
                Console.WriteLine("  Θ ■ 4 ■ Θ                                               |         |");
                Console.WriteLine("|   ■ ■ ■                                   ■ ■ ■       Θ |         |");
                Console.WriteLine("| Θ ■ ■ ■ Θ                               Θ ■ 14■ Θ       |         |");
                Console.WriteLine("|   ■ ■ ■                                   ■ ■ ■       Θ |         |");
                Console.WriteLine("|                             ^                           |         |");
                Console.WriteLine("|                             |                         Θ |         |");
                Console.WriteLine("---------    --------------   |    ------------    ------------------\n");

                //voor 1,2,3,... komt iets waarbij hij alleen de tafels laat zien die vrij zijn
                // Hier wordt op de datum en tijd van de reservering gekeken welke tafels er nog niet gereserveerd zijn.

                Console.WriteLine("Tafel: " + TafelsVrij_string + " zijn nog beschikbaar.\n");
                Console.WriteLine("De WC is aangegeven aan de rechter kant van het restaurant.");
                Console.WriteLine(" Θ zijn de stoelen.\nHet personeel is altijd in staat om uw tafel te wijzigen als dat beter uitkomt voor de rest van de gasten.");
                Console.WriteLine("Aan welke tafel wilt u eten? Vul het nummer van deze tafel in:");

                // Voeg check toe voor int, het crasht als je een string invoeft
                // int tafelNummer = Convert.ToInt32(Console.ReadLine());
                // Hier moet laten een int van gemaakt worden, maar het cracht nu als je dat invult
                bool r = true;
                string tafelNummer;

                while (r)
                {
                    tafelNummer = Console.ReadLine();

                    var isTableInt = Filter.FilterMain.typeCheckInt(tafelNummer);
                    if (isTableInt)
                    {
                        bool table_is_in_use = false;

                        foreach (string table in TableNumbersInUse)
                        {
                            if (table == tafelNummer)
                            {
                                table_is_in_use = true;
                            }
                        }

                        if (tafelNummer == "" || Convert.ToInt32(tafelNummer) < 1 || Convert.ToInt32(tafelNummer) > 15 || table_is_in_use) // We kunnen hier toevoegen dat als een tafel bezet is hij niet meer gereserveerd kan worden
                        {
                            Console.WriteLine("Dit tafelnummer is niet beschikbaar, probeer een ander tafelnummer.");
                        }
                        else
                        {
                            return tafelNummer.ToString();
                        }
                        r = false;
                    }
                    else
                    {
                        Console.WriteLine("");
                    }
                }




            }
        }
        public static void showReserveringen(string naamVanKlant)
        {
            // Laad het json bestand naar een string
            string innit = File.ReadAllText(paths.reservaring);

            // zet de string naar een array
            var Count = JArray.Parse(innit);

            // Loopt door alle reserveringen
            var running = true;
            Console.Clear();
            while (running)
            {

                foreach (JObject item in Count)
                {
                    // Loopt door alle objecten in het JSON bestand, en laat zien welke reserveringen er zijn.

                    if (naamVanKlant == item.GetValue("Achternaam").ToString())
                    {
                        string date = item.GetValue("Datum").ToString();
                        string name = item.GetValue("Naam").ToString();
                        string table = item.GetValue("TafelNummer").ToString();
                        string tijd = item.GetValue("Tijd").ToString();

                        Console.WriteLine($"{name} heeft een reservering op {date} voor tafel {table} om {tijd}.\n");
                    }
                }
                running = false;
                Console.WriteLine("Druk op enter om weer terug te gaan.");
                Console.ReadLine();
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
            string aantalPersonen = "";

            while (running)
            {
                // 3 kan niet als 1 en 2 niet gedaan zijn
                Console.Clear();
                Console.WriteLine("Type eerst het nummer van de optie die je wilt invullen en druk dan op enter, vul daarna je gegevens in : ");
                Console.WriteLine("1. Kies een datum                      : " + datum);
                Console.WriteLine("2. Op welk tijdstip wilt u komen eten? : " + tijd);
                Console.WriteLine("3. Kies een tafel                      : " + tafelNummer);
                Console.WriteLine("4. Wat is uw voornaam                  : " + naam);
                Console.WriteLine("5. Wat is uw achternaam                : " + achternaam);
                Console.WriteLine("6. Met hoeveel mensen komt u eten?     : " + aantalPersonen);
                Console.WriteLine("\n7. Plaats reservering                ");
                Console.WriteLine("8. Terug naar het hoofdmenu            ");

                switch (Console.ReadLine())
                {
                    case "1":
                        datum = getDate();
                        break;
                    case "2":
                        tijd = getTime();
                        break;
                    case "3":
                        if (tijd != "" && datum != "")
                        {
                            tafelNummer = getTable(tijd, datum);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Vul eerst optie 1 en 2 in: ");
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
                        if (tafelNummer != "")
                        {
                            if (tafelNummer == "4" || tafelNummer == "15")
                            {
                                aantalPersonen = Filter.FilterMain.FilterAantalPersonen(6, false);
                            }
                            else
                            {
                                aantalPersonen = Filter.FilterMain.FilterAantalPersonen(2, false);
                            }

                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Vul eerst optie 3 in a.u.b.");
                            Console.ReadLine();
                        }

                        break;
                    case "8":
                        running = false;
                        break;
                    case "7":

                        if (naam != "" && achternaam != "" && tafelNummer != "" && tijd != "" && datum != "" && aantalPersonen != "")
                        {









                            Console.WriteLine("Weet u zeker dat u deze reservering wilt plaatsen? ");
                            Console.WriteLine("Type ja en druk op enter om door te gaan met deze reservering. ");
                            Console.WriteLine("Als u wilt annuleren type dan niks en druk op enter.");
                            string confirm = Console.ReadLine();
                            if (confirm.ToUpper() == "JA")
                            {


                                bool EmailNotFound = true;
                                string email;

                                while (EmailNotFound)
                                {
                                    Console.WriteLine("Wat is uw email?");
                                    email = Console.ReadLine();
                                    try
                                    {

                                        string Emailusername = "greenhousesuporrt@gmail.com";
                                        string Emailpassword = "kinuqemwmtfrvjfr";
                                        using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
                                        {
                                            client.EnableSsl = true;
                                            client.DeliveryMethod = SmtpDeliveryMethod.Network;
                                            client.UseDefaultCredentials = false;
                                            client.Credentials = new NetworkCredential(Emailusername, Emailpassword);
                                            MailMessage msgObj = new MailMessage();
                                            msgObj.To.Add(email);
                                            msgObj.From = new MailAddress(Emailusername);
                                            msgObj.Subject = "Greenhouse reservering succesvol geplaatst!";
                                            msgObj.Body = $"Beste {naam} {achternaam},\n\n" +
                                                $"Er is een reservering geplaatst op {datum} aan tafel {tafelNummer}, u wordt verwacht voor {tijd} in het restaurant te zijn." +
                                                $"\nDeze reservering is voor 3 uur, en er wordt verwacht dat u voor die tijd klaar bent met eten." +
                                                $"\nVoor alle voorwaarden die aan deze reservering vastzitten kunt u naar het tabje 'regels' in de applicatie." +
                                                $"\n\nMet vriendelijke groet, \n\nTeam Greenhouse BV\nRotterdam, 3002AP";
                                            client.Send(msgObj);
                                            EmailNotFound = false;

                                        }

                                    }
                                    catch
                                    {
                                        Console.WriteLine("Dit is geen geldige email, probeer het opnieuw.");

                                    }
                                }




                                Reservering klant = new Reservering(naam, achternaam, tafelNummer, tijd, datum, aantalPersonen);

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
                                Console.WriteLine("Lees of bewerk de reservering nog eens goed.");
                                break;
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("De reservering is nog niet compleet, vul hem a.u.b. aan : ");
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
        public string TafelNummer { get; set; }
        public int Res_ID { get; set; }
        public string Tijd { get; set; }
        public string Datum { get; set; }

        public string AantalPersonen { get; set; }
        public string Info()
        {
            return $"Er staat een reservering op de naam {this.Naam} {this.Achternaam} op {this.Datum} om {this.Tijd} uur";
        }
        public Reservering(string naam, string achternaam, string tafelnummer, string tijd, string datum, string aantalPersonen)
        {
            Random r = new Random();
            this.Naam = naam;
            this.Achternaam = achternaam;
            this.TafelNummer = tafelnummer;
            this.Tijd = tijd;
            this.Datum = datum;
            this.AantalPersonen = aantalPersonen;

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


