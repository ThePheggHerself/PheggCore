using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PheggCore.Games
{
	public class PunishmentLog
	{
		public string Name { get; set; }
		public string UserId { get; set; }
		public string StaffId { get; set; }
		public string Offence { get; set; }
		public string Punishment { get; set; }
		public string Notes { get; set; }
		public string Region { get; set; }
		public long DateTime { get; set; }
		public long ID { get; set; }
	}
}
