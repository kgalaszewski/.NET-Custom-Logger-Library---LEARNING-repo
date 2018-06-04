using System;
using System.Threading;

namespace MyLogger
{
	public sealed class UserService
	{
		public delegate void OnCurrentUserSet();

		OnCurrentUserSet startLoggerForCurrentUser = LoggerService.GetInstance.RunLogger;

		public static string CurrentUser;



		public void SetCurrentUser()
		{
			Console.Clear();
			Console.WriteLine("Podaj swoja nazwe uzytkownika");
			CurrentUser = Console.ReadLine();
			if (String.IsNullOrEmpty(CurrentUser))
			{
				Console.WriteLine("Nazwa uzytkownika nie moze byc pusta");
				Thread.Sleep(2000);
				SetCurrentUser();
			}			
			startLoggerForCurrentUser();
		}
	}
}
