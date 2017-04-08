using System;

namespace Weather
{
	class Forcast
	{
		public class DisplayLocation
		{
			public string full { get; set; }
		}

		public class CurrentObservation
		{
			public DisplayLocation display_location { get; set; }
			public string temperature_string { get; set; }
		}

		public class RootObject
		{
			public CurrentObservation current_observation { get; set; }
		}
	}
}
