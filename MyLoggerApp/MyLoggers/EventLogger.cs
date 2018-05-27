using System;
using System.Diagnostics;

namespace MyLogger
{
	public sealed class EventLogger : ILogger
	{
		private string MySource = "MyLogger Application";
		private string MyLog = "MyLogger Application";

		public EventLogger()
		{
			if (!EventLog.SourceExists(MySource))
				EventLog.CreateEventSource(MySource, MyLog);
		}

		//-------------------------------------------------------------------------------------------------------------------------------------------------------------------

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
