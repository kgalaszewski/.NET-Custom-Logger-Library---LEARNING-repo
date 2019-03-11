using MyLoggerApp.LoggersFactory;
using MyLoggerApp.Services;
using System;
using System.Threading;

namespace MyLogger
{
    public sealed class LoggerService
	{
		private static readonly LoggerService _Instance = new LoggerService();

		private LoggerService()	{ }

		public static LoggerService GetInstance()
		{
			return _Instance;
		}
        
        // Public methods ----------------------------------------------------------------------------------------------------------------------------------

        public void StartLoggerLogic()
		{
            HelperService.GetInstance().ClearConsoleAndWriteMessage("Where do you want to log your message : \n3 destinations : Registry, EventViewer and File.txt -> press '3' \nOnly to File.txt -> press '1'");
            char logDestination = char.ToLower(Console.ReadKey().KeyChar);

			if (logDestination.Equals('1') || logDestination.Equals('3'))
			{
                HelperService.GetInstance().ClearConsoleAndWriteMessage("Please, type the name/ID of your message");
                string givenLogName = Console.ReadLine();
                HelperService.GetInstance().ClearConsoleAndWriteMessage("Please, type your message");
				string givenContent = Console.ReadLine();

                HelperService.GetInstance().EnsureThatActionSucceed(() => {
                    if (logDestination.Equals('1'))
                        logToFile(givenLogName, givenContent);
                    else
                        logToAllDestinations(givenLogName, givenContent);

                    Console.ReadKey();
                    ChooseNewAction();
                }, "Could not run logger properly");
			}
			else
			{
                HelperService.GetInstance().ClearConsoleAndWriteMessage("Incorret choice");
                Thread.Sleep(1000);
				ChooseNewAction();
			}				
		}

        public void ChooseNewAction()
        {
            try
            {
                HelperService.GetInstance().ClearConsoleAndWriteMessage("To save your logs (press 'Z') \n\nTo display all the saved logs (press 'W') " +
                    "\n\nTo change your NickName (press 'C') \n\nTo Close MyLoggerApp (press 'X')");

                startNewAction(char.ToLower(Console.ReadKey().KeyChar));
            }
            catch (Exception e)
            {
                HelperService.GetInstance().ClearConsoleAndWriteMessage($"Could not proceed this action due to {e.Message}");
            }
        }

        // Private methods ----------------------------------------------------------------------------------------------------------------------------------

        private void startNewAction(char userDecision)
        {
            switch (userDecision)
            {
                case 'x': closeLogger(); break;
                case 'c': changeCurrentUser(); break;
                case 'z': StartLoggerLogic(); break;
                case 'w':
                    TxtLogger txtLogger = new TxtLogger();
                    txtLogger.DisplayAllLogsSavedSoFar(); break;
                default: ChooseNewAction(); break;
            }
            Console.Clear();
        }

        private static void changeCurrentUser()
		{
            UserService.GetInstance().CreateNewUser();
		}		

		private void logToFile(string getLogName, string getText)
		{
            LoggerFactory fileFactory = LoggerFactoryProvider.GetLoggerFactory(LoggerTypes.TxtLogger);
			ILogger fileLogger = fileFactory.CreateLogger();
			fileLogger.LogMessage(getLogName,getText);
		}

		private void logToAllDestinations(string getLogName, string getText)
		{
			foreach (var loggerFactory in LoggerFactoryProvider.GetAllLoggerFactories())
			{
				ILogger currentLogger = loggerFactory.CreateLogger();
				currentLogger.LogMessage(getLogName, getText);
			}
		}

		private void closeLogger()
		{
            HelperService.GetInstance().ClearConsoleAndWriteMessage("Closing the program ... please wait");
			Thread.Sleep(1000);
			Environment.Exit(0);
		}
	}
}
