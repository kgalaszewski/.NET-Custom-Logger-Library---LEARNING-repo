namespace MyLoggerApp.Loggers
{
    public interface IEventLogService
    {
        void WriteToEventLog(string _mySource, string fullLogMessage);

        void CheckIfSourceExists(string _mySource, string _myLog);
    }
}