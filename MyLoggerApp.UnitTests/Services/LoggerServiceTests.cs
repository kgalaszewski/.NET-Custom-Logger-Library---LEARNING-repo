using MyLogger;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLoggerApp.UnitTests.Services
{
    [TestFixture]
    class LoggerServiceTests
    {
        [Test] 
        public void GetInstance_WhenCalled_ReturnsInstanceOfLoggerService()
        {
            var result = LoggerService.GetInstance();

            Assert.That(result, Is.TypeOf<LoggerService>());
        }
    }
}
