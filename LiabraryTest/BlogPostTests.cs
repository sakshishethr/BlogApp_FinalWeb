using Blog_App.Models;
using NUnit.Framework;

namespace Blog_App.Tests.Models
{
    public class BlogPostTests
    {
        [Test]
        public void BlogPostConstructor_SetsProperties()
        {
            // Arrange
            var id = 1;
            var blogTitle = "Test Blog Title";
            var blogContent = "Test Blog Content";

            // Act
            var blogPost = new BlogPost
            {
                Id = id,
                BlogTitle = blogTitle,
                BlogContent = blogContent
            };

            // Assert
            Assert.AreEqual(id, blogPost.Id);
            Assert.AreEqual(blogTitle, blogPost.BlogTitle);
            Assert.AreEqual(blogContent, blogPost.BlogContent);
        }
    }
}