namespace MyLogger
{
	public class TxtLoggerFactory : LoggerFactory
	{
		public override IMyLogger CreateLogger()
		{
			return new TxtLogger();
		}
	}
}
