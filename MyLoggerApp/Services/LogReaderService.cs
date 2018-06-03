using System;
using System.Collections.Generic;
using System.Threading;

namespace MyLogger
{
	class LogReaderService
	{
		public List<string> MyList = new List<string>();
		private List<string> AllLogsList = new List<string>();
		private List<string> UserLogsList = new List<string>();

		//-------------------------------------------------------------------------------------------------------------------------------------------------------------------

			/// <summary>
			/// After getting logs from file, asking user which logs should be read, then segregating them and displaying
			/// </summary>
		public void RunReader()
		{
			Console.WriteLine("Aby wyswietlic wszystkie logi, wybierz '1' \nAby wyswietlic tylko Twoje logi, wybierz '2'");
			char a = Console.ReadKey().KeyChar;

			switch (a)
			{
				case '1':
					AllLogs(); break;
				case '2':
					UserLogs(); break;
				default:
					Console.WriteLine("Niepoprawny wybor");
					Thread.Sleep(1000);
					break;
			}
			Console.ReadKey();
			LoggerService.GetInstance.NewAction();
		}

		//-------------------------------------------------------------------------------------------------------------------------------------------------------------------


		public void ReadList(List<string> ThisList)
		{
			foreach (var item in ThisList)
			{
				Console.WriteLine(item);
			}
		}

		//-------------------------------------------------------------------------------------------------------------------------------------------------------------------


		public void AllLogs()
		{
			Console.Clear();
			SplitLogs();
			ReadList(AllLogsList);
		}

		//-------------------------------------------------------------------------------------------------------------------------------------------------------------------

		public void UserLogs()
		{
			Console.Clear();
			SplitLogs();
			ReadList(UserLogsList);
		}

		//-------------------------------------------------------------------------------------------------------------------------------------------------------------------

			/// <summary>
			/// Segregating logs by User
			/// </summary>
		public void SplitLogs()
		{
			foreach (var item in MyList)
			{
				string singleRow;
				string[] SplitRow = item.Split('€');
				singleRow = $"Log uzytkownika {SplitRow[1]}\nData dodania: {SplitRow[0]}\nNazwa loga: {SplitRow[2]}\nTresc Loga: {SplitRow[3]}\n\n";
				AllLogsList.Add(singleRow);
				if (SplitRow[1].Equals(UserService.CurrentUser)) UserLogsList.Add(singleRow);
			}
		}
	}
}
