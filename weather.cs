using System;

namespace Weather
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			WeatherService service = new WeatherService();
			service.addCity("11370");
			service.addCity("1231441213");
			service.getWeather();

		}
	}
}
