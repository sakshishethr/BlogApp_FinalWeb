using Blog_App.Models;
using NUnit.Framework;

namespace Blog_App.Tests.Models
{
    public class ErrorViewModelTests
    {
        [Test]
        public void ShowRequestId_WithRequestId_ReturnsTrue()
        {
            // Arrange
            var model = new ErrorViewModel { RequestId = "123" };

            // Act
            var result = model.ShowRequestId;

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void ShowRequestId_WithoutRequestId_ReturnsFalse()
        {
            // Arrange
            var model = new ErrorViewModel { RequestId = null };

            // Act
            var result = model.ShowRequestId;

            // Assert
            Assert.IsFalse(result);
        }
    }
}