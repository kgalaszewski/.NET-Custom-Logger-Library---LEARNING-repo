using Moq;
using MyLogger;
using MyLoggerApp.Loggers;
using NUnit.Framework;

namespace MyLoggerApp.UnitTests.Loggers
{
    [TestFixture]
    class TxtLoggerTests
    {
        private const string _logName = "logMessage";
        private const string _logContent = "logContent";
        private const string _fileName = "FileMyLogger.txt";
        private TxtLogger _txtLogger;
        private Mock<ITxtLoggerService> _txtService;

        [SetUp]
        public void SetUp()
        {
            _txtService = new Mock<ITxtLoggerService>();
            _txtLogger = new TxtLogger(_txtService.Object);
        }

        [Test]
        public void LogMessage_WhenCalled_ShouldCallWriteToFile()
        {
            _txtLogger.LogMessage(_logName, _logContent);

            _txtService.Verify(ts => ts.WriteToFile(_fileName, _logName, _logContent), Times.Once);
        }

        [Test]
        [TestCase(null, _logContent)]
        [TestCase(" ", _logContent)]
        [TestCase(_logName, "")]
        public void LogMessage_WhenParametersAreNullOrWhiteSpace_ShouldNotCallWriteToEventLog(string logName, string logContent)
        {
            _txtLogger.LogMessage(logName, logContent);

            _txtService.Verify(ts => ts.WriteToFile(_fileName, _logName, _logContent), Times.Never);
        }

        [Test]
        public void DisplayAllLogsSavedSoFar_WhenCalled_ShouldCallDisplayAllSavedLogs()
        {
            _txtLogger.DisplayAllLogsSavedSoFar();

            _txtService.Verify(ts => ts.DisplayAllSavedLogs(_fileName), Times.Once);
        }
    }
}
