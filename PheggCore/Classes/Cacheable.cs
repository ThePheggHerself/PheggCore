using System;
using System.Collections.Generic;
using System.Text;

namespace PheggCore.Classes
{
	public class Cacheable
	{
		public Cacheable() { CreationTime = DateTime.Now; }

		public DateTime CreationTime { get; set; }
	}
}
