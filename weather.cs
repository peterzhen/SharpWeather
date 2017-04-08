using System;
using System.IO;
using System.Net;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace Weather
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			string city = "San_Francisco";
			string state = "CA";
			string apiKey = "3cdcff508836ddfe";
			string URL = String.Format(
				"http://api.wunderground.com/api/{0}/conditions/q/{1}/{2}.json",
				apiKey,
				state,
				city);
			
			WeatherService service = new WeatherService();
			Console.WriteLine("HTTP REQUEST URL: " + URL);

			// Create a request for the URL. 		
			WebRequest request = WebRequest.Create(URL);
            
			// Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

			// Display the status.
			Console.WriteLine (response.StatusDescription);

            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
			// Open the stream using a StreamReader for easy access.
			StreamReader reader = new StreamReader(dataStream);
			// Read the content.
			string responseFromServer = reader.ReadToEnd();

			var forcast = JsonConvert.DeserializeObject<Forcast.RootObject>(responseFromServer);
			//Console.WriteLine(values);
			// Display the content.
            // Cleanup the streams and the response.
            reader.Close ();
            dataStream.Close ();
            response.Close ();
		}
	}
}
