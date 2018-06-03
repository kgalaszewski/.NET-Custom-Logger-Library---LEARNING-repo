namespace MyLogger
{
	class Program
	{
		static void Main(string[] args)
		{
			//setting user, Logger will start after user is set
			UserService ThisUser = new UserService();
			ThisUser.SetCurrentUser();
		}
	}
}
