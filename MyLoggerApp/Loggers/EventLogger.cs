using MyLoggerApp.Loggers;
using MyLoggerApp.Services;
using System;

namespace MyLogger
{
	public sealed class EventLogger : IMyLogger
	{
		private string _mySource = "MyLogger Application";
		private string _myLog = "MyLogger Application";
        private IEventLogService _eventLogService;

        public EventLogger(IEventLogService eventLogService = null)
		{
            _eventLogService = eventLogService ?? new EventLogService();
            _eventLogService.CheckIfSourceExists(_mySource, _myLog);
		}

		public void LogMessage(string logName, string logContent)
		{
            if (!string.IsNullOrWhiteSpace(logName) && !string.IsNullOrWhiteSpace(logContent))
            {
                string fullLogMessage = $"{logName}: {logContent}";

                HelperService.GetInstance().EnsureThatActionSucceed(() =>
                {
                    _eventLogService.WriteToEventLog(_mySource, fullLogMessage);
                    Console.WriteLine($"The message has been logged to an EventViewer/Applications and Services Logs: {_myLog}");
                }, null, "The message could not have been logged");
            }	
            else
                HelperService.GetInstance().DisplayEmptyLogParametersAlert("logName", "logContent");
        }
	}
}
