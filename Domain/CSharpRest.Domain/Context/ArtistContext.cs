using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpRest.Domain.Data;
using CSharpRest.Domain.Access;

namespace CSharpRest.Domain.Contexts
{
    public class ArtistContext : DbContext
    {
        public ArtistContext() : base("MusicDb") { }

        public virtual DbSet<Data.Artist> Artists {get; set;}

        public virtual DbSet<Data.artist_albums> ArtistAlbums { get; set; }

        public virtual void SetObjectState(Data.Artist entity, EntityState state)
        {
            Entry(entity).State = state;
        }
    }
}
