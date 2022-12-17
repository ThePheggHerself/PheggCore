using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PheggCore.Website.API
{
	public class APIResponse
	{
		[JsonProperty("code")]
		public int Code { get; set; }
		[JsonProperty("response")]
		public string Response { get; set; }
	}
}
