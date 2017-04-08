using System;
using System.Collections.Generic;

namespace Weather
{
	class WeatherService
	{
		// List to store user's cities
		private List<City> cities;
		// Variable used to regulate prompt printing order 
		private bool prompting;

		public WeatherService()
		{
			this.cities = new List<City>();
			this.prompting = false;
			promptLoop();
		}

		// Loop to handle prompt method
		private void promptLoop()
		{
			initMessage();

			while (true)
			{
				if (!prompting)
				{
					prompt();
				}
			}
		}

		// Prompts for user input
		private void prompt()
		{
			this.prompting = true;
			// Add first city when List count is 0
			if (cities.Count == 0)
			{
				Console.Write("To begin, please enter a 5-digit US zipcode: ");
				string zipcode = Console.ReadLine();
				addCity(zipcode);
			}
			else
			{
				Console.Write("What would you like to do (add, weather, cities, exit)? ");
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

					case "weather":
						getWeather();
						break;

					case "cities":
						getCities();
						break;

					case "exit":
						Console.WriteLine("Goodbye");
						Environment.Exit(0);
						break;

					default:
						Console.WriteLine("Invalid Input, Try Again.\n");
						break;
				}

			}
			this.prompting = false;
		}

		// Initial application message
		private void initMessage()
		{
			Console.WriteLine("************************************************************");
			Console.WriteLine("Welcome To The Command Prompt Weather Service.");
			Console.WriteLine("************************************************************");
			Console.WriteLine();
			Console.WriteLine("To find the weather in your city, type in \"add\"");
			Console.WriteLine("This will prompt you to add a zipcode.");
			Console.WriteLine();
			Console.WriteLine("To fetch the weather for all your cities, type in \"weather\"");
			Console.WriteLine();
			Console.WriteLine("To get your current list of cities, type in \"cities\"");
			Console.WriteLine();
		}

		// Adds city to list
		private void addCity(string zipcode)
		{
			City newCity = new City(zipcode);
			// Checks if city is valid
			if (newCity.fetchWeather())
			{
				// Add city 
				cities.Add(newCity);
				Console.WriteLine(String.Format("\n{0} Succesfully Added!\n", newCity.getCity()));
			}
			else
			{
				Console.WriteLine("\nIncorrect Zipcode, Try Again.\n");
				// clean up newCity?
			}
		}

		// Loops through list and prints weather information
		private void getWeather()
		{
			Console.WriteLine("\nFetching Weather For Your Cities...");

			foreach (var city in cities)
			{
				Console.WriteLine(city.getWeather());
			}
			Console.WriteLine();
		}

		// Loops through List and prints all added city names
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
