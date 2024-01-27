using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace PheggCore.Website
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

	public class APIHeader
	{
		[JsonProperty("userid")]
		public string UserId { get; set; }
		[JsonProperty("key")]
		public string Key { get; set; }
	}

	public enum WebsitePermissions
	{
		None = 0,
		ViewApplications = 1 << 1,
		ViewAppeals = 1 << 2,
		ViewSurvey = 1 << 3,
		RequestSurvey = 1 << 4,
		DeletePunishments = 1 << 5,
		DeletePunishmentsOfOthers = 1 << 6,
		EditPunishments = 1 << 7,
		EditPunishmentsOfOthers = 1 << 8,
		UserNote = 1 << 9,
		ViewPunishments = 1 << 10,
		AddNewsletter = 1 << 11,
		DelNewsletter = 1 << 12,
	}
}
