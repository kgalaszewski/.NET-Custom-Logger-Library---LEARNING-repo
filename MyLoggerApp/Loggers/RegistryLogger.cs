using MyLoggerApp.Loggers;
using MyLoggerApp.Services;
using System;

namespace MyLogger
{
    public sealed class RegistryLogger : IMyLogger
	{
        private IRegistryService _registryService;

        public RegistryLogger(IRegistryService service = null)
        {
            _registryService = service ?? new RegistryService();
            _registryService.CreateSubKey("MyLoggerApp");
        }

        public void LogMessage(string logName, string logContent)
		{
            if (!string.IsNullOrWhiteSpace(logName) && !string.IsNullOrWhiteSpace(logContent))
            {
                HelperService.GetInstance().EnsureThatActionSucceed(() =>
                {
                    _registryService.SetValue(logName, logContent);
                    Console.WriteLine("The message has been logged to : HKEY_CURRENT_USER/MyLoggerRegistery");
                }, null, "The message could not have been logged");
            }
            else
                HelperService.GetInstance().DisplayEmptyLogParametersAlert("logName", "logContent");
		}
	}
}