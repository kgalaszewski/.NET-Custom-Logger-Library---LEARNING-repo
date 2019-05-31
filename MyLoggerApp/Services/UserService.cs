using MyLoggerApp.Services;
using System;

namespace MyLogger
{
    public sealed class UserService
	{
        private UserService() { HelperService.GetInstance().ClearConsoleAndWriteMessage("Welcome to MyLoggerApp\n\n"); }

        public ILoggerService _service = LoggerService.GetInstance();
        public IHelperService _helperService = HelperService.GetInstance();

        private static readonly UserService _Instance = new UserService();

        public static UserService GetInstance()
        {
            return _Instance;
        }

        public static string CurrentUserName;
        public bool IsUserCreated = false;
        
		public void CreateNewUser(bool isTest = false)
		{
            if (!isTest)
            {
                string givenNickName = null;

                while (String.IsNullOrWhiteSpace(givenNickName))
                {
                    HelperService.GetInstance().ClearConsoleAndWriteMessage("Please, choose and type your NickName");
                    givenNickName = Console.ReadLine();
                }

                _service.StartLoggerLogic(false);
                IsUserCreated = true;
            }
            else // simulating that user is created
                IsUserCreated = true;
        }

        public void SetServices(ILoggerService service, IHelperService hservice)
        {
            _service = service ?? LoggerService.GetInstance();
            _helperService = hservice ?? HelperService.GetInstance();
        }
	}
}
