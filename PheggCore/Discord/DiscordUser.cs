using Newtonsoft.Json.Linq;
using PheggCore.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PheggCore.Discord
{
	public class DiscordUser
	{
		public string Username
		{
			get
			{
				if (LoggedIn)
					return $"{UserObject["username"]}#{UserObject["discriminator"]}";
				else return string.Empty;
			}
		}
		public string UserID
		{
			get
			{
				if (LoggedIn)
					return UserObject["id"].ToString();
				else return string.Empty;
			}
		}
		public bool IsStaff
		{
			get
			{
				return StaffData != null;
			}
		}

		public bool LoggedIn
		{
			get
			{
				return MemberObject != null;
			}
		}

		public DateTime JoinedAt
		{
			get
			{
				return DateTime.Parse(MemberObject["joined_at"].ToString());
			}
		}
		public string Avatar
		{
			get
			{
				return $"https://cdn.discordapp.com/avatars/{UserID}/{UserObject["avatar"]}.png?size=1024";
			}
		}
		public bool IsBanned
		{
			get
			{
				return BanObject.ContainsKey("user");
			}
		}
		public bool IsDiscordMember
		{
			get
			{
				return MemberObject.ContainsKey("roles");
			}
		}

		public JObject MemberObject { get; set; }
		public JObject UserObject { get; set; }
		public JObject BanObject { get; set; }
		public JObject TokenObject { get; set; }
		public List<JObject> RolesObject { get; set; }

		public StaffMember StaffData { get; set; }
	}
}
