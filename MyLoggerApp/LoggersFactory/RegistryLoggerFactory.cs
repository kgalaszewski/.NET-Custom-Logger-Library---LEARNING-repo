namespace MyLogger
{
	class RegistryLoggerFactory : LoggerFactory
	{
		public override ILogger CreateLogger()
		{
			return new RegistryLogger();
		}
	}
}           //UserService currentUserService = new UserService();
			////currentUserService.SetCurrentUser();
