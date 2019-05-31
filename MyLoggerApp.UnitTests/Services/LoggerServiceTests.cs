using Moq;
using MyLogger;
using MyLoggerApp.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLoggerApp.UnitTests.Services
{
    [TestFixture]
    class LoggerServiceTests
    {
        private Mock<IHelperService> _helperMock;
        private LoggerService _service;

        [SetUp]
        public void SetUp()
        {
            _helperMock = new Mock<IHelperService>();
            _service = LoggerService.GetInstance();
        }

        [Test] 
        public void GetInstance_WhenCalled_ReturnsInstanceOfLoggerService()
        {
            var result = LoggerService.GetInstance();

            Assert.That(result, Is.TypeOf<LoggerService>());
        }

        [Test]
        public void StartLoggerLogic_WhenCalled_ClearConsoleAndWriteMessageIsCalled()
        {
            _service.StartLoggerLogic();
        }

        [Test]
        public void ChooseNewAction_HelperServiceThrowsException_ClearConsoleAndWriteMessageIsInvoked()
        {

        }
    }
}
