using System;
using System.Diagnostics;

namespace MyLogger
{
	public sealed class WriteToEventLog : ILogger
	{
		string MySource = "MyLogger Application";
		string MyLog = "MyLogger Application";

		private static readonly WriteToEventLog Instance = new WriteToEventLog();

		private WriteToEventLog()
		{
			if (!EventLog.SourceExists(MySource))
				EventLog.CreateEventSource(MySource, MyLog);
		}

		public static WriteToEventLog GetInstance
		{
			get
			{
				return Instance;
			}
		}


		public void LogTo(string LogName, string GetText)
		{
			string Text = $"{LogName}: {GetText}";
			try
			{
				EventLog.WriteEntry(MySource, Text);
			}
			catch (Exception e)
			{
				Console.WriteLine("Zapis do EventViewer nie powiódł się");
				Console.WriteLine(e.Message);
			}
			Console.WriteLine($"Dokonano wpisu do EventViewer/Applications and Services Logs: {MyLog}");
		}
	}
}
