using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRest.Domain.DataAccess
{
    public class AlbumAccess : DbContext
    {
        public AlbumAccess() : base("MusicDb") { }

        public virtual DbSet<Data.Album> Albums { get; set; }
    }
}
