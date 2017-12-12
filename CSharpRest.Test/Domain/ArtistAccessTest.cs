using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpRest.Domain.Data;
using System.Data.Entity;
using Moq;
using CSharpRest.Domain.Contexts;
using CSharpRest.Domain.Access;

namespace CSharpRest.Test.Domain
{
    [TestClass]
    public class ArtistAccessTest
    {
        [TestMethod]
        public void ArtistAccessReadTest()
        {
            //Arrange
            var artist = new Artist() { Id = 14 };

            var mockSet = new Mock<DbSet<Artist>>();

            mockSet.Setup(m => m.Find(It.IsAny<object[]>())).Returns(artist);

            var context = new Mock<ArtistContext>();
            context.SetupGet(m => m.Artists).Returns(mockSet.Object);

            var sut = new ArtistAccess(context.Object);

            //Act
            var sutArtist = sut.Read(14);

            //Assert
            Assert.AreEqual(artist, sutArtist);
        }

        [TestMethod]
        public void ArtistAccessCreateTest()
        {
            //Arrange
            var now = DateTime.Now;
            var mockSet = new Mock<DbSet<Artist>>();
            var context = new Mock<ArtistContext>();
            context.SetupGet(m => m.Artists).Returns(mockSet.Object);

            var sut = new ArtistAccess(context.Object);
            var sutArtist = new Artist() { Id = 14 };

            //Act
            var rArtist = sut.Create(sutArtist, now);

            //Assert
            mockSet.Verify(m => m.Add(sutArtist), Times.Once());
        }

        [TestMethod]
        public void ArtistAccessUpdateTest()
        {
            //Arrange
            var now = DateTime.Now;
            var mockSet = new Mock<DbSet<Artist>>();
            var context = new Mock<ArtistContext>();
            var artist = new Artist() { Id = 14 };

            context.SetupGet(m => m.Artists).Returns(mockSet.Object);
            context.Setup(m => m.SetObjectState(artist, EntityState.Modified));
            mockSet.Setup(m => m.Attach(artist)).Returns(artist);

            //Act
            var sut = new ArtistAccess(context.Object);
            sut.Update(artist, now);

            //Assert
            Assert.AreEqual(artist, mockSet.Object.Attach(artist));
        }

        [TestMethod]
        public void ArtistAccessDeleteTest()
        {
            //Arrange
            var mockSet = new Mock<DbSet<Artist>>();
            var context = new Mock<ArtistContext>();
            var artist = new Artist();
            context.SetupGet(m => m.Artists).Returns(mockSet.Object);
            context.Setup(m => m.SetObjectState(artist, EntityState.Deleted));
            mockSet.Setup(m => m.Remove(artist)).Returns(artist);

            //Act
            var sut = new ArtistAccess(context.Object);
            sut.Delete(artist);

            //Assert
            Assert.AreEqual(artist, mockSet.Object.Remove(artist));
            mockSet.Verify(m => m.Remove(artist), Times.Once());
        }

    }
}
