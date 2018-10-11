using System;
using System.Collections.Generic;
using System.Threading;

namespace MyLogger
{
	class LogReaderService
	{
		public List<string> ListOfAllLines = new List<string>();
		private List<string> listOfAllLogs = new List<string>();
		private List<string> listOfLogsSelectedByUser = new List<string>();

		//UserService currentUserService = new UserService();
		////currentUserService.SetCurrentUser();
		/// <summary>
		/// After getting logs from file, asking user which logs should be read, then segregating them and displaying
		/// </summary>
		public void RunReader()
		{
			Console.WriteLine("Aby wyswietlic wszystkie logi, wybierz '1' \nAby wyswietlic tylko Twoje logi, wybierz '2'");
			char decision = Console.ReadKey().KeyChar;

			switch (decision)
			{
				case '1':
					ReadAllLogs(); break;
				case '2':
					ReadCurrentUserLogs(); break;
				default:
					Console.WriteLine("Niepoprawny wybor");
					Thread.Sleep(1000);
					break;
			}
			Console.ReadKey();
			LoggerService.GetInstance.NewAction();
		}

		


		public void DisplayLogs(List<string> thisList)
		{
			foreach (var log in thisList)
			{
				Console.WriteLine(log);
			}
		}

		


		public void ReadAllLogs()
		{
			Console.Clear();
			SplitAndSegregateLogs();
			DisplayLogs(listOfAllLogs);
		}

		

		public void ReadCurrentUserLogs()
		{
			Console.Clear();
			SplitAndSegregateLogs();
			DisplayLogs(listOfLogsSelectedByUser);
		}



		/// <summary>
		/// Segregating logs and selecting by CurrentUser
		/// </summary>
		public void SplitAndSegregateLogs()
		{
			foreach (var thisLine in ListOfAllLines)
			{
				string currentLog;
				string[] SplittedLines = thisLine.Split('€');
				currentLog = $"Log uzytkownika {SplittedLines[1]}\nData dodania: {SplittedLines[0]}\nNazwa logu: {SplittedLines[2]}\nTresc logu: {SplittedLines[3]}\n\n";
				listOfAllLogs.Add(currentLog);
				if (SplittedLines[1].Equals(UserService.CurrentUser)) listOfLogsSelectedByUser.Add(currentLog);
			}
		}
	}
}
