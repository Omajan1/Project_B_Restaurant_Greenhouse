using NUnit.Framework;
using Login;
using contact;
using reservering;
using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using JSON;
using ConsoleReader;
using System.Net.Mail;
using System.Net;

namespace Nunit3
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Test_maken_van_een_reservaring()
        {
            // Moet false worden
            reservering.Reservering klant = new reservering.Reservering("Naam", "Achternaam", "5", "16:00", "00/00", "2");

            Assert.AreEqual(klant.Naam, "Naam");
            Assert.AreEqual(klant.Achternaam, "Achternaam");
            Assert.AreEqual(klant.TafelNummer, "5");
            Assert.AreEqual(klant.Tijd, "16:00");
            Assert.AreEqual(klant.Datum, "00/00");
            Assert.AreEqual(klant.Datum.Length, 5);
            Assert.AreEqual(klant.AantalPersonen, "2");
        }

        [Test]
        public void Tafel_String_checken()
        {
            string datum = "16/06";
            string tijd = "16:00";
            
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

            //check
            Assert.AreEqual(TafelsVrij_string, "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,");
        }

        [Test]
        public void Login_Geeft_False_Bij_Verkeerd_Wachtwoord_En_Username()
        {
            // Moet false worden
            bool s = Login.Login.check("", "");

            Assert.AreEqual(s, false);
        }

        [Test]
        public void Login_Geeft_True_Bij_Goed_Wachtwoord_En_Username()
        {
            // Moet false worden
            bool s = Login.Login.check("123", "456");

            Assert.AreEqual(s, true);
        }

        [Test]
        public void Contact_naam_staat_goed()
        {
            // Moet false worden
            Comment contact = new Comment("textTest", "nameTest", true);

            Assert.AreEqual(contact.Name, "nameTest");
        }

        [Test]
        public void Contact_text_staat_goed()
        {
            // Moet false worden
            Comment contact = new Comment("textTest", "nameTest", true);

            Assert.AreEqual(contact.Text, "textTest");
        }
    }
}