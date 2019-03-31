using MyLogger;
using MyLoggerApp.LoggersFactory;
using NUnit.Framework;

namespace MyLoggerApp.UnitTests.LoggersFactory
{
    [TestFixture]
    class LoggerFactoryProviderTests
    {
        [Test]
        public void GetAllLoggerFactories_WhenCalled_ShouldReturnThreeLoggers()
        {
            var result = LoggerFactoryProvider.GetAllLoggerFactories();

            Assert.That(result.Count == 3);
        }

        [Test]
        [TestCase(LoggerTypes.TxtLogger, "TxtLoggerFactory")]
        [TestCase(LoggerTypes.EventLogger, "EventLoggerFactory")]
        [TestCase(LoggerTypes.RegistryLogger, "RegistryLoggerFactory")]
        public void GetLoggerFactory_WhenCalled_ShouldReturnSpecificLogger(LoggerTypes type, string expected)
        {
            var result = LoggerFactoryProvider.GetLoggerFactory(type);

            Assert.That(result.ToString().Contains(expected));
        }

        [Test]
        public void GetLoggerFactory_WhenCalledWithWrongParameter_ShouldThrowInvalidOperationException()
        {
            Assert.That(() =>
            {
                LoggerFactoryProvider.GetLoggerFactory(LoggerTypes.OtherLogger);
            }, Throws.InvalidOperationException);
        }
    }
}
