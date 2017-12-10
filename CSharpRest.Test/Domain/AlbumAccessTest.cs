using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CSharpRest.Domain.Data;
using System.Data.Entity;
using CSharpRest.Domain.Contexts;
using CSharpRest.Domain.Access;

namespace CSharpRest.Test.Domain
{
    [TestClass]
    public class AlbumAccessTest
    {
        [TestMethod]
        public void ReadTest()
        {
            var mockSet = new Mock<DbSet<Album>>();
            var mockContext = new Mock<AlbumContext>();
            var access = new AlbumAccess(mockContext.Object);

            mockContext.Setup(m => m.Albums).Returns(mockSet.Object);

            //var service = new BlogService(mockContext.Object);
            //service.AddBlog("ADO.NET Blog", "http://blogs.msdn.com/adonet");

            //mockSet.Verify(m => m.Add(It.IsAny<Blog>()), Times.Once());
            //mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}
