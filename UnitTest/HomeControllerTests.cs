using System.Diagnostics;
using Blog_App.Controllers;
using Blog_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Blog_App.Tests.Controllers
{
    public class HomeControllerTests
    {
        private Mock<ILogger<HomeController>> _loggerMock;
        private HomeController _controller;

        [SetUp]
        public void Setup()
        {
            _loggerMock = new Mock<ILogger<HomeController>>();
            _controller = new HomeController(_loggerMock.Object);
        }

        [Test]
        public void Index_ReturnsViewResult()
        {
            // Arrange

            // Act
            var result = _controller.Index();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void Privacy_ReturnsViewResult()
        {
            // Arrange

            // Act
            var result = _controller.Privacy();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

    }
}