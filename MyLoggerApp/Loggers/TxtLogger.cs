using System;
using System.IO;

namespace MyLogger
{
	public sealed class TxtLogger : ILogger
	{
		private string fileName = "FileMyLogger.txt";

		
		
		public void LogTo(string getLogName, string getLogContent)
		{
			try
			{
				using (StreamWriter thisTxtFile = new StreamWriter((fileName), true))
				{
					thisTxtFile.WriteLine($"{DateTime.Now}€{UserService.CurrentUser}€{getLogName}€{getLogContent}");
					thisTxtFile.Close();
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Nie udało się zapisać do pliku.txt");
				Console.WriteLine(e.Message);
			}			
			Console.WriteLine($"Zapisano do pliku MyLogger/bin/Debug{fileName}");
		}
		//UserService currentUserService = new UserService();
		////currentUserService.SetCurrentUser();

		/// <summary>
		/// Reading all logs from file, then injecting to LogReaderService List
		/// </summary>
		public void ReadLogsFromFile()
		{
			try
			{
				using (StreamReader thisTxtFile = new StreamReader(fileName))
				{
					string thisRow;
					LogReaderService logReaderService = new LogReaderService();

					while ((thisRow = thisTxtFile.ReadLine()) != null)
					{
						logReaderService.ListOfAllLines.Add(thisRow);
					}
					thisTxtFile.Close();
					logReaderService.RunReader();
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Odczyt logów nie powiódł się");
				Console.WriteLine(e.Message);
			}
			LoggerService.GetInstance.NewAction();
		}
	}
}
