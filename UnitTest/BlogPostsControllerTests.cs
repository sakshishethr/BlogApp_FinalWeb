using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog_App.Controllers;
using Blog_App.Data;
using Blog_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace Blog_App.Tests
{
    [TestFixture]
    public class BlogPostsControllerTests
    {
        private Mock<ApplicationDbContext> _mockContext;
        private BlogPostsController _controller;

        [SetUp]
        public void SetUp()
        {
            var blogPosts = new List<BlogPost>
            {
                new BlogPost {Id = 1, BlogTitle = "Title 1", BlogContent = "Content 1"},
                new BlogPost {Id = 2, BlogTitle = "Title 2", BlogContent = "Content 2"},
                new BlogPost {Id = 3, BlogTitle = "Title 3", BlogContent = "Content 3"}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<BlogPost>>();
            mockSet.As<IQueryable<BlogPost>>().Setup(m => m.Provider).Returns(blogPosts.Provider);
            mockSet.As<IQueryable<BlogPost>>().Setup(m => m.Expression).Returns(blogPosts.Expression);
            mockSet.As<IQueryable<BlogPost>>().Setup(m => m.ElementType).Returns(blogPosts.ElementType);
            mockSet.As<IQueryable<BlogPost>>().Setup(m => m.GetEnumerator()).Returns(blogPosts.GetEnumerator());

            _mockContext = new Mock<ApplicationDbContext>();
            _mockContext.Setup(c => c.BlogPost).Returns(mockSet.Object);

            _controller = new BlogPostsController(_mockContext.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _mockContext = null;
            _controller = null;
        }

   

        [Test]
        public async Task Index_ReturnsAViewResult_WithAListOfBlogPosts()
        {
            // Arrange
            // (The SetUp method has done the arrangement for this test)

            // Act
            var result = await _controller.Index();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.IsInstanceOf<List<BlogPost>>(viewResult.Model);
            var model = viewResult.Model as List<BlogPost>;
            Assert.AreEqual(3, model.Count);
        }

    }
}