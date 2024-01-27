using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static PheggCore.Logger;

namespace PheggCore
{
	public static class Logger
	{
		public static string LogFileName { get; set; }

		public static string DateTimeFormat { get; private set; }

		internal class msgObject
		{
			internal msgObject(string msg, MessageSeverity severity)
			{
				this.msg = msg;
				this.severity = severity;
			}
			public string msg;
			public MessageSeverity severity;
		}
		public enum MessageSeverity
		{
			Debug, Info, Warning, Error
		}

		internal static List<msgObject> _msgs = new List<msgObject>();

		public static bool Debug = false;

		static Logger()
		{
			DateTimeFormat = $"{CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern} {CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern}";
			PrintMessages();
		}

		public static void Write(string message, MessageSeverity severity = MessageSeverity.Info) => _msgs.Add(new msgObject(message, severity));

		private static async void PrintMessages()
		{
			while (true)
			{
				if (_msgs.Count > 0)
				{
					var msg = _msgs[0];
					switch (msg.severity)
					{
						case MessageSeverity.Warning:
							Console.ForegroundColor = ConsoleColor.Yellow;
							break;
						case MessageSeverity.Error:
							Console.ForegroundColor = ConsoleColor.Red;
							break;
						case MessageSeverity.Debug:
							Console.ForegroundColor = ConsoleColor.Blue;
							break;
						default:
							break;
					}

					if (msg.severity != MessageSeverity.Debug || (msg.severity == MessageSeverity.Debug & Debug))
					{
						var msgSTr = string.Format("[{0}] {1} | {2}", DateTime.Now.ToString(DateTimeFormat), msg.severity.ToString().ToUpper(), msg.msg);

						if (string.IsNullOrEmpty(LogFileName))
						{
							if (!Directory.Exists("./Logs/"))
							{
								Directory.CreateDirectory("./Logs");
							}

							Logger.LogFileName = $"./Logs/{Assembly.GetEntryAssembly().GetName().Name}-{DateTime.Now.ToString("yyyy-MM-dd HH:mm")}.log";
						}

						if (!File.Exists(LogFileName))
							File.WriteAllText(LogFileName, msgSTr + Environment.NewLine);
						else
							File.AppendAllText(LogFileName, msgSTr + Environment.NewLine);

						Console.WriteLine(msgSTr);
						Console.ResetColor();
					}

					_msgs.Remove(msg);
				}

				await Task.Delay(100);
			}
		}
	}

	internal class _threadLogger
	{
		internal static List<msgObject> _msgs = new List<msgObject>();


	}
}
