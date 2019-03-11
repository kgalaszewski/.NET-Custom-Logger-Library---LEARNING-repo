using Microsoft.Win32;
using MyLoggerApp.Services;
using System;
using System.Security;

namespace MyLogger
{
	public sealed class RegistryLogger : ILogger
	{
        private RegistryKey _registryKey;

        public RegistryLogger()
        {
            _registryKey = Registry.CurrentUser.CreateSubKey("MyLoggerRegistry");
        }

        public void LogMessage(string logName, string logContent)
		{
            HelperService.GetInstance().EnsureThatActionSucceed(() => {
                _registryKey.SetValue(logName, logContent);
                _registryKey.Close();
                Console.WriteLine("The message have been logged to : HKEY_CURRENT_USER/MyLoggerRegistery");
            }, "The message could not have been logged");
		}
	}
}