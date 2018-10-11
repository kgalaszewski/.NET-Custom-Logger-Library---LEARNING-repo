namespace MyLogger
{
	class EventLoggerFactory : LoggerFactory
	{
		public override ILogger CreateLogger()
		{
			return new EventLogger();
		}
	}
}
//UserService currentUserService = new UserService();
////currentUserService.SetCurrentUser();