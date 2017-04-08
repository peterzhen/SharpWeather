using System;
using System.Collections.Generic;

namespace Weather
{
	public class WeatherService
	{
		private List<City> cities;

		public WeatherService()
		{
			this.cities = new List<City>();
			initMessage();
		}

		public void promptLoop()
		{
		}

		public void initMessage()
		{
			Console.WriteLine("************************************************************");
			Console.WriteLine("Welcome To The Command Prompt Weather Serivce.");
			Console.WriteLine("************************************************************");
			Console.WriteLine();
			Console.WriteLine("To Begin, type \"add\" in the command prompt.");
			Console.WriteLine("This will prompt you to add a city.");
			Console.WriteLine();
			Console.WriteLine("To fetch the weather for all your cities, type in \"fetch\"");
			Console.WriteLine("Note: You are only allowed 10 requests per minute");
			Console.WriteLine();
		}

		public void addCity(string zipcode)
		{
			City newCity = new City(zipcode);
			if (newCity.fetchWeather())
			{
				cities.Add(newCity);
				Console.WriteLine(String.Format("{0} Succesfully Added!", newCity.getCity()));
			}
			else
			{
				Console.WriteLine("Incorrect Zipcode, Try Again.");
			}
		}

		public void getWeather()
		{
			Console.WriteLine("Fetching Weather For Your Cities...");

			foreach (var city in cities)
			{
				Console.WriteLine(city.getWeather());
			}
			Console.WriteLine();
		}

		public void getCities()
		{
			Console.WriteLine("Your Cities: ");
			foreach (var city in cities)
			{
				Console.WriteLine(city.getCity());
			}
			Console.WriteLine();
		}
	}
}
