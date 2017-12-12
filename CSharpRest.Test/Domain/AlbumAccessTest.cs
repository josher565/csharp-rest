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
        public void AlbumAccessReadTest()
        {
            //Arrange
            var album = new Album() { Id = 14 };

            var mockSet = new Mock<DbSet<Album>>();
           
            mockSet.Setup(m => m.Find(It.IsAny<object[]>())).Returns(album);

            var context = new Mock<AlbumContext>();
            context.SetupGet(m => m.Albums).Returns(mockSet.Object);

            var sut = new AlbumAccess(context.Object);
            
            //Act
            var sutAlbum = sut.Read(14);

            //Assert
            Assert.AreEqual(album, sutAlbum);
        }

        [TestMethod]
        public void AlbumAccessCreateTest()
        {
            //Arrange
            var now = DateTime.Now;
            var mockSet = new Mock<DbSet<Album>>();
            var context = new Mock<AlbumContext>();
            context.SetupGet(m => m.Albums).Returns(mockSet.Object);

            var sut = new AlbumAccess(context.Object);
            var sutAlbum = new Album() { Id = 14 };

            //Act
            var rAlbum = sut.Create(sutAlbum, now);

            //Assert
            mockSet.Verify(m => m.Add(sutAlbum), Times.Once());
        }

        [TestMethod]
        public void AlbumAccessUpdateTest()
        {
            //Arrange
            var now = DateTime.Now;
            var mockSet = new Mock<DbSet<Album>>();
            var context = new Mock<AlbumContext>();
            var album = new Album() { Id = 14 };

            context.SetupGet(m => m.Albums).Returns(mockSet.Object);
            context.Setup(m => m.SetObjectState(album, EntityState.Modified));
            mockSet.Setup(m => m.Attach(album)).Returns(album);

            //Act
            var sut = new AlbumAccess(context.Object);
            sut.Update(album, now);

            //Assert
            Assert.AreEqual(album, mockSet.Object.Attach(album));
            context.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void AlbumAccessDeleteTest()
        {
            //Arrange
            var mockSet = new Mock<DbSet<Album>>();
            var context = new Mock<AlbumContext>();
            var album = new Album();
            context.SetupGet(m => m.Albums).Returns(mockSet.Object);
            context.Setup(m => m.SetObjectState(album, EntityState.Deleted));
            mockSet.Setup(m => m.Remove(album)).Returns(album);

            //Act
            var sut = new AlbumAccess(context.Object);
            sut.Delete(album);

            //Assert
            Assert.AreEqual(album, mockSet.Object.Remove(album));
            mockSet.Verify(m => m.Remove(album), Times.Once());
        }
    }
}
