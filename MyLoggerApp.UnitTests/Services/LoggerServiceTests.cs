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
        public void StartLoggerLogic_WhenCalled_LogicDidntFail()
        {
            _service.StartLoggerLogic(true);
            var result = _service.logicFailed;

            Assert.That(result == false);
        }

        [Test]
        public void SetHelperService_WhenCalled_SetsServiceProperely()
        {
            var newService = HelperService.GetInstance();
            _service.SetHelperService(newService);
            var result = _service._helperService;

            Assert.That(result, Is.EqualTo(newService));
        }
    }
}
