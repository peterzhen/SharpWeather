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

		public void initMessage()
		{
			Console.WriteLine("Welcome To The Command Prompt Weather Serivce.");
			Console.WriteLine("This Application Will Fetch The Weather For You.");
			Console.WriteLine("To Begin, type \"add\" in the command prompt.");
			Console.WriteLine("This will prompt you to add a city via zipcode.");
			Console.WriteLine("You may add up to 10 Cities.");
			Console.WriteLine("To fetch the weather for all your cities, type in \"fetch\"");
			Console.WriteLine("Note: You are only allowed 10 requests per minute");
		}

		public void addCity(int zipcode)
		{
			cities.Add(new City(zipcode));
		}

		public void getWeather()
		{
			Console.WriteLine("Fetching Weather For Your Cities...");

			foreach (var city in cities)
			{
				city.fetchWeather();
			}
		}

		public void getCities()
		{
			Console.WriteLine("Your Cities: ");
			foreach (var city in cities)
			{
				//Console.WriteLine(city.getCity());
				Console.WriteLine("city name");
			}
		}
	}
}
