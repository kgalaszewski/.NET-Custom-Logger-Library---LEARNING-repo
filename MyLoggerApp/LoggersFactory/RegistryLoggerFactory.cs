namespace MyLogger
{
	public class RegistryLoggerFactory : LoggerFactory
	{
		public override IMyLogger CreateLogger()
		{
			return new RegistryLogger();
		}
	}
}
