namespace MyLogger
{
	public class EventLoggerFactory : LoggerFactory
	{
		public override IMyLogger CreateLogger()
		{
			return new EventLogger();
		}
	}
}