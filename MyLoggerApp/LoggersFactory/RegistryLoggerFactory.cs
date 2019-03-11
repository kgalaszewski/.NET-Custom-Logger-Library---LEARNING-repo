namespace MyLogger
{
	class RegistryLoggerFactory : LoggerFactory
	{
		public override ILogger CreateLogger()
		{
			return new RegistryLogger();
		}
	}
}
