using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PheggCore.Community
{
	public class CommunityAppeal
	{
		public CommunityAppeal(string DiscordId, string steamId, string reasonForBan, string reasonForAppeal)
		{
			this.DiscordId = DiscordId;
			SteamId = steamId;
			ReasonForBan = reasonForBan;
			ReasonForAppeal = reasonForAppeal;

			LastSent = DateTime.Now;

			AppealID = new Guid().ToString();
		}

		public string DiscordId;
		public string SteamId;
		public string ReasonForBan;
		public string ReasonForAppeal;
		public DateTime LastSent;
		public string AppealID;
	}
}
