using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PheggCore.Website.API
{
	public class APIHeader
	{
		[JsonProperty("userid")]
		public string UserId { get; set; }
		[JsonProperty("key")]
		public string Key { get; set; }
	}
}
