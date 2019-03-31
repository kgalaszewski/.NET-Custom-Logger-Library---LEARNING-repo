namespace MyLoggerApp.Loggers
{
    public interface ITxtLoggerService
    {
        void DisplayAllSavedLogs(string _fileName);

        void WriteToFile(string _fileName, string logName, string logContent);
    }
}