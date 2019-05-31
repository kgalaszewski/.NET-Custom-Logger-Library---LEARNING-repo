using MyLogger;
using MyLoggerApp.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLoggerApp.UnitTests.Services
{
    [TestFixture]
    class UserServiceTests
    {
        private UserService _userService;

        [SetUp]
        public void SetUp()
        {
            _userService = UserService.GetInstance();
        }

        [Test]
        public void GetInstance_WhenCalled_ReturnsCorrectTypeInstance()
        {
            var result = UserService.GetInstance();

            Assert.That(result, Is.TypeOf<UserService>());
        }

        [Test]
        public void SetServices_WhenCalledProperely_ServicesAreSet()
        {
            var service1 = HelperService.GetInstance();
            var service2 = LoggerService.GetInstance();

            _userService.SetServices(service2, service1);

            Assert.That(_userService._helperService, Is.EqualTo(service1));
            Assert.That(_userService._service, Is.EqualTo(service2));
        }

        [Test]
        public void CreateUser_WhenCalled_UserIsCreatedProperely()
        {
            _userService.SetServices(LoggerService.GetInstance(), HelperService.GetInstance());

            _userService.CreateNewUser(true);

            var result = _userService.IsUserCreated;

            Assert.That(result, Is.True);
        }
    }
}
