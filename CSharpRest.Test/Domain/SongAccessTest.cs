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
    public class SongAccessTest
    {
        [TestMethod]
        public void SongAccessReadTest()
        {
            //Arrange
            var song = new Song() { Id = 14 };

            var mockSet = new Mock<DbSet<Song>>();

            mockSet.Setup(m => m.Find(It.IsAny<object[]>())).Returns(song);

            var context = new Mock<SongContext>();
            context.SetupGet(m => m.Songs).Returns(mockSet.Object);

            var sut = new SongAccess(context.Object);

            //Act
            var sutSong = sut.Read(14);

            //Assert
            Assert.AreEqual(song, sutSong);
        }

        [TestMethod]
        public void SongAccessCreateTest()
        {
            //Arrange
            var mockSet = new Mock<DbSet<Song>>();
            var context = new Mock<SongContext>();
            context.SetupGet(m => m.Songs).Returns(mockSet.Object);

            var sut = new SongAccess(context.Object);
            var sutSong = new Song() { Id = 14 };

            //Act
            var rArtist = sut.Create(sutSong);

            //Assert
            mockSet.Verify(m => m.Add(sutSong), Times.Once());
        }

        [TestMethod]
        public void SongAccessUpdateTest()
        {
            //Arrange
            var mockSet = new Mock<DbSet<Artist>>();
            var context = new Mock<ArtistContext>();
            var artist = new Artist() { Id = 14 };

            context.SetupGet(m => m.Artists).Returns(mockSet.Object);
            context.Setup(m => m.SetObjectState(artist, EntityState.Modified));
            mockSet.Setup(m => m.Attach(artist)).Returns(artist);

            //Act
            var sut = new ArtistAccess(context.Object);
            sut.Update(artist);

            //Assert
            Assert.AreEqual(artist, mockSet.Object.Attach(artist));
        }

        [TestMethod]
        public void SongAccessDeleteTest()
        {
            //Arrange
            var mockSet = new Mock<DbSet<Song>>();
            var context = new Mock<SongContext>();
            var song = new Song();
            context.SetupGet(m => m.Songs).Returns(mockSet.Object);
            context.Setup(m => m.SetObjectState(song, EntityState.Deleted));
            mockSet.Setup(m => m.Remove(song)).Returns(song);

            //Act
            var sut = new SongAccess(context.Object);
            sut.Delete(song);

            //Assert
            Assert.AreEqual(song, mockSet.Object.Remove(song));
            mockSet.Verify(m => m.Remove(song), Times.Once());
        }

    }
}
