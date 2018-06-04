using System;
using System.Linq;
using System.Threading;

namespace MyLogger
{
	public sealed class LoggerService
	{
		private static readonly LoggerService Instance = new LoggerService();

		private LoggerService()	{ }

		public static LoggerService GetInstance
		{
			get { return Instance; }
		}
				
		
		LoggerFactoryProvider loggerFactoryProvider = new LoggerFactoryProvider();


		/// <summary>
		/// Asking user where to log, then creating Loggers with factory
		/// </summary>
		public void RunLogger()
		{
			Console.Clear();
			Console.WriteLine("Gdzie chcesz dokonac wpisu: \nRegistry && EventViewer && File.txt -> wybierz '3' \nFile.txt -> wybierz '1'");
			char logDestination = char.ToLower(Console.ReadKey().KeyChar);

			if (logDestination.Equals('1') || logDestination.Equals('3'))
			{
				Console.Clear();
				Console.WriteLine("Podaj Nazwę/Id wpisu");
				string getLogName = Console.ReadLine();
				Console.WriteLine("Podaj treść wpisu");
				string getLogContent = Console.ReadLine();

				try
				{
					switch (logDestination)
					{
						case '1':
							LogToFile(getLogName, getLogContent);
							break;
						case '3':
							LogToAllDestinations(getLogName, getLogContent);
							break;
						default:
							Console.WriteLine($"Niepoprawny wybor (dostepne opcje: 1 oraz 3)");
							break;
					}
					Console.ReadKey();
					NewAction();
				}
				catch (Exception e)
				{
					Console.WriteLine("Nie udalo sie uruchomic Loggera");
					Console.WriteLine(e.Message);
				}
			}
			else
			{
				Console.Clear();
				Console.WriteLine("Nie ma takiej opcji");
				Thread.Sleep(1000);
				NewAction();
			}
				
		}

		


		public static void ChangeCurrentUser()
		{
			UserService newUserService = new UserService();
			newUserService.SetCurrentUser();
		}


		

		public void LogToFile(string getLogName, string getText)
		{
			LoggerFactory fileFactory = loggerFactoryProvider.LoggerFactoryList.Where(z => z is TxtLoggerFactory).Select(x => x as TxtLoggerFactory).FirstOrDefault();
			ILogger fileLogger = fileFactory.CreateLogger();
			fileLogger.LogTo(getLogName,getText);
		}




		public void LogToAllDestinations(string getLogName, string getText)
		{
			foreach (var factory in loggerFactoryProvider.LoggerFactoryList)
			{
				ILogger thisLogger = factory.CreateLogger();
				thisLogger.LogTo(getLogName, getText);
			}
		}

		


		public void NewAction()
		{
			try
			{
				Console.Clear();
				Console.WriteLine("Aby zapisać log (wciśnij 'Z') \n\nAby wyświetlić zapisane logi (wciśnij 'W') " +
					"\n\nAby zmienic nazwe uzytkownika (wcisnij 'C') \n\nAby zamknac MyLoggerApp (wciśnij 'X')");
				char newDecision = char.ToLower(Console.ReadKey().KeyChar);
				Console.Clear();
				switch (newDecision)
				{
					case 'x': CloseLogger(); break;
					case 'c': ChangeCurrentUser(); break;
					case 'z': RunLogger(); break;
					case 'w':
						TxtLogger txtLogger = new TxtLogger();
						txtLogger.ReadLogsFromFile(); break;
					default: NewAction(); break;
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}

		


		public void CloseLogger()
		{
			Console.Clear();
			Console.WriteLine("WYBRANO OPCJE - ZAKONCZ PROGRAM");
			Thread.Sleep(1000);
			Environment.Exit(0);
		}

	}
}
