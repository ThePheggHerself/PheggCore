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

		internal class MessageObject
		{
			internal MessageObject(string msg, string prefix, MessageSeverity severity = MessageSeverity.Info)
			{
				Message = msg;
				Prefix = prefix;
				Severity = severity;
			}
			public string Message;
			public string Prefix;
			public MessageSeverity Severity;

		}
		public enum MessageSeverity
		{
			Debug, Info, Warn, Error
		}

		internal static List<MessageObject> _msgs = new List<MessageObject>();

		public static bool DebugMode = false;

		static Logger()
		{
			DateTimeFormat = $"yyyy-MM-dd HH:mm:ss";
			PrintMessages();
		}

		[Obsolete]
		public static void Write(string message, MessageSeverity severity = MessageSeverity.Info) => _msgs.Add(new MessageObject(message, severity.ToString(), severity));

		public static void Info(string message, string prefix = null)
		{
			if (string.IsNullOrEmpty(prefix))
				prefix = MessageSeverity.Info.ToString();
			_msgs.Add(new MessageObject(message, prefix, MessageSeverity.Info));
		}
		public static void Warn(string message, string prefix = null)
		{
			if (string.IsNullOrEmpty(prefix))
				prefix = MessageSeverity.Warn.ToString();
			_msgs.Add(new MessageObject(message, prefix, MessageSeverity.Warn));
		}
		public static void Error(string message, string prefix = null)
		{
			if (string.IsNullOrEmpty(prefix))
				prefix = MessageSeverity.Error.ToString();
			_msgs.Add(new MessageObject(message, prefix, MessageSeverity.Error));
		}
		public static void Debug(string message, string prefix = null)
		{
			if (string.IsNullOrEmpty(prefix))
				prefix = MessageSeverity.Debug.ToString();
			_msgs.Add(new MessageObject(message, prefix, MessageSeverity.Debug));
		}

		private static async void PrintMessages()
		{
			while (true)
			{
				if (_msgs.Count > 0)
				{
					var msg = _msgs[0];
					switch (msg.Severity)
					{
						case MessageSeverity.Warn:
							Console.ForegroundColor = ConsoleColor.Yellow;
							break;
						case MessageSeverity.Error:
							Console.ForegroundColor = ConsoleColor.Red;
							break;
						case MessageSeverity.Debug:
							Console.ForegroundColor = ConsoleColor.Cyan;
							break;
						default:
							break;
					}

					if (msg.Severity != MessageSeverity.Debug || (msg.Severity == MessageSeverity.Debug & DebugMode))
					{
						var msgSTr = string.Format("[{0}] {1} | {2}", DateTime.Now.ToString(DateTimeFormat), msg.Severity.ToString().ToUpper(), msg.Message);

						if (string.IsNullOrEmpty(LogFileName))
						{
							if (!Directory.Exists("./Logs/"))
							{
								Directory.CreateDirectory("./Logs");
							}

							Logger.LogFileName = $"./Logs/{Assembly.GetEntryAssembly().GetName().Name}-{DateTime.Now.ToString("yyyy-MM-dd HH-mm")}.log";
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
		internal static List<MessageObject> _msgs = new List<MessageObject>();


	}
}
