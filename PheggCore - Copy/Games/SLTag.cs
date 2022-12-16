using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PheggCore.Games
{
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
