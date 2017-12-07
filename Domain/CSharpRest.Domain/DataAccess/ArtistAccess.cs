using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRest.Domain.DataAccess
{
    public class ArtistAccess : DbContext
    {
        public ArtistAccess() : base("MusicDb") { }

        public virtual DbSet<Data.Artist> Artists {get; set;}
    }
}
