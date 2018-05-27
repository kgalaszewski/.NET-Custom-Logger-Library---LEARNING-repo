using System;

namespace MyLogger
{
	public sealed class UserService
	{
		public static string CurrentUser;

		public void SetCurrentUser()
		{
			Console.WriteLine("Podaj swoj Login");
			CurrentUser = Console.ReadLine();
		}
	}
}
