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
    public class ArtistContext : DbContext, ICrud<Data.Artist>
    {
        public ArtistContext() : base("MusicDb") { }

        public virtual DbSet<Data.Artist> Artists {get; set;}

        public Data.Artist Create(Artist entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Artist entity)
        {
            throw new NotImplementedException();
        }

        public Artist Read(int id)
        {
            throw new NotImplementedException();
        }

        public Data.Artist Update(Artist entity)
        {
            throw new NotImplementedException();
        }
    }
}
