using NUnit.Framework;
using Login;
using Contact;
namespace Nunit3
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
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