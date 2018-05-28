namespace MyLogger
{
	class TxtLoggerFactory : LoggerFactory
	{
		public override ILogger CreateLogger()
		{
			return new TxtLogger();
		}
	}
}
