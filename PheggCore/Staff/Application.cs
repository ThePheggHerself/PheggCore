using System;
using System.Collections.Generic;
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
			AppId = new Guid().ToString();
		}

		public string Username;
		public string UserId;
		public string SteamId;
		public string Department;
		public string WhyJoin;
		public string WhatBring;
		public string PrevExp;
		public string AppId;

		public int Age;
		public int Hours;

		public DateTime LastSent;		
	}

	public class ApplicationResponse
	{
		public ApplicationResponse(bool pending, string response, DateTime submitDate)
		{
			Pending = pending;
			Response = response;
			SubmitDate = submitDate;
		}

		public bool Pending;
		public string Response;
		public DateTime SubmitDate;

	}
}
