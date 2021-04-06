using System;

namespace Greenhouse
{
    class Pages
    {
        public static string FirstPage0()
        {
            Console.WriteLine("--Welkom bij de Reserverings Applicatie van GreenHouse--\n");

            Console.WriteLine("Dit zijn de opties:\n");
            Console.WriteLine("1. Reserveren");
            Console.WriteLine("2. Menu");
            Console.WriteLine("3. Regels");
            Console.WriteLine("4. Contact Opnemen?");
            Console.WriteLine("5. Exit");

            Console.Write("Zet hier uw keuze neer: ");
            string result = Console.ReadLine();

            if (result == "1") //reservation
            {
                return "1";
            }
            else if (result == "2") //menu
            {
                return "2";
            }
            else if (result == "3") //rules
            {
                return "3";
            }
            else if (result == "4") //contact
            {
                return "4";
            }
            else if (result == "5") //exit
            {
                Environment.Exit(1);
                return null;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\n ----This is not a valid option, try again.----\n");
                FirstPage0();
                return null;
            }
        }

        public static void MenuPage0() //voor nu void 
        {
            Console.WriteLine("--Welkom bij de Menu Pagina--\n");

            Console.WriteLine("Kies de catagorie die u wilt bekijken\n");
            Console.WriteLine("1. Appitizer");
            Console.WriteLine("2. Main");
            Console.WriteLine("3. Dessert");
            Console.WriteLine("4. Fish");
            Console.WriteLine("5. Vegan");
            Console.WriteLine("6. Vega");
            Console.WriteLine("7. All options listed above (you can also type 'all')");

            Console.Write("Wat zou u willen zien: ");
            string result = Console.ReadLine();

            //check wat er is geinput
            if (result == "7" || result == "all")
            {
                //test cuz i dont got notin
                Console.Clear();
                Console.WriteLine("All options and stuff");
            }
        }

        public static void RulesPage()
        {
            Console.WriteLine("--Welcome to the Rules page.--\n");

            Console.WriteLine("Wij willen graag voor iedereen een zo gastvrij mogelijke ervaring creëren in ons restaurant. \n" +
                "Daarom hebben we een aantal huisregels opgesteld om het restaurant voor zoveel mogelijk mensen te accommoderen.\n");
            Console.WriteLine("-Wegens hygiënische redenen zijn huisdieren helaas niet toegestaan in ons  restaurant. Hulpdieren zijn uiteraard wel toegestaan. \n" +
                "-Gelieve geen bovenmatig geluid te maken zodat u de andere gasten niet hindert.\n" +
                "-Kinderen zijn toegestaan, maar gelieve er voor te zorgen dat uw kinderen geen overlast veroorzaken.Geen schreeuwende of rennende kinderen.\n" +
                "-Voor baby’s zijn er babystoelen.\n" +
                "-Geen agressie in het restaurant.\n" +
                "-Drugsgebruik is verboden.Drank is toegestaan, mits het door het restaurant geserveerd wordt.De bar kan stoppen met het serveren van beschonken mensen.\n" +
                "-We zijn niet aansprakelijk voor diefstal of verlies van eigendommen.\n" +
                "-Als u 30 minuten na uw gereserveerde tijd niet aanwezig bent, dan kunnen wij uw tafel weggeven aan andere wachtende klanten.\n" +
                "-Wapenbezit in het restaurant is verboden.\n" +
                "-Het is verboden om eigendommen van het restaurant mee te nemen.\n" +
                "-Grof taalgebruik tegen het personeel wordt niet getolereerd.\n" +
                "-Het binnentreden met aanstootgevende kleding is niet toegestaan.\n" +
                "-We verwachten dat iedereen elkaar met respect behandelt, zo niet, dan is het personeel altijd in staat de desbetreffende klant de toegang tot het restaurant te ontzeggen.\n" +
                "-Het nuttigen van eigen voedingsmiddelen en dranken is ten strengste verboden.\n" +
                "-Het netjes achterlaten van je tafel is niet verplicht, maar laat het acceptabel.\n");
            Console.WriteLine("Wij willen natuurlijk dat u uw bezoek aan ons restaurant prettig ervaart. " +
                "Met het naleven van de huisregels willen wij het bezoek aan ons restaurant plezierig houden voor iedereen.");
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            
            //Eerste page standaard open
            string FirstPage0Awnser = Pages.FirstPage0();

            //check voor ouput FirstPage0Awnser
            if (FirstPage0Awnser == "2") // menu ------ Test! Dit is nu heel lelijk 
                Console.Clear();
                Pages.MenuPage0();
        }
    }
}
