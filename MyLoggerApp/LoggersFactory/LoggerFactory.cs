namespace MyLogger
{
	abstract class LoggerFactory
	{
		public abstract ILogger CreateLogger();
	}
}
//UserService currentUserService = new UserService();
////currentUserService.SetCurrentUser();