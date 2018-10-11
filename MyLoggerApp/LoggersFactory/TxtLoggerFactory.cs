namespace MyLogger
{
	class TxtLoggerFactory : LoggerFactory
	{
		public override ILogger CreateLogger()
		{
			return new TxtLogger();
		}
	}           //UserService currentUserService = new UserService();
				////currentUserService.SetCurrentUser();
}
