using Moq;
using MyLogger;
using MyLoggerApp.Loggers;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace MyLoggerApp.UnitTests.Loggers
{
    [TestFixture]
    class EventLoggerTests
    {
        private const string _logName = "logMessage";
        private const string _logContent = "logContent";
        private IMyLogger _eventLogger;
        private Mock<IEventLogService> _eventService;

        [SetUp]
        public void SetUp()
        {
            _eventService = new Mock<IEventLogService>();
            _eventLogger = new EventLogger(_eventService.Object);
        }

        [Test]
        public void LogMessage_WhenCalled_ShouldCallWriteToEventLog()
        {
            _eventLogger.LogMessage(_logName, _logContent);

            _eventService.Verify(es => es.WriteToEventLog(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        [TestCase(null, _logContent)]
        [TestCase(" ", _logContent)]
        [TestCase(_logName, "")]
        public void LogMessage_WhenParametersAreNullOrWhiteSpace_ShouldNotCallWriteToEventLog(string logName, string logContent)
        {
            _eventLogger.LogMessage(logName, logContent);

            _eventService.Verify(es => es.WriteToEventLog(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }
    }
}
