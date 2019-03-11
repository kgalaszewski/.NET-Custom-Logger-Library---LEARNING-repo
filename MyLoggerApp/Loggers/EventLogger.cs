using MyLoggerApp.Services;
using System;
using System.Diagnostics;

namespace MyLogger
{
	public sealed class EventLogger : ILogger
	{
		private string _mySource = "MyLogger Application";
		private string _myLog = "MyLogger Application";

		public EventLogger()
		{
			if (!EventLog.SourceExists(_mySource))
				EventLog.CreateEventSource(_mySource, _myLog);
		}

		public void LogMessage(string logName, string logContent)
		{
			string fullLogMessage = $"{logName}: {logContent}";

            HelperService.GetInstance().EnsureThatActionSucceed(() => 
            {
                EventLog.WriteEntry(_mySource, fullLogMessage);
                Console.WriteLine($"The message has been logged to an EventViewer/Applications and Services Logs: {_myLog}");
            }, null,"The message could not have been logged");
		}
	}
}
