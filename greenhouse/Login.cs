using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JSON;
namespace Login
{
    public class Login
    {
        public static bool check(string username, string password)
        {




            // Laad het json bestand naar een string
            string initialJson = File.ReadAllText(paths.login);

            // Zet de string naar een array
            var array = JArray.Parse(initialJson);

            // Gaat door elk element van de JSON array heen
            foreach (JObject q in array)
            {
                JToken Username = q["username"];
                JToken Password = q["password"];
                string correctUsername = Username.ToString();
                string correctPassword = Password.ToString();
                if (correctUsername == username && correctPassword == password) return true;
            }
            return false;





        }
    }

}

