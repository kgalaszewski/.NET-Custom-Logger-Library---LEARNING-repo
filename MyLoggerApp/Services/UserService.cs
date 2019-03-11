using MyLoggerApp.Services;
using System;

namespace MyLogger
{
    public sealed class UserService
	{
        private UserService() { HelperService.GetInstance().ClearConsoleAndWriteMessage("Welcome to MyLoggerApp\n\n"); }

        private static readonly UserService _Instance = new UserService();

        public static UserService GetInstance()
        {
            return _Instance;
        }

        public static string CurrentUserName;
        
		public void CreateNewUser()
		{			
            string givenNickName = null;

			while (String.IsNullOrWhiteSpace(givenNickName))
			{
                HelperService.GetInstance().ClearConsoleAndWriteMessage("Please, choose and type your NickName");
                givenNickName = Console.ReadLine();
			}

            LoggerService.GetInstance().StartLoggerLogic();
        }
	}
}
