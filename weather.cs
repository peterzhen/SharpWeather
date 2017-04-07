using System;

namespace Weather
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			WeatherService service = new WeatherService();
			service.getCities();
			service.getWeather();
			service.addCity(11370);
			service.getCities();
			service.getWeather();
			service.addCity(112);
			service.getCities();
			service.getWeather();
		}
	}
}
