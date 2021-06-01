using contact;
using Filter;
using login;
using NUnit.Framework;
namespace Nunit3
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public void Test()
        {
            // Moet false worden
            reservering.Reservering klant = new reservering.Reservering("Naam", "Achternaam", "5", "16:00", "00/00", "0");
            Assert.AreNotEqual(klant.Naam, "");
        }

        [Test]
        public void Test_maken_van_een_reservaring_naam()
        {
            // Moet false worden
            reservering.Reservering klant = new reservering.Reservering("Naam", "Achternaam", "5", "16:00", "00/00", "0");

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
        public void Test_maken_van_een_reservaring_tafelnummer()
        {
            // Moet false worden
            reservering.Reservering klant = new reservering.Reservering("Naam", "Achternaam", "5", "16:00", "00/00", "0");


            Assert.AreEqual(klant.TafelNummer, "5");



        }

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

    }
}