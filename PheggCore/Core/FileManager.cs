using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PheggCore
{
	public static class FileManager
	{
		public static bool ReadFromFile(string path, out string toReturn)
		{
			if (File.Exists(path))
			{
				using (StreamReader sr = new StreamReader(path))
				{
					toReturn = sr.ReadToEnd();
				}

				return true;
			}
			else
			{
				toReturn = string.Empty;
				return false;
			}
		}
	}
}
