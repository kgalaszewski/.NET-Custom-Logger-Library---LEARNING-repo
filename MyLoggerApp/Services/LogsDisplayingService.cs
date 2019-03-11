using MyLoggerApp.Services;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MyLogger
{
	class LogsDisplayingService
	{
		public List<string> AllLogsCollection = new List<string>();
		private List<string> _allLogsPrepared = new List<string>();
		private List<string> _currentUserLogsPrepared = new List<string>();

        private enum UserChoice
        {
            AllLogs,
            CurrentUserLogs
        }

        // Public methods ----------------------------------------------------------------------------------------------------------------------------------

        public void ProcessAndDisplayTheReadLogs()
		{
			Console.WriteLine("To display all logs, press '1' \nATo display only your logs, press '2'");
			char decision = Console.ReadKey().KeyChar;

			switch (decision)
			{
				case '1':
					displayLogs(UserChoice.AllLogs);
                    break;
				case '2':
                    displayLogs(UserChoice.CurrentUserLogs);
                    break;
				default:
                    HelperService.GetInstance().ClearConsoleAndWriteMessage("Incorrect choice");
					Thread.Sleep(1000);
					break;
			}

			Console.ReadKey();
			LoggerService.GetInstance().ChooseNewAction();
		}

        // Private methods ----------------------------------------------------------------------------------------------------------------------------------
        
        private void displayTheLogsInConsole(List<string> thisList)
		{
            thisList.ForEach(x => Console.WriteLine(x));
		}

		private void displayLogs(UserChoice choice)
		{
			Console.Clear();
			splitAndPrepareTheLogs();

            if (choice == UserChoice.AllLogs)
                displayTheLogsInConsole(_allLogsPrepared);
            else
                displayTheLogsInConsole(_currentUserLogsPrepared);
        }

        private void splitAndPrepareTheLogs()
		{
			foreach (var log in AllLogsCollection)
			{
				string preparedMessage;
				string[] splittedLog = log.Split('€');
				preparedMessage = $"Log uzytkownika {splittedLog[1]}\nData dodania: {splittedLog[0]}\nNazwa logu: {splittedLog[2]}\nTresc logu: {splittedLog[3]}\n\n";
				_allLogsPrepared.Add(preparedMessage);
				if (splittedLog[1].Equals(UserService.CurrentUserName)) _currentUserLogsPrepared.Add(preparedMessage);
			}
		}
	}
}
