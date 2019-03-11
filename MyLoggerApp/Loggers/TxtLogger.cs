using MyLoggerApp.Services;
using System;
using System.IO;

namespace MyLogger
{
	public sealed class TxtLogger : ILogger
	{
		private string _fileName = "FileMyLogger.txt";		
		
		public void LogMessage(string logName, string logContent)
		{
            HelperService.GetInstance().EnsureThatActionSucceed(() => {
                using (StreamWriter streamWriter = new StreamWriter((_fileName), true))
                {
                    streamWriter.WriteLine($"{DateTime.Now}€{UserService.CurrentUserName}€{logName}€{logContent}");
                    streamWriter.Close();
                }
                Console.WriteLine($"The message have been logged to MyLogger/bin/Debug{_fileName}");
            }, "The message could not have been logged to file.txt");			
		}

		public void DisplayAllLogsSavedSoFar()
		{
            HelperService.GetInstance().EnsureThatActionSucceed(() => {
                using (StreamReader streamReader = new StreamReader(_fileName))
                {
                    string thisRow;
                    LogsDisplayingService logReaderService = new LogsDisplayingService();

                    while ((thisRow = streamReader.ReadLine()) != null)
                    {
                        logReaderService.AllLogsCollection.Add(thisRow);
                    }

                    streamReader.Close();
                    logReaderService.ProcessAndDisplayTheReadLogs();
                    LoggerService.GetInstance().ChooseNewAction();
                }
            }, "Could not get all logs saved so far");
		}
	}
}
