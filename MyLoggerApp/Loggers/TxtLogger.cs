using MyLoggerApp.Loggers;
using MyLoggerApp.Services;
using System;

namespace MyLogger
{
    public sealed class TxtLogger : IMyLogger
    {
        private const string _fileName = "FileMyLogger.txt";
        private ITxtLoggerService _txtService;

        public TxtLogger(ITxtLoggerService service = null)
        {
            _txtService = service ?? new TxtLoggerService();
        }

        public void LogMessage(string logName, string logContent)
        {
            if (!string.IsNullOrWhiteSpace(logName) && !string.IsNullOrWhiteSpace(logContent))
            {
                string fullLogMessage = $"{logName}: {logContent}";

                HelperService.GetInstance().EnsureThatActionSucceed(() =>
                {
                    _txtService.WriteToFile(_fileName, logName, logContent);
                    Console.WriteLine($"The message has been logged to MyLogger/bin/Debug{_fileName}");
                }, null, "The message could not have been logged to file.txt");
            }
            else
                HelperService.GetInstance().DisplayEmptyLogParametersAlert("logName", "logContent");
        }

        public void DisplayAllLogsSavedSoFar()
        {
            HelperService.GetInstance().EnsureThatActionSucceed(() =>
            {
                _txtService.DisplayAllSavedLogs(_fileName);
            }, null, "Could not get all logs saved so far");
        }
    }
}
