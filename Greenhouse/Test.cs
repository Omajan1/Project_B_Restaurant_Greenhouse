using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
namespace Test

{
	public class test
	{
		public class WeatherForecast
		{
			public string Date { get; set; }
			public string TemperatureCelsius { get; set; }
			public string Summary { get; set; }

			public WeatherForecast(string date, string temp, string sum)
            {
				Date = date;
				TemperatureCelsius = temp;
				Summary = sum;
            }
		}
		public class WeatherForecastWithPOCOs
		{
			public string Date { get; set; }
			public string TemperatureCelsius { get; set; }
			public string Summary { get; set; }

		}

		public static void run()
		{
			JsonSerializerOptions options = new JsonSerializerOptions
			{
				WriteIndented = true
				
				
			};

			WeatherForecastWithPOCOs weatherForecast = new WeatherForecastWithPOCOs();
			weatherForecast.Date = "1";
			weatherForecast.TemperatureCelsius = "1";
			weatherForecast.Summary = "1";
			string jsonStringRead = File.ReadAllText("../../../../Data/reservering.json");

			WeatherForecastWithPOCOs[] weatherForecastTest = JsonSerializer.Deserialize<WeatherForecastWithPOCOs[]>(jsonStringRead);

			WeatherForecastWithPOCOs[] newArr = new WeatherForecastWithPOCOs[weatherForecastTest.Length + 1];
			newArr[weatherForecastTest.Length] = weatherForecast;
			string jsonString = JsonSerializer.Serialize(newArr, options);
			File.WriteAllText("../../../../Data/reservering.json", jsonString);


			Console.WriteLine(weatherForecastTest[0].TemperatureCelsius +  weatherForecastTest[0].Date + weatherForecastTest[0].Summary);
			Console.ReadKey();
			
		}
	}

}
