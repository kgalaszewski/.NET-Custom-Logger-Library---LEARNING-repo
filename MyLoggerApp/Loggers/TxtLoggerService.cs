using MyLogger;
using System;
using System.IO;

namespace MyLoggerApp.Loggers
{
    class TxtLoggerService : ITxtLoggerService
    {
        public void WriteToFile(string _fileName, string logName, string logContent)
        {
            using (StreamWriter streamWriter = new StreamWriter((_fileName), true))
            {
                streamWriter.WriteLine($"{DateTime.Now}€{UserService.CurrentUserName}€{logName}€{logContent}");
                streamWriter.Close();
            }
        }

        public void DisplayAllSavedLogs(string _fileName)
        {
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
        }
    }
}
