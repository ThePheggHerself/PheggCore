using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PheggCore.Staff
{
	public class Application
	{
		public Application(string username, string userid, string steamid, int age, int hours, string whyjoin, string whatbring, string prevexp, string department)
		{
			Username = username;
			UserId = userid;
			SteamId = steamid;
			Age = age;
			Hours = hours;
			WhyJoin = whyjoin;
			WhatBring = whatbring;
			PrevExp = prevexp;
			Department = department;
			LastSent = DateTime.Now;
			AppId = Guid.NewGuid().ToString();
		}

		public Application(string username, string userid, string steamid, int age, int hours, string whyjoin, string whatbring, string prevexp, string department, string appId)
		{
			Username = username;
			UserId = userid;
			SteamId = steamid;
			Age = age;
			Hours = hours;
			WhyJoin = whyjoin;
			WhatBring = whatbring;
			PrevExp = prevexp;
			Department = department;
			LastSent = DateTime.Now;
			AppId = appId;
		}


		public Application(DataRow row)
		{
			Username = row["Username"].ToString();
			UserId = row["DiscordID"].ToString();
			SteamId = row["SteamID"].ToString();
			Age = int.TryParse(row["Age"].ToString(), out int age) ? age : 10;
			Hours = int.TryParse(row["Hours"].ToString(), out int hours) ? hours : 25;
			WhyJoin = row["WhyJoin"].ToString();
			WhatBring = row["WhatBring"].ToString();
			PrevExp = row["PreviousExperience"].ToString();
			Department = row["Department"].ToString();
			LastSent = new DateTime(long.Parse(row["LastSent"].ToString()));
			AppId = row["Id"].ToString();
		}

		[JsonConstructor]
		public Application() { }

		public string Username { get; set; }
		public string UserId { get; set; }
		public string SteamId { get; set; }
		public string Department { get; set; }
		public string WhyJoin { get; set; }
		public string WhatBring { get; set; }
		public string PrevExp { get; set; }
		public string AppId { get; set; }

		public int Age { get; set; }
		public int Hours { get; set; }

		public DateTime LastSent { get; set; }
	}

	public class ApplicationResponse
	{
		public ApplicationResponse(bool pending, string response, DateTime submitDate)
		{
			Pending = pending;
			Response = response;
			SubmitDate = submitDate;
		}

		[JsonConstructor]
		public ApplicationResponse() { }
		public bool Pending { get; set; }
		public string Response { get; set; }
		public DateTime SubmitDate { get; set; }

	}
}
