using Moq;
using MyLogger;
using MyLoggerApp.Loggers;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace MyLoggerApp.UnitTests.Loggers
{
    [TestFixture]
    class RegistryLoggerTests
    {
        private const string _logName = "logMessage";
        private const string _logContent = "logContent";
        private IMyLogger _registryLogger;
        private Mock<IRegistryService> _registryService;

        [SetUp]
        public void SetUp()
        {
            _registryService = new Mock<IRegistryService>();
            _registryLogger = new RegistryLogger(_registryService.Object);
        }

        [Test]
        public void LogMessage_WhenCalled_ShouldCallCreateSubKeyAndWriteToEventLog()
        {
            _registryLogger.LogMessage(_logName, _logContent);

            _registryService.Verify(rs => rs.CreateSubKey(It.IsAny<string>()), Times.Once);

            _registryService.Verify(rs => rs.SetValue(_logName, _logContent), Times.Once);
        }

        [Test]
        [TestCase(null, _logContent)]
        [TestCase(" ", _logContent)]
        [TestCase(_logName, "")]
        public void LogMessage_WhenParametersAreNullOrWhiteSpace_ShouldNotCallWriteToEventLog(string logName, string logContent)
        {
            _registryLogger.LogMessage(logName, logContent);

            _registryService.Verify(rs => rs.SetValue(_logName, _logContent), Times.Never);
        }
    }
}
