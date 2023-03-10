using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PheggCore
{
	public static class Core
	{
		public static void SetStrings(string playerStats, string website)
		{
			if (string.IsNullOrEmpty(PlayerStatsConnectionString) || string.IsNullOrEmpty(WebsiteConnectionString))
			{
				PlayerStatsConnectionString = playerStats;
				WebsiteConnectionString = website;
			}
			else
			{
				throw new Exception("Connection strings must only be set once");
			}
		}

		public static string PlayerStatsConnectionString { get; private set; }
		public static string WebsiteConnectionString { get; private set; }

		public static string ApiUrl { get; set; }
		public static bool Debug { get; set; }
	}
}
