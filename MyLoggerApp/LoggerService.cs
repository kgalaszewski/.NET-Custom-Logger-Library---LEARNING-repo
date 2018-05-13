using System;
using System.Collections.Generic;
using System.Threading;

namespace MyLogger
{
	public static class LoggerService
	{
		public static void RunLogger()
		{
			Console.WriteLine("\n\nPodaj nazwę wpisu, następnie treść wpisu");
			string GetLogName = Console.ReadLine();
			string GetText = Console.ReadLine();

			List<ILogger> LoggerInstances = new List<ILogger>()
			{WriteToEventLog.GetInstance,WriteToFile.GetInstance,WriteToRegistry.GetInstance};

			foreach (var Instance in LoggerInstances)
			{
				Instance.LogTo(GetLogName, GetText);
			}
			NewAction();
		}


		public static void NewAction()
		{
			Console.WriteLine("\n\nAby zapisać kolejny log (wciśnij 'Z')");
			Console.WriteLine("Aby wyświetlić wszystkie zapisane logi (wciśnij 'W')");
			char a = Console.ReadKey().KeyChar;

			if (a.Equals('z') || a.Equals('Z')) RunLogger();
			else if (a.Equals('w') || a.Equals('W')) WriteToFile.GetInstance.ReadFrom();
			else CloseLogger();
		}

		public static void CloseLogger()
		{
			Console.WriteLine(" Wybrano niepoprawną opcje");
			Thread.Sleep(1000);
			Environment.Exit(0);
		}
	}
}
