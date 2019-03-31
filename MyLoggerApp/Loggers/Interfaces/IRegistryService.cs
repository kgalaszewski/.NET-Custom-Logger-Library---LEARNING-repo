using Microsoft.Win32;

namespace MyLoggerApp.Loggers
{
    public interface IRegistryService
    {
        RegistryKey _registryKey { get; set; }

        void CreateSubKey(string name);

        void SetValue(string logName, string logContent);
    }
}