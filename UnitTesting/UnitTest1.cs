using System;
using contact;
using Filter;
using login;
using Rules;
using reservering;
using NUnit.Framework;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using JSON;



namespace Nunit3
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public void Regel_4()
        {
            var x = rules.show();
            Assert.AreEqual(x[4], "4. Voor baby’s zijn er babystoelen.\n");
        }


        [Test]
        public void False_Test()
        {
            // Moet false worden
            reservering.Reservering klant = new reservering.Reservering("Naam", "Achternaam", "5", "16:00", "00/00", "0");
            Assert.AreEqual(klant.Naam, "Naam");
        }


        //Reserveringtests

        [Test]

        public void Test_maken_van_een_reservaring_naam()
        {
            // Moet false worden

            reservering.Reservering klant = new reservering.Reservering("Naam", "Achternaam", "5", "16:00", "00/00", "2");


            Assert.AreEqual(klant.Naam, "Naam");


        }

        [Test]
        public void Test_maken_van_een_reservaring_achternaam()
        {
            // Moet false worden
            reservering.Reservering klant = new reservering.Reservering("Naam", "Achternaam", "5", "16:00", "00/00", "0");


            Assert.AreEqual(klant.Achternaam, "Achternaam");




        }
        [Test]
        public void Test_maken_van_een_reservaring_info()
        {

            Reservering klant = new Reservering("Naam", "Achternaam", "5", "16:00", "00/00", "0");


            Assert.AreEqual(klant.Info(), "Er staat een reservering op de naam Naam Achternaam op 00/00 om 16:00 uur");


        }

        [Test]
        public void Test_maken_van_een_reservaring_tafelnummer()
        {
            // Moet false worden
            reservering.Reservering klant = new reservering.Reservering("Naam", "Achternaam", "5", "16:00", "00/00", "0");


            Assert.AreEqual(klant.TafelNummer, "5");
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


        //Login tests

        [Test]
        public void Login_Geeft_False_Bij_Verkeerd_Wachtwoord_En_Username()
        {
            // Moet false worden
            bool s = Login.check("", "");

            Assert.AreEqual(s, false);
        }

        [Test]
        public void Login_Geeft_True_Bij_Goed_Wachtwoord_En_Username()
        {
            // Moet false worden
            bool s = Login.check("123", "456");

            Assert.AreEqual(s, true);
        }

        //Contact tests

        [Test]
        public void Contact_naam_staat_goed()
        {
            Comment contact = new Comment("textTest", "nameTest");
            Assert.AreEqual(contact.Name, "nameTest");
            contact.deleteComment("textTest");
        }

        [Test]
        public void Contact_text_staat_goed()
        {
            Comment contact = new Comment("textTest", "nameTest");
            Assert.AreEqual(contact.Text, "textTest");
            contact.deleteComment("textTest");
        }


      //Filtertests



        [Test]
        public void Filterstring_test()
        {
            string s = FilterMain.FilterString("a");
            Assert.AreEqual(s, "a");
        }

        [Test]
        public void TypecheckInt_geeft_false_bij_string()
        {
            bool b = FilterMain.typeCheckInt("a");
            Assert.AreEqual(b, false);
        }

          
        [Test]
        public void FilterAantalPersonen_test()
        {
            string s = Filter.FilterMain.FilterAantalPersonen(6, true);
            Assert.AreEqual(s, "6");
        }

        
        [Test]
        public void DateCheck_unit_test()
        {
            string s = Filter.DateCheck.Check(@"01/01
32/01
31/12
");

            Assert.AreEqual(s, "31/12");
        }
        
    }
}