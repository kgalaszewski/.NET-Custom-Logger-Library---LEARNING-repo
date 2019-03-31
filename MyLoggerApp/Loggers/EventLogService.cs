using System.Diagnostics;

namespace MyLoggerApp.Loggers
{
    public class EventLogService : IEventLogService
    {
        public void CheckIfSourceExists(string _mySource, string _myLog)
        {
            if (!EventLog.SourceExists(_mySource))
                EventLog.CreateEventSource(_mySource, _myLog);
        }

        public void WriteToEventLog(string _mySource, string fullLogMessage)
        {
            EventLog.WriteEntry(_mySource, fullLogMessage);
        }
    }
}
