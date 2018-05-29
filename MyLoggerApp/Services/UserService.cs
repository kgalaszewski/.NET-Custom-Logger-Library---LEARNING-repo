using System;

namespace MyLogger
{
	public sealed class UserService
	{
		public delegate void OnCurrentUserSet();

		OnCurrentUserSet onCurrentUserSet = LoggerService.GetInstance.RunLogger;

		public static string CurrentUser;

		public void SetCurrentUser()
		{
			Console.WriteLine("Podaj swoj Login");
			CurrentUser = Console.ReadLine();
			onCurrentUserSet();
		}
	}
}
