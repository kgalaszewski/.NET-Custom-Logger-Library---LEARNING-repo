using Microsoft.Win32;

namespace MyLoggerApp.Loggers
{
    class RegistryService : IRegistryService
    {
        public RegistryKey _registryKey { get; set; }

        public void CreateSubKey(string name)
        {
            _registryKey = Registry.CurrentUser.CreateSubKey(name);
        }

        public void SetValue(string logName, string logContent)
        {
            _registryKey.SetValue(logName, logContent);
            _registryKey.Close();
        }
    }
}
