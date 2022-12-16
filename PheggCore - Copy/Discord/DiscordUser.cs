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
		public DiscordUser(JObject UserObject, JObject MemberObject, JObject BanObject)
		{
			_userObject = UserObject;
			_memberObject = MemberObject;
			_banObject = BanObject;
		}
		public DiscordUser(JObject UserObject, JObject MemberObject, JObject BanObject, StaffMember StaffObject)
		{
			_userObject = UserObject;
			_memberObject = MemberObject;
			_banObject = BanObject;
			StaffData = StaffObject; 
		}

		public string Username {
			get
			{
				return $"{_userObject["username"]}#{_userObject["discriminator"]}";
			}
		}
		public string UserID
		{
			get
			{
				return _userObject["id"].ToString();
			}
		}
		public bool IsStaff
		{
			get
			{
				return StaffData == null;
			}
		}
		public StaffMember StaffData { get; }
		public DateTime JoinedAt
		{
			get
			{
				return DateTime.Parse(_memberObject["joined_at"].ToString());
			}
		}
		public string Avatar
		{
			get
			{
				return $"https://cdn.discordapp.com/avatars/{UserID}/{_userObject["avatar"]}.png?size=1024";
			}
		}
		public bool IsBanned
		{
			get
			{
				return _banObject.ContainsKey("user");
			}
		}
		public bool IsDiscordMember
		{
			get
			{
				return _memberObject.ContainsKey("roles");
			}
		}

		private JObject _memberObject { get; }
		private JObject _userObject { get; }
		private JObject _banObject { get; }
	}
}
