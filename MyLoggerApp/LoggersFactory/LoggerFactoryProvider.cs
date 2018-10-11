using System.Collections.Generic;

namespace MyLogger
{
	/// <summary>
	/// Keeping all LoggerFactories in list to let User choose which logger to create from available options
	/// </summary>
	class LoggerFactoryProvider
	{
		public List<LoggerFactory> LoggerFactoryList = new List<LoggerFactory>() {new TxtLoggerFactory(), new EventLoggerFactory(), new RegistryLoggerFactory()};
	}
}
//UserService currentUserService = new UserService();
////currentUserService.SetCurrentUser();