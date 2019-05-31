using MyLoggerApp.LoggersFactory;
using MyLoggerApp.Services;
using System;
using System.Threading;

namespace MyLogger
{
    public sealed class LoggerService : ILoggerService
    {
        private static readonly LoggerService _Instance = new LoggerService();

        public IHelperService _helperService = HelperService.GetInstance();

        private LoggerService() { }

        private string errorMsg { get; set; }

        public bool logicFailed = false;

        public static LoggerService GetInstance()
        {
            return _Instance;
        }

        // Public methods ----------------------------------------------------------------------------------------------------------------------------------

        public void StartLoggerLogic(bool isTest = false)
        {
            if (!isTest)
            {
                _helperService.ClearConsoleAndWriteMessage("Where do you want to log your message : \n3 destinations : Registry, EventViewer and File.txt -> press '3' \nOnly to File.txt -> press '1'");
                char logDestination = char.ToLower(Console.ReadKey().KeyChar);


                if (logDestination.Equals('1') || logDestination.Equals('3'))
                {
                    _helperService.ClearConsoleAndWriteMessage("Please, type the name/ID of your message");
                    string givenLogName = Console.ReadLine();
                    _helperService.ClearConsoleAndWriteMessage("Please, type your message");
                    string givenContent = Console.ReadLine();

                    _helperService.EnsureThatActionSucceed(() =>
                    {
                        if (logDestination.Equals('1'))
                            logToFile(givenLogName, givenContent);
                        else
                            logToAllDestinations(givenLogName, givenContent);

                        Console.ReadKey();
                        ChooseNewAction();
                    }, null, "Could not run logger properly");
                }
                else
                {
                    _helperService.ClearConsoleAndWriteMessage("Incorret choice");
                    logicFailed = true;
                    Thread.Sleep(1000);
                    ChooseNewAction();
                }
            }
        }

        public void ChooseNewAction()
        {
            try
            {
                _helperService.ClearConsoleAndWriteMessage("To save your logs (press 'Z') \n\nTo display all the saved logs (press 'W') " +
                    "\n\nTo change your NickName (press 'C') \n\nTo Close MyLoggerApp (press 'X')");

                startNewAction(char.ToLower(Console.ReadKey().KeyChar));
            }
            catch (Exception e)
            {
                errorMsg = $"Could not proceed this action due to {e.Message}";
                _helperService.ClearConsoleAndWriteMessage(errorMsg);
            }
        }

        public void SetHelperService(IHelperService service = null)
        {
            _helperService = service ?? HelperService.GetInstance();
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
            IMyLogger fileLogger = fileFactory.CreateLogger();
            fileLogger.LogMessage(getLogName, getText);
        }

        private void logToAllDestinations(string getLogName, string getText)
        {
            foreach (var loggerFactory in LoggerFactoryProvider.GetAllLoggerFactories())
            {
                IMyLogger currentLogger = loggerFactory.CreateLogger();
                currentLogger.LogMessage(getLogName, getText);
            }
        }

        private void closeLogger()
        {
            _helperService.ClearConsoleAndWriteMessage("Closing the program ... please wait");
            Thread.Sleep(1000);
            Environment.Exit(0);
        }
    }
}
