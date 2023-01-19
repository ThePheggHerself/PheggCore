using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PheggCore.Staff
{
	public class StaffMember
	{
		public string Name { get; set; }
		public string UserID { get; set; }
		public WebsitePermissions WebsitePermissions { get; set; } = WebsitePermissions.None;
		public string Department { get; set; }
		public bool IsManagement { get; set; }
		public string Mentor { get; set; }
		public string ApiKey { get; set; }
		public bool IsFormer { get; set; } = false;
		public string SteamID { get; set; }

		public bool HasPerm(WebsitePermissions Perm)
		{
			return WebsitePermissions.HasFlag(Perm);
		}
	}
}
