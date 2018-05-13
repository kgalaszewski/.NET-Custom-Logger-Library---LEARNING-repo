using System;
using System.IO;

namespace MyLogger
{
	public sealed class WriteToFile : ILogger
	{
		private string FileName = "FileMyLogger.txt";

		private static readonly WriteToFile Instance = new WriteToFile();

		private WriteToFile() { }

		public static WriteToFile GetInstance
		{
			get
			{
				return Instance;
			}
		}


		public void LogTo(string GetLogName, string GetText)
		{
			try
			{
				using (StreamWriter File = new StreamWriter((FileName), true))
				{
					File.WriteLine($"{GetLogName}: {GetText}");
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Nie udało się zapisać do pliku.txt");
				Console.WriteLine(e.Message);
			}
			Console.WriteLine($"Zapisano do pliku MyLogger/bin/Debug{FileName}");
		}


		public void ReadFrom()
		{
			Console.WriteLine("\n\nWszystkie logi aplikacji MyLogger:");
			try
			{
				using (StreamReader File = new StreamReader(FileName))
				{
					String line;
					while ((line = File.ReadLine()) != null)
					{
						Console.WriteLine(line);
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Odczyt logów nie powiódł się");
				Console.WriteLine(e.Message);
			}
			LoggerService.NewAction();
		}
	}
}
