using Newtonsoft.Json.Linq;
using PheggCore.Staff;
using System;
using System.Collections.Generic;
using System.Text;

namespace PheggCore
{
	public class PunishmentLog
	{
		public string Name { get; set; }
		public string UserId { get; set; }
		public string StaffName { get; set; }
		public string StaffId { get; set; }
		public string Offence { get; set; }
		public string Punishment { get; set; }
		public string Notes { get; set; }
		public string Region { get; set; }
		public long DateTime { get; set; }
		public long ID { get; set; }
	}
	public class DynamicTag
	{
		public DynamicTag(string userId, string tag, string colour, ulong perms = 0, string group = "", bool reservedSlot = false)
		{
			UserID = userId;
			ReservedSlot = reservedSlot;
			Tag = tag;
			Colour = colour;
			Perms = perms;
			Group = group;
		}

		public bool ReservedSlot { get; set; }
		public string UserID { get; set; }
		public string Tag { get; set; }
		public string Colour { get; set; }
		public ulong Perms { get; set; }
		public string Group { get; set; }
	}
}
