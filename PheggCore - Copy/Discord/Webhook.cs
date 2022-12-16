using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PheggCore.Discord
{
	public class Webhook
	{
		public string content;
		public string username;
		public string avatar_url;
		public bool tts = false;
		public DiscordEmbed[] embeds;

		public Webhook(string content, string username, string avatar_url, bool tts, DiscordEmbed[] embeds)
		{
			this.content = content;
			this.username = username;
			this.avatar_url = avatar_url;
			this.tts = tts;
			this.embeds = embeds;
		}
	}
}
