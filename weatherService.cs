using System;
using System.Collections.Generic;

namespace Weather
{
	class WeatherService
	{
		private List<City> cities;
		private bool prompting;

		public WeatherService()
		{
			this.cities = new List<City>();
			this.prompting = false;
			initMessage();
			promptLoop();
		}

		private void promptLoop()
		{
			while (true)
			{
				if (this.prompting == false)
				{
					this.prompting = true;
					if (cities.Count == 0)
					{
						Console.Write("To begin, please enter a 5-digit US zipcode: ");
						string zipcode = Console.ReadLine();
						addCity(zipcode);
					}
					else
					{
						Console.Write("What would you like to do (add, get, cities, exit)? ");
						string prompt = Console.ReadLine();
						Console.WriteLine();
						switch (prompt)
						{
							case "add":
								Console.Write("Adding City - Enter a 5-digit US zipcode: ");
								string zipcode = Console.ReadLine();
								Console.WriteLine();
								addCity(zipcode);
								break;

							case "get":
								getWeather();
                                this.prompting = false;
								break;

							case "cities":
								getCities();
	                            this.prompting = false;
								break;

							case "exit":
								Console.WriteLine("Goodbye");
								Environment.Exit(0);
								break;

							default:
								Console.WriteLine("Invalid Input, Try Again.\n");
                                this.prompting = false;
								break;
						}
					}
				}
			}
		}

		private void initMessage()
		{
			Console.WriteLine("************************************************************");
			Console.WriteLine("Welcome To The Command Prompt Weather Serivce.");
			Console.WriteLine("************************************************************");
			Console.WriteLine();
			Console.WriteLine("To find the weather in your city, type in \"add\"");
			Console.WriteLine("This will prompt you to add a zipcode.");
			Console.WriteLine();
			Console.WriteLine("To fetch the weather for all your cities, type in \"get\"");
			Console.WriteLine();
			Console.WriteLine("To get your current list of cities, type in \"cities\"");
			Console.WriteLine();
		}

		private void addCity(string zipcode)
		{
			City newCity = new City(zipcode);
			if (newCity.fetchWeather())
			{
				cities.Add(newCity);
				Console.WriteLine(String.Format("\n{0} Succesfully Added!\n", newCity.getCity()));
			}
			else
			{
				Console.WriteLine("\nIncorrect Zipcode, Try Again.\n");
			}
			this.prompting = false;
		}

		private void getWeather()
		{
			Console.WriteLine("\nFetching Weather For Your Cities...");

			foreach (var city in cities)
			{
				Console.WriteLine(city.getWeather());
			}
			Console.WriteLine();
		}

		private void getCities()
		{
			Console.WriteLine("\nYour Cities: ");
			foreach (var city in cities)
			{
				Console.WriteLine(city.getCity());
			}
			Console.WriteLine();
		}
	}
}
