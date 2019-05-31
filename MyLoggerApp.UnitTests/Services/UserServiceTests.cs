using MyLogger;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLoggerApp.UnitTests.Services
{
    [TestFixture]
    class UserServiceTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void GetInstance_WhenCalled_ReturnsCorrectTypeInstance()
        {
            var result = UserService.GetInstance();

            Assert.That(result, Is.TypeOf<UserService>());
        }
    }
}
