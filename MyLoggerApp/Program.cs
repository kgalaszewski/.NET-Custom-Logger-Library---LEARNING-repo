namespace MyLogger
{
	class Program
	{
		static void Main(string[] args)
		{
			// Setting currentUser will start Logger
			UserService currentUserService = new UserService();
			currentUserService.SetCurrentUser();
		}
	}
}
