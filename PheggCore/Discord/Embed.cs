using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PheggCore.Discord
{
	public class DiscordEmbed
	{
		public string title;
		public string type = "rich";
		public string description;
		public string url;
		public string timestamp;
		public int color;

		public EmbedThumbnail thumbnail;
		public EmbedFooter footer;
		public List<EmbedField> fields;
		public EmbedAuthor author;


	}

	public class EmbedFooter
	{
		public EmbedFooter(string Text, string IconURL = "", string ProxyIconURL = "")
		{
			text = Text;
			icon_url = IconURL;
			proxy_icon_url = ProxyIconURL;
		}

		public string text;
		public string icon_url;
		public string proxy_icon_url;
	}
	public class EmbedField
	{
		public EmbedField(string Name, string Value, bool InLine = false)
		{
			name = Name;
			value = Value;
			inline = InLine;
		}

		public string name;
		public string value;
		public bool inline;
	}
	public class EmbedAuthor
	{
		public EmbedAuthor(string Name, string URL = "", string IconURL = "", string ProxyIconURL = "")
		{
			name = Name;
			url = URL;
			icon_url = IconURL;
			proxy_icon_url = ProxyIconURL;
		}

		public string name;
		public string url;
		public string icon_url;
		public string proxy_icon_url;
	}
	public class EmbedThumbnail
	{
		public EmbedThumbnail(string URL, int Height = 1024, int Width = 1024)
		{
			url = URL;
			height = Height;
			width = Width;
		}

		public string url;
		public int height;
		public int width;
	}
}
