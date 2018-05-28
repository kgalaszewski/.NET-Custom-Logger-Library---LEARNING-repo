using System;
using System.IO;

namespace MyLogger
{
	public sealed class TxtLogger : ILogger
	{
		private string FileName = "FileMyLogger.txt";

		//-------------------------------------------------------------------------------------------------------------------------------------------------------------------

		public void LogTo(string GetLogName, string GetText)
		{
			try
			{
				using (StreamWriter File = new StreamWriter((FileName), true))
				{
					File.WriteLine($"{DateTime.Now}€{UserService.CurrentUser}€{GetLogName}€{GetText}");
					File.Close();
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Nie udało się zapisać do pliku.txt");
				Console.WriteLine(e.Message);
			}			
			Console.WriteLine($"Zapisano do pliku MyLogger/bin/Debug{FileName}");
		}

		//-------------------------------------------------------------------------------------------------------------------------------------------------------------------

		public void ReadFrom()
		{
			try
			{
				using (StreamReader File = new StreamReader(FileName))
				{
					String line;
					LogReaderService logReaderService = new LogReaderService();

					while ((line = File.ReadLine()) != null)
					{
						logReaderService.MyList.Add(line);
					}
					File.Close();
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
