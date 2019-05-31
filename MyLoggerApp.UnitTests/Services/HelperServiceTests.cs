using Moq;
using MyLoggerApp.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLoggerApp.UnitTests.Services
{
    [TestFixture]
    class HelperServiceTests
    {
        [Test]
        public void GetInstance_WhenCalled_ReturnsInstanceOfHelperService()
        {
            var result = HelperService.GetInstance();

            Assert.That(result, Is.TypeOf<HelperService>());
        }
    }
}
