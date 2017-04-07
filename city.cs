using System;

namespace Weather
{
	public class City
	{
		private int zipcode;

		public City(int zipcode)
		{
			this.zipcode = zipcode;
		}

		public void fetchWeather()
		{
			Console.WriteLine(this.zipcode + "'s Weather");
		}

		public void getCity()
		{
			Console.WriteLine("City Name: " + this.zipcode);
		}
	}
}
