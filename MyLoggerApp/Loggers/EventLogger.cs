using System;
using System.Diagnostics;

namespace MyLogger
{
	public sealed class EventLogger : ILogger
	{
		private string mySource = "MyLogger Application";
		private string myLog = "MyLogger Application";

		public EventLogger()
		{
			if (!EventLog.SourceExists(mySource))
				EventLog.CreateEventSource(mySource, myLog);
		}

		


		public void LogTo(string getLogName, string getLogContent)
		{
			string completeLog = $"{getLogName}: {getLogContent}";

			try
			{
				EventLog.WriteEntry(mySource, completeLog);
			}
			catch (SystemException se)
			{
				Console.WriteLine("Nie masz wystarczajacych uprawnien");
				Console.WriteLine(se.Message);
			}
			catch (Exception e)
			{
				Console.WriteLine("Zapis do EventViewer nie powiódł się");
				Console.WriteLine(e.Message);
			}
			Console.WriteLine($"Dokonano wpisu do EventViewer/Applications and Services Logs: {myLog}");
		}
	}
}
