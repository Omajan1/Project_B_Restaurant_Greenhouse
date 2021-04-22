using System;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;
namespace Test

{
	public class test
	{
        public  class Account
        {
            public string Email { get; set; }
            public bool Active { get; set; }
        }



        

        

		public static void run()
		{

            Account account = new Account
            {
                Email = "james@example.com",
                Active = true,


            };


            // Laad het json bestand naar een string
            string initialJson = File.ReadAllText(@"../../../../Data/test.json");

            // zet de string naar een array
            var array = JArray.Parse(initialJson);

            // Maakt het object om toetevoegen naar een object voor json
            JObject jsonObject = JObject.FromObject(account);

            // Voegt het json object toe aan de array
            array.Add(jsonObject);

            // Slaat het op in JSON
            File.WriteAllText(@"../../../../Data/test.json", JsonConvert.SerializeObject(array, Formatting.Indented));



        }
	}

}
