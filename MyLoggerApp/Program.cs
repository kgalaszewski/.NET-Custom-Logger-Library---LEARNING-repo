namespace MyLogger
{
	class Program
	{
		static void Main(string[] args)
		{
			UserService ThisUser = new UserService();
			ThisUser.SetCurrentUser();
			LoggerService.GetInstance.RunLogger();
		}
	}
}
