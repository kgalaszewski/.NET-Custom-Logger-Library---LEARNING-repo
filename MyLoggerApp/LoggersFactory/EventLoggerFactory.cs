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