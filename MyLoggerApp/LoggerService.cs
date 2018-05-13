using System;
using System.Collections.Generic;
using System.Threading;

namespace MyLogger
{
	public class LoggerService
	{
		public static void RunLogger()
		{
			Console.WriteLine("\n\nPodaj Nazwę/Id wpisu");
			string GetLogName = Console.ReadLine();
			Console.WriteLine("Podaj treść wpisu");
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
			try
			{
				Console.WriteLine("\n\nAby zapisać kolejny log (wciśnij 'Z') \n\nAby wyświetlić wszystkie zapisane logi (wciśnij 'W')");
				char a = char.ToLower(Console.ReadKey().KeyChar);
				switch (a)
				{
					case 'z': RunLogger(); break;
					case 'w': WriteToFile.GetInstance.ReadFrom(); break;
					default: CloseLogger(); break;
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}			
		}


		public static void CloseLogger()
		{
			Console.WriteLine(" Wybrano niepoprawną opcje");
			Thread.Sleep(1000);
			Environment.Exit(0);
		}
	}
}
