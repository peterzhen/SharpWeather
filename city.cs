using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace Weather
{
	class City
	{
		private string zipcode;
		private string cityName;
		private string degrees;
		private const string apiKey = "3cdcff508836ddfe";

		public City(string zipcode)
		{
			this.zipcode = zipcode;
			this.cityName = "";
			this.degrees = "";

		}

		// Requests weather from API
		public bool fetchWeather()
		{
			string URL = String.Format(
				"http://api.wunderground.com/api/{0}/conditions/q/{1}.json",
				apiKey,
				this.zipcode);

			// Create a request for the URL	
			WebRequest request = WebRequest.Create(URL);

			// Get the response
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();

			// Check response status
			if (response.StatusDescription.Equals("OK"))
			{
				// Get the stream containing content returned by the server.
				Stream dataStream = response.GetResponseStream();
				// Open the stream using a StreamReader for easy access.
				StreamReader reader = new StreamReader(dataStream);
				// Read the content.
				string responseFromServer = reader.ReadToEnd();

				var forcast = JsonConvert.DeserializeObject<Forcast.RootObject>(responseFromServer);

				try
				{
					this.cityName = forcast.current_observation.display_location.full;
					this.degrees = forcast.current_observation.temperature_string;
				}
				catch
				{
					return false;
				}


				// Cleanup the streams and the response.
	            reader.Close();
	            dataStream.Close();
				response.Close();
				return true;
			}
			else
			{
				return false;
			}
		}
      
		// Returns a string with weather information
        public string getWeather()
		{
			return (String.Format("{0} - {1}", this.cityName, this.degrees));
		}

		// Returns a string with city name
		public string getCity()
		{
			return "City Name: " + this.cityName;
		}
	}
}
