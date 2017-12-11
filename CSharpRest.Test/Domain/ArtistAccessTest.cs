using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            context.SetupGet(m => m.Albums).Returns(mockSet.Object);

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
            var mockSet = new Mock<DbSet<Artist>>();
            var context = new Mock<ArtistContext>();
            context.SetupGet(m => m.Albums).Returns(mockSet.Object);

            var sut = new ArtistAccess(context.Object);
            var sutArtist = new Artist() { Id = 14 };

            //Act
            var rAlbum = sut.Create(sutArtist);

            //Assert
            mockSet.Verify(m => m.Add(sutAlbum), Times.Once());
        }

        [TestMethod]
        public void ArtistAccessUpdateTest()
        {
            //Arrange
            var mockSet = new Mock<DbSet<Artist>>();
            var context = new Mock<ArtistContext>();
            var artist = new Artist() { Id = 14 };

            context.SetupGet(m => m.Albums).Returns(mockSet.Object);
            context.Setup(m => m.SetObjectState(album, EntityState.Modified));
            mockSet.Setup(m => m.Attach(album)).Returns(artist);

            //Act
            var sut = new ArtistAccess(context.Object);
            sut.Update(artist);

            //Assert
            Assert.AreEqual(artist, mockSet.Object.Attach(artist));
            context.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void ArtistAccessDeleteTest()
        {
            //Arrange
            var mockSet = new Mock<DbSet<Artist>>();
            var context = new Mock<ArtistContext>();
            var artist = new Artist();
            context.SetupGet(m => m.Albums).Returns(mockSet.Object);
            context.Setup(m => m.SetObjectState(album, EntityState.Deleted));
            mockSet.Setup(m => m.Remove(album)).Returns(album);

            //Act
            var sut = new ArtistAccess(context.Object);
            sut.Delete(artist);

            //Assert
            Assert.AreEqual(artist, mockSet.Object.Remove(artist));
            mockSet.Verify(m => m.Remove(Artist), Times.Once());
        }

    }
}
