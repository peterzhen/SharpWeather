using System;

namespace Weather
{
	public class WeatherService
	{
		private List<City> cities;


		public WeatherService()
		{
			this.totalCities = 0;
			this.cities = new List<City>();
		}

		public void addCity(int zipcode)
		{
			totalCities.Add(new City(zipcode);
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
				Console.WriteLine(city.getCity());
			}
		}
	}
}
