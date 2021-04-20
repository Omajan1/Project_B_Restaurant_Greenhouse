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
			public int Date { get; set; }
			public int TemperatureCelsius { get; set; }
			public string Summary { get; set; }

			public WeatherForecast(int date, int temp, string sum)
            {
				Date = date;
				TemperatureCelsius = temp;
				Summary = sum;
            }
		}
		public static void run()
		{
			JsonSerializerOptions options = new JsonSerializerOptions
			{
				WriteIndented = true

			};
			WeatherForecast weatherForecast = new WeatherForecast(1, 1, "DD");
			string jsonString = JsonSerializer.Serialize(weatherForecast, options);
			File.WriteAllText("TEST.json", jsonString);

		}
	}

}
