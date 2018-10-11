namespace MyLogger
{
	class Program
	{
		static void Main(string[] args)
		{
			UserService currentUserService = new UserService();
			currentUserService.SetCurrentUser();
			//UserService currentUserService = new UserService();
			////currentUserService.SetCurrentUser();
		}
	}
}
