using System.Collections.Generic;

namespace MyLogger
{
	class LoggerFactoryProvider
	{
		public List<LoggerFactory> LoggerFactoryList = new List<LoggerFactory>() {new TxtLoggerFactory(), new EventLoggerFactory(), new RegistryLoggerFactory()};
	}
}
